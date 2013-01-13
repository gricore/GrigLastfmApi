namespace GrigCoreLastfm.API.Types
{
    public class Member
    {
        private string _name = string.Empty;
        private string _yearfrom = string.Empty;
        private string _yearto = string.Empty;

        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or set year from
        /// </summary>
        public string Yearfrom
        {
            get { return _yearfrom; }
            set { _yearfrom = value; }
        }

        /// <summary>
        /// Gets or sets year to
        /// </summary>
        public string Yearto
        {
            get { return _yearto; }
            set { _yearto = value; }
        }
    }
}
