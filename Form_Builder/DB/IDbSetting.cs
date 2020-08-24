using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Builder.DB
{
    public interface IDbSetting
    {
        public string InputTypeCollectionName { get; set; }
        public string SubmissionCollectionName { get; set; }
        public string FormCollectionName { get; set; }
        public string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
