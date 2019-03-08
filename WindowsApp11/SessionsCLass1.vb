Public Class Session_Line
    Public line_content As String
    Public pract_type As String     ' col 1
    Public pract_time As String       ' col 2 (ignore col 3-4-5-6)
End Class


Public Class DogSession

    Public pract_Excel As New Microsoft.Office.Interop.Excel.Application
    Public start_day, end_day As String
    Public pet_name, pet_ID As String
    Public lines_read As New List(Of String)

    Public Sub Init_session()
        pet_name = pract_Excel.Cells(2, 1).text.Substring(10)
        pet_ID = pract_Excel.Cells(2, 2).text.substring(8)
        start_day = pract_Excel.Cells(1, 1).text.Replace("From:", "").Replace(" ", "")
        end_day = pract_Excel.Cells(1, 2).text.Replace("To:", "").Replace(" ", "")
    End Sub

    Public Sub Read_Lines()
        Dim tLine As String
        Dim tCnt = 4
        Dim prev_time_stamp As String = ""

        Dim prev_line As New Session_Line
        tLine = pract_Excel.Cells(tCnt, 1).text
        While (tLine <> "")
            ' lines that are not needed
            If tLine = "Position" Then
                Continue While
            End If
            If tLine = "Fever Indication" Then
                Continue While
            End If
            If (pract_Excel.Cells(tCnt, 6) = "" And pract_Excel.Cells(tCnt, 7) = "" And
                pract_Excel.Cells(tCnt, 8) = "" And pract_Excel.Cells(tCnt, 9) = "") Then
                Continue While
            End If
            ' at this point we keep the line
            ' TBD analyze if line has same time as previous time, 
            ' to add the data to same timestamp
            Dim new_line As New Session_Line
            new_line.pract_type = pract_Excel.Cells(tCnt, 1)
            new_line.pract_time = pract_Excel.Cells(tCnt, 2)
            If (new_line.pract_time = prev_line.pract_time) Then
                ' we are at same time stamp, so need to get practice and add it to prev line


                Continue While
            End If
            ' here a new time stamp 
            ' add pract to new time, make current line as previous, and loop 

            prev_line = new_line
        End While

    End Sub


    Public Sub Open_Session_file(_fname As String)
        pract_Excel.Workbooks.Open(_fname)
    End Sub






    Public Sub Close_Excel()
        pract_Excel.Workbooks.Close()
        '  pract_Excel = Nothing
    End Sub

End Class ' of class DogSession

Public Class SessionsClass

End Class
