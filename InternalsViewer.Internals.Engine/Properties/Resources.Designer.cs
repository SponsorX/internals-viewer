﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InternalsViewer.Internals.Engine.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("InternalsViewer.Internals.Engine.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DBCC PAGE({0}, {1}, {2}, {3}) WITH TABLERESULTS.
        /// </summary>
        internal static string Sql_DatabasePageReader_Page {
            get {
                return ResourceManager.GetString("Sql_DatabasePageReader_Page", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT iau.allocation_unit_id               AS AllocationUnitId
        ///      ,o.object_id                          AS ObjectId
        ///	  ,iau.first_iam_page                   AS FirstIamPage
        ///      ,iau.root_page                        AS RootPage
        ///      ,iau.first_page                       AS FirstPage
        ///      ,s.name                               AS SchemaName
        ///	  ,o.name                               AS TableName
        ///      ,i.name                               AS IndexName
        ///	  ,is_ms_shipped                        AS I [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Sql_Metadata_AllocationUnits {
            get {
                return ResourceManager.GetString("Sql_Metadata_AllocationUnits", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT compatibility_level FROM sys.databases WHERE name = &apos;master&apos;.
        /// </summary>
        internal static string Sql_Metadata_CompatabilityLevel {
            get {
                return ResourceManager.GetString("Sql_Metadata_CompatabilityLevel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT d.database_id                       AS DatabaseId
        ///      ,df.database_id                      AS DatabaseId
        ///      ,d.name                              AS Name
        ///      ,d.compatibility_level               AS CompatabilityLevel
        ///      ,df.file_id                          AS FileId
        ///      ,df.type                             AS FileType
        ///      ,fg.name                             AS [FileGroup]
        ///      ,df.name                             AS [FilePath]
        ///      ,physical_name                       AS Physi [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Sql_Metadata_Database {
            get {
                return ResourceManager.GetString("Sql_Metadata_Database", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT size FROM sys.database_files WHERE file_id = @FileId.
        /// </summary>
        internal static string Sql_Metadata_FileSize {
            get {
                return ResourceManager.GetString("Sql_Metadata_FileSize", resourceCulture);
            }
        }
    }
}
