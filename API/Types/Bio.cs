using System.Collections.Generic;

namespace GrigCoreLastfm.API.Types
{
    public class Bio
    {
        private string _published = string.Empty;
        private string _summary = string.Empty;
        private string _placeformed = string.Empty;
        private string _yearformed = string.Empty;
        private List<Formation> _formationlist = new List<Formation>();

        /// <summary>
        /// Gets or sets published
        /// </summary>
        public string Published
        {
            get { return _published; }
            set { _published = value; }
        }

        /// <summary>
        /// Gets or sets summary
        /// </summary>
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
       
        /// <summary>
        /// Gets or sets placeformed
        /// </summary>
        public string Placeformed
        {
            get { return _placeformed; }
            set { _placeformed = value; }
        }
       
        /// <summary>
        /// Gets or set yearformed
        /// </summary>
        public string Yearformed
        {
            get { return _yearformed; }
            set { _yearformed = value; }
        }
       
        /// <summary>
        /// Gets or sets formationlist
        /// </summary>
        public List<Formation> Formationlist
        {
            get { return _formationlist; }
            set { _formationlist = value; }
        }
    }
}
