namespace GrigCoreLastfm.XML.Model
{
    public class GXmlAttrubute
    {
        private string _key = string.Empty;
        /// <summary>
        /// Gets or sets attribute kay
        /// </summary>
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private string _value = string.Empty;
        /// <summary>
        /// Gets or sets attribute value
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

    }
}
