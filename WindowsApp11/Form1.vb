'Add a reference To Microsoft Excel Object Library. To Do this, follow these steps
'On the Project menu, click Add Reference.
'On the COM tab, locate Microsoft Excel Object Library, And then click Select. 
'Imports System.Data.OleDb
'Imports Console = System.Console
Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.IO

Public Class Form1

    ' 10 Nov 2019: making directories according to courses
    'Public root_dir As String = "C:\\Users\\yigal\\Documents\\Yigal\\DogsProj\\"
    Public root_dir As String
    Public course_dir As String ' will be assigned according to selected course
    Public in_files_dir As String
    Public out_files_dir As String
    Public practice_file As String


    Public in_PathName As String = "C:\\Users\\yigal\\Documents\\Yigal\\DogsProj\\SessionsFiles\\"
    Public default_work_dir As String = "C:\\Users\\yigal\\Documents\\Yigal\\DogsProj\\"
    Public default_sessions_dir As String = "C:\\Users\\yigal\\Documents\\Yigal\DogsProj\\" + "SessionsFiles\\"
    Public default_pratice_file_name As String = "C:\\Users\\yigal\\Documents\\Yigal\\DogsProj\\practice_list1.xlsx"
    'Public LogFile = "C:\\Users\\yigal\\Documents\\Yigal\\DogsProj\\logDog.txt"
    Public LogFile As String ' 11 Nov 2019: folder is assigned according to course
    Public SessionsFile As String

    ' Public csv_pattern As String = "export-all-Bell-11302018_083229.csv" 10 Nov 19
    Public csv_pattern As String = "*.csv"   ' *083229.csv

    Public result_out_file_name As String = "C:\Users\yigal\Documents\Yigal\DogsProj\result_output1.xlsx"
    Public sleep_out_file_name As String

    Dim DogsList As New DogsListClass
    Dim practiceList As New PracticesList
    Dim sessions As New List_of_Sessions
    Dim total_sessions As New List(Of Session_CSV_file) ' will include all CSV files content

    ' 13 Nov 2019 adding new stracture of CSV files fast scan (just header, no lines)
    Dim CSV_files_headers As New List(Of CSV_file_header)

    Dim Stage_Read_Practice_Table As Boolean = False
    Dim Stage_Read_Session_Files As Boolean = False

    Public total_line_cnt As Integer
    Dim course_name As String = Nothing ' will hold the course name year 2016-17 or 2017-18

    'Public pre_time As Integer
    'Public post_time As Integer


    Dim MAX_NUM_OF_DOGS As Integer = 50
    Dim MAX_NUM_OF_PRACTICES As Integer = 500
    Dim MAX_NUM_OF_PRACTICES_TYPES As Integer = 50

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Rotate's form's image
        PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
        PictureBox1.Refresh()

        Header_label.BackColor = Color.Yellow
    End Sub



    Private Function check_course()
        Dim ret As Boolean
        ret = False
        ' "201617"
        If RadioButton1.Checked Then
            course_name = "2016_17"
            ret = True
        ElseIf RadioButton2.Checked Then
            course_name = "2017_18"
            ret = True
        ElseIf RadioButton3.Checked Then
            course_name = "2018_19"
            ret = True
        ElseIf RadioButton4.Checked Then
            course_name = "TBD_not_used"
            ret = True
        ElseIf RadioButton5.Checked Then
            course_name = "Trials"
            ret = True

        Else
            MessageBox.Show("No project was selected")
            Return False
        End If

        ' MessageBox.Show("project: " + course_name)

        'Public root_dir As String = "C:\\Users\\yigal\\Documents\\Yigal\\DogsProj\\"

        Dim Path_tmp As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        Path_tmp = Path_tmp & "\" & "Yigal\" & "DogsProj\"
        root_dir = Path_tmp.Replace("\", "\\")



        course_dir = root_dir + "Course" + course_name + "\\"
        in_files_dir = course_dir + "in_files\\"
        out_files_dir = course_dir + "out_files\\"
        practice_file = course_dir + "practice_list_" + course_name + ".xlsx"
        LogFile = course_dir + "logDog.txt"
        SessionsFile = course_dir + "Sessions_list.txt"

        Dim dir As New IO.DirectoryInfo(course_dir)
        If Not dir.Exists Then
            MsgBox("Missing Course folder")
            Return False
        End If

        Dim dir1 As New IO.DirectoryInfo(in_files_dir)
        If Not dir1.Exists Then
            MsgBox("Missing In files folder")
            Return False
        End If

        Dim dir2 As New IO.DirectoryInfo(out_files_dir)
        If Not dir2.Exists Then
            MsgBox("Missing Out files folder")
            Return False
        End If

        ' check if folders and required files exixt
        If Not My.Computer.FileSystem.FileExists(practice_file) Then
            MsgBox("Missing prctice file")
            Return False
        End If


        Return True
    End Function


    Private Sub Rename_file_name_to_old(_fname)
        If File.Exists(_fname) Then
            Print_to_log_file("renaming " + "outfile " + _fname)
            Dim fn As String = Path.GetFileNameWithoutExtension(_fname)
            Dim ext As String = Path.GetExtension(_fname)
            Dim dir As String = Path.GetDirectoryName(_fname)
            fn = fn + "_old"

            Dim new_out_file_name As String = Path.Combine(dir, fn + ext)
            If File.Exists(new_out_file_name) Then
                File.Delete(new_out_file_name)
            End If

            File.Move(_fname, new_out_file_name)
        End If
    End Sub

    Private Function check_files_and_folders()

        If check_course() = False Then
            'MessageBox.Show("Select a project")
            Return False
        End If
        Print_to_log_file("Course name: " + course_name)
        result_out_file_name = out_files_dir + "course_" + course_name + "_out.xlsx"
        result_out_file_name = result_out_file_name.Replace("\\", "\")
        sleep_out_file_name = result_out_file_name.Replace("_out.", "_sleep_out.")

        'If File.Exists(result_out_file_name) Then
        '    Print_to_log_file("outfile " + result_out_file_name + "renaming")
        '    Dim fn As String = Path.GetFileNameWithoutExtension(result_out_file_name)
        '    Dim ext As String = Path.GetExtension(result_out_file_name)
        '    'Dim fn_with_ext As String = Path.GetFileName(f1)
        '    'Dim fn_plus_path As String = Path.GetFullPath(f1)
        '    Dim dir As String = Path.GetDirectoryName(result_out_file_name)
        '    fn = fn + "_old"

        '    Dim new_out_file_name As String = Path.Combine(dir, fn + ext)
        '    If File.Exists(new_out_file_name) Then
        '        File.Delete(new_out_file_name)
        '    End If

        '    File.Move(result_out_file_name, new_out_file_name)
        'End If
        Rename_file_name_to_old(result_out_file_name)
        Rename_file_name_to_old(sleep_out_file_name)
        Rename_file_name_to_old(SessionsFile)

        PreChecks.BackColor = Color.Yellow
        Dim dir_bool1 As Boolean = IO.Directory.Exists(root_dir)
        Dim dir_bool2 As Boolean = IO.Directory.Exists(course_dir)
        Dim dir_bool3 As Boolean = IO.Directory.Exists(in_files_dir)
        Dim dir_bool4 As Boolean = IO.Directory.Exists(out_files_dir)

        Dim file_bool1 As Boolean = IO.File.Exists(practice_file)

        If dir_bool1 And dir_bool2 And dir_bool3 And dir_bool4 And file_bool1 Then
            Print_to_log_file("OK - Files and folders")
            TxtBoxWorkDir.Text = course_dir
            TxtBoxSessionDir.Text = in_files_dir

            Dim d As New System.IO.DirectoryInfo(in_files_dir)
            Dim intFiles As Integer
            intFiles = d.GetFiles.GetUpperBound(0) + 1
            TxtBoxNumOfFiles.Text = intFiles.ToString


            PreChecks.BackColor = Color.Green
            Return True
        Else

            If dir_bool1 = False Then
                Print_to_log_file("Error: root_dir is missing")
            End If
            If dir_bool2 = False Then
                Print_to_log_file("Error: course_dir is missing")
            End If
            If dir_bool3 = False Then
                Print_to_log_file("Error: in_files_dir is missing")
            End If
            If dir_bool4 = False Then
                Print_to_log_file("Error: out_files_dir is missing")
            End If
            If file_bool1 = False Then
                Print_to_log_file("Error: practice_file is missing")
            End If
            MessageBox.Show("Missing files or folders. Look at LOG file")
            Return False
        End If
    End Function

    Sub CreateDogsGrid(ByRef _dgv As DataGridView)
        ' Create an unbound DataGridView by declaring a column count.
        _dgv.ColumnCount = 4 ' num, name,DOB,Age
        _dgv.ColumnHeadersVisible = True

        ' Set the column header style.
        Dim ColumnHeaderStyle As DataGridViewCellStyle = New DataGridViewCellStyle()
        ColumnHeaderStyle.BackColor = Color.Beige
        ColumnHeaderStyle.Font = New Font("Verdana", 6, FontStyle.Bold)
        _dgv.ColumnHeadersDefaultCellStyle = ColumnHeaderStyle

        ' Set the column header names.
        _dgv.Columns(0).Name = "Num"
        _dgv.Columns(1).Name = "Name"
        _dgv.Columns(2).Name = "DOB"
        _dgv.Columns(3).Name = "Age"
    End Sub

    Sub CreatePracicesTypeGrid(ByRef _dgv1 As DataGridView)
        ' *****************  COPIED - TBD
        ' Create an unbound DataGridView by declaring a column count.
    End Sub

    Sub AddToDogsGrid(ByVal _dgv As DataGridView, ByVal _num As Integer, ByVal _name As String, _DOB As Date, _age As Integer)
        ' Populate the rows.

        '_dgv.Rows.Add()
        _dgv.Rows.Add(_num.ToString, _name, _DOB, _age)
        _dgv.AutoResizeColumns()

    End Sub

    Sub AddToPracticesListGrid(ByVal _dgv As DataGridView, ByVal _num As Integer, ByVal _name As String, ByVal _date As String, _type As String, _start As String, _end As String, _video As String)
        ' Populate the rows.
        ' parameters are strings, even the date ones. The sender should translate (using tostring suffix mostly)

        ' Set the column header style.
        Dim ColumnHeaderStyle As DataGridViewCellStyle = New DataGridViewCellStyle()
        ColumnHeaderStyle.BackColor = Color.Beige
        ColumnHeaderStyle.Font = New Font("Verdana", 4, FontStyle.Bold)
        _dgv.ColumnHeadersDefaultCellStyle = ColumnHeaderStyle

        _dgv.Rows.Add(_num.ToString,
                      _name,
                      _date,
                      _type,
                      _start.ToString,
                      _end.ToString,
                      _video)
        _dgv.AutoResizeColumns()
    End Sub

    Sub CreatePracicesListGrid(ByRef _dgv1 As DataGridView)

        ' **********************************************
        ' Create an unbound DataGridView by declaring a column count.
        _dgv1.ColumnCount = 7 ' 7 Columns
        _dgv1.ColumnHeadersVisible = True

        ' Set the column header style.
        Dim ColumnHeaderStyle As DataGridViewCellStyle = New DataGridViewCellStyle()
        ColumnHeaderStyle.BackColor = Color.Beige
        ColumnHeaderStyle.Font = New Font("Verdana", 6, FontStyle.Bold)
        _dgv1.ColumnHeadersDefaultCellStyle = ColumnHeaderStyle

        ' Set the column header names.
        _dgv1.Columns(0).Name = "Num"
        _dgv1.Columns(1).Name = "Dog Name"
        _dgv1.Columns(2).Name = "Pract Date"
        _dgv1.Columns(3).Name = "Pract Type"
        _dgv1.Columns(4).Name = "Pract Start"
        _dgv1.Columns(5).Name = "Pract End"
        _dgv1.Columns(6).Name = "Video Num"

    End Sub

    'Public Sub ShowEvent(sender As Object, e As EventArgs) Handles Me.Shown
    '    ' ****** STARTs AUTOMATICALLY running WITH FORM

    '    'set default directory
    '    ' TxtBoxWorkDir.Text = default_work_dir
    '    TxtBoxWorkDir.Text = course_dir


    '    TxtBoxSessionDir.Text = default_sessions_dir
    '    TxtBoxSessionDir.Text = in_files_dir


    '    'TxtBoxPracticeFile.Text = default_pratice_file_name
    '    TxtBoxPracticeFile.Text = practice_file

    '    ' count files in session directory
    '    Dim FilesInFolder As Integer = 0
    '    Dim d As New System.IO.DirectoryInfo(TxtBoxSessionDir.Text)
    '    Dim intFiles As Integer
    '    intFiles = d.GetFiles.GetUpperBound(0) + 1
    '    TxtBoxNumOfFiles.Text = intFiles.ToString

    '    ' Display picture
    '    PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
    '    PictureBox1.Refresh()

    '    ' set color before usage
    '    RdPracticeFile.BackColor = Color.Yellow

    '    ProgressBar1.Value = 10

    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonSelectWorkFolder.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TxtBoxWorkDir.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TxtBoxSessionDir.Text = FolderBrowserDialog1.SelectedPath
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles SelectPracticeFile.Click
        ' Call ShowDialog.
        OpenFileDialog1.InitialDirectory = TxtBoxWorkDir.Text
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()

        ' Test result.
        If result = Windows.Forms.DialogResult.OK Then
            ' Get the file name.
            Dim path As String = OpenFileDialog1.FileName
            TxtBoxPracticeFile.Text = path
            ProgressBar1.Value = 30
        End If
    End Sub

    Private Sub RdPracticeFile_Click(sender As Object, e As EventArgs) Handles RdPracticeFile.Click
        ReadPracticeFile()
    End Sub ' of RdPracticeFile_Click (invoked from button)

    Private Sub ReadPracticeFile()

        Print_to_log_file("Reading Practice file " + Date.Now(), False)
        Print_to_log_file("Practice file: " + Me.TxtBoxPracticeFile.Text)
        Print_to_log_file("------------------------------")

        RdPracticeFile.BackColor = Color.GreenYellow

        Console.BackgroundColor = ConsoleColor.Blue
        Console.WriteLine(" ......STARTING.................")
        Console.BackgroundColor = ConsoleColor.White

        Read_Dog_List() ' into DogList list (name and dob)
        DogsList.Print_dogs_list(course_dir) ' create text file with list of dogs


        Read_Pracice_Types_List() ' into practiceList (pract name & pract number)
        practiceList.Print_practices_list(course_dir) ' the class way


        Read_sessions_list()
        ' sessions.Print_sessions_list(root_dir)
        sessions.Print_sessions_list(course_dir) ' into sessions pract name, pract type, start time, end time, video num )


        RdPracticeFile.BackColor = Color.Green
        Stage_Read_Practice_Table = True
    End Sub ' of RdPracticeFile

    Private Sub Read_Dog_List()
        ' Reading dogs from practice file
        ' *******************************
        ' Dim DogsList As New DogsListClass   ' *** the Class way
        Dim counter As Integer = 0
        Dim row_cnt As Integer = 2
        Dim col_cnt As Integer = 14
        Dim stmp As String

        Dim MyExcel As New Microsoft.Office.Interop.Excel.Application
        'MyExcel.Workbooks.Open(Me.TxtBoxPracticeFile.Text)
        MyExcel.Workbooks.Open(practice_file)

        counter = 0
        Do
            If counter < MAX_NUM_OF_DOGS And MyExcel.Cells(row_cnt, col_cnt).text <> "END" Then
                Dim tdog As New DogClass  ' *** the Class way
                tdog.SetDogName(MyExcel.Cells(row_cnt, col_cnt).text)
                tdog.SetDogDOB(MyExcel.Cells(row_cnt, col_cnt + 1).value)
                'tdog.SetDogAge()
                DogsList.AddDog(tdog)                                    ' *** the class way
                stmp = CStr(MyExcel.ActiveCell.Row) + " " + CStr(MyExcel.ActiveCell.Column)
                counter = counter + 1
                row_cnt = row_cnt + 1
                '           MyExcel.ActiveCell.Offset(1, 0).Activate() ' move to col 2
                TxtNumOfDogs.Text = counter
            Else
                Exit Do
            End If
        Loop

        'DogsList.Print_dogs_list() ' create text file with list of dogs

        MyExcel.Workbooks.Close()
        MyExcel = Nothing

    End Sub ' of Read_Dog_List 

    Private Sub Read_Pracice_Types_List()
        Dim pname As String
        Dim pnum As Integer

        ' ******  Count Practices types table
        Dim counter = 0
        Dim row_cnt = 2
        Dim col_cnt = 11
        Dim stmp As String

        Dim MyExcel As New Microsoft.Office.Interop.Excel.Application
        'MyExcel.Workbooks.Open(Me.TxtBoxPracticeFile.Text)
        MyExcel.Workbooks.Open(practice_file)
        MyExcel.Workbooks.Open(practice_file)

        Do
            stmp = MyExcel.Cells(row_cnt, col_cnt).text ' get Practice name

            If counter < MAX_NUM_OF_PRACTICES_TYPES And stmp <> "END" Then
                counter = counter + 1

                TxtPracticeTypes.Text = counter
                pname = MyExcel.Cells(row_cnt, col_cnt).text ' class way get Practice name
                pnum = MyExcel.Cells(row_cnt, col_cnt + 1).value ' class way get Practice num
                practiceList.add_practice(pname, pnum)      ' add another practice pair (name and number)
                row_cnt = row_cnt + 1
            Else
                Exit Do
            End If
        Loop

        MyExcel.Workbooks.Close()
        MyExcel = Nothing

    End Sub ' of Read_Pracice_Types_List

    Private Sub Read_sessions_list()
        ' read list pf required practics from practice excel file
        Dim MyExcel As New Microsoft.Office.Interop.Excel.Application
        'MyExcel.Workbooks.Open(Me.TxtBoxPracticeFile.Text)
        MyExcel.Workbooks.Open(practice_file)

        Dim counter = 1
        Dim row_cnt = 2
        Dim col_cnt = 1
        Dim stmp = MyExcel.Cells(row_cnt, col_cnt).text ' get first dog's name

        Do
            Dim s As New Session
            s._logfile = LogFile

            TxtPracticesNum.Text = counter

            Dim dog_name As String = MyExcel.Cells(row_cnt, col_cnt).text
            s.SetdogName(dog_name)
            Dim pract_date As Date = MyExcel.Cells(row_cnt, col_cnt + 1).value
            s.SetPracticeDate(pract_date)
            Dim dog_dob As Date
            Dim bool_find As Boolean = False
            For Each d In DogsList.dogs_List
                If (d.Name = dog_name) Then
                    dog_dob = d.Dob
                    bool_find = True
                End If
            Next

            If bool_find = False Then
                MessageBox.Show("Error in getting DOB")
                Print_to_log_file("Error in getting DOB, dog name: " + dog_name)
            End If

            s.SetDogsAge(pract_date, dog_dob)
            s.SetDogsDOB(dog_dob)

            ' 19 Feb 2020 adding counter to allow debug messages, And abort the message box in SetpracticeType
            s.SetpracticeType(counter, MyExcel.Cells(row_cnt, col_cnt + 2).text, practiceList)
            s.SetstartTime(MyExcel.Cells(row_cnt, col_cnt + 3).text)
            s.SetendTime(MyExcel.Cells(row_cnt, col_cnt + 4).text)
            s.SetvideoNum(MyExcel.Cells(row_cnt, col_cnt + 5).text)
            sessions.add_session(s)

            counter = counter + 1
            row_cnt = row_cnt + 1
            stmp = MyExcel.Cells(row_cnt, col_cnt).text ' get next dog's name
        Loop Until counter > MAX_NUM_OF_PRACTICES Or stmp = "END"

        MyExcel.Workbooks.Close()
        MyExcel = Nothing

    End Sub ' of Read_sessions_list

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles ButCLose.Click
        Me.Close()
    End Sub



    Private Sub TxtBoxWorkDir_TextChanged(sender As Object, e As EventArgs) Handles TxtBoxWorkDir.TextChanged

    End Sub

    Private Sub Button1_Click_3(sender As Object, e As EventArgs)
    End Sub

    Private Sub try3()
    End Sub

    Private Sub RdSessionFiles_Click(sender As Object, e As EventArgs) Handles RdSessionFiles.Click
        Read_session_files()
    End Sub

    Private Sub Read_session_files()
        If Stage_Read_Practice_Table = False Then
            MessageBox.Show("Must read practice file BEFORE reading sessions list")
            Exit Sub
        End If

        ' if we want a quick run for analysis without the long CSV files read
        If skip_CSV_RadioButton.Checked Then
            Exit Sub
        End If

        Read_CSV_Session_files(in_files_dir)
    End Sub

    Private Sub TxtBoxHeader_TextChanged(sender As Object, e As EventArgs)
    End Sub

    '  ***** reading CSV session files ********************
    Public Sub Read_CSV_Session_files(_dir As String)
        Dim pract_Excel As New Microsoft.Office.Interop.Excel.Application
        Dim dog_session As New DogSession

        Dim file_count As Integer = 0
        Dim fileName As String
        'Dim session_num As Integer
        Dim no_match_cnt As Integer = 0
        Dim match_cnt As Integer = 0
        Dim pet_name As String
        Dim pet_id As String
        Dim csv_start_date As DateTime
        Dim csv_end_date As DateTime
        Dim total_lines_of_csv As Integer = 0

        RdSessionFiles.BackColor = Color.GreenYellow
        num_of_lines_TextBox.BackColor = Color.Yellow
        num_of_lines_TextBox.Text = "starting"

        Print_to_log_file("Start reading CSV files")
        Print_to_log_file("Dir is: " + _dir)

        fileName = Dir(_dir & csv_pattern)

        Do While fileName <> ""
            Dim curr_session As New Session_CSV_file
            file_count += 1

            Print_to_log_file("Start reading CSV file: " + _dir + fileName)
            '** Open CSV file
            pract_Excel.Workbooks.Open(_dir + fileName)
            ' ** Get pet & date info about this session
            pet_name = pract_Excel.Cells(2, 1).text.Replace("Pet name: ", "").Replace(" ", "")
            curr_session.pet_name = pet_name
            pet_id = pract_Excel.Cells(2, 2).text.Replace("Pet id: ", "").Replace(" ", "")
            curr_session.pet_ID = pet_id
            Print_to_log_file("Pet name & ID: " + pet_name + " / " + pet_id)

            ' get the start date & end date of this session file
            Dim s1 As String = pract_Excel.Cells(1, 1).text.Replace("From:", "").Replace(" ", "")

            Dim t_bool As Boolean = Date.TryParseExact(s1, "MM/dd/yyyy",
                               Globalization.CultureInfo.InvariantCulture,
                               Globalization.DateTimeStyles.None, csv_start_date)
            curr_session.session_start_time = csv_start_date ' Oct 23, 2019
            'curr_session.session_end_time = csv_end_date
            If (t_bool = False) Then
                MessageBox.Show("Error E1 while checking CSV file date")
                Console.WriteLine("Error E1 while checking CSV file date")
            End If

            s1 = pract_Excel.Cells(1, 2).text.Replace("To:", "").Replace(" ", "")

            t_bool = Date.TryParseExact(s1, "MM/dd/yyyy",
                               Globalization.CultureInfo.InvariantCulture,
                               Globalization.DateTimeStyles.None, csv_end_date)
            curr_session.session_end_time = csv_end_date ' Oct 23 2019
            If (t_bool = False) Then
                MessageBox.Show("Error E2 while checking CSV file date")
                Console.WriteLine("Error E2 while checking CSV file date")
            End If

            Dim line_Cnt As Integer = 3

            ' columns to ignore: source, fever indication, position, position duration, 
            '                   activity group, manual data note, manual data value
            ' lines to ignore: fever indication, position

            Dim line_data_type As String = "BLABLA"   ' just to enter the loop
            Dim line_date As DateTime = Nothing
            Dim prev_line_date As DateTime = Nothing ' just to start the loop
            Dim same_time As Boolean
            'Dim to_ignore As New List(Of String)
            'to_ignore.Add("Fever Indication")
            'to_ignore.Add("Position")
            Dim posi_cnt As Integer = 0
            Dim acti_cnt As Integer = 0
            Dim pulse_cnt As Integer = 0
            Dim resp_cnt As Integer = 0
            Dim vvti_cnt As Integer = 0
            Dim sleep_score_cnt = 0
            Dim activity_score_cnt = 0

            'Dim line_data As New Session_CSV_file.dog_data
            Dim prev_line_data As New Session_CSV_file.dog_data
            'Dim line_data As New Session_CSV_file.dog_data


            Dim pos_tmp As String
            Dim pos_flag As Boolean = False
            Dim pos_dur_tmp As Integer
            Dim pos_dur_flag As Boolean = False
            Dim activity_tmp As Double
            Dim activity_flag As Boolean = False
            Dim pulse_tmp As Integer
            Dim pulse_flag As Boolean = False
            Dim resp_tmp As Integer
            Dim resp_flag As Boolean = False
            Dim vvti_tmp As Double
            Dim vvti_flag As Boolean = False
            Dim sleep_score_tmp As Double
            Dim sleep_score_flag As Boolean = False
            Dim activity_score_tmp As Integer
            Dim activity_score_flag As Boolean = False

            Dim first_cycle = True
            Dim tmp_value As Boolean = False  ' to indicate there was a valur


            ' ** read lines from CSV file, line after line
            While (line_data_type <> "")
                line_Cnt += 1
                total_line_cnt += 1
                num_of_lines_TextBox.Text = total_line_cnt.ToString()
                line_data_type = pract_Excel.Cells(line_Cnt, 1).Text

                prev_line_date = line_date
                line_date = pract_Excel.Cells(line_Cnt, 2).value
                line_date = line_date.AddSeconds(-line_date.Second) ' 31 Oct 
                If Not first_cycle Then

                    If line_date = prev_line_date Then
                        same_time = True
                    ElseIf tmp_value Then
                        same_time = False
                        Dim line_data As New Session_CSV_file.Dog_data
                        line_data.activity = activity_tmp
                        line_data.activity_flag = activity_flag
                        line_data.pract_type = line_data_type
                        line_data.pract_time = prev_line_date
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

                        activity_tmp = Nothing
                        activity_flag = False
                        pos_tmp = Nothing
                        pos_flag = False
                        pos_dur_tmp = Nothing
                        pos_dur_flag = False
                        pulse_tmp = Nothing
                        pulse_flag = False
                        resp_tmp = Nothing
                        resp_flag = False
                        vvti_tmp = Nothing
                        vvti_flag = False

                        tmp_value = False
                    End If

                End If

                first_cycle = False ' good only for first run of the while loop
                'If (Not same_time) Then
                ' curr_session.List_of_dog_data.Add(line_data)
                ' line_date = Nothing
                ' End If

                'line_data.pract_type = line_data_type
                'line_data.pract_time = line_date

                ' now collect the data according to the data type

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
                        activity_tmp = pract_Excel.Cells(line_Cnt, 7).value
                        activity_flag = True
                        tmp_value = True
                    Case "Pulse"
                        pulse_cnt += 1
                        'line_data.pulse = pract_Excel.Cells(line_Cnt, 9).value
                        pulse_tmp = pract_Excel.Cells(line_Cnt, 9).value
                        pulse_flag = True
                        tmp_value = True
                    Case "Respiration"
                        resp_cnt += 1
                        'line_data.respiration = pract_Excel.Cells(line_Cnt, 10).value
                        resp_tmp = pract_Excel.Cells(line_Cnt, 10).value
                        resp_flag = True
                        tmp_value = True
                    Case "VVTI"
                        vvti_cnt += 1
                        'line_data.vvti = pract_Excel.Cells(line_Cnt, 11).value
                        vvti_tmp = pract_Excel.Cells(line_Cnt, 11).value
                        vvti_flag = True
                        tmp_value = True
                    Case "Sleep"
                        sleep_score_cnt += 1
                        sleep_score_tmp = pract_Excel.Cells(line_Cnt, 14).value
                        sleep_score_flag = True
                        tmp_value = True
                    Case "Activity Score"
                        activity_score_cnt += 1
                        activity_score_tmp = pract_Excel.Cells(line_Cnt, 15).value
                        activity_score_flag = True
                        tmp_value = True
                    Case "Fever Indication"
                        ' do nothing
                    Case "Position"
                        ' do nothing
                    Case "Position Score"
                        ' do nothing

                    Case Else
                        Console.WriteLine("Wrong place in case of data type in CSV lines")
                        Console.WriteLine("line number: " + line_Cnt.ToString())
                End Select


                '        Console.WriteLine(lineDate.ToString() + "  " + lineTime.ToString())
                'If Not same_time Then
                'End If

            End While ' keep reading lines from this CSV file
            total_lines_of_csv += line_Cnt

            Print_to_log_file("Total number of lines read: " + line_Cnt.ToString())
            Print_to_log_file("Lines with Position       : " + posi_cnt.ToString())
            Print_to_log_file("Lines with Activity       : " + acti_cnt.ToString())
            Print_to_log_file("Lines with Pulse          : " + pulse_cnt.ToString())
            Print_to_log_file("Lines with Respiration    : " + resp_cnt.ToString())
            Print_to_log_file("Lines with VVTI           : " + vvti_cnt.ToString())
            Print_to_log_file("Lines with Sleep score    : " + sleep_score_cnt.ToString())
            Print_to_log_file("Lines with Activity score : " + activity_score_cnt.ToString())

            pract_Excel.Workbooks.Close()
            total_sessions.Add(curr_session)

            num_of_lines_TextBox.Text = total_line_cnt.ToString()

            fileName = Dir()
            Console.WriteLine(" finished file number " + file_count.ToString())
            Console.WriteLine("Pet name & ID: {0} {1} ", dog_session.pet_name, dog_session.pet_ID)
        Loop ' go and read next CSV file

        Print_to_log_file("Total lines read      : " + total_lines_of_csv.ToString())
        Print_to_log_file("file count            : " + file_count.ToString())
        Print_to_log_file("Had a match           : " + match_cnt.ToString())
        Print_to_log_file("Failed to find a match: " + no_match_cnt.ToString())

        'MyExcel.Workbooks.Close(Me.TxtBoxPracticeFile.Text)
        ProgressBar1.Value = 75
        RdSessionFiles.BackColor = Color.Green

        num_of_lines_TextBox.BackColor = Color.Green

        RdSessionFiles.BackColor = Color.Green

    End Sub ' of Read_Session_files



    ' Control k c - to comment all ines, Control k u - to uncomment
    Public Sub ReadFromExcel()
        'Dim dt As DataTable = New DataTable("table")
        'Dim csBuilder As OleDbConnectionStringBuilder = New OleDbConnectionStringBuilder
        'csBuilder.Provider = "Microsoft.ACE.OLEDB.12.0"
        'csBuilder.DataSource = "..\..\Table.xlsx"
        'csBuilder.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES")
        'Dim connection As OleDbConnection = New OleDbConnection(csBuilder.ConnectionString)
        'connection.Open
        'Dim query As String = "SELECT * FROM Sample"
        'Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(query, connection)
        'adapter.FillSchema(dt, SchemaType.Source)
        'adapter.Fill(dt)
        'For Each row As DataRow In dt.Rows
        '    For Each item In row.ItemArray
        '        Console.WriteLine(item)
        '    Next
        'Next

    End Sub

    Sub Print_sessions_log(_str As String, Optional _keep As Boolean = True)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(SessionsFile, _keep)
        file.WriteLine(_str)
        file.Close()
    End Sub ' Print_to_log_file


    Sub Print_to_log_file(_str As String, Optional _keep As Boolean = True)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(LogFile, _keep)
        file.WriteLine(_str)
        file.Close()
    End Sub ' Print_to_log_file

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Time_from_start.Text = Date.Now.ToString()
        ' Run ALL stages 
        ProgressBar1.Value = 1

        If check_files_and_folders() = False Then
            'MessageBox.Show("Missing files or folders. Look at LOG file")
            Return
        End If

        Button3.BackColor = Color.GreenYellow
        Status_Box.Text = "Starting"
        Status_Box.BackColor = Color.Yellow

        Status_Box.Text = "Checking files and folders"

        ProgressBar1.Value = 10
        Status_Box.Text = "Reading practice file"
        ReadPracticeFile() ' with dogs DOB but not age (depends on sessions day)
        ProgressBar1.Value = 30

        Status_Box.Text = "Reading Session files headers"
        ReadSessionsHeader(in_files_dir) ' 13 Nov 2019 (parallel to prev run)

        Status_Box.Text = "Locating matches"
        Dim num_of_matches As Integer
        num_of_matches = Find_matches() ' 13 Nov 2019 (parallel to prev run)
        If num_of_matches = 0 Then
            MessageBox.Show("No Matches found")
            Return
        End If

        ProgressBar1.Value = 50
        RdSessionFiles.BackColor = Color.GreenYellow
        num_of_lines_TextBox.BackColor = Color.Yellow
        num_of_lines_TextBox.Text = "starting"

        Status_Box.Text = "Reading relevant CSV files"
        'Return

        If skip_CSV_RadioButton.Checked Then
            Return
        End If
        Read_relevant_CSV_files()
        num_of_lines_TextBox.BackColor = Color.Green
        ProgressBar1.Value = 75
        Status_Box.Text = "Creating results files"
        Create_results_new(total_sessions, TxtPreTime.Value, TxtPostTime.Value,
                           result_out_file_name, sleep_out_file_name)
        ProgressBar1.Value = 90

        Status_Box.Text = "Creating statistics"
        create_statistics()

        Status_Box.Text = "Finished"
        Status_Box.BackColor = Color.Green
        ProgressBar1.Value = 100
        Button3.BackColor = Color.Green

        'Return
        ' old flow
        'ProgressBar1.Value = 40
        'Read_session_files()
        'check_sessions()
        'Create_results()
        'create_statistics()
        'ProgressBar1.Value = 100
        'Button3.BackColor = Color.Green
    End Sub

    Private Sub Read_relevant_CSV_files()
        ' 13 Nov 2019 in parallel to previous working  - read CSV, only those who are in the matching list 

        Print_to_log_file("in read_relevant_CSV_files, reading CSV files (onlt those who have a match")

        Dim total_lines_cnt As Integer = 0
        Dim current_lines_cnt As Integer
        Dim num_of_file_read As Integer = 0

        num_of_lines_TextBox.BackColor = Color.Yellow

        For Each s In sessions.sessionsList
            If s.csv_fname = Nothing Then
                Continue For
            End If
            Print_to_log_file("working on file: " + s.csv_fname)
            'TBD read the specific CSV file
            total_sessions.Add(Read_CSV_file(s.csv_fname, s.dog_age, s.practiceType, s.practiceNum,
                                             s.startTime, s.endTime,
                                             TxtPreTime.Value, TxtPostTime.Value, current_lines_cnt))
            total_lines_cnt += current_lines_cnt
            num_of_lines_TextBox.Text = total_lines_cnt
            num_of_file_read += 1
            Num_Of_files_read.Text = num_of_file_read.ToString()
            Num_Of_files_read.BackColor = Color.Yellow

        Next
        Num_Of_files_read.BackColor = Color.Green
    End Sub

    Private Function Find_matches() As Integer
        ' find if there are matches between list of practices (from practice file) and CSV files

        Dim match_flag As Boolean
        Dim match_cnt As Integer = 0
        Dim no_match_cnt As Integer = 0
        Dim stmp As String

        Dim session_cnt As Integer = 0

        Print_to_log_file("In Find matches, searching for matches ")
        ' mark all files as "have no match". Later in the loop, matches will be marked
        For Each p In CSV_files_headers
            p.has_a_match = False
        Next


        For Each s In sessions.sessionsList
            session_cnt += 1
            numOfPratices_read.Text = session_cnt.ToString() ' 20 Feb 2020
            match_flag = False
            Dim csv_files_cnt As Integer = 0
            For Each p In CSV_files_headers
                ' p.has_a_match = False
                csv_files_cnt += 1
                If s.dogName = p.dog_name And s.practiceDate = p.start_day Then
                    ' we have a match
                    match_flag = True
                    match_cnt += 1

                    s.csv_fname = p.csv_fname
                    p.has_a_match = True

                    stmp = match_cnt.ToString() + " ) "
                    stmp += "Match found for session " + session_cnt.ToString
                    stmp += " >> s.dogName: " + s.dogName + " s.practiceDate: " + s.practiceDate
                    'Print_to_log_file("Match found for session " + session_cnt.ToString)
                    Print_to_log_file(stmp)
                End If
                Matches_box.Text = match_cnt.ToString()
            Next ' of foreach p

            If match_flag = False Then
                no_match_cnt += 1
                stmp = no_match_cnt.ToString() + " ) "
                stmp += "--------*** NO Match of for session " + session_cnt.ToString
                stmp += " >> s.dogName: " + s.dogName + " s.practiceDate: " + s.practiceDate
                'Print_to_log_file("*** Match was NOT found for session " + session_cnt.ToString)
                'Print_to_log_file("s.dogName: " + s.dogName + "s.practiceDate: " + s.practiceDate)
                Print_to_log_file(stmp)
            End If

        Next ' of foreach s

        Print_to_log_file("**********************************")
        Print_to_log_file("Total    matches: " + match_cnt.ToString())
        Print_to_log_file("Total NO matches: " + no_match_cnt.ToString())
        Print_to_log_file("**********************************")
        Print_to_log_file("")


        ' 20 Feb 20 look to print all files that have no match 
        Print_to_log_file("Files that had no match - not used")
        For Each p In CSV_files_headers
            If p.has_a_match = False Then
                Print_to_log_file("No match for file: " + p.csv_fname)
            End If

        Next




        Dim line_str_tmp As String
        Dim tmp_csv_name As String ' sometimes CSV file name can be nothing, so prevent run time error

        ' printe header to file, before pronting all lines
        line_str_tmp = "Dog Name".PadRight(10) + " , " +
                "practice Type".PadRight(10) + " , " + "Practice Date" + "CSV file name".PadRight(10) + " , "
        Print_sessions_log(line_str_tmp)

        For Each s In sessions.sessionsList
            If s.csv_fname = Nothing Then
                tmp_csv_name = " "
            Else
                ' print only sessions that have CSV files assigned
                tmp_csv_name = s.csv_fname
                line_str_tmp = s.dogName.PadRight(10) + "," +
                            s.practiceType.PadRight(10) + "," + s.practiceDate.ToString().PadRight(10) + "," + tmp_csv_name.PadRight(10)
                Print_sessions_log(line_str_tmp)
            End If
        Next
        Return match_cnt
    End Function



    Private Sub ReadSessionsHeader(_dir As String)
        Dim csv_fname As String
        Dim f_cnt As Integer = 0
        Dim CSV_header_tmp As New CSV_file_header
        'CSV_header_tmp = 

        csv_fname = Dir(_dir & csv_pattern)

        Do While csv_fname <> ""
            f_cnt += 1
            CSV_files_headers.Add(CSV_header_tmp.CSV_header_read(_dir + csv_fname))
            Console.WriteLine(" finished reading CSV file header: " + f_cnt.ToString() + ") " + csv_fname)
            Print_to_log_file(" finished reading CSV file header: " + f_cnt.ToString() + ") " + csv_fname)
            csv_fname = Dir()
        Loop ' go and read next CSV file
        ' *** now alll headers of CSV files are inside CSV_files_headers
        ' ** now let's see if there is  match for every entry in the practice file
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles num_of_lines_TextBox.TextChanged

    End Sub

    Private Sub chk_sessions_button_Click(sender As Object, e As EventArgs) Handles chk_sessions_button.Click
        check_sessions()
    End Sub

    Private Sub check_sessions()
        'find if sessions have relevant session file
        chk_sessions_button.BackColor = Color.GreenYellow

        Dim sessio_num As Integer = 0
        Dim match_cnt As Integer

        For Each s In sessions.sessionsList
            For Each f In total_sessions
                match_cnt = 0
                '                Console.WriteLine(s.practiceDate.ToString)
                '                Console.WriteLine(f.session_start_time.ToString())
                If (s.practiceDate = f.session_start_time) Then

                    s.list_of_CSV_matches.Add(match_cnt)

                    Console.WriteLine("Match")
                    match_cnt += 1
                End If

            Next ' of foreach f
            '  Print_to_log_file("Session " & sessio_num.ToString() & " has " & match_cnt & " matches")
        Next    ' of foreach s

        Print_to_log_file("re-print all matches")

        sessio_num = 0
        For Each c In sessions.sessionsList
            sessio_num += 1
            Dim c_cnt As Integer = 0
            For Each t In c.list_of_CSV_matches
                c_cnt += 1
            Next
            Print_to_log_file("Session " & sessio_num.ToString() & " has " & c_cnt & " matches")

        Next

        chk_sessions_button.BackColor = Color.Green

    End Sub

    Private Sub Create_results_button_Click(sender As Object, e As EventArgs) Handles Create_results_button.Click
        Create_results()
    End Sub

    Private Sub Create_results()
        Create_results_button.BackColor = Color.GreenYellow
        output_lines_textbox.Text = "starting"

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

        For Each s In sessions.sessionsList
            For Each c In s.list_of_CSV_matches
                ' go over all relevant CSV files 
                Console.WriteLine("looking at c         : " & c.ToString())
                Console.WriteLine("looking at dog       : " & sessions.sessionsList(c).dogName)
                Console.WriteLine("looking at pract date: " & sessions.sessionsList(c).practiceDate)
                Console.WriteLine("looking at pract type: " & sessions.sessionsList(c).practiceType)
                Console.WriteLine("looking at start     : " & sessions.sessionsList(c).startTime)
                Console.WriteLine("looking at end       : " & sessions.sessionsList(c).endTime)

                Dim dog_data_cnt As Integer = -1
                Dim prev_date As Date = Nothing
                Dim prev_pract_time As Date = Nothing



                For Each l In total_sessions(c).List_of_dog_data
                    dog_data_cnt += 1

                    Dim l_start = sessions.sessionsList(c).practiceDate.Add(sessions.sessionsList(c).startTime.TimeOfDay)
                    Dim l_end = sessions.sessionsList(c).practiceDate.Add(sessions.sessionsList(c).endTime.TimeOfDay)
                    Dim l_start_pre_time As DateTime = l_start.AddMinutes(-TxtPreTime.Value)
                    Dim l_end_post_time As DateTime = l_end.AddMinutes(TxtPreTime.Value)

                    If l.pract_time < l_start_pre_time Then
                        Continue For
                    End If
                    If l.pract_time > l_end_post_time Then
                        Continue For
                    End If

                    ' Means that time is within pre/act/post
                    Dim l_time_zone As Integer

                    If l.pract_time < l_start Then
                        l_time_zone = 1
                    ElseIf l.pract_time <= l_end Then
                        l_time_zone = 2
                    Else
                        l_time_zone = 3
                    End If

                    xlWorksheet.Cells(out_line_cnt, 1) = total_sessions(c).pet_ID

                    ' get Dog's age
                    ' Console.WriteLine("Dog's name: " + total_sessions(c).pet_name)
                    ' calc dog age at time of the session
                    Dim l_pet_dob As Date = DogsList.GetDogDob(total_sessions(c).pet_name)
                    Dim l_pract_date As Date = sessions.sessionsList(c).practiceDate
                    Dim ageindays As TimeSpan = l_pract_date - l_pet_dob
                    Dim l_age = Int(ageindays.Days / 7)
                    xlWorksheet.Cells(out_line_cnt, 2) = l_age

                    'session's date
                    xlWorksheet.Cells(out_line_cnt, 3) = total_sessions(c).session_start_time
                    'xlWorksheet.Cells(out_line_cnt, 4) = sessions.sessionsList(c).sessionOnAday
                    xlWorksheet.Cells(out_line_cnt, 4) = sessions.Count_num_of_sessions_per_day(total_sessions(c).pet_name, l_pract_date)

                    ' find the practice type number in the practices table
                    Dim l_pract = -77
                    For Each p In practiceList.practicesList
                        If sessions.sessionsList(c).practiceType = p.praticeName Then
                            l_pract = p.practiceNum
                        End If

                    Next

                    xlWorksheet.Cells(out_line_cnt, 5) = l_pract
                    xlWorksheet.Cells(out_line_cnt, 6) = sessions.sessionsList(c).predictability.ToString()
                    xlWorksheet.Cells(out_line_cnt, 7) = sessions.sessionsList(c).videoNum
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

                    ' 2o OCt trials
                    'Dim xx As String
                    'xx = Format(l.pract_time, "HH:mm")

                    xlWorksheet.Cells(out_line_cnt, 9) = l1.ToString("HH:mm")
                    xlWorksheet.Cells(out_line_cnt, 10) = l2.ToString("HH:mm")
                    'xlWorksheet.Cells(out_line_cnt, 11) = l.pract_time 21 Oct 2019, nove to 24h clock
                    xlWorksheet.Cells(out_line_cnt, 11) = Format(l.pract_time, "HH:mm")
                    'xlWorksheet.Cells(out_line_cnt, 12) = total_sessions(c).get_activity(c)

                    If total_sessions(c).List_of_dog_data(dog_data_cnt).activity_flag Then
                        xlWorksheet.Cells(out_line_cnt, 12) = total_sessions(c).List_of_dog_data(dog_data_cnt).activity
                    End If

                    If total_sessions(c).List_of_dog_data(dog_data_cnt).pulse_flag Then
                        xlWorksheet.Cells(out_line_cnt, 13) = total_sessions(c).List_of_dog_data(dog_data_cnt).pulse
                    End If

                    If total_sessions(c).List_of_dog_data(dog_data_cnt).resp_flag Then
                        xlWorksheet.Cells(out_line_cnt, 14) = total_sessions(c).List_of_dog_data(dog_data_cnt).respiration
                    End If

                    If total_sessions(c).List_of_dog_data(dog_data_cnt).vvti_flag Then
                        xlWorksheet.Cells(out_line_cnt, 15) = total_sessions(c).List_of_dog_data(dog_data_cnt).vvti
                    End If


                    If total_sessions(c).List_of_dog_data(dog_data_cnt).sleep_flag Then
                        xlWorksheet.Cells(out_line_cnt, 16) = total_sessions(c).List_of_dog_data(dog_data_cnt).sleep
                    End If

                    If total_sessions(c).List_of_dog_data(dog_data_cnt).activity_flag Then
                        xlWorksheet.Cells(out_line_cnt, 17) = total_sessions(c).List_of_dog_data(dog_data_cnt).activity_score
                    End If

                    output_lines_textbox.Text = (out_line_cnt - 1).ToString()

                    If (prev_date <> total_sessions(c).session_start_time) Or (prev_pract_time <> l.pract_time) Then
                        'out_line_cnt += 1
                    End If

                    prev_date = total_sessions(c).session_start_time

                    out_line_cnt += 1    '23 Oct 2019
                    'dog_data_cnt += 1

                Next ' of total_sessions(c).List_of_dog_data


                xlWorksheet.Cells(1, 4).Interior.Color = Color.Green

                result_out_file_name = out_files_dir + "course_" + course_name + "out.xlsx"
                Dim t As String = result_out_file_name.Replace("\\", "^^")
                Dim t1 = result_out_file_name.Replace("^^", "\")

                Dim t2 As String = t1.Replace("\\", "\")
                result_out_file_name = result_out_file_name.Replace("\\", "\")

                Print_to_log_file("Out file name is: " + result_out_file_name)
            Next ' of s.list_of_CSV_matches
        Next ' of foreach sessions.sessionsList

        ' **** save the result file ******
        If File.Exists(result_out_file_name) Then
            Print_to_log_file("outfile " + result_out_file_name + "renaming")
            Dim fn As String = Path.GetFileNameWithoutExtension(result_out_file_name)
            Dim ext As String = Path.GetExtension(result_out_file_name)
            'Dim fn_with_ext As String = Path.GetFileName(f1)
            'Dim fn_plus_path As String = Path.GetFullPath(f1)
            Dim dir As String = Path.GetDirectoryName(result_out_file_name)
            fn = fn + "_old"

            Dim new_out_file_name As String = Path.Combine(dir, fn + ext)
            If File.Exists(new_out_file_name) Then
                File.Delete(new_out_file_name)
            End If

            File.Move(result_out_file_name, new_out_file_name)
        End If

        xlWorksheet.SaveAs(result_out_file_name)
        ' result_out_file_name

        xlWorkbook.Close()
        xlApp.Quit()

        xlApp = Nothing
        xlWorkbook = Nothing
        xlWorksheet = Nothing

        'TBD

        Create_results_button.BackColor = Color.Green
    End Sub ' of Create_results

    Private Sub Create_stats_button_Click(sender As Object, e As EventArgs) Handles Create_stats_button.Click
        create_statistics()
    End Sub

    Private Sub create_statistics()
        Create_stats_button.BackColor = Color.GreenYellow
        ' TBD

        Create_stats_button.BackColor = Color.Green
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PreChecks_Click(sender As Object, e As EventArgs) Handles PreChecks.Click

        check_files_and_folders()

    End Sub

    Private Sub TxtBoxPracticeFile_TextChanged(sender As Object, e As EventArgs) Handles TxtBoxPracticeFile.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Header_label_Click(sender As Object, e As EventArgs) Handles Header_label.Click

    End Sub


End Class

