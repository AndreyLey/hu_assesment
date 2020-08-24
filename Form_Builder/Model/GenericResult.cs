using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Builder.Model
{
    public class GenericResult<T> : BaseResult
    {
        public T Result {get;set;}
        public GenericResult() : base() { }
    }
}
