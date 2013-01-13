using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GrigCoreLastfm.Utilities
{
    public class RefTools
    {
        #region Methods

        /// <summary>
        /// Set property value in object
        /// </summary>
        /// <param name="obj">Object, where is property</param>
        /// <param name="propName">Object property name</param>
        /// <param name="value">Object property new value</param>
        public void SetPropertyValue(object obj, string propName, object value)
        {
            try
            {
                // Gets a object type
                Type objectType = obj.GetType();
                // Get property name
                string propertyName = UppercaseFirst(propName);
                // Get property
                PropertyInfo propertyInfo = objectType.GetProperty(propertyName);
                //// Get property value              
                // Set value
                propertyInfo.SetValue(obj, value, null);
            }
            catch { }

        }

        /// <summary>
        /// Uppercase first symbol in string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        /// <summary>
        /// Get property value by name
        /// </summary>
        /// <param name="propName">Property name</param>
        /// <param name="obj">Object, where is property</param>
        /// <returns></returns>
        public object GetPropertyValue(string propName, object obj)
        {
            try
            {
                // Gets a object type
                Type objectType = obj.GetType();
                // Get property name
                string propertyName = UppercaseFirst(propName);
                // Get property
                PropertyInfo propertyInfo = objectType.GetProperty(propertyName);
                // Get property value
                var propValue = propertyInfo.GetValue(obj, null);
                return propValue;
            }
            catch 
            {
                return new object();
            }
        }

        /// <summary>
        /// Get property info by name
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public PropertyInfo GetPropertyInfoByName(string propName, object obj)
        {
            try
            {
                // Gets a object type
                Type objectType = obj.GetType();
                // Get property name
                string propertyName = UppercaseFirst(propName);
                // Get property
                PropertyInfo propertyInfo = objectType.GetProperty(propertyName);
                return propertyInfo;
            }
            catch
            {
                return null;
            }

        }

        #endregion

    }
}
