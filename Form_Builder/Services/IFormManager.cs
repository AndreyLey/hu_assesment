using Form_Builder.DB;
using Form_Builder.Model;
using Form_Builder.Model.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InputType = Form_Builder.Model.InputType;

namespace Form_Builder.Services
{
    public interface IFormManager
    {
        List<InputType> GetTypes();
        Form GetFormById(string id);
        FormSummaryResponse GetFormSummaryById(string id);
        bool SaveForm(Form form);
        List<Submission> GetSubmissions();
        bool SaveSubmission(string id, Submission submission);
    }
}
