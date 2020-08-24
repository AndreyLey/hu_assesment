using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Builder.Model
{
    public class BaseResult
    {
        public bool Success { get; set; } = true;
        public List<string> Error { get; set; } = new List<string>();

    }
}
