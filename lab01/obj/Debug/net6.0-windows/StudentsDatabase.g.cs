﻿#pragma checksum "..\..\..\StudentsDatabase.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A67CE1C5EEDA67EB78DED4DDE3A9B7B759FCDEB0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Lab01_OP;
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


namespace Lab01_OP {
    
    
    /// <summary>
    /// StudentsDatabase
    /// </summary>
    public partial class StudentsDatabase : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\StudentsDatabase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Lab01_OP.StudentsDatabase StudentsDatabaseWindow;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\StudentsDatabase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IDBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\StudentsDatabase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SNP_Box;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\StudentsDatabase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Number_Box;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\StudentsDatabase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\StudentsDatabase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\StudentsDatabase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MainMenuButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MultiProgram;component/studentsdatabase.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\StudentsDatabase.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.StudentsDatabaseWindow = ((Lab01_OP.StudentsDatabase)(target));
            return;
            case 2:
            this.IDBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.SNP_Box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Number_Box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\StudentsDatabase.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.Adding);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RemoveButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\StudentsDatabase.xaml"
            this.RemoveButton.Click += new System.Windows.RoutedEventHandler(this.Removing);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MainMenuButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\StudentsDatabase.xaml"
            this.MainMenuButton.Click += new System.Windows.RoutedEventHandler(this.MainMenuButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

