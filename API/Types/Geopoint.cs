using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigCoreLastfm.API.Types
{
    public class Geopoint : Base
    {
        private string _geolat = string.Empty;
        /// <summary>
        /// Gets or sets geo lat
        /// </summary>
        public string Geolat
        {
            get { return _geolat; }
            set { _geolat = value; }
        }

        private string _geolong = string.Empty;
        /// <summary>
        /// Gets or sets geo long
        /// </summary>
        public string Geolong
        {
            get { return _geolong; }
            set { _geolong = value; }
        }
        

    }
}
