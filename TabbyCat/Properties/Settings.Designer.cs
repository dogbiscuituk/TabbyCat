﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TabbyCat.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.5.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("VS2015Blue")]
        public global::TabbyCat.Types.Theme Options_Theme {
            get {
                return ((global::TabbyCat.Types.Theme)(this["Options_Theme"]));
            }
            set {
                this["Options_Theme"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("TabbyCat Files (*.tcxf)|*.tcxf|TabbyCat Templates (*.tcxt)|*.tcxt|All Files (*.*)" +
            "|*.*")]
        public string FileFilter {
            get {
                return ((string)(this["FileFilter"]));
            }
            set {
                this["FileFilter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Images (*.bmp;*.gif;*.jpeg;*.jpg;*.png)|*.bmp;*.gif;*.jpeg;*.jpg;*.png|All files " +
            "(*.*)|*.*")]
        public string ImageFilter {
            get {
                return ((string)(this["ImageFilter"]));
            }
            set {
                this["ImageFilter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string FilesFolderPath {
            get {
                return ((string)(this["FilesFolderPath"]));
            }
            set {
                this["FilesFolderPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string TemplatesFolderPath {
            get {
                return ((string)(this["TemplatesFolderPath"]));
            }
            set {
                this["TemplatesFolderPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool Options_OpenInNewWindow {
            get {
                return ((bool)(this["Options_OpenInNewWindow"]));
            }
            set {
                this["Options_OpenInNewWindow"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Hue, Saturation")]
        public string KnownColorSortOrder {
            get {
                return ((string)(this["KnownColorSortOrder"]));
            }
            set {
                this["KnownColorSortOrder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::TabbyCat.Types.TextStyleInfos SyntaxHighlightStyles {
            get {
                return ((global::TabbyCat.Types.TextStyleInfos)(this["SyntaxHighlightStyles"]));
            }
            set {
                this["SyntaxHighlightStyles"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://www.khronos.org/registry/OpenGL/specs/gl/GLSLangSpec.4.60.html")]
        public string GLSLUrl {
            get {
                return ((string)(this["GLSLUrl"]));
            }
            set {
                this["GLSLUrl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("330|400|410|420|430|440|450|460")]
        public string GLSLVersions {
            get {
                return ((string)(this["GLSLVersions"]));
            }
            set {
                this["GLSLVersions"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0|1|2|4|8|16")]
        public string SampleCounts {
            get {
                return ((string)(this["SampleCounts"]));
            }
            set {
                this["SampleCounts"] = value;
            }
        }
    }
}
