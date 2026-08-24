Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Net.Sockets

Module modEncryptAndSend
    Sub Main()
        'Dim TDES As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        'TDES.GenerateIV()
        'TDES.GenerateKey()

        Try
            'Create a TCP connection to a listening TCP process.
            'Use "localhost" to specify the current computer or
            'replace "localhost" with the IP address of the 
            'listening process. 
            Dim TCP As New TcpClient("localhost", 11000)

            'Create a network stream from the TCP connection. 
            Dim NetStream As NetworkStream = TCP.GetStream()

            'Create a new instance of the RijndaelManaged class
            'and encrypt the stream.
            Dim RMCrypto As New RijndaelManaged

            Dim Key As Byte() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16}
            Dim IV As Byte() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16}

            'Create a CryptoStream, pass it the NetworkStream, and encrypt 
            'it with the Rijndael class.
            Dim CryptStream As New CryptoStream(NetStream, RMCrypto.CreateEncryptor(Key, IV), CryptoStreamMode.Write)

            'Create a StreamWriter for easy writing to the 
            'network stream.
            Dim SWriter As New StreamWriter(CryptStream)

            'Write to the stream.
            SWriter.WriteLine("Hello World!")

            'Inform the user that the message was written
            'to the stream.
            Console.WriteLine("The message was sent.")

            'Close all the connections.
            SWriter.Close()
            CryptStream.Close()
            NetStream.Close()
            TCP.Close()
        Catch
            'Inform the user that an exception was raised.
            Console.WriteLine("The connection failed.")
        End Try
    End Sub
End Module
