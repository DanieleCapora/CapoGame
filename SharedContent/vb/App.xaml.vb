'*********************************************************
'
' Copyright (c) Microsoft. All rights reserved.
' This code is licensed under the MIT License (MIT).
' THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
' ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
' IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
' PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
'
'*********************************************************
Imports System
Imports Windows.ApplicationModel
Imports Windows.ApplicationModel.Activation
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Navigation

Namespace Global.SDKTemplate

    ''' <summary>
    ''' Provides application-specific behavior to supplement the default Application class.
    ''' </summary>
    NotInheritable Partial Class App
        Inherits Application

        Public Sub New()
            Me.InitializeComponent()
            Me.Construct()
        End Sub

        ''' <summary>
        ''' Invoked when the application is launched normally by the end user.  Other entry points
        ''' will be used such as when the application is launched to open a specific file.
        ''' </summary>
        ''' <param name="e">Details about the launch request and process.</param>
        Protected Overrides Sub OnLaunched(e As LaunchActivatedEventArgs)
#If DEBUG Then
            If System.Diagnostics.Debugger.IsAttached Then
                Me.DebugSettings.EnableFrameRateCounter = False
            End If
#End If

            Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)
            If rootFrame Is Nothing Then
                rootFrame = New Frame()
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages(0)
                AddHandler rootFrame.NavigationFailed, AddressOf OnNavigationFailed
                If e.PreviousExecutionState = ApplicationExecutionState.Terminated Then
                End If

                Window.Current.Content = rootFrame
            End If

            If rootFrame.Content Is Nothing Then
                rootFrame.Navigate(GetType(MainPage), e.Arguments)
            End If

            Window.Current.Activate()
        End Sub

        Private Function CreateRootFrame() As Frame
            Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)
            If rootFrame Is Nothing Then
                rootFrame = New Frame()
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages(0)
                AddHandler rootFrame.NavigationFailed, AddressOf OnNavigationFailed
                Window.Current.Content = rootFrame
            End If

            Return rootFrame
        End Function

        ''' <summary>
        ''' Invoked when Navigation to a certain page fails
        ''' </summary>
        ''' <param name="sender">The Frame which failed navigation</param>
        ''' <param name="e">Details about the navigation failure</param>
        Sub OnNavigationFailed(sender As Object, e As NavigationFailedEventArgs)
            Throw New Exception("Failed to load Page " & e.SourcePageType.FullName)
        End Sub

        ' Add any application contructor code in here.
        Partial Private Sub Construct()
        End Sub
    End Class
End Namespace
