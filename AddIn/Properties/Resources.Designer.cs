﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1434
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InternalsViewer.SSMSAddIn.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("InternalsViewer.SSMSAddIn.Properties.Resources", typeof(Resources).Assembly);
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
        
        internal static System.Drawing.Bitmap AllocationMap {
            get {
                object obj = ResourceManager.GetObject("AllocationMap", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap allocationMapIcon {
            get {
                object obj = ResourceManager.GetObject("allocationMapIcon", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap allocationMapIconMask {
            get {
                object obj = ResourceManager.GetObject("allocationMapIconMask", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap AppWindow {
            get {
                object obj = ResourceManager.GetObject("AppWindow", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Address.
        /// </summary>
        internal static string Display_HexViewerAddress {
            get {
                return ResourceManager.GetString("Display_HexViewerAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data.
        /// </summary>
        internal static string Display_HexViewerData {
            get {
                return ResourceManager.GetString("Display_HexViewerData", resourceCulture);
            }
        }
        
        internal static System.Drawing.Bitmap pageImage {
            get {
                object obj = ResourceManager.GetObject("pageImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap TransactionLogIcon {
            get {
                object obj = ResourceManager.GetObject("TransactionLogIcon", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
