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

        public  Form GetFormById(string id)
        {
            try
            {
                Console.WriteLine("In Get Form by Id Manager ");
                if (!String.IsNullOrEmpty(id))
                {
                    var form = _dBAccessLayer.GetForm(id);

                    Console.WriteLine("In Get Form by Id Manager ");
                    return form;
                }
                else
                    return null;
            }
            catch(Exception e) 
            {
                Console.WriteLine($"Exception while Get Form by Id: {e}");
                return null;
            }

        }

        public List<FormSummaryResponse> GetFormsSummary()
        {
            List<FormSummaryResponse> formsSummaryResponse = new List<FormSummaryResponse>();
            try
            {
                Console.WriteLine("In Get Form Manager");

                var forms = _dBAccessLayer.GetForms();

                forms.ForEach(form =>
                    formsSummaryResponse.Add(new FormSummaryResponse()
                    {
                        Id = form.Id,
                        FormName = form.Form_name,
                        Submissions = form.Submissions_Ids.Count()
                    })
                );
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception while GetFormsSummary: {e}");
            }
            return formsSummaryResponse;

        }

        public FormSummaryResponse GetFormSummaryById(string id)
        {
            try
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
            catch(Exception e)
            {
                Console.WriteLine($"Exception while GetFormsSummaryById: {e}");
                return null;
            }

        }

        public List<Submission> GetSubmissionsByFormId(string id)
        {
            List<Submission> submissionsById = new List<Submission>();
            try
            {
                Console.WriteLine("In Get Submissions By FormId");
                var submissionIds = _dBAccessLayer.GetForm(id).Submissions_Ids;
                submissionsById = _dBAccessLayer.GetSubmissions(submissionIds);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception while GetSubmissionsByFormId: {e}");
            }
            return submissionsById;
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
                Console.Write($"Exxception while GetTypes: {e}");
            }
            return types;
        }

        public async Task SaveForm(Form form)
        {
            try
            {
               await _dBAccessLayer.SaveForm(form);
            }
            catch (Exception e)
            {
                Console.Write($"Exception while Save Form: {e}");
            }
        }

        public async Task SaveSubmission(string id, Submission submission)
        {
            try
            {
                Console.WriteLine("In Save Submissions");
                if (!String.IsNullOrEmpty(id) && submission != null)
                {
                    await _dBAccessLayer.SaveSubmission(id, submission);
                }
            }
            catch(Exception e)
            {
                Console.Write($"Exception while SaveSubmission: {e}");

            }
        }
    }
}
