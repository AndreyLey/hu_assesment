using Form_Builder.DB;
using Form_Builder.Model;
using Form_Builder.Model.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Builder.Services
{
    public class FormManager : IFormManager
    {
        private readonly IDBAccessLayer _dBAccessLayer;
        public FormManager(IDBAccessLayer dBAccessLayer)
        {      
            _dBAccessLayer = dBAccessLayer;
            Console.WriteLine("Form Manager Service Initialized");
        }

        public Form GetFormById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var form = _dBAccessLayer.GetForm(id);

                Console.WriteLine("In Get Form Manager");
                return form;
            }
            else
                return null;
        }

        public FormSummaryResponse GetFormSummaryById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var form = _dBAccessLayer.GetForm(id);

                Console.WriteLine("In Get Form Manager");
                return new FormSummaryResponse()
                    {
                        Id = form.Id,
                        FormName = form.Form_name,
                        Submissions = form.Submissions_Ids.Count()
                    };                   
            }
            else
                return null;
        }

        public List<Submission> GetSubmissions()
        {
            throw new NotImplementedException();
        }

        public List<InputType> GetTypes()
        {
            Console.WriteLine("In Get Types");
            List<InputType> types = new List<InputType>();
            try
            {
                types = _dBAccessLayer.GetTypes();
            }
            catch(Exception e)
            {
                Console.Write($"GetTypes: {e}");
            }
            return types;
            //throw new NotImplementedException();
        }

        public bool SaveForm(Form form)
        {
            try
            {
               return  _dBAccessLayer.SaveForm(form);
            }
            catch (Exception e)
            {
                Console.Write($"Save Form: {e}");
                return false;
            }
        }

        public bool SaveSubmission(string id, Submission submission)
        {
            Console.WriteLine("In Save Submissions");
            if(!String.IsNullOrEmpty(id) && submission != null)
            {
                _dBAccessLayer.SaveSubmission(id, submission);
                return true;
            }
            return false;
            //throw new NotImplementedException();
        }
    }
}
