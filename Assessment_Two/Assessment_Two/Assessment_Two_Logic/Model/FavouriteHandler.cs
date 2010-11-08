using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace Assessment_Two_Logic.Model
{
    public class FavouriteHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();  

        public delegate void ChangeHandler(object subject);
        
        public event ChangeHandler ChangeEvent;

        /// <summary>
        /// Object used to locking to prevent deadlocks.
        /// </summary>
        private static Object lockObject = new Object();

        private static FavouriteHandler _Instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static FavouriteHandler Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (lockObject)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new FavouriteHandler();
                        }
                    }
                }
                return _Instance;
            }
        }

        private XmlSerialiser<List<Favourite>> _Serializer;
        private List<Favourite> _Favourites;

        /// <summary>
        /// Gets the history.
        /// </summary>
        /// <value>The history.</value>
        public List<Favourite> Favourites
        {
            get
            {
                return _Favourites;
            }
        }

        private FavouriteHandler()
        {
            this._Serializer = new XmlSerialiser<List<Favourite>>();
            this._Favourites = new List<Favourite>();
        }

        private FavouriteHandler(String filePath)
        {
            this._Serializer = new XmlSerialiser<List<Favourite>>(filePath);
            this._Favourites = new List<Favourite>();
        }

        /// <summary>
        /// Adds the entry.
        /// </summary>
        /// <param name="url">The URL.</param>
        public void AddEntry(String name, String url)
        {
            Favourite favourite = new Favourite(url, name);
            this.Favourites.Add(favourite);
            this.Notify();
        }

        /// <summary>
        /// Edits the favourite.
        /// </summary>
        /// <param name="fav">The fav.</param>
        /// <param name="newName">The new name.</param>
        /// <param name="newUrl">The new URL.</param>
        public void EditFavourite(Favourite fav, String newName, String newUrl)
        {
            foreach (Favourite favourite in this.Favourites)
            {
                if (favourite.Equals(fav))
                {
                    favourite.Name = newName;
                    favourite.Url = newUrl;
                }
            }
            this.Notify();
        }

        /// <summary>
        /// Deletes the favourite.
        /// </summary>
        /// <param name="fav">The fav.</param>
        public void DeleteFavourite(Favourite fav)
        {
            this.Favourites.Remove(fav);
            this.Notify();
        }

        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SetFilePath(String path)
        {
            this._Serializer.FilePath = path;
        }

        /// <summary>
        /// Loads the history.
        /// </summary>
        public void LoadFavourite()
        {
            try
            {
                List<Favourite> favourites = this._Serializer.Read();
                this._Favourites = favourites;
                this.Notify();
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }

        /// <summary>
        /// Loads the history.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void LoadFavourite(String filePath)
        {
            String oldPath = this._Serializer.FilePath;
            this._Serializer.FilePath = filePath;
            List<Favourite> favourites = this._Serializer.Read();
            this._Favourites = favourites;
            this._Serializer.FilePath = oldPath;
            this.Notify();
        }

        /// <summary>
        /// Saves the history.
        /// </summary>
        public void SaveFavourite()
        {
            this._Serializer.Write(this.Favourites);
        }

        /// <summary>
        /// Saves the history.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SaveFavourite(String path)
        {
            String oldPath = this._Serializer.FilePath;
            this._Serializer.FilePath = path;
            this.SaveFavourite();
            this._Serializer.FilePath = oldPath;
        }

        private void Notify()
        {
            if (ChangeEvent != null)
            {
                ChangeEvent(this);
            }
        }
    }
}
