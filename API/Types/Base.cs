using GrigCoreLastfm.Lastfm;
using GrigCoreLastfm.Request;
using GrigCoreLastfm.Utilities;
using GrigCoreLastfm.XML;

namespace GrigCoreLastfm.API.Types
{
    public abstract class Base
    {
        #region Fields

        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets a session
        /// </summary>
        public Session Session { get; set; }

        #endregion

        #region Utilities

        /// <summary>
        /// Convert values to current object
        /// </summary>
        /// <param name="emptyObj">Current class object: this</param>
        /// <param name="fullObj">Getted object</param>
        protected void ConvertValues(object emptyObj, object fullObj)
        {
            var refTools = new RefTools();           
            var myObjectType = emptyObj.GetType();
            var fieldInfo = myObjectType.GetProperties();

            foreach (var info in fieldInfo)
            {
                info.SetValue(this, refTools.GetPropertyValue(info.Name, fullObj), null);
            }
        }

        /// <summary>
        /// Get last.fm object automatically
        /// </summary>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <param name="lastfmObject"></param>
        protected void AutomaticGetObject(string method, RequestParameters parameters, ref object lastfmObject)
        {
            var request = new LastfmRequest(method, parameters);
            var parser = new XmlParser(request.RequestURL);
            var inner = parser.ConvertToInners();
            var lastfmParser = new LastfmParser();
            lastfmObject = lastfmParser.SetObjectPropertiesValues(lastfmObject, inner, Session);
        }

        /// <summary>
        /// Get last.fm object automatically
        /// </summary>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <param name="lastfmObject"></param>
        /// <param name="type"></param>
        protected void AutomaticGetObject(string method, RequestParameters parameters, ref object lastfmObject, string type)
        {
            var request = new LastfmRequest(method, parameters);
            var parser = new XmlParser(request.RequestURL);
            var inner = parser.ConvertToInners().GetInnerByKey(type);
            var lastfmParser = new LastfmParser();
            lastfmObject = lastfmParser.SetObjectPropertiesValues(lastfmObject, inner, Session);
        }

        #endregion
    }
}
