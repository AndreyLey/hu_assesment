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



        public MongoDbAccessLayer(IDbSetting settings)
        {
            _settings = settings;
            _client = new MongoClient(settings.ConnectionString);
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
            var allForms = (from form in _forms.AsQueryable() select form);
            return allForms.ToList();
        }

        public Form GetForm(string id)
        {
            return (from form in _forms.AsQueryable() where form.Id==id select form).FirstOrDefault();

            //throw new NotImplementedException();
        }

        public List<Submission> GetSubmissions()
        {
            throw new NotImplementedException();
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
            //throw new NotImplementedException();
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
            //throw new NotImplementedException();
        }

        //public List<Document> GetAllDocuments()
        //{
        //    return _documents.Find(doc => true).ToList();
        //}

        //public bool WriteDataToDB(Dictionary<string, Word> words, Dictionary<string, Document> documents)
        //{
        //    try
        //    {
        //        WriteToDocuments(documents);
        //        WriteToWords(words);
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    return true;
        //}

        //private void WriteToDocuments(Dictionary<string, Document> documents)
        //{
        //    _documents.InsertManyAsync(documents.Values.ToList());
        //}

        //private void WriteToWords(Dictionary<string, Word> wordsToWrite)
        //{
        //    _words.InsertManyAsync(wordsToWrite.Values.ToList());
        //}

        //public Word FindWord(string wordToSearch)
        //{
        //    try
        //    {
        //        var word = _words.Find<Word>(w => w.word.Equals(wordToSearch)).FirstOrDefault();
        //        return word;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        //public Document FindDocumentById(string id)
        //{
        //    try
        //    {
        //        var document = _documents.Find<Document>(doc => doc.Id.Equals(id.ToLower())).FirstOrDefault();
        //        return document;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}
    }
}
