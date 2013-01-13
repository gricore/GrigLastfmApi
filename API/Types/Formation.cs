namespace GrigCoreLastfm.API.Types
{
    public class Formation
    {
        private string _yearfrom = string.Empty;
        private string _yearto = string.Empty;

        /// <summary>
        /// Gets or sets year from
        /// </summary>
        public string Yearfrom
        {
            get { return _yearfrom; }
            set { _yearfrom = value; }
        }

        /// <summary>
        /// Gets or sets yearto
        /// </summary>
        public string Yearto
        {
            get { return _yearto; }
            set { _yearto = value; }
        }
    }
}
