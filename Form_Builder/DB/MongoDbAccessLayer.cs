using Form_Builder.DB;
using Form_Builder.Model;
using Form_Builder.Model.Out;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
//using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SearchEngine.DB
{

    public class MongoDbAccessLayer : IDBAccessLayer
    {
        private readonly List<InputType> typeNames = new List<InputType> { new InputType("text"), new InputType("date"),new InputType("tel"),new InputType("email"),new InputType("number")};

        public IDbSetting _settings;
        public MongoClient _client;
        IMongoCollection<InputType> _inputTypes;
        IMongoCollection<Form> _forms;
        IMongoCollection<Submission> _submissions;

        private static readonly Object formsLock = new Object();



        public MongoDbAccessLayer(IDbSetting settings, DbConnectionString dbConnectionString)
        {
            _settings = settings;
            _client = new MongoClient($"mongodb://{dbConnectionString.DbHost}:{dbConnectionString.DbPort}");
            var database = _client.GetDatabase(_settings.DatabaseName);
            _inputTypes = database.GetCollection<InputType>(_settings.InputTypeCollectionName);
            _forms = database.GetCollection<Form>(_settings.FormCollectionName);
            _submissions = database.GetCollection<Submission>(_settings.SubmissionCollectionName);
            //////REMOVE///////
            _inputTypes.InsertMany(typeNames);

            Console.WriteLine("MongoDbAccessLayer Initialized");
        }

        public List<Form> GetForms()
        {
            List<Form> forms = new List<Form>();
            lock (formsLock)
            {
                 forms = (from form in _forms.AsQueryable() select form).ToList();
            }
            return forms;
        }

        public Form GetForm(string id)
        {
            return (from form in _forms.AsQueryable() where form.Id==id select form).FirstOrDefault();
        }

        public List<Submission> GetSubmissions(List<string> ids)
        {
            var filter = Builders<Submission>.Filter.In(x => x.Id, ids);
            return _submissions.Find(filter).ToList();
        }

        public List<InputType> GetTypes()
        {
            List<InputType> inputTypes=new List<InputType>();
            try
            {
                var result = (from type in _inputTypes.AsQueryable() select type).ToList();
                return result;
            }
            catch  { throw; }
        }

        public bool SaveForm(Form form)
        {
            try
            {
                _forms.InsertOneAsync(form);
                return true;
            }
            catch { throw; }
        }

        public bool SaveSubmission(string id, Submission submission)
        {
            try
            {
                var submissionResult = _submissions.InsertOneAsync(submission);
                var filter = Builders<Form>.Filter.Eq(e => e.Id, id);
                var update = Builders<Form>.Update.Push<string>(e => e.Submissions_Ids, submission.Id);
                _forms.FindOneAndUpdateAsync(filter, update);
                return true;
            }
            catch { throw; }
        }
    }
}
