﻿#pragma checksum "..\..\Registration.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AE0842045039221DF89B4164EEBA422F3BE82B6C"
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
using MaterialDesignThemes.Wpf.Transitions;
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


namespace MixerAirways {
    
    
    /// <summary>
    /// Registration
    /// </summary>
    public partial class Registration : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon RegMail;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RegMailTxt;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost Complite;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReadyBtn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost RegFail;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon RegUserName;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RegUserNameTxt;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon RegPassword;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox RegPasswordTxt;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegistrationButton;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackToLoginButton;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ProgressBar1;
        
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
            System.Uri resourceLocater = new System.Uri("/MixerAirways;component/registration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Registration.xaml"
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
            this.RegMail = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 2:
            this.RegMailTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\Registration.xaml"
            this.RegMailTxt.GotFocus += new System.Windows.RoutedEventHandler(this.RegMailTxt_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Complite = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 4:
            this.ReadyBtn = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\Registration.xaml"
            this.ReadyBtn.Click += new System.Windows.RoutedEventHandler(this.ReadyBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RegFail = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 6:
            this.RegUserName = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 7:
            this.RegUserNameTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\Registration.xaml"
            this.RegUserNameTxt.GotFocus += new System.Windows.RoutedEventHandler(this.RegUserNameTxt_GotFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RegPassword = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 9:
            this.RegPasswordTxt = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 48 "..\..\Registration.xaml"
            this.RegPasswordTxt.GotFocus += new System.Windows.RoutedEventHandler(this.RegPasswordTxt_GotFocus);
            
            #line default
            #line hidden
            return;
            case 10:
            this.RegistrationButton = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\Registration.xaml"
            this.RegistrationButton.Click += new System.Windows.RoutedEventHandler(this.RegistrationButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BackToLoginButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\Registration.xaml"
            this.BackToLoginButton.Click += new System.Windows.RoutedEventHandler(this.BackToLoginButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ProgressBar1 = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

