using GrigCoreLastfm.Request;
using System.Collections.Generic;

namespace GrigCoreLastfm.API.Types
{
    public class Artist : Base
    {
        #region Properties

        private string _mbid = string.Empty;
        /// <summary>
        /// Gets or sets mbid
        /// </summary>
        public string Mbid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_mbid))
                    GetInfo();
                return _mbid;
            }
            set { _mbid = value; }
        }

        private string _url = string.Empty;
        /// <summary>
        /// Gets or sets url
        /// </summary>
        public string Url
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_url))
                    GetInfo();
                return _mbid;
            }
            set { _url = value; }
        }

        private string _streamable = string.Empty;
        /// <summary>
        /// Gets or sets streamable
        /// </summary>
        public string Streamable
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_streamable))
                    GetInfo();
                return _streamable;
            }
            set { _streamable = value; }
        }

        private string _ontour = string.Empty;
        /// <summary>
        /// Gets or sets ontour
        /// </summary>
        public string Ontour
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_ontour))
                    GetInfo();
                return _ontour;
            }
            set { _ontour = value; }
        }

        private Images _images = new Images();
        /// <summary>
        /// Gets images
        /// </summary>
        public Images Images
        {
            get { return _images; }
            set { _images = value; }
        }

        private List<Album> _albums = new List<Album>();
        /// <summary>
        /// Gets or sets albums
        /// </summary>
        public List<Album> Albums
        {
            get { return _albums; }
            set { _albums = value; }
        }

        private List<Artist> _similar = new List<Artist>();
        /// <summary>
        /// Gets or sets similars
        /// </summary>
        public List<Artist> Similar
        {
            get { return _similar; }
            set { _similar = value; }
        }

        private List<Tag> _tags = new List<Tag>();
        /// <summary>
        /// Gets or sets tags
        /// </summary>
        public List<Tag> Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        private Stats _stats = new Stats();
        /// <summary>
        /// Gets or sets stats
        /// </summary>
        public Stats Stats
        {
            get { return _stats; }
            set { _stats = value; }
        }

        private Bio _bio = new Bio();
        /// <summary>
        /// Gets or sets bio
        /// </summary>
        public Bio Bio
        {
            get { return _bio; }
            set { _bio = value; }
        }

        private List<Member> _bandmembers = new List<Member>();
        /// <summary>
        /// Gets or set bandmembers
        /// </summary>
        public List<Member> Bandmembers
        {
            get { return _bandmembers; }
            set { _bandmembers = value; }
        }

        private List<Track> _tracks = new List<Track>();
        /// <summary>
        /// Gets or sets top tracks
        /// </summary>
        public List<Track> Tracks
        {
            get { return _tracks; }
            set { _tracks = value; }
        }

        private List<Event> _events = new List<Event>();
        /// <summary>
        /// Gets or sets artist events
        /// </summary>
        public List<Event> Events
        {
            get { return _events; }
            set { _events = value; }
        }


        #endregion

        #region Methods

        /// <summary>
        /// Get artist Info
        /// </summary>
        public void GetInfo()
        {
            var parameters = new RequestParameters
                {
                    new RequestParameter {Key = "artist", Value = Name},
                    new RequestParameter {Key = "api_key", Value = Session.ApiKey},
                    new RequestParameter {Key = "api_sec", Value = Session.ApiSec}
                };
            object obj = new Artist { Session = Session };
            AutomaticGetObject("artist.getInfo", parameters, ref obj, "artist");
            ConvertValues(this, obj);
        }

        /// <summary>
        /// Get artist top albums
        /// </summary>
        /// <returns></returns>
        public List<Album> GetTopAlbums()
        {
            var parameters = new RequestParameters
                {
                    new RequestParameter {Key = "artist", Value = Name},
                    new RequestParameter {Key = "api_key", Value = Session.ApiKey},
                    new RequestParameter {Key = "api_sec", Value = Session.ApiSec}
                };

            object obj = new Artist { Session = Session };
            AutomaticGetObject("artist.getTopAlbums", parameters, ref obj);

            var finalArtist = obj as Artist;
            if (finalArtist != null) Albums = finalArtist.Albums;

            return Albums;
        }

        /// <summary>
        /// Get artist top tags
        /// </summary>
        /// <returns></returns>
        public List<Tag> GetTopTags()
        {
            var parameters = new RequestParameters
                {
                    new RequestParameter {Key = "artist", Value = Name},
                    new RequestParameter {Key = "api_key", Value = Session.ApiKey},
                    new RequestParameter {Key = "api_sec", Value = Session.ApiSec}
                };

            object obj = new Artist { Session = Session };
            AutomaticGetObject("artist.getTopTags", parameters, ref obj);

            var finalArtist = obj as Artist;
            if (finalArtist != null) Tags = finalArtist.Tags;

            return Tags;
        }

        /// <summary>
        /// Get top tarcks
        /// </summary>
        /// <returns></returns>
        public List<Track> GetTopTracks()
        {
            var parameters = new RequestParameters
                {
                    new RequestParameter {Key = "artist", Value = Name},
                    new RequestParameter {Key = "api_key", Value = Session.ApiKey},
                    new RequestParameter {Key = "api_sec", Value = Session.ApiSec}
                };

            object obj = new Artist { Session = Session };
            AutomaticGetObject("artist.getTopTracks", parameters, ref obj);

            var finalArtist = obj as Artist;
            if (finalArtist != null) Tracks = finalArtist.Tracks;

            return Tracks;
        }

        /// <summary>
        /// Gets artist events
        /// </summary>
        /// <returns></returns>
        public List<Event> GetEvents()
        {
            var parameters = new RequestParameters
                {
                    new RequestParameter {Key = "artist", Value = Name},
                    new RequestParameter {Key = "api_key", Value = Session.ApiKey},
                    new RequestParameter {Key = "api_sec", Value = Session.ApiSec}
                };

            object obj = new Artist { Session = Session };
            AutomaticGetObject("artist.getEvents", parameters, ref obj);

            var finalArtist = obj as Artist;
            if (finalArtist != null) Events = finalArtist.Events;

            return Events;
        }

        #endregion

        #region Ctors

        /// <summary>
        /// Init an artist
        /// </summary>
        public Artist(string name, Session session)
        {
            Name = name;
            Session = session;
        }

        public Artist()
        {

        }

        #endregion
    }
}
