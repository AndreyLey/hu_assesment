using Form_Builder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InputType = Form_Builder.Model.InputType;

namespace Form_Builder.DB
{
    public interface IDBAccessLayer
    {
        List<InputType> GetTypes();
        Form GetForm(string id);
        bool SaveForm(Form form);
        List<Submission> GetSubmissions();
        bool SaveSubmission(string id, Submission submission);
    }
}
