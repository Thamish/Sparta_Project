﻿#pragma checksum "..\..\..\RemovePlayer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05690A19C17EE22B6D2450E697A41321B8AF9152"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FootballManagerApp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FootballManagerApp {
    
    
    /// <summary>
    /// RemovePlayer
    /// </summary>
    public partial class RemovePlayer : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\RemovePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Home;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\RemovePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleText;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\RemovePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PlayersListBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\RemovePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemovePlayerButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\RemovePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstNamefilter;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\RemovePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Positionfilter;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\RemovePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FilterTitle;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FootballManagerApp;component/removeplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RemovePlayer.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Home = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\RemovePlayer.xaml"
            this.Home.Click += new System.Windows.RoutedEventHandler(this.Home_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TitleText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PlayersListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.RemovePlayerButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\RemovePlayer.xaml"
            this.RemovePlayerButton.Click += new System.Windows.RoutedEventHandler(this.RemovePlayerButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FirstNamefilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\RemovePlayer.xaml"
            this.FirstNamefilter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Positionfilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\RemovePlayer.xaml"
            this.Positionfilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Positionfilter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FilterTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

