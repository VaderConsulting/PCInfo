Imports System
Imports System.Net.Sockets
Imports System.Threading
Imports System.IO
Imports System.Security.Cryptography

Module modReceiveAndDecrypt
    Sub Main()
        'The key and IV must be the same values that were used
        'to encrypt the stream.  
        Dim Key As Byte() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16}
        Dim IV As Byte() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16}

        Try
            'Initialize a TCPListener on port 11000
            'using the current IP address.
            Dim TCPListen As New TcpListener(11000)

            'Start the listener.
            TCPListen.Start()

            'Check for a connection every five seconds.
            While Not TCPListen.Pending()
                Console.WriteLine("Still listening. Will try in 5 seconds.")

                Thread.Sleep(5000)
            End While

            'Accept the client if one is found.
            Dim TCP As TcpClient = TCPListen.AcceptTcpClient()

            'Create a network stream from the connection.
            Dim NetStream As NetworkStream = TCP.GetStream()

            'Create a new instance of the RijndaelManaged class
            'and decrypt the stream.
            Dim RMCrypto As New RijndaelManaged

            'Create an instance of the CryptoStream class, pass it the NetworkStream, and decrypt 
            'it with the Rijndael class using the key and IV.
            Dim CryptStream As New CryptoStream(NetStream, RMCrypto.CreateDecryptor(Key, IV), CryptoStreamMode.Read)

            'Read the stream.
            Dim SReader As New StreamReader(CryptStream)

            'Display the message.
            Console.WriteLine("The decrypted original message: {0}", SReader.ReadToEnd())

            'Close the streams.
            SReader.Close()
            NetStream.Close()
            TCP.Close()
            'Catch any exceptions. 
        Catch
            Console.WriteLine("The Listener Failed.")
        End Try
    End Sub

End Module
