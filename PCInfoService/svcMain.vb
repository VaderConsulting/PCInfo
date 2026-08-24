#Region " Imports "

Imports System.ServiceProcess

#End Region

Public Class svcMain
    Inherits System.ServiceProcess.ServiceBase

#Region " Locals "



#End Region

#Region " Properties "

#End Region

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        ' This call is required by the Component Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call

    End Sub

    'UserService overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' The main entry point for the process
    <MTAThread()> _
    Shared Sub Main()
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase

        ' More than one NT Service may run within the same process. To add
        ' another service to this process, change the following line to
        ' create a second service object. For example,
        '
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New svcMain}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    Friend WithEvents scMain As System.ServiceProcess.ServiceController
    Friend WithEvents tmrMain As System.Timers.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.scMain = New System.ServiceProcess.ServiceController
        Me.tmrMain = New System.Timers.Timer
        CType(Me.tmrMain, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'scMain
        '
        Me.scMain.ServiceName = "PCInfo"
        '
        'tmrMain
        '
        Me.tmrMain.Enabled = True
        Me.tmrMain.Interval = CType(configurationAppSettings.GetValue("tmrMain.Interval", GetType(System.Double)), Double)
        '
        'svcMain
        '
        Me.ServiceName = "PCInfo Service"
        CType(Me.tmrMain, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

#Region " Methods "

    Protected Overrides Sub OnStart(ByVal args() As String)
        StartService()
    End Sub

    Protected Overrides Sub OnStop()
        StopService()
    End Sub

#End Region

#Region " Private Subs "

    Private Sub StartService()
        mbStopService = False
    End Sub

    Private Sub StopService()
        mbStopService = True
    End Sub

    Private Sub tmrMain_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles tmrMain.Elapsed

        ' Disable timer prior to starting work
        tmrMain.Enabled = False

        If Not mbStopService Then

            GetConfig()
            DoWork()

        End If

        ' ReEnable timer now the work has completed
        tmrMain.Enabled = True

    End Sub

#End Region



End Class