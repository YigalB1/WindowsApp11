Public Class Session_Line
    ' each possible sessio has 3 parameters
    Public line_content As String
    Public pract_type As String     ' col 1
    Public pract_time As String       ' col 2 (ignore col 3-4-5-6)
End Class


Public Class DogSession
    ' the class handles the CSV file being read

    Public pract_Excel As New Microsoft.Office.Interop.Excel.Application
    Public start_day, end_day As Date
    Public pet_name, pet_ID As String
    Public lines_read As New List(Of String) ' TBD: to check if needed
    Public reuired_date As Date ' the date of the required practice from practice list
    ' perhaps required date is not needed if required start and end include date
    Public required_session_start_time As Date ' the start of the required practice from practice list
    Public required_session_end_time As Date ' the end of the required practice from practice list
    Public required_start_pre_time As Date ' the required start time before the session
    Public required_end_post_time As Date ' the required end time after the session

    Public Sub Init_session()
        ' called after starting reading the CSV file
        ' getting the pet's name, ID, start day of the practice 
        ' (and end day as well - not sure if needed)

        pet_name = pract_Excel.Cells(2, 1).text.Substring(10)  ' from CSV file
        pet_ID = pract_Excel.Cells(2, 2).text.substring(8)

        Dim s1 As String = pract_Excel.Cells(1, 1).text.Replace("From:", "").Replace(" ", "")


        Dim x1 As String = s1.Substring(0, 2)
        Dim x2 As String = s1.Substring(3, 2)
        Dim x3 As String = x2 + "/" + x1 + "/" + s1.Substring(6, 4)
        start_day = CDate(x3)

        s1 = pract_Excel.Cells(1, 2).text.Replace("To:", "").Replace(" ", "")
        x1 = s1.Substring(0, 2)
        x2 = s1.Substring(3, 2)
        x3 = x2 + "/" + x1 + "/" + s1.Substring(6, 4)
        end_day = CDate(x3)
        ' end_day = d3


        ' get the session specific date and time
        ' to be used later for the CSV parsing

        'reuired_session_start_time =
        '    reuired_session_end_time =
        '    reuired_start_pre_time =
        '    reuired_end_post_time =




    End Sub

    Public Sub IsLine_Pre_Act_Post(x_dat_time As Date)

        Dim x As Integer = 1

    End Sub

    Public Sub Read_Lines()

        Dim tLine As String = "BLABLA" ' dummy, just to start the loop
        Dim tdate As Date
        Dim tCnt As Integer = 3 ' should be 4, but incremented at loop start
        Dim LineCnt As Integer = 4
        Dim prev_time_stamp As String = ""
        'Dim lineDate As Date
        'Dim lineTime As Date
        Dim tState As Integer
        Dim x As Integer = 0
        Dim y As Integer = 0

        Try



            While (tLine <> "")
                tCnt += 1
                tLine = pract_Excel.Cells(tCnt, 1).Text
                tdate = pract_Excel.Cells(tCnt, 2).value ' date and timeof practice
                '               lineDate = get_date(tdate)
                '               lineTime = get_time(tdate)

                ' check if line is in boundaries
                tState = In_Time_Boundaries(tdate)
                If tState = -1 Then
                    Continue While    ' time is before PRE or after POST, skip to next line
                End If

                ' At this stage we have only lines at PRE/ACT/POST stages


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
            Dim x As Integer = 1
            Return _inline.Date()
        Else
            Console.WriteLine("Error with date: " + _inline.ToString())
            Dim y As Integer = 2
        End If
        Return _inline.Date()  ' PLACE HOLDER 
    End Function

    Function get_time(_inline As Date) As Date
        ' TBD current content just for start

        If IsDate(_inline) Then
            Return _inline
        Else
            Return Date.Now()
        End If
    End Function


    Public Sub Set_required_times(_start As Date, _end As Date, _prepost As Integer)

        '  Dim start = start_day.Add(_start)

        Dim tStart As DateTime = New DateTime(
  start_day.Year, start_day.Month, start_day.Day,
  _start.Hour, _start.Minute, _start.Second)

        Dim tEnd As DateTime = New DateTime(
  start_day.Year, start_day.Month, start_day.Day,
  _end.Hour, _end.Minute, _end.Second)

        Dim tPreStart = tStart.AddMinutes(-_prepost)
        Dim tPostEnd = tEnd.AddMinutes(_prepost)

        required_session_start_time = tStart
        required_session_end_time = tEnd
        required_start_pre_time = tPreStart
        required_end_post_time = tPostEnd




    End Sub


    Private Function In_Time_Boundaries(_tdate) As Integer
        ' returns: -1 for out of scale
        '           0 if in PRE  stage
        '           1 if in ACT  stage
        '           2 if in POST stage

        Dim in_time As Integer = -1

        If _tdate > required_start_pre_time And _tdate < required_end_post_time Then
            ' in the time boundaries
            If _tdate < required_session_start_time Then
                ' in PRE state
                Return (0)
                Exit Function
            End If

            If _tdate < required_session_end_time Then
                ' in ACT state
                Return (1)
                Exit Function
            End If

            If _tdate < required_end_post_time Then
                ' in POST state
                Return (2)
                Exit Function
            End If
        End If

        Return in_time
    End Function




    Public Sub Open_Session_file(_fname As String)
            pract_Excel.Workbooks.Open(_fname)
        End Sub

        Public Sub Close_Excel()
            pract_Excel.Workbooks.Close()
            '  pract_Excel = Nothing
        End Sub

    End Class ' of class DogSession

