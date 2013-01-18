using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigCoreLastfm.API.Types
{
    public class Venue : Base
    {
        private string _id = string.Empty;
        /// <summary>
        /// Gets or sets value id
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Location _location = new Location();
        /// <summary>
        /// Gets or sets location
        /// </summary>
        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }
        
        
    }
}
