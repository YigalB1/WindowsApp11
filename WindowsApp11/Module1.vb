Imports Microsoft.Office.Interop

Module Module1



    Public Function Read_CSV_file(_fname As String, _dog_age As Integer, _activity_start As Date, _activity_end As Date, _pre_time As Integer, _post_time As Integer) As Session_CSV_file
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



        Dim csv_start_date As DateTime
        Dim s1 As String = CSV_Excel.Cells(1, 1).text.Replace("From:", "").Replace(" ", "")
        Dim t_bool As Boolean = Date.TryParseExact(s1, "MM/dd/yyyy",
                               Globalization.CultureInfo.InvariantCulture,
                               Globalization.DateTimeStyles.None, csv_start_date)
        curr_session.session_start_time = csv_start_date ' Oct 23, 2019
        If (t_bool = False) Then
            MessageBox.Show("Error E1 while checking CSV file date")
            Console.WriteLine("Error E1 while checking CSV file date")
        End If




        ' ** finished reading CSV header
        ' start reading data lines, line after line
        Dim line_Cnt As Integer = 3 ' first line to read is 4, incremented soon
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

        Dim tmp_value As Boolean = False  ' to indicate there was a value

        Do  ' assume line 3 has always data
            line_Cnt += 1
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
                    tmp_value = True
                Case "Pulse"
                    pulse_cnt += 1
                    'line_data.pulse = pract_Excel.Cells(line_Cnt, 9).value
                    pulse_tmp = CSV_Excel.Cells(line_Cnt, 9).value
                    pulse_flag = True
                    tmp_value = True
                Case "Respiration"
                    resp_cnt += 1
                    'line_data.respiration = pract_Excel.Cells(line_Cnt, 10).value
                    resp_tmp = CSV_Excel.Cells(line_Cnt, 10).value
                    resp_flag = True
                    tmp_value = True
                Case "VVTI"
                    vvti_cnt += 1
                    'line_data.vvti = pract_Excel.Cells(line_Cnt, 11).value
                    vvti_tmp = CSV_Excel.Cells(line_Cnt, 11).value
                    vvti_flag = True
                    tmp_value = True
                Case "Sleep"
                    sleep_score_cnt += 1
                    sleep_score_tmp = CSV_Excel.Cells(line_Cnt, 14).value
                    sleep_score_flag = True
                    tmp_value = True
                Case "Activity Score"
                    activity_score_cnt += 1
                    activity_score_tmp = CSV_Excel.Cells(line_Cnt, 15).value
                    activity_score_flag = True
                    tmp_value = True
                Case "Fever Indication"
                        ' do nothing
                Case "Position"
                        ' do nothing
                Case "Position Score"
                    ' do nothing

                Case Else
                    Console.WriteLine("Wrong place in case of data type in CSV lines, line: " + line_Cnt.ToString())
            End Select

            nxt_line_date = CSV_Excel.Cells(line_Cnt + 1, 2).value
            If line_date <> nxt_line_date Then
                Dim line_data As New Session_CSV_file.Dog_data
                line_data.pract_time = line_date
                line_data.activity = activity_tmp
                line_data.pulse = pulse_tmp
                line_data.respiration = resp_tmp
                line_data.vvti = vvti_tmp
                line_data.sleep = sleep_score_tmp
                line_data.activity_score = activity_score_tmp

                curr_session.List_of_dog_data.Add(line_data)




            End If

        Loop While (line_data_type <> "")
        Console.WriteLine("Num of lines read: " + (line_Cnt - 3).ToString)




        CSV_Excel.Workbooks.Close()
        CSV_Excel = Nothing
        'total_sessions.Add(curr_session)
        Return curr_session


    End Function


    Public Sub Create_results_new(_tot_sessions As List(Of Session_CSV_file),
                                  _pre_time As Integer, _post_time As Integer, _out_file As String)


        Dim xlApp As New Excel.Application
        Dim xlWorkbook As Excel.Workbook = xlApp.Workbooks.Add()
        Dim xlWorksheet As Excel.Worksheet = CType(xlWorkbook.Sheets("sheet1"), Excel.Worksheet)

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

        Dim out_line_cnt As Integer = 2

        ' go over the sessions list (were read from pratice file)
        ' get the relevant CSV files, and get the pre_act_post data

        Dim l_start As DateTime
        Dim l_end As DateTime
        Dim l_start_pre_time As DateTime
        Dim l_end_post_time As DateTime


        For Each l In _tot_sessions

            Console.WriteLine("here")

            l_start = l.activity_start_time + l.session_start_time
            l_end = l.activity_end_time + l.session_start_time

            'l_start = l.activity_start_time.Add(l.session_start_time)
            'l_end = l.activity_end_time.Add(l.session_start_time.TimeOfDay)

            l_start_pre_time = l_start.AddMinutes(-_pre_time)
            l_end_post_time = l_end.AddMinutes(_post_time)



            'l_start = sessions.sessionsList(c).practiceDate.Add(sessions.sessionsList(c).startTime.TimeOfDay)
            'l_end = sessions.sessionsList(c).practiceDate.Add(sessions.sessionsList(c).endTime.TimeOfDay)
            'l_start_pre_time As DateTime = l_start.AddMinutes(-TxtPreTime.Value)
            ' l_end_post_time As DateTime = l_end.AddMinutes(TxtPreTime.Value)


            For Each line In l.List_of_dog_data
                If line.pract_time < l_start_pre_time Then
                    Continue For
                End If
                If line.pract_time > l_end_post_time Then
                    Continue For
                End If
                Dim l_time_zone As Integer

                If line.pract_time < l_start Then
                    l_time_zone = 1
                ElseIf line.pract_time <= l_end Then
                    l_time_zone = 2
                Else
                    l_time_zone = 3
                End If

                xlWorksheet.Cells(out_line_cnt, 1) = l.pet_ID
                xlWorksheet.Cells(out_line_cnt, 2) = l.pet_age
                xlWorksheet.Cells(out_line_cnt, 3) = l.session_start_time
                'xlWorksheet.Cells(out_line_cnt, 4) = 
                xlWorksheet.Cells(out_line_cnt, 5) = line.pract_type
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


                'If line.sleep_flag Then
                xlWorksheet.Cells(out_line_cnt, 16) = line.sleep
                'End If

                'If line.activity_score_flag Then
                xlWorksheet.Cells(out_line_cnt, 17) = line.activity_score
                'End If




                out_line_cnt += 1
            Next


            'xlWorksheet.Cells(out_line_cnt, 4) = sessions.sessionsList(c).sessionOnAday
            'xlWorksheet.Cells(out_line_cnt, 4) = sessions.Count_num_of_session


            '            Dim l_pet_dob As Date = l.pet_DOB
            '            Dim ageindays As TimeSpan = l.session_start_time - l_pet_dob
            '            Dim l_age = Int(ageindays.Days / 7)





        Next

        xlWorksheet.SaveAs(_out_file)
        ' result_out_file_name

        xlWorkbook.Close()
        xlApp.Quit()


        ' xlWorksheet.Workbooks.Close()
        ' xlWorksheet = Nothing
    End Sub ' of Create_results_new









End Module
