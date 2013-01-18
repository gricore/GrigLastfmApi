using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigCoreLastfm.API.Types
{
    public class Event : Base
    {
        private string _id = string.Empty;
        /// <summary>
        /// Gets or sets event id
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _title = string.Empty;
        /// <summary>
        /// Gets or sets title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private Venue _venue = new Venue();
        /// <summary>
        /// Gets or sets venue
        /// </summary>
        public Venue Venue
        {
            get { return _venue; }
            set { _venue = value; }
        }
        

    }
}
