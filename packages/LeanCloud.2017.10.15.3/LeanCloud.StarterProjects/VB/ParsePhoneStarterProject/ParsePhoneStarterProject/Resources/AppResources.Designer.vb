﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.17626
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System


'This class was auto-generated by the StronglyTypedResourceBuilder
'class via a tool like ResGen or Visual Studio.
'To add or remove a member, edit your .ResX file then rerun ResGen
'with the /str option, or rebuild your VS project.
'''<summary>
'''  A strongly-typed resource class, for looking up localized strings, etc.
'''</summary>
<Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), _
 Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
 Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()> _
Public Class AppResources

    Private Shared resourceMan As Global.System.Resources.ResourceManager

    Private Shared resourceCulture As Global.System.Globalization.CultureInfo

    <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")> _
    Friend Sub New()
        MyBase.New
    End Sub

    '''<summary>
    '''  Returns the cached ResourceManager instance used by this class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Public Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
        Get
            If Object.ReferenceEquals(resourceMan, Nothing) Then
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("ParsePhoneStarterProject.AppResources", GetType(AppResources).Assembly)
                resourceMan = temp
            End If
            Return resourceMan
        End Get
    End Property

    '''<summary>
    '''  Overrides the current thread's CurrentUICulture property for all
    '''  resource lookups using this strongly typed resource class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Public Shared Property Culture() As Global.System.Globalization.CultureInfo
        Get
            Return resourceCulture
        End Get
        Set
            resourceCulture = value
        End Set
    End Property

    '''<summary>
    '''  Looks up a localized string similar to LeftToRight.
    '''</summary>
    Public Shared ReadOnly Property ResourceFlowDirection() As String
        Get
            Return ResourceManager.GetString("ResourceFlowDirection", resourceCulture)
        End Get
    End Property

    '''<summary>
    '''  Looks up a localized string similar to us-EN.
    '''</summary>
    Public Shared ReadOnly Property ResourceLanguage() As String
        Get
            Return ResourceManager.GetString("ResourceLanguage", resourceCulture)
        End Get
    End Property

    '''<summary>
    '''  Looks up a localized string similar to MY APPLICATION.
    '''</summary>
    Public Shared ReadOnly Property ApplicationTitle() As String
        Get
            Return ResourceManager.GetString("ApplicationTitle", resourceCulture)
        End Get
    End Property

    '''<summary>
    '''  Looks up a localized string similar to button.
    '''</summary>
    Public Shared ReadOnly Property AppBarButtonText() As String
        Get
            Return ResourceManager.GetString("AppBarButtonText", resourceCulture)
        End Get
    End Property

    '''<summary>
    '''  Looks up a localized string similar to Menu Item.
    '''</summary>
    Public Shared ReadOnly Property AppBarMenuItemText() As String
        Get
            Return ResourceManager.GetString("AppBarMenuItemText", resourceCulture)
        End Get
    End Property
End Class