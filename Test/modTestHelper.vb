Module modHelper

#Region " Friends "

    Friend mbStopService As Boolean = True
    Friend mbIsClient As Boolean = True
    Friend mbIsCollectionPoint As Boolean = False
    Friend mbIsDatabaseFeeder As Boolean = False
    Friend mstrUsernames() As System.Collections.Specialized.StringCollection
    Friend mstrIPAddresses() As System.Collections.Specialized.StringCollection
    Friend mstrComputername As String
    Friend mstrADSitename As String

#End Region

#Region " Helper Functions "

    Friend Sub GetConfig()
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader

        mbIsClient = CType(configurationAppSettings.GetValue("IsClient", GetType(System.Boolean)), Boolean)
        mbIsCollectionPoint = CType(configurationAppSettings.GetValue("IsCollectionPoint", GetType(System.Boolean)), Boolean)
        mbIsDatabaseFeeder = CType(configurationAppSettings.GetValue("IsDatabaseFeeder", GetType(System.Boolean)), Boolean)
    End Sub

    Friend Sub DoWork()
        If mbIsClient Then
            GetPCInfo()
        End If

        If mbIsCollectionPoint Then
            CollectAndSendFiles()
        End If

        If mbIsDatabaseFeeder Then
            RetrieveFilesAndWriteDataToDatabase()
        End If
    End Sub

    Private Sub GetPCInfo()
        If mbStopService Then Exit Sub

        GetUsernames()
        GetIPAddresses()
        GetComputername()
        GetADSitename()

    End Sub

    Private Sub GetUsernames()
        If mbStopService Then Exit Sub

    End Sub

    Private Sub GetIPAddresses()
        If mbStopService Then Exit Sub
    End Sub

    Private Sub GetComputername()
        If mbStopService Then Exit Sub
    End Sub

    Private Sub GetADSitename()
        If mbStopService Then Exit Sub
    End Sub

    Private Sub CollectAndSendFiles()
        If mbStopService Then Exit Sub
    End Sub

    Private Sub RetrieveFilesAndWriteDataToDatabase()
        If mbStopService Then Exit Sub
    End Sub

#End Region

End Module

