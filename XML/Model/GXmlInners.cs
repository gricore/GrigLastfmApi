using System;
using System.Collections.Generic;

namespace GrigCoreLastfm.XML.Model
{
    public class GXmlInners : List<GXmlInner>, ICloneable
    {
        /// <summary>
        /// Clone object
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var collection = new GXmlInners();
            collection.AddRange(this);
            return collection;
        }

        public void Add(GXmlInners inners)
        {
            this.AddRange(inners);
        }
    }
}
