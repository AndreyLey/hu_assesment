using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Builder.Model.Out
{
    public class FormSummaryResponse
    {
        public string Id { get; set; }
        public string FormName { get; set; }
        public int Submissions { get; set; }
        
    }
}
