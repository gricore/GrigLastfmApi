using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrigCoreLastfm.Request;

namespace GrigCoreLastfm.API.Types
{
    public class User : Base
    {
        private Images _images = new Images();
        private string _realname = string.Empty;


        public Images Images
        {
            get { return _images; }
            set { _images = value; }
        }

        public string Realname
        {
            get { return _realname; }
            set { _realname = value; }
        }

        #region Methods

        public void GetInfo()
        {
            // Params
            var parameters = new RequestParameters { { "api_key", Session.ApiKey }, { "user", Name } };
            // Object
            object userObject = new User(Name, Session);
            // Get Object Data
            AutomaticGetObject("user.getInfo", parameters, ref userObject, "user");
            // Convert
            ConvertValues(this, userObject);
        }


        public bool IsUserBe()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return false;

            return true;
        }

        #endregion

        #region Ctors

        public User(string name, Session session)
        {
            Name = name;
            Session = session;
        }

        public User()
        {

        }

        #endregion
    }
}
