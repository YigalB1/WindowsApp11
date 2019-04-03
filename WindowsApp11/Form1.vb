'Add a reference To Microsoft Excel Object Library. To Do this, follow these steps
'On the Project menu, click Add Reference.
'On the COM tab, locate Microsoft Excel Object Library, And then click Select. 
'Imports System.Data.OleDb
'Imports Console = System.Console
Imports System.Data.OleDb
Imports Microsoft.Office.Interop

Public Class Form1


    Public in_PathName As String = "C:\\Users\\yigal\\Documents\\Yigal\\DogsProj\\SessionsFiles\\"
    Public default_work_dir As String = "C:\\Users\\yigal\\Documents\\Yigal\\DogsProj\\"
    Public default_sessions_dir As String = "C:\\Users\\yigal\\Documents\\Yigal\DogsProj\\" + "SessionsFiles\\"
    Public default_pratice_file_name As String = "C:\\Users\\yigal\\Documents\\Yigal\\DogsProj\\practice_list1.xlsx"
    Public LogFile = "C:\\Users\\yigal\\Documents\\Yigal\\DogsProj\\logDog.txt"
    Public csv_pattern As String = "export-all-Bell-11302018_083229.csv"
    ' *083229.csv

    Public result_out_file_name As String = "C:\Users\yigal\Documents\Yigal\DogsProj\result_output1.xlsx"

    Dim DogsList As New DogsListClass
    Dim practiceList As New PracticesList
    Dim sessions As New List_of_Sessions
    Dim total_sessions As New List(Of Session_file) ' will include all CSV files contect

    Dim Stage_Read_Practice_Table As Boolean = False
    Dim Stage_Read_Session_Files As Boolean = False

    Dim total_line_cnt As Integer



    Dim MAX_NUM_OF_DOGS As Integer = 50
    Dim MAX_NUM_OF_PRACTICES As Integer = 500
    Dim MAX_NUM_OF_PRACTICES_TYPES As Integer = 50

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

    Public Sub ShowEvent(sender As Object, e As EventArgs) Handles Me.Shown
        ' ****** STARTs AUTOMATICALLY running WITH FORM

        'set default directory
        TxtBoxWorkDir.Text = default_work_dir
        'TxtBoxWorkDir.Text = "C:\Users\yigal\Documents\Yigal\DogsProj\"
        TxtBoxSessionDir.Text = default_sessions_dir
        'TxtBoxSessionDir.Text = TxtBoxWorkDir.Text + "SessionsFiles\"

        TxtBoxPracticeFile.Text = default_pratice_file_name
        'TxtBoxPracticeFile.Text = TxtBoxWorkDir.Text + "practice_list1.xlsx"

        ' count files in session directory
        Dim FilesInFolder As Integer = 0
        Dim d As New System.IO.DirectoryInfo(TxtBoxSessionDir.Text)
        Dim intFiles As Integer
        intFiles = d.GetFiles.GetUpperBound(0) + 1
        TxtBoxNumOfFiles.Text = intFiles.ToString

        ' Display picture
        PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
        PictureBox1.Refresh()

        ' set color before usage
        RdPracticeFile.BackColor = Color.Yellow

        ProgressBar1.Value = 10

    End Sub

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
        'Print_to_log_file("Reading Practice file " + Date.Now(), False)
        'Print_to_log_file("Practice file: " + Me.TxtBoxPracticeFile.Text)
        'Print_to_log_file("------------------------------")



        'RdPracticeFile.BackColor = Color.GreenYellow

        'Console.BackgroundColor = ConsoleColor.Blue
        'Console.WriteLine(" ......STARTING.................")
        'Console.BackgroundColor = ConsoleColor.White


        'Read_Dog_List()
        'DogsList.Print_dogs_list() ' create text file with list of dogs
        'ProgressBar1.Value = 40

        'Read_Pracice_Types_List()
        'practiceList.Print_practices_list() ' the class way
        'ProgressBar1.Value = 50

        'Read_sessions_list()
        'sessions.Print_sessions_list()
        'ProgressBar1.Value = 60

        ''        Dim pname As String
        ''        Dim pnum As Integer


        'RdPracticeFile.BackColor = Color.Green
        'Stage_Read_Practice_Table = True

    End Sub ' of RdPracticeFile_Click (invoked from button)



    Private Sub ReadPracticeFile()

        Print_to_log_file("Reading Practice file " + Date.Now(), False)
        Print_to_log_file("Practice file: " + Me.TxtBoxPracticeFile.Text)
        Print_to_log_file("------------------------------")



        RdPracticeFile.BackColor = Color.GreenYellow

        Console.BackgroundColor = ConsoleColor.Blue
        Console.WriteLine(" ......STARTING.................")
        Console.BackgroundColor = ConsoleColor.White


        Read_Dog_List()
        DogsList.Print_dogs_list() ' create text file with list of dogs
        ProgressBar1.Value = 40

        Read_Pracice_Types_List()
        practiceList.Print_practices_list() ' the class way
        ProgressBar1.Value = 50

        Read_sessions_list()
        sessions.Print_sessions_list()
        ProgressBar1.Value = 60

        '        Dim pname As String
        '        Dim pnum As Integer


        RdPracticeFile.BackColor = Color.Green
        Stage_Read_Practice_Table = True

    End Sub ' of RdPracticeFile





    Private Sub Read_Dog_List()
        ' Reading dogs from practice file
        ' *******************************
        ' Dim DogsList As New DogsListClass   ' *** the Class way
        Dim counter As Integer = 0
        Dim row_cnt As Integer = 2
        Dim col_cnt As Integer = 12
        Dim stmp As String

        Dim MyExcel As New Microsoft.Office.Interop.Excel.Application
        MyExcel.Workbooks.Open(Me.TxtBoxPracticeFile.Text)

        counter = 0
        Do

            If counter < MAX_NUM_OF_DOGS And MyExcel.Cells(row_cnt, col_cnt).text <> "END" Then

                Dim tdog As New DogClass  ' *** the Class way
                tdog.SetDogName(MyExcel.Cells(row_cnt, col_cnt).text)
                tdog.SetDogDOB(MyExcel.Cells(row_cnt, col_cnt + 1).value)
                tdog.SetDogAge()

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
        Dim col_cnt = 9
        Dim stmp As String

        Dim MyExcel As New Microsoft.Office.Interop.Excel.Application
        MyExcel.Workbooks.Open(Me.TxtBoxPracticeFile.Text)

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
        MyExcel.Workbooks.Open(Me.TxtBoxPracticeFile.Text)

        Dim counter = 1
        Dim row_cnt = 2
        Dim col_cnt = 1
        Dim stmp = MyExcel.Cells(row_cnt, col_cnt).text ' get first dog's name

        Do
            Dim s As New Session

            TxtPracticesNum.Text = counter

            s.SetdogName(MyExcel.Cells(row_cnt, col_cnt).text)
            s.SetPracticeDate(MyExcel.Cells(row_cnt, col_cnt + 1).value)
            s.SetpracticeType(MyExcel.Cells(row_cnt, col_cnt + 2).text)
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


    Private Sub Button1_Click_2(sender As Object, e As EventArgs)
        BoxDogsList.Items.Add("xxx".PadRight(10, " ") + CStr(17))
    End Sub

    Private Sub TxtBoxWorkDir_TextChanged(sender As Object, e As EventArgs) Handles TxtBoxWorkDir.TextChanged

    End Sub

    'Private Sub ReadPracticeFile()
    '    ' TBD, Not used in code
    '    ' Reads directly from file to dataset
    '    Dim practice_connection As System.Data.OleDb.OleDbConnection
    '    Dim DtSet As System.Data.DataSet
    '    Dim my_command As System.Data.OleDb.OleDbDataAdapter

    '    practice_connection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data source='C:\\Users\\yigal\\Documents\\Yigal\\DogsProj\\practice_list.xlsx';Extended Properties = Excel 8.0")
    '    my_command = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", practice_connection)
    '    my_command.TableMappings.Add("Table", "TestTable")
    '    DtSet = New System.Data.DataSet()
    '    my_command.Fill(DtSet)

    '    DataGridView1.DataSource = DtSet.Tables
    '    practice_connection.Close()


    'End Sub

    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles Button1.Click

        Dim xlApp As New Excel.Application
        Dim xlWorkbook As Excel.Workbook = xlApp.Workbooks.Add()
        Dim xlWorksheet As Excel.Worksheet = CType(xlWorkbook.Sheets("sheet1"), Excel.Worksheet)

        xlWorksheet.Cells(1, 1) = "Dog"
        xlWorksheet.Cells(1, 2) = "Age"
        xlWorksheet.Cells(1, 3) = "Date"
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

        xlWorksheet.Cells(1, 4).Interior.Color = Color.Yellow


        'Cells(1, 4).Interior.Color = Color.Yellow


        'xlWorksheet.Cells.Range(1, 4).Interior.Color = Color.Yellow


        ' Selection.Rows(Counter).Interior.Pattern = xlGray16



        Dim s1 As String = "C:\Users\yigal\Documents\Yigal\DogsProj\result_output1.xlsx"
        xlWorksheet.SaveAs(result_out_file_name)
        ' result_out_file_name

        xlWorkbook.Close()
        xlApp.Quit()

        xlApp = Nothing
        xlWorkbook = Nothing
        xlWorksheet = Nothing





        'Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
        'Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        'Dim xls As New Microsoft.Office.Interop.Excel.Application

        'Dim resourcesFolder = IO.Path.GetFullPath(Application.StartupPath & "\..\..\Resources\")
        'Dim fileName = "trial.xlsx"

        ''xlsWorkBook = xls.Workbooks.Open(resourcesFolder & fileName)
        'xlsWorkBook = xls.Workbooks.Open(result_out_file_name)
        'xlsWorkSheet = xlsWorkBook.Sheets("Sheet1")

        ''xlsWorkSheet.Cells(1, 1) = "11"
        'xlsWorkSheet.Cells(1, 1) = "11"
        'xlsWorkSheet.Cells(1, 2) = "12"
        'xlsWorkSheet.Cells(1, 3) = "13"
        'xlsWorkSheet.Cells(2, 1) = "21"
        'xlsWorkSheet.Cells(2, 2) = "22"
        'xlsWorkSheet.Cells(2, 3) = "23"

        'xlsWorkBook.Close()
        'xls.Quit()



        'Dim MyExcel As New Microsoft.Office.Interop.Excel.Application
        'MyExcel.Workbooks.Open(result_out_file_name)

        'MyExcel.Cells(1, 1).text = "11"
        'MyExcel.Cells(1, 2).text = "12"
        'MyExcel.Cells(1, 3).text = "13"
        'MyExcel.Cells(2, 1).text = "21"
        'MyExcel.Cells(2, 2).text = "22"
        'MyExcel.Cells(2, 3).text = "23"

        'MyExcel.Workbooks.Close()
        'MyExcel = Nothing

    End Sub

    Private Sub try3()


    End Sub

    Private Sub RdSessionFiles_Click(sender As Object, e As EventArgs) Handles RdSessionFiles.Click
        Read_session_files()

        'If Stage_Read_Practice_Table = False Then
        '    MessageBox.Show("Must read practice file BEFORE reading sessions list")
        '    Exit Sub
        'End If
        'Read_CSV_Session_files()
    End Sub

    Private Sub Read_session_files()
        If Stage_Read_Practice_Table = False Then
            MessageBox.Show("Must read practice file BEFORE reading sessions list")
            Exit Sub
        End If
        Read_CSV_Session_files()

    End Sub


    Private Sub TxtBoxHeader_TextChanged(sender As Object, e As EventArgs) Handles TxtBoxHeader.TextChanged

    End Sub


    ' **** new code below - reading session files

    Public Sub Read_CSV_Session_files()
        ' reading CSV files 

        Dim pract_Excel As New Microsoft.Office.Interop.Excel.Application
        Dim dog_session As New DogSession

        Dim file_count As Integer = 0
        Dim fileName As String
        Dim session_num As Integer
        Dim no_match_cnt As Integer = 0
        Dim match_cnt As Integer = 0
        Dim pet_name As String
        Dim pet_id As String
        Dim csv_start_date As DateTime
        Dim csv_end_date As DateTime
        Dim total_lines_of_csv As Integer = 0


        RdSessionFiles.BackColor = Color.GreenYellow

        '       Dim total_sessions As New List(Of Session_file) ' will include all CSV files contect

        num_of_lines_TextBox.BackColor = Color.Yellow
        num_of_lines_TextBox.Text = "starting"




        '    fileName = Dir(in_PathName & "*084330.csv")
        fileName = Dir(in_PathName & csv_pattern)
        Print_to_log_file("Start reading CSV files")
        Print_to_log_file("Dir is: " + in_PathName)

        Do While fileName <> ""
            Dim curr_session As New Session_file
            file_count += 1

            'dog_session.Open_Session_file(in_PathName + fileName)
            Print_to_log_file("Start reading CSV file: " + in_PathName + fileName)
            pract_Excel.Workbooks.Open(in_PathName + fileName)

            'dog_session.Init_session()


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
            curr_session.session_start_time = csv_start_date
            curr_session.session_end_time = csv_end_date
            If (t_bool = False) Then
                MessageBox.Show("Error E1 while checking CSV file date")
                Console.WriteLine("Error E1 while checking CSV file date")
            End If


            s1 = pract_Excel.Cells(1, 1).text.Replace("From:", "").Replace(" ", "")

            t_bool = Date.TryParseExact(s1, "MM/dd/yyyy",
                               Globalization.CultureInfo.InvariantCulture,
                               Globalization.DateTimeStyles.None, csv_end_date)
            If (t_bool = False) Then
                MessageBox.Show("Error E2 while checking CSV file date")
                Console.WriteLine("Error E2 while checking CSV file date")
            End If


            ' moved to later stage. First we read all CSV files
            'session_num = sessions.Is_Session_Needed(dog_session.pet_name, dog_session.start_day)

            ' done below, not in class
            'dog_session.Read_Lines()





            'Dim tdate As Date
            ' Dim tCnt As Integer = 3 ' number of header lines
            Dim line_Cnt As Integer = 3
            'Dim prev_time_stamp As String = ""

            ' Dim lineTime As Date


            ' columns to ignore: source, fever indication, position, position duration, 
            '                   activity group, manual data note, manual data value
            ' lines to ignore: fever indication, position



            Dim line_data_type As String = "BLABLA"   ' just to enter the loop
            Dim line_date As DateTime
            Dim to_ignore As New List(Of String)
            to_ignore.Add("Fever Indication")
            to_ignore.Add("Position")
            Dim posi_cnt As Integer = 0
            Dim acti_cnt As Integer = 0
            Dim pulse_cnt As Integer = 0
            Dim resp_cnt As Integer = 0
            Dim vvti_cnt As Integer = 0



            While (line_data_type <> "")
                Dim line_data As New Session_file.dog_data
                line_Cnt += 1
                total_line_cnt += 1
                num_of_lines_TextBox.Text = total_line_cnt.ToString()

                line_data_type = pract_Excel.Cells(line_Cnt, 1).Text
                If to_ignore.Contains(line_data_type) Then
                    Continue While
                End If

                line_date = pract_Excel.Cells(line_Cnt, 2).value
                line_data.pract_type = line_data_type
                line_data.pract_time = line_date

                ' now collect the data according to the data type

                Select Case line_data_type
                    Case "Position"
                        posi_cnt += 1
                        line_data.position = pract_Excel.Cells(line_Cnt, 5).text
                        line_data.position_duration = pract_Excel.Cells(line_Cnt, 6).value
                    Case "Activity"
                        acti_cnt += 1
                        line_data.activity = pract_Excel.Cells(line_Cnt, 7).value

                    Case "Pulse"
                        pulse_cnt += 1
                        line_data.pulse = pract_Excel.Cells(line_Cnt, 9).value

                    Case "Respiration"
                        resp_cnt += 1
                        line_data.respiration = pract_Excel.Cells(line_Cnt, 10).value

                    Case "VVTI"
                        vvti_cnt += 1
                        line_data.vvti = pract_Excel.Cells(line_Cnt, 11).value

                    Case Else
                        Console.WriteLine("Wrong place in case of data type in CSV lines")
                        Console.WriteLine("line number: " + line_Cnt.ToString())
                End Select


                '        Console.WriteLine(lineDate.ToString() + "  " + lineTime.ToString())
                curr_session.List_of_dog_data.Add(line_data)
            End While
            total_lines_of_csv += line_Cnt

            Print_to_log_file("Total number of lines read: " + line_Cnt.ToString())
            Print_to_log_file("Lines with Position       : " + posi_cnt.ToString())
            Print_to_log_file("Lines with Activity       : " + acti_cnt.ToString())
            Print_to_log_file("Lines with Pulse          : " + pulse_cnt.ToString())
            Print_to_log_file("Lines with Respiration    : " + resp_cnt.ToString())
            Print_to_log_file("Lines with VVTI           : " + vvti_cnt.ToString())


            pract_Excel.Workbooks.Close()
            total_sessions.Add(curr_session)

            num_of_lines_TextBox.Text = total_line_cnt.ToString()


            'If session_num = -1 Then
            '    no_match_cnt += 1
            '    Print_to_log_file("Failed to find session for CSV file: " + fileName)
            '    Print_to_log_file("Dog: " + dog_session.pet_name + "  " + dog_session.start_day)
            'Else
            '    Print_to_log_file("Match ")
            '    match_cnt += 1

            '    ' start reading line by line, see if time is matching the pre/act/post
            'End If

            ' dog_session.Close_Excel()

            fileName = Dir()
            Console.WriteLine(" finished file number " + file_count.ToString())
            Console.WriteLine("Pet name & ID: {0} {1} ", dog_session.pet_name, dog_session.pet_ID)
        Loop ' go and read next CSV file

        Print_to_log_file("Total lines ewad      : " + total_lines_of_csv.ToString())
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






    Sub Print_to_log_file(_str As String, Optional _keep As Boolean = True)
        '        Dim LogFile = "C:\\Users\\yigal\\Documents\\Yigal\DogsProj\\logDog.txt"

        Dim file As System.IO.StreamWriter

        file = My.Computer.FileSystem.OpenTextFileWriter(LogFile, _keep)
        file.WriteLine(_str)
        file.Close()

    End Sub ' Print_to_log_file

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        ' Run them all
        ReadPracticeFile()
        Read_session_files()
        check_sessions()

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
                    match_cnt += 1
                    Console.WriteLine("Match")
                End If

            Next
            Print_to_log_file(sessio_num.ToString() & " has " & match_cnt & " matches")
        Next



            chk_sessions_button.BackColor = Color.Green

    End Sub






End Class

