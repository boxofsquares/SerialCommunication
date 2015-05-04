Module Module1
    Public fileStream As StreamWriter = New IO.StreamWriter("serialFile.txt", True)
    Public Sub Main()
        Dim myPort As SerialPort = New SerialPort("COM1", 4800)


        AddHandler myPort.DataReceived, AddressOf DataReceivedHandler


        myPort.Open()
        Console.WriteLine("Port opened.")
        Console.ReadLine()
        Console.WriteLine("User stopppppp.")
        Console.ReadLine()

        fileStream.Write(vbNewLine)
        fileStream.Close()

    End Sub

    Private Sub DataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)
        Dim port1 As SerialPort = CType(sender, SerialPort)
        Dim indata As String = port1.ReadExisting
        If Asc(indata) = 13 Then
            Console.Write(vbNewLine)
            fileStream.Write(vbNewLine)
        End If
        Console.Write(indata)
        fileStream.Write(indata)

    End Sub
End Module
