﻿#pragma checksum "..\..\..\..\GUI\Pages\InsertAdmin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0A3CA42050871CCAFEE34235CDAD48BC4A43BCC76F21FAF32CC1864AD0473358"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using ProjetNotrePetiteCuisine.GUI.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ProjetNotrePetiteCuisine.GUI.Pages {
    
    
    /// <summary>
    /// InsertAdmin
    /// </summary>
    public partial class InsertAdmin : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\GUI\Pages\InsertAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HomeButton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\GUI\Pages\InsertAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UsernameTextBox;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\GUI\Pages\InsertAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PrenomTextBox;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\GUI\Pages\InsertAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NomTextBox;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\GUI\Pages\InsertAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MailTextBox;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\GUI\Pages\InsertAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumtelTextBox;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\GUI\Pages\InsertAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox ChoosePasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\GUI\Pages\InsertAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox ConfirmPasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\GUI\Pages\InsertAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddAdmin;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjetNotrePetiteCuisine;component/gui/pages/insertadmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\GUI\Pages\InsertAdmin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.HomeButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\GUI\Pages\InsertAdmin.xaml"
            this.HomeButton.Click += new System.Windows.RoutedEventHandler(this.HomeButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UsernameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PrenomTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.NomTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.MailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.NumtelTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ChoosePasswordTextBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.ConfirmPasswordTextBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.AddAdmin = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\..\..\GUI\Pages\InsertAdmin.xaml"
            this.AddAdmin.Click += new System.Windows.RoutedEventHandler(this.AddAdmin_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

