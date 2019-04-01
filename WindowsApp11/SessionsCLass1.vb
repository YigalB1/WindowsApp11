Public Class Session_Line
    Public line_content As String
    Public pract_type As String     ' col 1
    Public pract_time As String       ' col 2 (ignore col 3-4-5-6)
End Class


Public Class DogSession
    ' the class handles the CSV file being read

    Public pract_Excel As New Microsoft.Office.Interop.Excel.Application
    Public start_day, end_day As Date
    Public pet_name, pet_ID As String
    Public lines_read As New List(Of String)

    Public Sub Init_session()
        ' TBD - moving parts to read CSV procedure
        pet_name = pract_Excel.Cells(2, 1).text.Substring(10)
        pet_ID = pract_Excel.Cells(2, 2).text.substring(8)

        Dim s1 As String = pract_Excel.Cells(1, 1).text.Replace("From:", "").Replace(" ", "")

        '      Try
        '  d1 = CDate(s1)
        Dim x1 As String = s1.Substring(0, 2)
        Dim x2 As String = s1.Substring(3, 2)
        Dim x3 As String = x2 + "/" + x1 + "/" + s1.Substring(6, 4)
        Dim d3 As Date = CDate(x3)

        '      Catch ex As Exception
        '      MessageBox.Show(ex.Message)
        '      End Try

        start_day = d3

        s1 = pract_Excel.Cells(1, 2).text.Replace("To:", "").Replace(" ", "")
        x1 = s1.Substring(0, 2)
        x2 = s1.Substring(3, 2)
        x3 = x2 + "/" + x1 + "/" + s1.Substring(6, 4)
        d3 = CDate(x3)
        end_day = d3


    End Sub

    Public Sub IsLine_Pre_Act_Post(x_dat_time As Date)

        Dim x As Integer = 1

    End Sub




    Public Sub Read_Lines()

        Dim tLine As String
        Dim tdate As Date
        Dim tCnt As Integer = 4
        Dim LineCnt As Integer = 4
        Dim prev_time_stamp As String = ""
        Dim lineDate As Date
        'Dim lineTime As Date

        Try
            tLine = pract_Excel.Cells(tCnt, 1).Text
            While (tLine <> "")
                tdate = pract_Excel.Cells(tCnt, 2).value
                lineDate = get_date(tdate)
                'lineTime = get_time(tdate)
                tCnt += 1
                tLine = pract_Excel.Cells(tCnt, 1).Text
                '        Console.WriteLine(lineDate.ToString() + "  " + lineTime.ToString())
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Exit Sub


        Dim prev_line As New Session_Line
        tLine = pract_Excel.Cells(tCnt, 1).Text
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

    Function get_date(_inline As Date) As Date
        ' TBD current content just for start

        If IsDate(_inline) Then
            Return _inline.Date()
        Else
            Console.WriteLine("Error with date: " + _inline.ToString())
        End If
        Return _inline ' in case of error only
    End Function

    'Function get_time(_inline As Date) As Date
    '    ' TBD current content just for start

    '    If IsDate(_inline) Then
    '        Return _inline.time()
    '    Else
    '        Return Date.Now()
    '    End If
    'End Function



    Public Sub Open_Session_file(_fname As String)
            pract_Excel.Workbooks.Open(_fname) ' TBD - not needed, file opened at CDV routine
        End Sub

        Public Sub Close_Excel()
            pract_Excel.Workbooks.Close()
            '  pract_Excel = Nothing
        End Sub

    End Class ' of class DogSession

'Public Class SessionsClass
'
'End Class
'