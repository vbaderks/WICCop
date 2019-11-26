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
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

using Microsoft.Test.Tools.WicCop.InteropServices.ComTypes;
using Microsoft.Test.Tools.WicCop.Properties;

namespace Microsoft.Test.Tools.WicCop
{
    internal static class Extensions
    {
        public delegate uint GetStringMethod(uint cch, StringBuilder wz);

        private delegate void GetGuidMethod(out Guid guid);

        public static string GetString(GetStringMethod method)
        {
            uint size = method(0, null);
            if (size > 0)
            {
                var sb = new StringBuilder {
                    Length = (int)size
                };
                method(size, sb);

                return sb.ToString();
            }

            return string.Empty;
        }

        public static string ToString(this Delegate method, string format)
        {
            return method.Method.ToString(format);
        }

        public static string ToString(this MethodBase method, string format)
        {
            return method.ToString(format, "...");
        }

        public static string ToString(this Delegate method, string format, string parameters)
        {
            return method.Method.ToString(format, parameters);
        }

        public static string ToString(this MethodBase method, string format, string parameters)
        {
            string s = string.Format(CultureInfo.InvariantCulture, "{0}::{1}({2})", method.DeclaringType.Name, method.Name, parameters);

            return string.Format(CultureInfo.CurrentUICulture, format, s);
        }

        public static void ReleaseComObject(this object o)
        {
            if (o == null) return;
            if (o.GetType().IsArray) { foreach (object i in o as Array) i.ReleaseComObject(); }
            else Marshal.ReleaseComObject(o);
        }

        private static bool OrderedItemsEqual<T>(this T[] left, T[] right)
        {
            if (left == null)
            {
                return right == null;
            }

            if (right == null)
            {
                return false;
            }

            T[] l = left.Clone() as T[];
            T[] r = right.Clone() as T[];

            Array.Sort(l);
            Array.Sort(r);

            return l.ItemsEqual(r);
        }

        public static bool ItemsEqual<T>(this T[] left, T[] right)
        {
            if (left == null)
            {
                return right == null;
            }

            if (right == null)
            {
                return false;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            for (int i = 0; i < left.Length; i++)
            {
                if (!left[i].Equals(right[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static Guid GetGuid(GetGuidMethod method)
        {
            method(out var res);
            return res;
        }

        private static void Add(this List<DataEntry[]> list, Delegate method, object expected, object actual)
        {
            list.Add(new[] { new DataEntry(Resources.Method, method.ToString("{0}")), new DataEntry(Resources.Expected, expected), new DataEntry(Resources.Actual, actual) });
        }

        private static void Check(GetGuidMethod left, GetGuidMethod right, List<DataEntry[]> violations)
        {
            Guid l = GetGuid(left);
            Guid r = GetGuid(right);
            if (l != r)
            {
                violations.Add(left, l, r);
            }
        }

        private static void CheckCommaSeparated(GetStringMethod left, GetStringMethod right, List<DataEntry[]> violations)
        {
            var l = GetString(left);
            var r = GetString(right);

            if (!l.Split(',').OrderedItemsEqual(r.Split(',')))
            {
                violations.Add(left, l, r);
            }
        }

        private static void Check(GetStringMethod left, GetStringMethod right, List<DataEntry[]> violations)
        {
            var l = GetString(left);
            var r = GetString(right);
            if (l != r)
            {
                violations.Add(left, l, r);
            }
        }

        private static void Check<T>(Func<T> left, Func<T> right, List<DataEntry[]> violations)
        {
            T l = left();
            T r = right();
            if (!l.Equals(r))
            {
                violations.Add(left, l, r);
            }
        }

        public static DataEntry[][] CompareInfos(this IWICBitmapCodecInfo left, IWICBitmapCodecInfo right)
        {
            IWICComponentInfo l = left as IWICComponentInfo;

            var res = new List<DataEntry[]>(l.CompareInfos(right));

            Check<bool>(left.DoesSupportAnimation, right.DoesSupportAnimation, res);
            Check<bool>(left.DoesSupportChromakey, right.DoesSupportChromakey, res);
            Check<bool>(left.DoesSupportLossless, right.DoesSupportLossless, res);
            Check<bool>(left.DoesSupportMultiframe, right.DoesSupportMultiframe, res);
            Check(left.GetColorManagementVersion, right.GetColorManagementVersion, res);
            Check(left.GetContainerFormat, right.GetContainerFormat, res);
            Check(left.GetDeviceManufacturer, right.GetDeviceManufacturer, res);

            CheckCommaSeparated(left.GetDeviceModels, right.GetDeviceModels, res);
            CheckCommaSeparated(left.GetMimeTypes, right.GetMimeTypes, res);
            CheckCommaSeparated(left.GetFileExtensions, right.GetFileExtensions, res);

            return res.ToArray();
        }

        private static IEnumerable<DataEntry[]> CompareInfos(this IWICComponentInfo left, IWICComponentInfo right)
        {
            var res = new List<DataEntry[]>();

            Check(left.GetAuthor, right.GetAuthor, res);
            Check(left.GetCLSID, right.GetCLSID, res);
            Check(left.GetComponentType, right.GetComponentType, res);
            Check(left.GetFriendlyName, right.GetFriendlyName, res);
            Check(left.GetSigningStatus, right.GetSigningStatus, res);
            Check(left.GetSpecVersion, right.GetSpecVersion, res);
            Check(left.GetVendorGUID, right.GetVendorGUID, res);
            Check(left.GetVersion, right.GetVersion, res);

            return res.ToArray();
        }
    }
}
