Imports System.Management
Imports System.Runtime.InteropServices

Module modLogOnInfo
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Friend Structure USER_INFO_2
        Public name As String
        Public password As String
        Public password_age As Integer
        Public priv As Integer
        Public home_dir As String
        Public comment As String
        Public flags As Integer
        Public script_path As String
        Public auth_flags As Integer
        Public full_name As String
        Public usr_comment As String
        Public param As String
        Public workstations As String
        Public last_logon As Integer
        Public last_logoff As Integer
        Public acct_expires As Integer
        Public max_storage As Integer
        Public units_per_week As Integer
        Public logon_hours As Byte
        Public bad_pw_count As Integer
        Public num_logons As Integer
        Public logon_server As String
        Public country_code As Integer
        Public code_page As Integer
    End Structure

    Public Declare Function NetUserEnum Lib "Netapi32.dll" ( _
        <MarshalAs(UnmanagedType.LPWStr)> ByVal servername As String, _
        ByVal level As Integer, _
        ByVal filter As Integer, _
        ByRef bufptr As IntPtr, _
        ByVal prefmaxlen As Integer, _
        ByRef entriesread As Integer, _
        ByRef totalentries As Integer, _
        ByRef resume_handle As Integer) As Integer

    Public Declare Function NetApiBufferFree Lib "Netapi32.dll" (ByVal buffer As IntPtr) As Integer

    Public Class LocalUserLastLogOn
        Private _username As String
        Private _lastLoggedOn As DateTime

        Friend Sub New(ByVal ui As USER_INFO_2)
            _username = ui.name
            _lastLoggedOn = #1/1/1970#.AddSeconds(ui.last_logon)
        End Sub

        Public ReadOnly Property username() As String
            Get
                Return _username
            End Get
        End Property

        Public ReadOnly Property lastLoggedOn() As DateTime
            Get
                Return _lastLoggedOn
            End Get
        End Property
    End Class

    Public Function GetLocalUsersLastLogOn() As LocalUserLastLogOn()
        Dim users As New ArrayList

        Dim entriesRead, totalEntries, hResume As Integer
        Dim bufPtr As IntPtr

        NetUserEnum(Nothing, 2, 2, bufPtr, -1, entriesRead, totalEntries, hResume)
        If entriesRead > 0 Then
            Dim iter As IntPtr = bufPtr
            For i As Integer = 0 To entriesRead - 1
                users.Add(New LocalUserLastLogOn(Marshal.PtrToStructure(iter, GetType(USER_INFO_2))))
                iter = New IntPtr(iter.ToInt32 + Marshal.SizeOf(GetType(USER_INFO_2)))
            Next
        End If
        NetApiBufferFree(bufPtr)

        Return users.ToArray(GetType(LocalUserLastLogOn))
    End Function

    Public Function IsUserLoggedOn(ByVal userName As String) As Boolean
        Dim mc As New ManagementClass("Win32_Process")
        Dim moc As ManagementObjectCollection = mc.GetInstances
        Dim mo As ManagementObject
        For Each mo In moc
            Dim p As New ROOT.CIMV2.Process(mo)

            Dim processDomain, processUser As String
            p.GetOwner(processDomain, processUser)
            If processUser = userName Then
                Return True
            End If
        Next
    End Function
End Module



