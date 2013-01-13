using System;
using System.Collections.Generic;

namespace GrigCoreLastfm.XAML.Model
{
    public class GXmlAttrubutes : List<GXmlAttrubute>, ICloneable
    {
        public object Clone()
        {
            var collection = new GXmlAttrubutes();
            collection.AddRange(this);
            return collection;
        }
    }
}
