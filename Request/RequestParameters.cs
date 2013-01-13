using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigCoreLastfm.Request
{
    public class RequestParameters : List<RequestParameter>
    {
        public void Add(string key, string value)
        {
            Add(new RequestParameter{Key = key,Value = value});
        }
    }
}
