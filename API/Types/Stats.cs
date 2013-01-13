namespace GrigCoreLastfm.API.Types
{
    public class Stats
    {
        private string _listeners = string.Empty;
        private string _playcount = string.Empty;

        /// <summary>
        /// Gets or sets listeners
        /// </summary>
        public string Listeners
        {
            get { return _listeners; }
            set { _listeners = value; }
        }

        /// <summary>
        /// Gets or sets playcount
        /// </summary>
        public string Playcount
        {
            get { return _playcount; }
            set { _playcount = value; }
        }
    }
}
