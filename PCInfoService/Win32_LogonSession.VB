Imports System
Imports System.ComponentModel
Imports System.Management
Imports System.Collections
Imports System.Globalization
Imports System.ComponentModel.Design.Serialization
Imports System.Reflection

Namespace ROOT.CIMV2
    
    'Functions ShouldSerialize<PropertyName> are functions used by VS property browser to check if a particular property has to be serialized. These functions are added for all ValueType properties ( properties of type Int32, BOOL etc.. which cannot be set to null). These functions use Is<PropertyName>Null function. These functions are also used in the TypeConverter implementation for the properties to check for NULL value of property so that an empty value can be shown in Property browser in case of Drag and Drop in Visual studio.
    'Functions Is<PropertyName>Null() are used to check if a property is NULL.
    'Functions Reset<PropertyName> are added for Nullable Read/Write properties. These functions are used by VS designer in property browser to set a property to NULL.
    'Every property added to the class for WMI property has attributes set to define its behavior in Visual Studio designer and also to define a TypeConverter to be used.
    'Datetime conversion functions ToDateTime and ToDmtfDateTime are added to the class to convert DMTF datetime to System.DateTime and vice-versa.
    'An Early Bound class generated for the WMI class.Win32_LogonSession
    Public Class LogonSession
        Inherits System.ComponentModel.Component
        
        'Private property to hold the WMI namespace in which the class resides.
        Private Shared CreatedWmiNamespace As String = "ROOT\CIMV2"
        
        'Private property to hold the name of WMI class which created this class.
        Private Shared CreatedClassName As String = "Win32_LogonSession"
        
        'Private member variable to hold the ManagementScope which is used by the various methods.
        Private Shared statMgmtScope As System.Management.ManagementScope = Nothing
        
        Private PrivateSystemProperties As ManagementSystemProperties
        
        'Underlying lateBound WMI object.
        Private PrivateLateBoundObject As System.Management.ManagementObject
        
        'Member variable to store the 'automatic commit' behavior for the class.
        Private AutoCommitProp As Boolean = true
        
        'Private variable to hold the embedded property representing the instance.
        Private embeddedObj As System.Management.ManagementBaseObject
        
        'The current WMI object used
        Private curObj As System.Management.ManagementBaseObject
        
        'Flag to indicate if the instance is an embedded object.
        Private isEmbedded As Boolean = false
        
        'Below are different overloads of constructors to initialize an instance of the class with a WMI object.
        Public Sub New()
            Me.New(CType(Nothing,System.Management.ManagementScope), CType(Nothing,System.Management.ManagementPath), CType(Nothing,System.Management.ObjectGetOptions))
        End Sub
        
        Public Sub New(ByVal keyLogonId As String)
            Me.New(CType(Nothing,System.Management.ManagementScope), CType(New System.Management.ManagementPath(LogonSession.ConstructPath(keyLogonId)),System.Management.ManagementPath), CType(Nothing,System.Management.ObjectGetOptions))
        End Sub
        
        Public Sub New(ByVal mgmtScope As System.Management.ManagementScope, ByVal keyLogonId As String)
            Me.New(CType(mgmtScope,System.Management.ManagementScope), CType(New System.Management.ManagementPath(LogonSession.ConstructPath(keyLogonId)),System.Management.ManagementPath), CType(Nothing,System.Management.ObjectGetOptions))
        End Sub
        
        Public Sub New(ByVal path As System.Management.ManagementPath, ByVal getOptions As System.Management.ObjectGetOptions)
            Me.New(CType(Nothing,System.Management.ManagementScope), CType(path,System.Management.ManagementPath), CType(getOptions,System.Management.ObjectGetOptions))
        End Sub
        
        Public Sub New(ByVal mgmtScope As System.Management.ManagementScope, ByVal path As System.Management.ManagementPath)
            Me.New(CType(mgmtScope,System.Management.ManagementScope), CType(path,System.Management.ManagementPath), CType(Nothing,System.Management.ObjectGetOptions))
        End Sub
        
        Public Sub New(ByVal path As System.Management.ManagementPath)
            Me.New(CType(Nothing,System.Management.ManagementScope), CType(path,System.Management.ManagementPath), CType(Nothing,System.Management.ObjectGetOptions))
        End Sub
        
        Public Sub New(ByVal mgmtScope As System.Management.ManagementScope, ByVal path As System.Management.ManagementPath, ByVal getOptions As System.Management.ObjectGetOptions)
            MyBase.New
            If (Not (path) Is Nothing) Then
                If (CheckIfProperClass(mgmtScope, path, getOptions) <> true) Then
                    Throw New System.ArgumentException("Class name does not match.")
                End If
            End If
            PrivateLateBoundObject = New System.Management.ManagementObject(mgmtScope, path, getOptions)
            PrivateSystemProperties = New ManagementSystemProperties(PrivateLateBoundObject)
            curObj = PrivateLateBoundObject
        End Sub
        
        Public Sub New(ByVal theObject As System.Management.ManagementObject)
            MyBase.New
            If (CheckIfProperClass(theObject) = true) Then
                PrivateLateBoundObject = theObject
                PrivateSystemProperties = New ManagementSystemProperties(PrivateLateBoundObject)
                curObj = PrivateLateBoundObject
            Else
                Throw New System.ArgumentException("Class name does not match.")
            End If
        End Sub
        
        Public Sub New(ByVal theObject As System.Management.ManagementBaseObject)
            MyBase.New
            If (CheckIfProperClass(theObject) = true) Then
                embeddedObj = theObject
                PrivateSystemProperties = New ManagementSystemProperties(theObject)
                curObj = embeddedObj
                isEmbedded = true
            Else
                Throw New System.ArgumentException("Class name does not match.")
            End If
        End Sub
        
        'Property returns the namespace of the WMI class.
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
        Public ReadOnly Property OriginatingNamespace As String
            Get
                Return "ROOT\CIMV2"
            End Get
        End Property
        
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
        Public ReadOnly Property ManagementClassName As String
            Get
                Dim strRet As String = CreatedClassName
                If (Not (curObj) Is Nothing) Then
                    If (Not (curObj.ClassPath) Is Nothing) Then
                        strRet = CType(curObj("__CLASS"),String)
                        If ((strRet Is Nothing)  _
                                    OrElse (strRet Is System.String.Empty)) Then
                            strRet = CreatedClassName
                        End If
                    End If
                End If
                Return strRet
            End Get
        End Property
        
        'Property pointing to an embedded object to get System properties of the WMI object.
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
        Public ReadOnly Property SystemProperties As ManagementSystemProperties
            Get
                Return PrivateSystemProperties
            End Get
        End Property
        
        'Property returning the underlying lateBound object.
        <Browsable(false),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
        Public ReadOnly Property LateBoundObject As System.Management.ManagementBaseObject
            Get
                Return curObj
            End Get
        End Property
        
        'ManagementScope of the object.
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
        Public Property Scope As System.Management.ManagementScope
            Get
                If (isEmbedded = false) Then
                    Return PrivateLateBoundObject.Scope
                Else
                    Return Nothing
                End If
            End Get
            Set
                If (isEmbedded = false) Then
                    PrivateLateBoundObject.Scope = value
                End If
            End Set
        End Property
        
        'Property to show the commit behavior for the WMI object. If true, WMI object will be automatically saved after each property modification.(ie. Put() is called after modification of a property).
        <Browsable(false),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
        Public Property AutoCommit As Boolean
            Get
                Return AutoCommitProp
            End Get
            Set
                AutoCommitProp = value
            End Set
        End Property
        
        'The ManagementPath of the underlying WMI object.
        <Browsable(true)>  _
        Public Property Path As System.Management.ManagementPath
            Get
                If (isEmbedded = false) Then
                    Return PrivateLateBoundObject.Path
                Else
                    Return Nothing
                End If
            End Get
            Set
                If (isEmbedded = false) Then
                    If (CheckIfProperClass(Nothing, value, Nothing) <> true) Then
                        Throw New System.ArgumentException("Class name does not match.")
                    End If
                    PrivateLateBoundObject.Path = value
                End If
            End Set
        End Property
        
        'Public static scope property which is used by the various methods.
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
        Public Shared Property StaticScope As System.Management.ManagementScope
            Get
                Return statMgmtScope
            End Get
            Set
                statMgmtScope = value
            End Set
        End Property
        
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),  _
         Description("The AuthenticationPackage is the name of the subsystem used to authenticate the l"& _ 
"ogon session. ")>  _
        Public ReadOnly Property AuthenticationPackage As String
            Get
                Return CType(curObj("AuthenticationPackage"),String)
            End Get
        End Property
        
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),  _
         Description("The Caption property is a short textual description (one-line string) of the obje"& _ 
"ct.")>  _
        Public ReadOnly Property Caption As String
            Get
                Return CType(curObj("Caption"),String)
            End Get
        End Property
        
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),  _
         Description("The Description property provides a textual description of the object. ")>  _
        Public ReadOnly Property Description As String
            Get
                Return CType(curObj("Description"),String)
            End Get
        End Property
        
        <Browsable(false),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
        Public ReadOnly Property IsInstallDateNull As Boolean
            Get
                If (curObj("InstallDate") Is Nothing) Then
                    Return true
                Else
                    Return false
                End If
            End Get
        End Property
        
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),  _
         Description("The InstallDate property is datetime value indicating when the object was install"& _ 
"ed. A lack of a value does not indicate that the object is not installed."),  _
         TypeConverter(GetType(WMIValueTypeConverter))>  _
        Public ReadOnly Property InstallDate As Date
            Get
                If (Not (curObj("InstallDate")) Is Nothing) Then
                    Return ToDateTime(CType(curObj("InstallDate"),String))
                Else
                    Return System.DateTime.MinValue
                End If
            End Get
        End Property
        
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),  _
         Description("The LogonId is the ID assigned to the logon session. The application that initiat"& _ 
"ed the session should have called AllocateLocallyUniqueId in order to generate t"& _ 
"his ID. ")>  _
        Public ReadOnly Property LogonId As String
            Get
                Return CType(curObj("LogonId"),String)
            End Get
        End Property
        
        <Browsable(false),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
        Public ReadOnly Property IsLogonTypeNull As Boolean
            Get
                If (curObj("LogonType") Is Nothing) Then
                    Return true
                Else
                    Return false
                End If
            End Get
        End Property
        
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),  _
         Description("The LogonType is a numeric value indicating what type of logon session this is. "&Microsoft.VisualBasic.ChrW(10)& _ 
"System - Interactive - This logon type is intended for users who will be interac"& _ 
"tively using the machine, such as a user being logged on by a terminal server, r"& _ 
"emote shell, or similar process. "&Microsoft.VisualBasic.ChrW(10)&"Network - This logon type is intended for high"& _ 
" performance servers to authenticate clear text passwords. LogonUser does not ca"& _ 
"che credentials for this logon type. "&Microsoft.VisualBasic.ChrW(10)&"Batch - This logon type is intended for ba"& _ 
"tch servers, where processes may be executing on behalf of a user without their "& _ 
"direct intervention; or for higher performance servers that process many clear-t"& _ 
"ext authentication attempts at a time, such as mail or web servers. LogonUser do"& _ 
"es not cache credentials for this logon type."&Microsoft.VisualBasic.ChrW(10)&"Service - Indicates a service-type"& _ 
" logon. The account provided must have the service privilege enabled."&Microsoft.VisualBasic.ChrW(10)&"Proxy - Pr"& _ 
"oxy logon. This logon type is not supported."&Microsoft.VisualBasic.ChrW(10)&"Unlock - This logon type is intende"& _ 
"d for GINA DLLs logging on users who will be interactively using the machine. Th"& _ 
"is logon type allows a unique audit record to be generated that shows when the w"& _ 
"orkstation was unlocked. "&Microsoft.VisualBasic.ChrW(10)&"Network Cleartext - Windows 2000: This logon type pres"& _ 
"erves the name and password in the authentication packages, allowing the server "& _ 
"to make connections to other network servers while impersonating the client. Thi"& _ 
"s allows a server to accept clear text credentials from a client, call LogonUser"& _ 
", verify that the user can access the system across the network, and still commu"& _ 
"nicate with other servers. "&Microsoft.VisualBasic.ChrW(10)&"New Credentials - Windows 2000: This logon type allo"& _ 
"ws the caller to clone its current token and specify new credentials for outboun"& _ 
"d connections. The new logon session has the same local identify, but uses diffe"& _ 
"rent credentials for other network connections. "&Microsoft.VisualBasic.ChrW(10)),  _
         TypeConverter(GetType(WMIValueTypeConverter))>  _
        Public ReadOnly Property LogonType As LogonTypeValues
            Get
                If (curObj("LogonType") Is Nothing) Then
                    Return CType(System.Convert.ToInt64(0),LogonTypeValues)
                End If
                Return CType(Convert.ToInt64(curObj("LogonType")),LogonTypeValues)
            End Get
        End Property
        
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),  _
         Description("The Name property defines the label by which the object is known. When subclassed"& _ 
", the Name property can be overridden to be a Key property.")>  _
        Public ReadOnly Property Name As String
            Get
                Return CType(curObj("Name"),String)
            End Get
        End Property
        
        <Browsable(false),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
        Public ReadOnly Property IsStartTimeNull As Boolean
            Get
                If (curObj("StartTime") Is Nothing) Then
                    Return true
                Else
                    Return false
                End If
            End Get
        End Property
        
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),  _
         Description("The StartTime property represents the time at which the session started."),  _
         TypeConverter(GetType(WMIValueTypeConverter))>  _
        Public ReadOnly Property StartTime As Date
            Get
                If (Not (curObj("StartTime")) Is Nothing) Then
                    Return ToDateTime(CType(curObj("StartTime"),String))
                Else
                    Return System.DateTime.MinValue
                End If
            End Get
        End Property
        
        <Browsable(true),  _
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),  _
         Description("The Status property is a string indicating the current status of the object. Vari"& _ 
"ous operational and non-operational statuses can be defined. Operational statuse"& _ 
"s are ""OK"", ""Degraded"" and ""Pred Fail"". ""Pred Fail"" indicates that an element ma"& _ 
"y be functioning properly but predicting a failure in the near future. An exampl"& _ 
"e is a SMART-enabled hard drive. Non-operational statuses can also be specified."& _ 
" These are ""Error"", ""Starting"", ""Stopping"" and ""Service"". The latter, ""Service"","& _ 
" could apply during mirror-resilvering of a disk, reload of a user permissions l"& _ 
"ist, or other administrative work. Not all such work is on-line, yet the managed"& _ 
" element is neither ""OK"" nor in one of the other states.")>  _
        Public ReadOnly Property Status As String
            Get
                Return CType(curObj("Status"),String)
            End Get
        End Property
        
        Private Overloads Function CheckIfProperClass(ByVal mgmtScope As System.Management.ManagementScope, ByVal path As System.Management.ManagementPath, ByVal OptionsParam As System.Management.ObjectGetOptions) As Boolean
            If ((Not (path) Is Nothing)  _
                        AndAlso (System.String.Compare(path.ClassName, ManagementClassName, true, CultureInfo.InvariantCulture) = 0)) Then
                Return true
            Else
                Return CheckIfProperClass(New System.Management.ManagementObject(mgmtScope, path, OptionsParam))
            End If
        End Function
        
        Private Overloads Function CheckIfProperClass(ByVal theObj As System.Management.ManagementBaseObject) As Boolean
            If ((Not (theObj) Is Nothing)  _
                        AndAlso (System.String.Compare(CType(theObj("__CLASS"),String), ManagementClassName, true, CultureInfo.InvariantCulture) = 0)) Then
                Return true
            Else
                Dim parentClasses As System.Array = CType(theObj("__DERIVATION"),System.Array)
                If (Not (parentClasses) Is Nothing) Then
                    Dim count As Int32 = 0
                    count = 0
                    Do While (count < parentClasses.Length)
                        If (System.String.Compare(CType(parentClasses.GetValue(count),String), ManagementClassName, true, CultureInfo.InvariantCulture) = 0) Then
                            Return true
                        End If
                        count = (count + 1)
                    Loop
                End If
            End If
            Return false
        End Function
        
        'Converts a given datetime in DMTF format to System.DateTime object.
        Shared Function ToDateTime(ByVal dmtfDate As String) As Date
            Dim year As Integer = System.DateTime.MinValue.Year
            Dim month As Integer = System.DateTime.MinValue.Month
            Dim day As Integer = System.DateTime.MinValue.Day
            Dim hour As Integer = System.DateTime.MinValue.Hour
            Dim minute As Integer = System.DateTime.MinValue.Minute
            Dim second As Integer = System.DateTime.MinValue.Second
            Dim ticks As Long = 0
            Dim dmtf As String = dmtfDate
            Dim datetime As Date = System.DateTime.MinValue
            Dim tempString As String = System.String.Empty
            If (dmtf Is Nothing) Then
                Throw New System.ArgumentOutOfRangeException
            End If
            If (dmtf.Length = 0) Then
                Throw New System.ArgumentOutOfRangeException
            End If
            If (dmtf.Length <> 25) Then
                Throw New System.ArgumentOutOfRangeException
            End If
            Try 
                tempString = dmtf.Substring(0, 4)
                If ("****" <> tempString) Then
                    year = System.Int32.Parse(tempString)
                End If
                tempString = dmtf.Substring(4, 2)
                If ("**" <> tempString) Then
                    month = System.Int32.Parse(tempString)
                End If
                tempString = dmtf.Substring(6, 2)
                If ("**" <> tempString) Then
                    day = System.Int32.Parse(tempString)
                End If
                tempString = dmtf.Substring(8, 2)
                If ("**" <> tempString) Then
                    hour = System.Int32.Parse(tempString)
                End If
                tempString = dmtf.Substring(10, 2)
                If ("**" <> tempString) Then
                    minute = System.Int32.Parse(tempString)
                End If
                tempString = dmtf.Substring(12, 2)
                If ("**" <> tempString) Then
                    second = System.Int32.Parse(tempString)
                End If
                tempString = dmtf.Substring(15, 6)
                If ("******" <> tempString) Then
                    ticks = (System.Int64.Parse(tempString)  _
                                * (System.TimeSpan.TicksPerMillisecond / 1000))
                End If
                If ((((((((year < 0)  _
                            OrElse (month < 0))  _
                            OrElse (day < 0))  _
                            OrElse (hour < 0))  _
                            OrElse (minute < 0))  _
                            OrElse (minute < 0))  _
                            OrElse (second < 0))  _
                            OrElse (ticks < 0)) Then
                    Throw New System.ArgumentOutOfRangeException
                End If
            Catch e As System.Exception
                e = e
                Throw New System.ArgumentOutOfRangeException
            End Try
            datetime = New Date(year, month, day, hour, minute, second, 0)
            datetime = datetime.AddTicks(ticks)
            Dim tickOffset As System.TimeSpan = System.TimeZone.CurrentTimeZone.GetUtcOffset(datetime)
            Dim UTCOffset As Integer = 0
            Dim OffsetToBeAdjusted As Long = 0
            Dim OffsetMins As Long = (tickOffset.Ticks / System.TimeSpan.TicksPerMinute)
            tempString = dmtf.Substring(22, 3)
            If (tempString <> "***") Then
                tempString = dmtf.Substring(21, 4)
                Try 
                    UTCOffset = System.Int32.Parse(tempString)
                Catch e As System.Exception
                    e = e
                    Throw New System.ArgumentOutOfRangeException
                End Try
                OffsetToBeAdjusted = (OffsetMins - UTCOffset)
                datetime = datetime.AddMinutes(OffsetToBeAdjusted)
            End If
            Return datetime
        End Function
        
        'Converts a given System.DateTime object to DMTF datetime format.
        Shared Function ToDmtfDateTime(ByVal [date] As Date) As String
            Dim utcString As String = System.String.Empty
            Dim tickOffset As System.TimeSpan = System.TimeZone.CurrentTimeZone.GetUtcOffset([date])
            Dim OffsetMins As Long = (tickOffset.Ticks / System.TimeSpan.TicksPerMinute)
            If (System.Math.Abs(OffsetMins) > 999) Then
                [date] = [date].ToUniversalTime
                utcString = "+000"
            Else
                If (tickOffset.Ticks >= 0) Then
                    utcString = ("+" + (tickOffset.Ticks / System.TimeSpan.TicksPerMinute).ToString.PadLeft(3, Microsoft.VisualBasic.ChrW(48)))
                Else
                    Dim strTemp As String = OffsetMins.ToString
                    utcString = ("-" + strTemp.Substring(1, (strTemp.Length - 1)).PadLeft(3, Microsoft.VisualBasic.ChrW(48)))
                End If
            End If
            Dim dmtfDateTime As String = [date].Year.ToString.PadLeft(4, Microsoft.VisualBasic.ChrW(48))
            dmtfDateTime = (dmtfDateTime + [date].Month.ToString.PadLeft(2, Microsoft.VisualBasic.ChrW(48)))
            dmtfDateTime = (dmtfDateTime + [date].Day.ToString.PadLeft(2, Microsoft.VisualBasic.ChrW(48)))
            dmtfDateTime = (dmtfDateTime + [date].Hour.ToString.PadLeft(2, Microsoft.VisualBasic.ChrW(48)))
            dmtfDateTime = (dmtfDateTime + [date].Minute.ToString.PadLeft(2, Microsoft.VisualBasic.ChrW(48)))
            dmtfDateTime = (dmtfDateTime + [date].Second.ToString.PadLeft(2, Microsoft.VisualBasic.ChrW(48)))
            dmtfDateTime = (dmtfDateTime + ".")
            Dim dtTemp As Date = New Date([date].Year, [date].Month, [date].Day, [date].Hour, [date].Minute, [date].Second, 0)
            Dim microsec As Long = ((([date].Ticks - dtTemp.Ticks)  _
                        * 1000)  _
                        / System.TimeSpan.TicksPerMillisecond)
            Dim strMicrosec As String = microsec.ToString
            If (strMicrosec.Length > 6) Then
                strMicrosec = strMicrosec.Substring(0, 6)
            End If
            dmtfDateTime = (dmtfDateTime + strMicrosec.PadLeft(6, Microsoft.VisualBasic.ChrW(48)))
            dmtfDateTime = (dmtfDateTime + utcString)
            Return dmtfDateTime
        End Function
        
        Private Function ShouldSerializeInstallDate() As Boolean
            If (IsInstallDateNull = false) Then
                Return true
            End If
            Return false
        End Function
        
        Private Function ShouldSerializeLogonType() As Boolean
            If (IsLogonTypeNull = false) Then
                Return true
            End If
            Return false
        End Function
        
        Private Function ShouldSerializeStartTime() As Boolean
            If (IsStartTimeNull = false) Then
                Return true
            End If
            Return false
        End Function
        
        <Browsable(true)>  _
        Public Sub CommitObject()
            If (isEmbedded = false) Then
                PrivateLateBoundObject.Put
            End If
        End Sub
        
        Private Shared Function ConstructPath(ByVal keyLogonId As String) As String
            Dim strPath As String = "ROOT\CIMV2:Win32_LogonSession"
            strPath = (strPath  _
                        + (".LogonId="  _
                        + (""""  _
                        + (keyLogonId + """"))))
            Return strPath
        End Function
        
        'Different overloads of GetInstances() help in enumerating instances of the WMI class.
        Public Overloads Shared Function GetInstances() As LogonSessionCollection
            Return GetInstances(CType(Nothing,System.Management.ManagementScope), CType(Nothing,System.Management.EnumerationOptions))
        End Function
        
        Public Overloads Shared Function GetInstances(ByVal condition As String) As LogonSessionCollection
            Return GetInstances(Nothing, condition, Nothing)
        End Function
        
        Public Overloads Shared Function GetInstances(ByVal selectedProperties() As System.String ) As LogonSessionCollection
            Return GetInstances(Nothing, Nothing, selectedProperties)
        End Function
        
        Public Overloads Shared Function GetInstances(ByVal condition As String, ByVal selectedProperties() As System.String ) As LogonSessionCollection
            Return GetInstances(Nothing, condition, selectedProperties)
        End Function
        
        Public Overloads Shared Function GetInstances(ByVal mgmtScope As System.Management.ManagementScope, ByVal enumOptions As System.Management.EnumerationOptions) As LogonSessionCollection
            If (mgmtScope Is Nothing) Then
                If (statMgmtScope Is Nothing) Then
                    mgmtScope = New System.Management.ManagementScope
                    mgmtScope.Path.NamespacePath = "root\CIMV2"
                Else
                    mgmtScope = statMgmtScope
                End If
            End If
            Dim pathObj As System.Management.ManagementPath = New System.Management.ManagementPath
            pathObj.ClassName = "Win32_LogonSession"
            pathObj.NamespacePath = "root\CIMV2"
            Dim clsObject As System.Management.ManagementClass = New System.Management.ManagementClass(mgmtScope, pathObj, Nothing)
            If (enumOptions Is Nothing) Then
                enumOptions = New System.Management.EnumerationOptions
                enumOptions.EnsureLocatable = true
            End If
            Return New LogonSessionCollection(clsObject.GetInstances(enumOptions))
        End Function
        
        Public Overloads Shared Function GetInstances(ByVal mgmtScope As System.Management.ManagementScope, ByVal condition As String) As LogonSessionCollection
            Return GetInstances(mgmtScope, condition, Nothing)
        End Function
        
        Public Overloads Shared Function GetInstances(ByVal mgmtScope As System.Management.ManagementScope, ByVal selectedProperties() As System.String ) As LogonSessionCollection
            Return GetInstances(mgmtScope, Nothing, selectedProperties)
        End Function
        
        Public Overloads Shared Function GetInstances(ByVal mgmtScope As System.Management.ManagementScope, ByVal condition As String, ByVal selectedProperties() As System.String ) As LogonSessionCollection
            If (mgmtScope Is Nothing) Then
                If (statMgmtScope Is Nothing) Then
                    mgmtScope = New System.Management.ManagementScope
                    mgmtScope.Path.NamespacePath = "root\CIMV2"
                Else
                    mgmtScope = statMgmtScope
                End If
            End If
            Dim ObjectSearcher As System.Management.ManagementObjectSearcher = New System.Management.ManagementObjectSearcher(mgmtScope, New SelectQuery("Win32_LogonSession", condition, selectedProperties))
            Dim enumOptions As System.Management.EnumerationOptions = New System.Management.EnumerationOptions
            enumOptions.EnsureLocatable = true
            ObjectSearcher.Options = enumOptions
            Return New LogonSessionCollection(ObjectSearcher.Get)
        End Function
        
        <Browsable(true)>  _
        Public Shared Function CreateInstance() As LogonSession
            Dim mgmtScope As System.Management.ManagementScope = Nothing
            If (statMgmtScope Is Nothing) Then
                mgmtScope = New System.Management.ManagementScope
                mgmtScope.Path.NamespacePath = CreatedWmiNamespace
            Else
                mgmtScope = statMgmtScope
            End If
            Dim mgmtPath As System.Management.ManagementPath = New System.Management.ManagementPath(CreatedClassName)
            Return New LogonSession(New System.Management.ManagementClass(mgmtScope, mgmtPath, Nothing).CreateInstance)
        End Function
        
        <Browsable(true)>  _
        Public Sub Delete()
            PrivateLateBoundObject.Delete
        End Sub
        
        Public Enum LogonTypeValues As Long
            
            Interactive = 2
            
            Network = 3
            
            Batch = 4
            
            Service = 5
            
            Unlock = 7
            
            NetworkCleartext = 8
            
            NewCredentials = 9
            
            INVALID_ENUM_VALUE = 0
        End Enum
        
        'Enumerator implementation for enumerating instances of the class.
        Public Class LogonSessionCollection
            Inherits Object
            Implements ICollection
            
            Private ObjectCollection As ManagementObjectCollection
            
            Public Sub New(ByVal objCollection As ManagementObjectCollection)
                MyBase.New
                ObjectCollection = objCollection
            End Sub
            
            Public ReadOnly Property Count As Integer Implements System.Collections.ICollection.Count
                Get
                    Return ObjectCollection.Count
                End Get
            End Property
            
            Public ReadOnly Property IsSynchronized As Boolean Implements System.Collections.ICollection.IsSynchronized
                Get
                    Return ObjectCollection.IsSynchronized
                End Get
            End Property
            
            Public ReadOnly Property SyncRoot As Object Implements System.Collections.ICollection.SyncRoot
                Get
                    Return Me
                End Get
            End Property
            
            Public Sub CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
                ObjectCollection.CopyTo(array, index)
                Dim nCtr As Integer
                nCtr = 0
                Do While (nCtr < array.Length)
                    array.SetValue(New LogonSession(CType(array.GetValue(nCtr),System.Management.ManagementObject)), nCtr)
                    nCtr = (nCtr + 1)
                Loop
            End Sub
            
            Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
                Return New LogonSessionEnumerator(ObjectCollection.GetEnumerator)
            End Function
            
            Public Class LogonSessionEnumerator
                Inherits Object
                Implements System.Collections.IEnumerator
                
                Private ObjectEnumerator As ManagementObjectCollection.ManagementObjectEnumerator
                
                Public Sub New(ByVal objEnum As ManagementObjectCollection.ManagementObjectEnumerator)
                    MyBase.New
                    ObjectEnumerator = objEnum
                End Sub
                
                Public ReadOnly Property Current As Object Implements System.Collections.IEnumerator.Current
                    Get
                        Return New LogonSession(CType(ObjectEnumerator.Current,System.Management.ManagementObject))
                    End Get
                End Property
                
                Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                    Return ObjectEnumerator.MoveNext
                End Function
                
                Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                    ObjectEnumerator.Reset
                End Sub
            End Class
        End Class
        
        'TypeConverter to handle null values for ValueType properties
        Public Class WMIValueTypeConverter
            Inherits TypeConverter
            
            Private baseConverter As TypeConverter
            
            Public Sub New(ByVal baseType As System.Type)
                MyBase.New
                baseConverter = TypeDescriptor.GetConverter(baseType)
            End Sub
            
            Public Overloads Overrides Function CanConvertFrom(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal srcType As System.Type) As Boolean
                Return baseConverter.CanConvertFrom(context, srcType)
            End Function
            
            Public Overloads Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
                Return baseConverter.CanConvertTo(context, destinationType)
            End Function
            
            Public Overloads Overrides Function ConvertFrom(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object) As Object
                Return baseConverter.ConvertFrom(context, culture, value)
            End Function
            
            Public Overloads Overrides Function CreateInstance(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal dictionary As System.Collections.IDictionary) As Object
                Return baseConverter.CreateInstance(context, dictionary)
            End Function
            
            Public Overloads Overrides Function GetCreateInstanceSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
                Return baseConverter.GetCreateInstanceSupported(context)
            End Function
            
            Public Overloads Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributeVar() As System.Attribute) As PropertyDescriptorCollection
                Return baseConverter.GetProperties(context, value, attributeVar)
            End Function
            
            Public Overloads Overrides Function GetPropertiesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
                Return baseConverter.GetPropertiesSupported(context)
            End Function
            
            Public Overloads Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
                Return baseConverter.GetStandardValues(context)
            End Function
            
            Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
                Return baseConverter.GetStandardValuesExclusive(context)
            End Function
            
            Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
                Return baseConverter.GetStandardValuesSupported(context)
            End Function
            
            Public Overloads Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
                If (Not (context) Is Nothing) Then
                    If (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) = false) Then
                        Return ""
                    End If
                End If
                Return baseConverter.ConvertTo(context, culture, value, destinationType)
            End Function
        End Class
        
        'Embedded class to represent WMI system Properties.
        <TypeConverter(GetType(System.ComponentModel.ExpandableObjectConverter))>  _
        Public Class ManagementSystemProperties
            
            Private PrivateLateBoundObject As System.Management.ManagementBaseObject
            
            Public Sub New(ByVal ManagedObject As System.Management.ManagementBaseObject)
                MyBase.New
                PrivateLateBoundObject = ManagedObject
            End Sub
            
            <Browsable(true)>  _
            Public ReadOnly Property GENUS As Integer
                Get
                    Return CType(PrivateLateBoundObject("__GENUS"),Integer)
                End Get
            End Property
            
            <Browsable(true)>  _
            Public ReadOnly Property [CLASS] As String
                Get
                    Return CType(PrivateLateBoundObject("__CLASS"),String)
                End Get
            End Property
            
            <Browsable(true)>  _
            Public ReadOnly Property SUPERCLASS As String
                Get
                    Return CType(PrivateLateBoundObject("__SUPERCLASS"),String)
                End Get
            End Property
            
            <Browsable(true)>  _
            Public ReadOnly Property DYNASTY As String
                Get
                    Return CType(PrivateLateBoundObject("__DYNASTY"),String)
                End Get
            End Property
            
            <Browsable(true)>  _
            Public ReadOnly Property RELPATH As String
                Get
                    Return CType(PrivateLateBoundObject("__RELPATH"),String)
                End Get
            End Property
            
            <Browsable(true)>  _
            Public ReadOnly Property PROPERTY_COUNT As Integer
                Get
                    Return CType(PrivateLateBoundObject("__PROPERTY_COUNT"),Integer)
                End Get
            End Property
            
            <Browsable(true)>  _
            Public ReadOnly Property DERIVATION As String()
                Get
                    Return CType(PrivateLateBoundObject("__DERIVATION"),String())
                End Get
            End Property
            
            <Browsable(true)>  _
            Public ReadOnly Property SERVER As String
                Get
                    Return CType(PrivateLateBoundObject("__SERVER"),String)
                End Get
            End Property
            
            <Browsable(true)>  _
            Public ReadOnly Property [NAMESPACE] As String
                Get
                    Return CType(PrivateLateBoundObject("__NAMESPACE"),String)
                End Get
            End Property
            
            <Browsable(true)>  _
            Public ReadOnly Property PATH As String
                Get
                    Return CType(PrivateLateBoundObject("__PATH"),String)
                End Get
            End Property
        End Class
    End Class
End Namespace
