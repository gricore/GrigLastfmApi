using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using GrigCoreLastfm.UIComponent;
using GrigCoreLastfm.Request;

namespace GrigCoreLastfm.API.Types
{
    public class Session : Base
    {
        private string _apiKey = string.Empty;
        private string _apiSec = string.Empty;
        private string _token = string.Empty;
        private string _apiSig = string.Empty;
        private string _key = string.Empty;

        public string ApiKey
        {
            get { return _apiKey; }
            set { _apiKey = value; }
        }

        public string ApiSec
        {
            get { return _apiSec; }
            set { _apiSec = value; }
        }

        public string Token
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(_token))
                //    GetToken();
                return _token;
            }
            set { _token = value; }
        }

        public string ApiSig
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(_apiSig))
                //    GetApiSig();
                return _apiSig;
            }
            set { _apiSig = value; }
        }

        public string Key
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(_key))
                //    GetSession();
                return _key;
            }
            set { _key = value; }
        }


        public Session(string apiKey, string apiSec)
        {
            ApiKey = apiKey;
            ApiSec = apiSec;
        }

        public void GetSession()
        {
            if (string.IsNullOrWhiteSpace(Token)) GetToken();
            if (string.IsNullOrWhiteSpace(ApiSig)) GetApiSig();

            var browser = new System.Windows.Controls.WebBrowser();
            browser.Navigate("http://www.last.fm/api/auth/?api_key="
                + ApiKey + "&token="
                + Token);
            var logWindow = new LogInWindow(browser);
            logWindow.ShowDialog();

            var Params = new RequestParameters { { "token", Token }, { "api_sig", ApiSig },
            { "api_key", ApiKey }};

            object lfmSession = new Session { ApiKey = ApiKey, ApiSec = ApiSec, ApiSig = ApiSig, Token = Token, Name = Name, Key = Key };
            AutomaticGetObject("auth.getsession", Params, ref lfmSession, "session");
            var lastSession = lfmSession as Session;
            if (lastSession != null)
            {
                Key = lastSession.Key;
                Name = lastSession.Name;
            }
        }

        public void GetToken()
        {
            var Params = new RequestParameters { { "api_key", ApiKey }, { "api_sec", ApiSec } };
            object lfmSession = new Session { ApiKey = ApiKey, ApiSec = ApiSec, ApiSig = ApiSig, Token = Token, Name = Name, Key = Key };
            AutomaticGetObject("auth.getToken", Params, ref lfmSession);
            var lastSession = lfmSession as Session;
            if (lastSession != null) Token = lastSession.Token;
        }

        public void GetApiSig()
        {
            if (string.IsNullOrWhiteSpace(Token)) GetToken();

            var tmp = "api_key" + ApiKey + "methodauth.getsessiontoken" + Token + ApiSec;
            ApiSig = md5(tmp);
        }

        #region Utilities

        private string md5(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            var c = new MD5CryptoServiceProvider();
            buffer = c.ComputeHash(buffer);

            var builder = new StringBuilder();
            foreach (var b in buffer)
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }

        #endregion

        #region Methods

        public bool HasSession()
        {
            if (string.IsNullOrWhiteSpace(_key))
                return false;
            return true;
        }

        #endregion

        #region Ctor

        public Session()
        {

        }

        #endregion
    }
}
