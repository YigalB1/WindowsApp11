Imports Microsoft.Office.Interop

Module Module1



    Public Function Read_CSV_file(_fname As String, _dog_age As Integer, _pract_type As String,
                                  _pract_num As Integer, _pract_date As Date, _activity_start As Date,
                                  _activity_end As Date, _pre_time As Integer,
                                  _post_time As Integer, ByRef _line_counter As Integer) As Session_CSV_file
        Dim CSV_Excel As New Microsoft.Office.Interop.Excel.Application
        Dim curr_session As New Session_CSV_file ' includes all data read from this excel

        curr_session.activity_start_time = _activity_start
        curr_session.activity_end_time = _activity_end
        curr_session.activity_pre_time = _pre_time
        curr_session.activity_post_time = _post_time

        Console.WriteLine("Start reading CSV file " + _fname)
        CSV_Excel.Workbooks.Open(_fname)    '** Open CSV file

        ' start reading data from the CSV file
        curr_session.pet_name = CSV_Excel.Cells(2, 1).text.Replace("Pet name: ", "").Replace(" ", "")
        curr_session.pet_ID = CSV_Excel.Cells(2, 2).text.Replace("Pet id: ", "").Replace(" ", "")
        curr_session.pet_age = _dog_age ' age at that session
        curr_session.practice_type = _pract_type
        curr_session.Practice_num = _pract_num

        Dim csv_start_date As DateTime
        Dim s1 As String = CSV_Excel.Cells(1, 1).text.Replace("From:", "").Replace(" ", "")
        Dim t_bool As Boolean = Date.TryParseExact(s1, "MM/dd/yyyy",
                               Globalization.CultureInfo.InvariantCulture,
                               Globalization.DateTimeStyles.None, csv_start_date)


        ' curr_session.session_start_time = csv_start_date ' 6 March 2020: use parameter inside because training can be on 2 days
        curr_session.session_start_time = _pract_date ' Oct 23, 2019
        If (t_bool = False) Then
            MessageBox.Show("Error E1 while checking CSV file date")
            Console.WriteLine("Error E1 while checking CSV file date")
        End If

        ' ** finished reading CSV header
        ' start reading data lines, line after line
        Dim line_Cnt As Integer = 3 ' first line to read is 4, incremented soon
        ' Dim total_line_cnt As Integer = 0 ' counts the total number of lines over all files
        Dim line_data_type As String
        Dim line_date As DateTime = Nothing
        Dim nxt_line_date As DateTime = Nothing ' to check if next cycle has same time as current

        Dim activity_tmp As Double
        Dim activity_flag As Boolean = False
        Dim acti_cnt As Integer = 0

        Dim pulse_tmp As Integer
        Dim pulse_flag As Boolean = False
        Dim pulse_cnt As Integer = 0
        Dim resp_tmp As Integer
        Dim resp_flag As Boolean = False
        Dim resp_cnt As Integer
        Dim vvti_tmp As Double
        Dim vvti_flag As Boolean = False
        Dim vvti_cnt As Integer

        Dim sleep_score_tmp As Double
        Dim sleep_score_flag As Boolean = False
        Dim sleep_score_cnt = 0
        Dim activity_score_tmp As Integer
        Dim activity_score_flag As Boolean = False
        Dim activity_score_cnt = 0

        'Dim tmp_value As Boolean = False  ' to indicate there was a value

        Do  ' assume line 3 has always data
            line_Cnt += 1
            'total_line_cnt += 1
            '_line_counter = (total_line_cnt - 3).ToString()
            line_data_type = CSV_Excel.Cells(line_Cnt, 1).Text
            line_date = CSV_Excel.Cells(line_Cnt, 2).value

            Select Case line_data_type
                    'Case "Position"
                    '    posi_cnt += 1
                    '    pos_tmp = pract_Excel.Cells(line_Cnt, 5).text
                    '    pos_dur_tmp = pract_Excel.Cells(line_Cnt, 6).value
                    '    'line_data.position = pract_Excel.Cells(line_Cnt, 5).text
                    '    'line_data.position_duration = pract_Excel.Cells(line_Cnt, 6).value
                Case "Activity"
                    acti_cnt += 1
                    'line_data.activity = pract_Excel.Cells(line_Cnt, 7).value
                    activity_tmp = CSV_Excel.Cells(line_Cnt, 7).value
                    activity_flag = True
                    'tmp_value = True
                Case "Pulse"
                    pulse_cnt += 1
                    'line_data.pulse = pract_Excel.Cells(line_Cnt, 9).value
                    pulse_tmp = CSV_Excel.Cells(line_Cnt, 9).value
                    pulse_flag = True
                    'tmp_value = True
                Case "Respiration"
                    resp_cnt += 1
                    'line_data.respiration = pract_Excel.Cells(line_Cnt, 10).value
                    resp_tmp = CSV_Excel.Cells(line_Cnt, 10).value
                    resp_flag = True
                    'tmp_value = True
                Case "VVTI"
                    vvti_cnt += 1
                    'line_data.vvti = pract_Excel.Cells(line_Cnt, 11).value
                    vvti_tmp = CSV_Excel.Cells(line_Cnt, 11).value
                    vvti_flag = True
                    'tmp_value = True
                Case "Sleep"
                    sleep_score_cnt += 1
                    sleep_score_tmp = CSV_Excel.Cells(line_Cnt, 14).value
                    sleep_score_flag = True
                    'tmp_value = True
                Case "Activity Score"
                    activity_score_cnt += 1
                    activity_score_tmp = CSV_Excel.Cells(line_Cnt, 15).value
                    activity_score_flag = True
                    'tmp_value = True
                Case "Fever Indication"
                        ' do nothing
                Case "Position"
                        ' do nothing
                Case "Position Score"
                    ' do nothing
                Case Else
                    ' If it is null, we reached end of file
                    If line_data_type <> "" Then
                        Console.WriteLine("Wrong place in case of data type in CSV lines, line: " + line_Cnt.ToString())
                    End If

            End Select

            If Not (activity_flag Or pulse_flag Or resp_flag Or vvti_flag Or activity_score_tmp) Then
                Continue Do
            End If

            nxt_line_date = CSV_Excel.Cells(line_Cnt + 1, 2).value


            ' **** try combing lines that differ in less than 10 seconds
            Dim seconds As Long = DateDiff(DateInterval.Second, line_date, nxt_line_date)
            'Console.WriteLine("delta in seconds: " + seconds.ToString())

            If seconds > 10 Then

                'End If

                'If line_date.AddSeconds(-line_date.Second) <> nxt_line_date.AddSeconds(-nxt_line_date.Second
                '       ) Then
                Dim line_data As New Session_CSV_file.Dog_data
                line_data.pract_time = line_date
                line_data.activity = activity_tmp
                line_data.activity_flag = activity_flag
                line_data.pulse = pulse_tmp
                line_data.pulse_flag = pulse_flag
                line_data.respiration = resp_tmp
                line_data.resp_flag = resp_flag
                line_data.vvti = vvti_tmp
                line_data.vvti_flag = vvti_flag
                line_data.sleep = sleep_score_tmp
                line_data.sleep_flag = sleep_score_flag
                line_data.activity_score = activity_score_tmp
                line_data.activity_score_flag = activity_score_flag

                curr_session.List_of_dog_data.Add(line_data)

                activity_flag = False
                pulse_flag = False
                resp_flag = False
                vvti_flag = False
                'sleep_score_flag = False '****once per file, should remain true
                'activity_score_flag = False  ' **** once per file, should remain true

            End If
            Application.DoEvents()
        Loop While (line_data_type <> "")

        ' finished reading the linces of the CSV
        Console.WriteLine("Num of lines read: " + (line_Cnt - 3).ToString)
        _line_counter = line_Cnt - 3

        CSV_Excel.Workbooks.Close()
        CSV_Excel.Quit()
        CSV_Excel = Nothing
        'total_sessions.Add(curr_session)
        Application.DoEvents()


        ' num_of_lines_TextBox.value = total_line_cnt.ToString()
        Return curr_session
    End Function


    Public Function Create_results_new(_tot_sessions As List(Of Session_CSV_file),
                                  _pre_time As Integer, _post_time As Integer,
                                  _out_file As String, _sleep_out_file As String, _cnt_txt_box As TextBox) As List(Of String)

        Dim Sleep_list As New List(Of SleepClass)

        Dim xlApp As New Excel.Application
        Dim xlWorkbook As Excel.Workbook = xlApp.Workbooks.Add()
        Dim xlWorksheet As Excel.Worksheet = CType(xlWorkbook.Sheets("sheet1"), Excel.Worksheet)

        ' variables for the sleep report (second excel file)
        Dim t_name As String = Nothing
        Dim t_session_day As DateTime
        Dim t_sleep_flag As Boolean
        Dim t_sleep_score As Double
        Dim t_activity_score As Integer
        Dim t_activity_flag As Boolean

        Dim log_out_lst As New List(Of String) ' to return to log file


        xlWorksheet.Cells(1, 1) = "Dog"
        xlWorksheet.Cells(1, 2) = "Age"
        xlWorksheet.Cells(1, 3) = "Session Date"
        xlWorksheet.Cells(1, 4) = "Session in day"
        xlWorksheet.Cells(1, 5) = "Practice"
        xlWorksheet.Cells(1, 6) = "Predictability"
        xlWorksheet.Cells(1, 7) = "Video num"
        xlWorksheet.Cells(1, 8) = "Time Zone"
        xlWorksheet.Cells(1, 9) = "Start"
        xlWorksheet.Cells(1, 10) = "End"
        xlWorksheet.Cells(1, 11) = "Reading Time"
        xlWorksheet.Cells(1, 12) = "Activity"
        xlWorksheet.Cells(1, 13) = "Pulse"
        xlWorksheet.Cells(1, 14) = "Respiration"
        xlWorksheet.Cells(1, 15) = "HRV"
        xlWorksheet.Cells(1, 16) = "Sleep score"
        xlWorksheet.Cells(1, 17) = "Activity Score"
        xlWorksheet.Cells(1, 20) = "Total Activity count"
        xlWorksheet.Cells(1, 21) = "Zeros count"
        xlWorksheet.Cells(1, 22) = "max zeros is a row"
        xlWorksheet.Cells(1, 23) = "Num of Zeros in training"    ' 22 April 2020
        xlWorksheet.Cells("A1:A30").Style.WrapText = True    ' 22 April 2020


        Dim out_line_cnt As Integer = 2

        ' go over the sessions list (were read from pratice file)
        ' get the relevant CSV files, and get the pre_act_post data

        Dim l_start As DateTime
        Dim l_end As DateTime
        Dim l_start_pre_time As DateTime
        Dim l_end_post_time As DateTime


        ' for activity quality analysis
        Dim quality_activity_cnt As Integer = 0
        Dim quality_activity_smpl As Integer
        Dim zero_acitivty_cnt As Integer = 0
        Dim zero_acitivty_smpl As Integer
        Dim zero_acitivty_in_a_row_cnt As Integer = 0
        Dim max_acitivty_in_a_row = 0
        Dim time_zone_change As Boolean = False ' indicates moving from pre->act->post
        Dim zeros_in_zone_1 As Integer = 0  ' 22 April 2020
        Dim zeros_in_zone_2 As Integer = 0  ' 22 April 2020
        Dim zeros_in_zone_3 As Integer = 0  ' 22 April 2020

        ' 2 Apr 2020 bug fix below 
        Dim pet_name_smpl As String = "xxxxx"
        Dim pet_name_ID_smpl As String = "77777"
        Dim pract_time_smpl As DateTime
        Dim many_zeros_cnt As Integer = 0

        'Dim line_cnt As Integer = 0 ' need for debug 

        Dim l_time_zone As Integer = 777 ' 4 April 2020 moved before the Loop
        Dim prev_l_time_zone As Integer = 777  ' 4 April 2020
        Dim tz_error_cnt As Integer = 0


        For Each l In _tot_sessions

            ' 29 March 2020 bug fix: should be zeroed only when changing time zoned
            '   not when new dog or training starts
            ' max_acitivty_in_a_row = 0


            zero_acitivty_in_a_row_cnt = 0

            'Console.WriteLine("here")

            l_start = l.activity_start_time + l.session_start_time
            l_end = l.activity_end_time + l.session_start_time

            If (l.activity_start_time > l.activity_end_time) Then
                l_end = l_end.AddDays(1)
            End If

            'If (l.activity_start_time < l.activity_end_time) Then
            'End If

            'l_start = l.activity_start_time.Add(l.session_start_time)
            'l_end = l.activity_end_time.Add(l.session_start_time.TimeOfDay)

            l_start_pre_time = l_start.AddMinutes(-_pre_time)
            l_end_post_time = l_end.AddMinutes(_post_time)



            'l_start = sessions.sessionsList(c).practiceDate.Add(sessions.sessionsList(c).startTime.TimeOfDay)
            'l_end = sessions.sessionsList(c).practiceDate.Add(sessions.sessionsList(c).endTime.TimeOfDay)
            'l_start_pre_time As DateTime = l_start.AddMinutes(-TxtPreTime.Value)
            ' l_end_post_time As DateTime = l_end.AddMinutes(TxtPreTime.Value)



            'Dim line_cnt As Integer = 0 ' need for debug 
            'Dim l_time_zone As Integer = 777 ' 4 April 2020 moved before the Loop
            'Dim prev_l_time_zone As Integer = 777  ' 4 April 2020


            For Each line In l.List_of_dog_data
                'line_cnt += 1

                ' skip when time not within pre-actual-post zones
                If line.pract_time < l_start_pre_time Then
                    Continue For
                End If
                If line.pract_time > l_end_post_time Then
                    Continue For
                End If
                ' Dim l_time_zone As Integer                '4 April 2020 moved from here to before loop

                ' --------------------------------------
                ' if here, we are within pre-actual-post

                ' check if time is before start, but last time zone was 3, so there wa a change
                If line.pract_time < l_start Then
                    If l_time_zone = 3 Then
                        time_zone_change = True
                    End If
                    prev_l_time_zone = l_time_zone
                    l_time_zone = 1

                    ' if time is after start, but before end of practice, so  we are in time zone 2 now.
                    ' if previously we were at time zone 1, there was a change
                ElseIf line.pract_time <= l_end Then
                    If l_time_zone = 1 Then
                        time_zone_change = True
                    End If
                    prev_l_time_zone = l_time_zone
                    l_time_zone = 2
                Else
                    If l_time_zone = 2 Then
                        time_zone_change = True
                    End If
                    prev_l_time_zone = l_time_zone
                    l_time_zone = 3
                End If

                ' check if there was illegal move between time zones
                Dim str_error As String = Nothing


                ' check if we are in same time zone, but different dog  10 April 2020
                '                Dim cond1 As Boolean = l_time_zone = prev_l_time_zone And pet_name_ID_smpl <> l.pet_ID
                '                 Dim cond2 As Boolean = pet_name_ID_smpl <> l.pet_ID And prev_l_time_zone <> 3 And l_time_zone <> 1

                If pet_name_ID_smpl <> l.pet_ID And l_time_zone = prev_l_time_zone Then
                    str_error = " --- Error 1: dog change, same time zone,"
                    str_error += " Line in output excel file: " + (out_line_cnt).ToString().PadLeft(5)
                    str_error += " Prev dog: " + pet_name_ID_smpl + " current dog: " + l.pet_ID
                    xlWorksheet.Cells(out_line_cnt, 23) = str_error
                    log_out_lst.Add(str_error)
                End If

                ' new set of checks, should cover the above and more. Keep in source to validate.
                ' dog changed, but not with first line  (no dog before that)
                If pet_name_ID_smpl <> l.pet_ID And out_line_cnt <> 2 Then
                    If prev_l_time_zone <> 3 Then
                        str_error = " --- Error2: dog changed, last time zone is not 3,"
                        str_error += " Line in output excel file: " + (out_line_cnt).ToString().PadLeft(5)
                        str_error += " Prev dog: " + pet_name_ID_smpl + " current dog: " + l.pet_ID
                        xlWorksheet.Cells(out_line_cnt, 24) = str_error
                        log_out_lst.Add(str_error)
                    End If

                    If l_time_zone <> 1 Then
                        str_error = " --- Error 3: dog changed, new time zone is not 1,"
                        str_error += " Line in output excel file: " + (out_line_cnt).ToString().PadLeft(5)
                        str_error += " Prev dog: " + pet_name_ID_smpl + " current dog: " + l.pet_ID
                        xlWorksheet.Cells(out_line_cnt, 24) = str_error
                        log_out_lst.Add(str_error)
                    End If

                End If




                ' skip line 2 (always "different" and all cases when we are still in same time zone, step after step
                If out_line_cnt <> 2 And l_time_zone <> prev_l_time_zone And prev_l_time_zone <> 777 Then
                    If l_time_zone = 1 And prev_l_time_zone <> 3 Then
                        tz_error_cnt += 1
                        str_error = tz_error_cnt.ToString().PadLeft(3) + " >>>> Error with time zone change. now 1, was " + prev_l_time_zone.ToString()
                        str_error += " Line in output excel file: " + (out_line_cnt).ToString().PadLeft(5)
                        xlWorksheet.Cells(out_line_cnt, 25) = str_error
                        log_out_lst.Add(str_error)
                    End If
                    If l_time_zone = 2 And prev_l_time_zone <> 1 Then
                        tz_error_cnt += 1
                        str_error = tz_error_cnt.ToString().PadLeft(3) + " >>>> Error with time zone change. now 2, was " + prev_l_time_zone.ToString()
                        str_error += " Line in output excel file: " + (out_line_cnt).ToString().PadLeft(5)
                        xlWorksheet.Cells(out_line_cnt, 25) = str_error
                        log_out_lst.Add(str_error)
                    End If
                    If l_time_zone = 3 And prev_l_time_zone <> 2 Then
                        tz_error_cnt += 1
                        str_error = tz_error_cnt.ToString().PadLeft(3) + " >>>> Error with time zone change. now 3, was " + prev_l_time_zone.ToString()
                        str_error += " Line in output excel file: " + (out_line_cnt).ToString().PadLeft(5)
                        xlWorksheet.Cells(out_line_cnt, 25) = str_error
                        log_out_lst.Add(str_error)
                    End If
                End If

                If time_zone_change Then ' sample the counters of activity quality and zeros

                    quality_activity_smpl = quality_activity_cnt
                    zero_acitivty_smpl = zero_acitivty_cnt


                    Dim str_zeros_error As String = Nothing

                    xlWorksheet.Cells(out_line_cnt - 1, 20) = quality_activity_smpl
                    xlWorksheet.Cells(out_line_cnt - 1, 21) = zero_acitivty_smpl
                    xlWorksheet.Cells(out_line_cnt - 1, 22) = max_acitivty_in_a_row


                    ' 22 Apr 2020
                    If prev_l_time_zone = 2 And zero_acitivty_smpl > 0 Then
                        str_zeros_error = "^^^ one or more zeros in time zone 2, line: " + (out_line_cnt - 1).ToString()
                        log_out_lst.Add(str_zeros_error)
                    End If




                    ' 22 Apr 2020 the lines below were added to see how many zeros totally in a practice, all time zones
                    If prev_l_time_zone = 1 Then
                        zeros_in_zone_1 = zero_acitivty_smpl
                    End If
                    If prev_l_time_zone = 2 Then
                        zeros_in_zone_2 = zero_acitivty_smpl
                    End If
                    If prev_l_time_zone = 3 Then
                        zeros_in_zone_3 = zero_acitivty_smpl
                        xlWorksheet.Cells(out_line_cnt - 1, 23) = zeros_in_zone_1 + zeros_in_zone_2 + zeros_in_zone_3       ' 22 Apr 2020 

                        If prev_l_time_zone = 3 Then
                            str_zeros_error = "^^^ one or more zeros in time zone 2, line: " + (out_line_cnt - 1).ToString()
                            log_out_lst.Add(str_zeros_error)
                        End If


                        zeros_in_zone_1 = 0 ' 22 Apr 2020
                        zeros_in_zone_2 = 0 ' 22 Apr 2020
                        zeros_in_zone_3 = 0 ' 22 Apr 2020
                    End If



                    If max_acitivty_in_a_row >= 4 Or zero_acitivty_smpl >= 4 Then       ' 2 Apr 2020 Added
                        many_zeros_cnt += 1
                        Dim msg_str As String
                        msg_str = many_zeros_cnt.ToString().PadRight(4)
                        msg_str += "Num of consecutive zeros is: " + max_acitivty_in_a_row.ToString().PadRight(2)
                        msg_str += " Tot Num of zeros is: " + zero_acitivty_smpl.ToString().PadRight(2)
                        msg_str += " pet ID: " + pet_name_ID_smpl.PadRight(5) ' 4 April 2020 added
                        msg_str += " Dog: " + pet_name_smpl.PadRight(6)
                        msg_str += " Time: " + pract_time_smpl.ToString().PadRight(23)
                        msg_str += " Line in output excel file: " + (out_line_cnt - 1).ToString().PadLeft(5)
                        'msg_str += " " + str_error
                        log_out_lst.Add(msg_str)
                    End If
                    time_zone_change = False
                    quality_activity_cnt = 0
                    zero_acitivty_cnt = 0
                    zero_acitivty_in_a_row_cnt = 0
                    max_acitivty_in_a_row = 0
                End If

                ' 2 April 2020 bug fix: log file should keep prev line info
                ' 4 April 2020 moved outside the loop. That was stupid!
                pet_name_smpl = l.pet_name
                pract_time_smpl = line.pract_time
                pet_name_ID_smpl = l.pet_ID

                xlWorksheet.Cells(out_line_cnt, 1) = l.pet_ID
                xlWorksheet.Cells(out_line_cnt, 2) = l.pet_age
                xlWorksheet.Cells(out_line_cnt, 3) = l.session_start_time
                'xlWorksheet.Cells(out_line_cnt, 4) = 
                ' xlWorksheet.Cells(out_line_cnt, 5) = l.practice_type
                xlWorksheet.Cells(out_line_cnt, 5) = l.Practice_num
                'xlWorksheet.Cells(out_line_cnt, 6) = sessions.sessionsList(c).predictability.ToString()
                'xlWorksheet.Cells(out_line_cnt, 7) = sessions.sessionsList(c).videoNum
                xlWorksheet.Cells(out_line_cnt, 8) = l_time_zone

                ' mark start time of each timezone (pre/act/post)
                Dim l1, l2 As DateTime

                Select Case l_time_zone
                    Case 1
                        l1 = l_start_pre_time
                        l2 = l_start
                    Case 2
                        l1 = l_start
                        l2 = l_end
                    Case 3
                        l1 = l_end
                        l2 = l_end_post_time
                    Case Else
                        MessageBox.Show("Error in case of timeZone, num is: " + l_time_zone.ToString())
                        Debug.WriteLine("Error in case of timeZone, num is: " + l_time_zone.ToString())
                End Select

                xlWorksheet.Cells(out_line_cnt, 9) = l1.ToString("HH:mm")
                xlWorksheet.Cells(out_line_cnt, 10) = l2.ToString("HH:mm")
                'xlWorksheet.Cells(out_line_cnt, 11) = l.pract_time 21 Oct 2019, nove to 24h clock
                xlWorksheet.Cells(out_line_cnt, 11) = Format(line.pract_time, "HH:mm")
                'xlWorksheet.Cells(out_line_cnt, 12) = line.activity

                If line.activity_flag Then
                    xlWorksheet.Cells(out_line_cnt, 12) = line.activity

                    quality_activity_cnt += 1

                    If (line.activity = 0) Then
                        zero_acitivty_cnt += 1
                        zero_acitivty_in_a_row_cnt += 1
                        If zero_acitivty_in_a_row_cnt > max_acitivty_in_a_row Then
                            max_acitivty_in_a_row = zero_acitivty_in_a_row_cnt
                        End If

                    Else
                        zero_acitivty_in_a_row_cnt = 0
                    End If

                    'Debug.Write("Line_cnt: " + line_cnt.ToString() + "// l_time_zone: " + l_time_zone.ToString)
                    'Debug.Write("// time_zone_change: " + time_zone_change.ToString())
                    'Debug.Write("// quality_activity_cnt: " + quality_activity_cnt.ToString())
                    'Debug.WriteLine("// zero_acitivty: " + zero_acitivty_cnt.ToString())

                End If

                If line.pulse_flag Then
                    xlWorksheet.Cells(out_line_cnt, 13) = line.pulse
                End If

                If line.resp_flag Then
                    xlWorksheet.Cells(out_line_cnt, 14) = line.respiration
                End If

                If line.vvti_flag Then
                    xlWorksheet.Cells(out_line_cnt, 15) = line.vvti
                End If

                If line.sleep_flag Then
                    xlWorksheet.Cells(out_line_cnt, 16) = line.sleep
                End If

                If line.activity_score_flag Then
                    xlWorksheet.Cells(out_line_cnt, 17) = line.activity_score
                End If

                ' 1 march 2020 print activity quality results
                If time_zone_change Then
                    '                   xlWorksheet.Cells(out_line_cnt, 20) = quality_activity_smpl
                    '                   xlWorksheet.Cells(out_line_cnt, 21) = zero_acitivty_smpl
                    '                   time_zone_change = False
                    '                   quality_activity_cnt = 0
                    '                   zero_acitivty_cnt = 0
                End If

                t_name = l.pet_ID
                t_session_day = l.session_start_time
                t_sleep_flag = line.sleep_flag
                t_sleep_score = line.sleep
                t_activity_flag = line.activity_score_flag
                t_activity_score = line.activity_score

                out_line_cnt += 1

                Application.DoEvents() ' 3 april 2020
            Next ' of for each lines of that specific dog

            Dim Sleep_list_tmp As New SleepClass
            Sleep_list_tmp.pet_id = t_name
            Sleep_list_tmp.session_day = t_session_day
            Sleep_list_tmp.sleep_flag = t_sleep_flag
            Sleep_list_tmp.sleep_score = t_sleep_score
            Sleep_list_tmp.acitivity_flag = t_activity_flag
            Sleep_list_tmp.activity_score = t_activity_score

            ' TBD : to add a check - if same dog same day already in the sleep list -> dont add it
            Dim exist_tmp As Boolean = False
            For Each tmp_slp In Sleep_list
                If tmp_slp.pet_id = Sleep_list_tmp.pet_id And tmp_slp.session_day = Sleep_list_tmp.session_day Then
                    exist_tmp = True
                End If
            Next

            If exist_tmp = False Then
                Sleep_list.Add(Sleep_list_tmp)
            End If

            _cnt_txt_box.Text = out_line_cnt.ToString()
            Application.DoEvents()


        Next ' of for each sessions

        xlWorksheet.SaveAs(_out_file)
        xlWorkbook.Close()
        xlApp.Quit()
        Application.DoEvents()

        ' ****************************************************************************
        ' now open the 2nd output excel - this time for sleep score and activity score
        ' ****************************************************************************
        Dim xlApp1 As New Excel.Application
        Dim xlWorkbook1 As Excel.Workbook = xlApp1.Workbooks.Add()
        Dim xlWorksheet1 As Excel.Worksheet = CType(xlWorkbook1.Sheets("sheet1"), Excel.Worksheet)

        out_line_cnt = 1
        xlWorksheet1.Cells(out_line_cnt, 1) = "Session Date"
        xlWorksheet1.Cells(out_line_cnt, 2) = "Dog"
        xlWorksheet1.Cells(out_line_cnt, 3) = "Sleep Score"
        xlWorksheet1.Cells(out_line_cnt, 4) = "Activity Score"

        For Each line In Sleep_list
            out_line_cnt += 1
            xlWorksheet1.Cells(out_line_cnt, 1) = line.session_day
            xlWorksheet1.Cells(out_line_cnt, 2) = line.pet_id
            If line.sleep_flag Then
                xlWorksheet1.Cells(out_line_cnt, 3) = line.sleep_score
            End If
            If line.acitivity_flag Then
                xlWorksheet1.Cells(out_line_cnt, 4) = line.activity_score
            End If

        Next

        Console.WriteLine("Before saving output sleep excel")
        xlWorksheet1.SaveAs(_sleep_out_file)
        xlWorkbook1.Close()
        xlApp1.Quit()
        Application.DoEvents()

        Return log_out_lst
    End Function ' of Create_results_new

End Module
