using System;
using System.Collections.Generic;
using System.Text;

namespace PrizeDraw.Data
{
    public class PropertyIsRepititive : Exception
    {
        public string PropertyName { set; get; }
        public string PropertyDisplayName { set; get; }

        public string ErrorMessage { get { return $"{PropertyDisplayName} وارد شده تکراری است"; } }
        public PropertyIsRepititive(string propertyNmae, string propertydisplayname)
        {
            this.PropertyDisplayName = propertydisplayname;
            this.PropertyName = propertyNmae;
        }
    }
}
