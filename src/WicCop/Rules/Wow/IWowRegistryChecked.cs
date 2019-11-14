using System;
using System.Collections.Generic;

namespace Microsoft.Test.Tools.WicCop.Rules.Wow
{
    internal interface IWowRegistryChecked
    {
        IEnumerable<string> GetKeys();
    }
}
