using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigCoreLastfm.API.Types
{
    public class Location : Base
    {
        private string _city = string.Empty;
        /// <summary>
        /// Gets or sets city
        /// </summary>
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _country = string.Empty;
        /// <summary>
        /// Gets or sets country
        /// </summary>
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private string _street = string.Empty;
        /// <summary>
        /// Gets or sets street
        /// </summary>
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        private string _postalcode = string.Empty;
        /// <summary>
        /// Gets or sets postal code
        /// </summary>
        public string Postalcode
        {
            get { return _postalcode; }
            set { _postalcode = value; }
        }

        private Geopoint _geopoint = new Geopoint();
        /// <summary>
        /// Gets or sets geo point
        /// </summary>
        public Geopoint Geopoint
        {
            get { return _geopoint; }
            set { _geopoint = value; }
        }
        

    }
}
