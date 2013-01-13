using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigCoreLastfm.Request
{
    public class LastfmRequest
    {
        // Base URL
        private const string BaseUrl = "http://ws.audioscrobbler.com/2.0/?method=";

        private string requestURL = string.Empty;
        internal string RequestURL { get { return requestURL; } private set { requestURL = value; } }

        private RequestParameters parameters = new RequestParameters();

        public LastfmRequest(string method, RequestParameters parameters)
        {
            RequestURL = BaseUrl;
            RequestURL += method;

            if (parameters.Count > 0)
            {
                foreach (var requestParameter in parameters)
                {
                    RequestURL += ("&" + requestParameter.Key + "=" + requestParameter.Value);
                }
            }

        }
        
    }
}
