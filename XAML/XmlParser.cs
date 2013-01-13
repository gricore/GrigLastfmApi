using System.Reflection;
using GrigCoreLastfm.XAML.Model;
using System;
using System.Xml;
using System.Threading.Tasks;
using System.Linq;

namespace GrigCoreLastfm.XAML
{
    public class XmlParser
    {
        #region Fields

        private readonly string _url;

        #endregion

        #region Methods

        /// <summary>
        /// Convert page to GXml data objects
        /// </summary>
        /// <returns></returns>
        public GXmlInner ConvertToInners()
        {
            var xmlDoc = GetDocument();

            return GetInners(xmlDoc.LastChild);
        }


        #endregion

        #region Utilities

        /// <summary>
        /// Get Inners
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <returns></returns>
        private GXmlInner GetInners(XmlNode xmlNode)
        {
            try
            {
                if (HasChildNodes(xmlNode))
                {
                    #region NonParallel
                    //foreach (XmlNode node in xmlNode.ChildNodes)
                    //{
                    //    fInner.Inners.Add(GetInners(node));

                    //}
                    #endregion

                    var fInner = PrepareWithChildInner(xmlNode);
                    var members = xmlNode.ChildNodes.OfType<XmlNode>();
                    Parallel.ForEach(members, node => fInner.Inners.Add(GetInners(node)));

                    return fInner;
                }
                else
                {
                    var fInner = PrepareWithChildInner(xmlNode);
                    fInner.InnerValue = xmlNode.InnerXml;
                    return fInner;
                }
            }
            catch (Exception)
            {
               return new GXmlInner();
            }
            


        }


        private GXmlInner PrepareWithChildInner(XmlNode node)
        {
            #region Non Parallel
            //if (node.Attributes != null)
            //    foreach (XmlAttribute attr in node.Attributes)
            //    {
            //        inner.Attrubutes.Add(new GXmlAttrubute { Key = attr.Name, Value = attr.Value });
            //    }
            #endregion

            try
            {
                var inner = new GXmlInner { Name = node.Name, Value = node.Value };
                // Parallel
                if (node.Attributes != null)
                {
                    var members = node.Attributes.OfType<XmlAttribute>();
                    Parallel.ForEach(members, attribute => inner.Attrubutes.Add(new GXmlAttrubute { Key = attribute.Name, Value = attribute.Value }));
                }
                return inner;
            }
            catch (Exception)
            {
                return new GXmlInner();
            }
        }

        /// <summary>
        /// Download XmlDocument from URL
        /// </summary>
        /// <returns></returns>
        private XmlDocument GetDocument()
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(_url);
                return doc;
            }
            catch
            {
                return new XmlDocument();
            }
        }

        /// <summary>
        /// Has child nodes
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool HasChildNodes(XmlNode node)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(node.FirstChild.InnerXml))
                {
                    return false;
                }

                return true;

                //if (node.HasChildNodes)
                //    return true;

                //return false;
            }
            catch (Exception)
            {
                return false;
            }
        }



        #endregion

        #region Ctor

        public XmlParser(string url)
        {
            _url = url;
        }

        #endregion
    }
}
