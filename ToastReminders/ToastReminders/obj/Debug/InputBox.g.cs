﻿#pragma checksum "..\..\InputBox.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D6404A58CC261E4DA5102D6399C9161B15FDEB34769478E14B69863874645CCC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using ToastReminders;


namespace ToastReminders {
    
    
    /// <summary>
    /// InputBox
    /// </summary>
    public partial class InputBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\InputBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ReminderTitle;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\InputBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddReminder;
        
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
            System.Uri resourceLocater = new System.Uri("/ToastReminders;component/inputbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\InputBox.xaml"
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
            this.ReminderTitle = ((System.Windows.Controls.TextBox)(target));
            
            #line 10 "..\..\InputBox.xaml"
            this.ReminderTitle.GotFocus += new System.Windows.RoutedEventHandler(this.TextGotFocus);
            
            #line default
            #line hidden
            
            #line 10 "..\..\InputBox.xaml"
            this.ReminderTitle.LostFocus += new System.Windows.RoutedEventHandler(this.TextLostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddReminder = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\InputBox.xaml"
            this.AddReminder.Click += new System.Windows.RoutedEventHandler(this.AddReminder_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

