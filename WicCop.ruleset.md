# Static analyzer notes

## .NET

CA1028: If possible, make the underlying type of WICBitmapEncoderCacheOption System.Int32 instead of uint.
=> Enable as soon as possible.

CA1031: Modify 'Start' to catch a more specific exception type, or rethrow the exception.
=> Enable as soon as possible.

CA1034: Do not nest type InstanceInfo. Alternatively, change its accessibility so that it is not externally visible.
=> Enable as soon as possible.

CA1036: EOL should define operator(s) '==, !=, <, <=, >, >=' and Equals since it implements IComparable.
=> Enable as soon as possible.

CA1051: // Do not declare visible instance fields
=> Enable as soon as possible.

CA1052: // Type 'ConfigTool' is a static holder type but is neither static nor NotInheritable
=> Enable as soon as possible.

CA1054: Change the type of parameter URL of method X from string to System.Uri
=> Enable as soon as possible.

CA1055: // Change the return type of method TestContext.GetRawURL() from string to System.Uri.
=> Enable as soon as possible.

CA1056: Change the type of property HttpHost.URL from string to System.Uri.
=> Enable as soon as possible.

CA1062: // In externally visible method '', validate parameter 'task' is non-null before using it.
=> Enable as soon as possible.

CA1303 // Do not pass literals as localized parameters
=> All messages are in English, no need for localized parameters.

CA1304: The behavior of 'string.ToLower()' could vary based on the current user's locale settings.
=> All messages are in English, no need for localized parameters.

CA1305: // The behavior of 'string.Format(string, params object[])' could vary based on the current user's locale settings.
=> Enable as soon as possible.

CA1307: The behavior of 'string.EndsWith(string)' could vary based on the current user's locale settings.
=> Enable as soon as possible.

CA1707: Remove the underscores from member name.
=> Enable as soon as possible.

CA1712: Do not prefix enum values with the name of the enum type 'PROPBAG2_TYPE'.
=> Enable as soon as possible.

CA1714: Flags enums should have plural names
=> Enable as soon as possible.

CA1716 // Rename virtual/interface member xxx so that it no longer conflicts with the reserved language keyword 'Continue'. Using a reserved keyword as the name of a virtual/interface member makes it harder for consumers in other languages to override/implement the member.
=> A lot of warnings are caused by compatibility with VB.Net, which is not relevant for this projects.

CA1720: // Identifier 'obj' contains type name
=> Enable as soon as possible.

CA1724: // The type name TaskBase conflicts in whole or in part with the namespace name 'Rox.TaskBase'. Change either name to eliminate the conflict.
=> Enable as soon as possible.

CA1801: // Parameter ctx of method Set is never used. Remove the parameter or use it in the method body.
=> Enable as soon as possible.

CA1806: // ConvertPR calls CreatePRInstances but does not use the HRESULT or error code that the method returns
=> Enable as soon as possible.

CA1812: Cleaner is an internal class that is apparently never instantiated.
=> Enable as soon as possible.

CA1815: ReservedGuid should override Equals.
=> Enable as soon as possible.

CA1820: // Test for empty strings using 'string.Length' property or 'string.IsNullOrEmpty' method instead of an Equality check.
=> Enable as soon as possible.

CA1822: // Member GetConfig does not access instance data and can be marked as static (Shared in VisualBasic)
=> Enable as soon as possible.

CA1823: // Unused field 'hpconfig'.
=> Enable as soon as possible.

CA1824: Mark assemblies with NeutralResourcesLanguageAttribute
=> Enable as soon as possible.

CA2000: // Call System.IDisposable.Dispose on object.
=> Enable as soon as possible.

CA2100: Review if the query string passed to 'string OleDbCommand.CommandText' in 'Execute', accepts any user input.
=> Enable as soon as possible.

CA2101: // Specify marshaling for P/Invoke string arguments
=> Enable as soon as possible.

CA2211: // Non-constant fields should not be visible
=> Enable as soon as possible.

CA2214: Do not call overridable methods in constructors
=> Enable as soon as possible.

CA2234: Modify '' to call 'WebRequest.Create(Uri)' instead of 'WebRequest.Create(string)'.
=> Enable as soon as possible.

CA2235: Field Parent is a member of type DataEntryCollection which is serializable but is of type Microsoft.Test.Tools.WicCop.Rules.RuleBase which is not serializable
=> Enable as soon as possible.

CA2241: Provide correct arguments to formatting methods
=> Enable as soon as possible.

CA2153: catching corrupted state exception.
=> Enable as soon as possible.

CA3075: // Unsafe overload of 'LoadXml' method
=> Enable as soon as possible.

CA5392: // The method PutElementDoubleArray64 didn't use DefaultDllImportSearchPaths attribute for P/Invokes.
=> Enable as soon as possible.

CA5359: // The ServerCertificateValidationCallback is set to a function that accepts any server certificate, by always returning true.
=> Enable as soon as possible.
