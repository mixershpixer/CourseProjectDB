﻿#pragma checksum "..\..\FlightItem.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A39FD6A58232D3E1FD7C36D7006D2CB1347FC19ACEA6CF4AE8446A25FF8BBEBB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MixerAirways;
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
    /// FlightItem
    /// </summary>
    public partial class FlightItem : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\FlightItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border background;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\FlightItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DepAirport;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\FlightItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DepCity;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\FlightItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DepTime;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\FlightItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ArrAirport;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\FlightItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ArrCity;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\FlightItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ArrTime;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\FlightItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Model;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\FlightItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ID;
        
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
            System.Uri resourceLocater = new System.Uri("/MixerAirways;component/flightitem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FlightItem.xaml"
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
            
            #line 8 "..\..\FlightItem.xaml"
            ((MixerAirways.FlightItem)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.UserControl_MouseUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 9 "..\..\FlightItem.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Grid_MouseEnter);
            
            #line default
            #line hidden
            
            #line 9 "..\..\FlightItem.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Grid_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.background = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.DepAirport = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.DepCity = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.DepTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.ArrAirport = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.ArrCity = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.ArrTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.Model = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.ID = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

