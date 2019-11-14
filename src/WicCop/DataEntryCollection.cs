//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;

using Microsoft.Test.Tools.WicCop.Rules;

namespace Microsoft.Test.Tools.WicCop
{
    [Serializable]
    [TypeConverter(typeof(DataEntryCollectionConverter))]
    public class DataEntryCollection : List<DataEntry>
    {
        public DataEntryCollection(RuleBase parent, params DataEntry[][] entries)
        {
            Parent = parent;

            foreach (DataEntry[] array in entries)
            {
                AddRange(array);
            }
        }

        public RuleBase Parent
        {
            get;
        }

        public void WriteTo(XmlWriter xw)
        {
            xw.WriteStartElement("Entries");
            foreach (DataEntry de in this)
            {
                de.WriteTo(xw);
            }
            xw.WriteEndElement();
        }
    }
}
