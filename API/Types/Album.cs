using GrigCoreLastfm.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigCoreLastfm.API.Types
{
    public class Album : Base
    {
        #region Properties

        private string _mbid = string.Empty;
        /// <summary>
        /// Gets or sets mbid
        /// </summary>
        public string Mbid
        {
            get { return _mbid; }
            set { _mbid = value; }
        }


        private string _url = string.Empty;
        /// <summary>
        /// Gets or sets url
        /// </summary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }


        private Artist _artist = new Artist();
        /// <summary>
        /// Gets or sets artist
        /// </summary>
        public Artist Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }

        private string _artistname = string.Empty;
        /// <summary>
        /// Gets or sets artist name
        /// </summary>
        public string Artistname
        {
            get { return _artistname; }
            set { _artistname = value; }
        }


        private List<Track> _tracks = new List<Track>();
        /// <summary>
        /// Gets or sets tracks
        /// </summary>
        public List<Track> Tracks
        {
            get { return _tracks; }
            set { _tracks = value; }
        }


        #endregion

        #region Methods

        public void GetInfo()
        {
            var parameters = new RequestParameters
                {
                    new RequestParameter {Key = "artist", Value = Artist.Name},
                    new RequestParameter {Key = "album", Value = Name},
                    new RequestParameter {Key = "api_key", Value = Session.ApiKey},
                    new RequestParameter {Key = "api_sec", Value = Session.ApiSec}
                };
            object obj = new Album { Session = Session };
            AutomaticGetObject("album.getInfo", parameters, ref obj, "album");
            ConvertValues(this, obj);
            Artist = new Artist(Artistname, this.Session);
        }

        #endregion

        #region Ctor

        public Album()
        {

        }

        #endregion
    }
}
