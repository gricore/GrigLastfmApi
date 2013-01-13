using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigCoreLastfm.API.Types
{
    public class Album : Base
    {
        
        public string Mbid { get; set; }

        public string Url { get; set; }

        private Artist _artist = new Artist();
        public Artist Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }

        public Album()
        {
            
        }
    }
}
