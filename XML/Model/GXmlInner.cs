using System.Linq;

namespace GrigCoreLastfm.XML.Model
{
    public class GXmlInner
    {
        #region Properties

        private GXmlAttrubutes _attrubutes = new GXmlAttrubutes();
        /// <summary>
        /// Gets or sets attrubutes
        /// </summary>
        public GXmlAttrubutes Attrubutes
        {
            get { return _attrubutes; }
            set { _attrubutes = value; }
        }

        private string _name = string.Empty;
        /// <summary>
        /// Gets or sets key
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private string _value = string.Empty;
        /// <summary>
        /// Gets or sets value
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private GXmlInners _inners = new GXmlInners();
        /// <summary>
        /// Gets or sets innters
        /// </summary>
        public GXmlInners Inners
        {
            get { return _inners; }
            set { _inners = value; }
        }

        private string _innerValue = string.Empty;
        /// <summary>
        /// Gets or sets inner
        /// </summary>
        public string InnerValue
        {
            get { return _innerValue; }
            set { _innerValue = value; }
        }
        

        #endregion

        #region Methods
       
        /// <summary>
        /// Has innters
        /// </summary>
        /// <returns></returns>
        public bool HasInners()
        {
            if (Inners.Count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Get inner by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public GXmlInner GetInnerByKey(string key)
        {
            foreach (var gXmlInner in Inners.Where(gXmlInner => gXmlInner.Name == key))
            {
                return gXmlInner;
            }

            return new GXmlInner();
        }

        public GXmlInner GetInnerByKeyAndAttrubute(string key, string attrubuteValue)
        {
            foreach (GXmlInner gXmlInner in Inners)
            {
                GXmlAttrubute attr = gXmlInner.GetAttributeByValue(attrubuteValue);
                if (gXmlInner.Name == key && attr.Value == attrubuteValue) return gXmlInner;
            }

            return new GXmlInner();
        }

        /// <summary>
        /// Get attrubute by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GXmlAttrubute GetAttributeByValue(string name)
        {
            foreach (var gXmlAttrubute in Attrubutes.Where(gXmlAttrubute => gXmlAttrubute.Value == name))
            {
                return gXmlAttrubute;
            }

            return new GXmlAttrubute();
        }

        public string GetAttributeValue(string key)
        {
            foreach (var attr in Attrubutes.Where(attr => attr.Key == key))
            {
                return attr.Value;
            }
            return string.Empty;
        }

        #endregion

    }
}
