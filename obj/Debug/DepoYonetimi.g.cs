#pragma checksum "..\..\DepoYonetimi.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D82E618512CB11F2870FD48FBE0F84D2C6C03C1B2F5C6184667E05E0F8D3260B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DYSis;
using LiveCharts.Wpf;
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


namespace DYSis {
    
    
    /// <summary>
    /// DepoYonetimi
    /// </summary>
    public partial class DepoYonetimi : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\DepoYonetimi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\DepoYonetimi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DYButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\DepoYonetimi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EYButton;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\DepoYonetimi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DepoGirdiButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\DepoYonetimi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\DepoYonetimi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DepoGirdiButton_Copy;
        
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
            System.Uri resourceLocater = new System.Uri("/DYSis;component/depoyonetimi.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DepoYonetimi.xaml"
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
            this.AButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\DepoYonetimi.xaml"
            this.AButton.Click += new System.Windows.RoutedEventHandler(this.AButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DYButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\DepoYonetimi.xaml"
            this.DYButton.Click += new System.Windows.RoutedEventHandler(this.DYButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EYButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\DepoYonetimi.xaml"
            this.EYButton.Click += new System.Windows.RoutedEventHandler(this.EYButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DepoGirdiButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\DepoYonetimi.xaml"
            this.DepoGirdiButton.Click += new System.Windows.RoutedEventHandler(this.DepoGirdiButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dg = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.DepoGirdiButton_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\DepoYonetimi.xaml"
            this.DepoGirdiButton_Copy.Click += new System.Windows.RoutedEventHandler(this.DepoGirdiButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 41 "..\..\DepoYonetimi.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

