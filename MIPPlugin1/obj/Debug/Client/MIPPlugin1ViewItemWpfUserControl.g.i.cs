﻿#pragma checksum "..\..\..\Client\MIPPlugin1ViewItemWpfUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EDE6CDF2DCD11A07ADDB8FC31B362DB5F98B121C3A929807C1B903D789ADED48"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MIPPlugin1.Client;
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
using VideoOS.Platform.Client;


namespace MIPPlugin1.Client {
    
    
    /// <summary>
    /// MIPPlugin1ViewItemWpfUserControl
    /// </summary>
    public partial class MIPPlugin1ViewItemWpfUserControl : VideoOS.Platform.Client.ViewItemWpfUserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Client\MIPPlugin1ViewItemWpfUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid _headerGrid;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Client\MIPPlugin1ViewItemWpfUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock _nameTextBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/MIPPlugin1;component/client/mipplugin1viewitemwpfusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Client\MIPPlugin1ViewItemWpfUserControl.xaml"
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
            
            #line 9 "..\..\..\Client\MIPPlugin1ViewItemWpfUserControl.xaml"
            ((MIPPlugin1.Client.MIPPlugin1ViewItemWpfUserControl)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ViewItemWpfUserControl_MouseDown);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\Client\MIPPlugin1ViewItemWpfUserControl.xaml"
            ((MIPPlugin1.Client.MIPPlugin1ViewItemWpfUserControl)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ViewItemWpfUserControl_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this._headerGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this._nameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

