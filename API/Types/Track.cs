using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigCoreLastfm.API.Types
{
    public class Track : Base
    {
        private string _duration = string.Empty;
        /// <summary>
        /// Gets or sets track duration
        /// </summary>
        public string Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        private string _playcount = string.Empty;
        /// <summary>
        /// Gets or sets playcount
        /// </summary>
        public string Playcount
        {
            get { return _playcount; }
            set { _playcount = value; }
        }

        private string _listeners = string.Empty;
        /// <summary>
        /// Gets or sets track listeners
        /// </summary>
        public string Listeners
        {
            get { return _listeners; }
            set { _listeners = value; }
        }

        private string _mbid = string.Empty;
        /// <summary>
        /// Gets or sets track mbid
        /// </summary>
        public string Mbid
        {
            get { return _mbid; }
            set { _mbid = value; }
        }


        private string _url = string.Empty;
        /// <summary>
        /// Gets or sets track url
        /// </summary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _streamable = string.Empty;
        /// <summary>
        /// Gets or sets track streamable
        /// </summary>
        public string Streamable
        {
            get { return _streamable; }
            set { _streamable = value; }
        }

        private Artist _artist = new Artist();
        /// <summary>
        /// Gets or sets track artist
        /// </summary>
        public Artist Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }

        private Images _images = new Images();
        /// <summary>
        /// Gets or sets track images
        /// </summary>
        public Images Images
        {
            get { return _images; }
            set { _images = value; }
        }
        
    }
}
