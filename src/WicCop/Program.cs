//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace Microsoft.Test.Tools.WicCop
{
    internal static class Program
    {
        internal static bool NoWow { get; private set; }

        [STAThread]
        private static void Main(string[] args)
        {
            NoWow = args.Length > 0 && args[0] == "-nowow";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var form = new MainForm(false);
            Application.Run(form);
        }
    }
}
