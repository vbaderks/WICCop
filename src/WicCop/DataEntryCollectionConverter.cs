//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------

using System;
using System.ComponentModel;

using Microsoft.Test.Tools.WicCop.Rules;

namespace Microsoft.Test.Tools.WicCop
{
    internal class DataEntryCollectionConverter : CollectionConverter
    {
        private class DataEntryPropertyDescriptor : SimplePropertyDescriptor
        {
            private readonly DataEntry entry;
            private readonly RuleBase rule;

            public DataEntryPropertyDescriptor(DataEntry entry, RuleBase rule)
                : base(typeof(DataEntryCollection), entry.Text, entry.Value == null ? typeof(object): entry.Value.GetType(), null)
            {
                this.entry = entry;
                this.rule = rule;
            }

            public override bool IsReadOnly => true;

            public override object GetValue(object component)
            {
                return entry.Value;
            }

            public override void SetValue(object component, object value)
            {
                throw new NotImplementedException();
            }

            public override string Category => rule.FullPath;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            var d = (DataEntryCollection) value;

            return new PropertyDescriptorCollection(Array.ConvertAll(d.ToArray(),
                input => new DataEntryPropertyDescriptor(input, d.Parent)), true);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
