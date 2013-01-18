using System.Collections;
using GrigCoreLastfm.API.Types;
using System;
using System.Linq;
using GrigCoreLastfm.Utilities;
using GrigCoreLastfm.XML.Model;
using System.Threading.Tasks;

namespace GrigCoreLastfm.Lastfm
{
    public class LastfmParser
    {
        #region Fields

        readonly RefTools _refTools = new RefTools();

        #endregion

        #region Methods

        /// <summary>
        /// Set last.fm object property values with session from GXmlInner
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="inner"></param>
        /// <param name="session"></param>
        public object SetObjectPropertiesValues(object obj, GXmlInner inner, Session session)
        {
            // This inner has no childs
            var theImagesProperty = new Images();
          
            Parallel.ForEach(inner.Inners, gXmlInner =>
                   {
                       #region
                       try
                       {
                           if (gXmlInner.HasInners() == false)
                           {
                               gXmlInner.Name = gXmlInner.Name.Replace(":", string.Empty);
                               gXmlInner.Name = gXmlInner.Name.Replace("artist", "artistname");
                               if (gXmlInner.Name.Contains("image"))
                               {
                                   _refTools.SetPropertyValue(theImagesProperty, gXmlInner.GetAttributeValue("size"), gXmlInner.InnerValue);
                                   _refTools.SetPropertyValue(obj, "Images", theImagesProperty);
                               }
                               else
                               {
                                   _refTools.SetPropertyValue(obj, gXmlInner.Name, gXmlInner.InnerValue);
                               }
                           }
                           else
                           {
                               if (!IsList(gXmlInner)) // Is list, but just properties list
                               {
                                   // Replace name
                                   gXmlInner.Name = gXmlInner.Name.Replace(":", string.Empty);
                                   // Get object property 'PropertyInfo'
                                   Type objectPropertyInfo = _refTools.GetPropertyInfoByName(gXmlInner.Name, obj).PropertyType;
                                   // Get object property copy
                                   var tempPropertyObject =
                                       Activator.CreateInstance(objectPropertyInfo.Assembly.FullName,
                                                                objectPropertyInfo.FullName);
                                   // Unwrap object property copy
                                   var propertyObject = tempPropertyObject.Unwrap();
                                   // Add session to obj
                                   SetSessionToObject(session, propertyObject);
                                   // Set values to property copy
                                   propertyObject = SetObjectPropertiesValues(propertyObject, gXmlInner, session);
                                   // Set property copy value to object property 
                                   _refTools.SetPropertyValue(obj, gXmlInner.Name, propertyObject);
                               }
                               else // Items list, it's seriusly
                               {
                                   // Parse Items Type Name: Example topalbums - albums
                                   var itemTypeName = gXmlInner.Name.Replace("top", string.Empty);
                                   itemTypeName = itemTypeName.Replace(":", string.Empty);
                                   // Get Item type
                                   Type objectPropertyInfo = _refTools.GetPropertyInfoByName(itemTypeName, obj).PropertyType;
                                   var theItemType = objectPropertyInfo.GetGenericArguments().Single();

                                   // Create temp list for items
                                   var objectsList =
                                           (IList)_refTools.GetPropertyInfoByName(itemTypeName, obj).GetValue(obj, null);

                                   // parallel foreach
                                   Parallel.ForEach(gXmlInner.Inners, xmlInner =>
                                   {
                                       try
                                       {
                                           // create temp item
                                           var tempPropertyObject =
                                           Activator.CreateInstance(theItemType.Assembly.FullName,
                                                                    theItemType.FullName);
                                           object addedPropertyObject = tempPropertyObject.Unwrap();
                                           // Set session to object
                                           SetSessionToObject(session, addedPropertyObject);

                                           addedPropertyObject = SetObjectPropertiesValues(addedPropertyObject, xmlInner, session);
                                           // Add object to list
                                           objectsList.Add(addedPropertyObject);
                                       }
                                       catch { }
                                   });


                                   // after foreach add items = object property(list)
                                   _refTools.SetPropertyValue(obj, gXmlInner.Name, objectsList);
                               }
                           }

                       }
                       catch { }
                       #endregion
                   });
            return obj;
        }

        /// <summary>
        /// Set last.fm object property values from GXmlInner
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="inner"></param>
        public void SetObjectPropertiesValues(ref object obj, GXmlInner inner)
        {
            obj = SetObjectPropertiesValues(obj, inner, null);
        }

        #endregion

        #region Utilites

        /// <summary>
        /// Set session property
        /// </summary>
        /// <param name="session"></param>
        /// <param name="obj"></param>
        private void SetSessionToObject(Session session, object obj)
        {
            if (session != null)
            {
                _refTools.SetPropertyValue(obj, "Session", session);
            }
        }

        /// <summary>
        /// Get session property
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private Session GetSessionFromObject(object obj)
        {
            object sessionObj = _refTools.GetPropertyValue("Session", obj);
            var sessionVar = sessionObj as Session;
            return sessionVar;
        }

        /// <summary>
        /// Inners in inner is list?
        /// inner[n].Name = inner[n+1].Name => is list
        /// </summary>
        /// <param name="inner"></param>
        /// <returns></returns>
        private bool IsList(GXmlInner inner)
        {
            if (inner.Inners.Count > 1)
                if (inner.Inners[0].Name == inner.Inners[1].Name)
                    if (inner.Name != "image")
                        return true;

            #region
            //var activeName = inner.Inners.First().Name;
            //bool first = true;
            //foreach (var gXmlInner in inner.Inners)
            //{
            //    if (first)
            //    {
            //        first = false; 
            //        continue;
            //    }
            //    if (gXmlInner.Name == activeName)
            //        return true;
            //}
            #endregion

            return false;
        }

        #endregion

    }

}
