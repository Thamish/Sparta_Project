// Updated by XamlIntelliSenseFileGenerator 17/06/2020 17:02:01
#pragma checksum "..\..\..\PlayersPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B2EE1F14480170B66AD51E39596C17421E95C129"
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


namespace FootballManagerApp
{


    /// <summary>
    /// Players
    /// </summary>
    public partial class PlayersPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {


#line 15 "..\..\..\PlayersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Home;

#line default
#line hidden


#line 16 "..\..\..\PlayersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddPlayerButton;

#line default
#line hidden


#line 17 "..\..\..\PlayersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditPlayerButton;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FootballManagerApp;V1.0.0.0;component/playerspage.xaml", System.UriKind.Relative);

#line 1 "..\..\..\PlayersPage.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.Home = ((System.Windows.Controls.Button)(target));

#line 15 "..\..\..\PlayersPage.xaml"
                    this.Home.Click += new System.Windows.RoutedEventHandler(this.Home_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.AddPlayerButton = ((System.Windows.Controls.Button)(target));

#line 16 "..\..\..\PlayersPage.xaml"
                    this.AddPlayerButton.Click += new System.Windows.RoutedEventHandler(this.AddPlayerButton_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.EditPlayerButton = ((System.Windows.Controls.Button)(target));

#line 17 "..\..\..\PlayersPage.xaml"
                    this.EditPlayerButton.Click += new System.Windows.RoutedEventHandler(this.EditPlayerButton_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}
