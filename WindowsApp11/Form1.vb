'Add a reference To Microsoft Excel Object Library. To Do this, follow these steps
'On the Project menu, click Add Reference.
'On the COM tab, locate Microsoft Excel Object Library, And then click Select. 


Public Class Form1

    Private Structure DogRecord
        Dim Name As String
        Dim DOB As Date
        Dim Age As Integer
        Dim Sex As String
    End Structure
    Dim dogs() As DogRecord   ' Size to be defined when reading practice file

    Private Structure Dogs_struct
        Dim dogs_cnt As Integer
        Dim dogs_list() As DogRecord
    End Structure
    Dim Dogs_records As Dogs_struct



    Private Structure Practice_Type
        Dim Practice_Name As String
        Dim Practice_Code As Integer
    End Structure
    Dim Practice_Types() As Practice_Type   ' Size to be defined when reading practice file


    Private Structure PracticeRecord
        Dim Pract_dog As String
        Dim Pract_Date As Date
        Dim Pract_Type As String
        Dim Pract_Start As Date
        Dim Pract_End As Date
        Dim Pract_Video As String
    End Structure

    Dim practices_list() As PracticeRecord   ' Size to be defined when reading practice file

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
        ' *****************  in work - TBD



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
        ' ****** START AUTOMATICALLY WITH FORM



        'set default directory
        TxtBoxWorkDir.Text = "C:\Users\yigal\Documents\Yigal\DogsProj\"
        TxtBoxSessionDir.Text = TxtBoxWorkDir.Text + "SessionsFiles\"
        TxtBoxPracticeFile.Text = TxtBoxWorkDir.Text + "practice_list1.xlsx"

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
        CreateDogsGrid(DGV_Dogs_list)
        ' CreatePracicesTypeGrid(DGV_Practices_list)
        CreatePracicesListGrid((DGV_Practices_list))

        'AddToDogsGrid(DGV_Dogs_list, 15, "AXY", Today(), 17)

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

        RdPracticeFile.BackColor = Color.GreenYellow
        ' Open excel file
        Dim MyExcel As New Microsoft.Office.Interop.Excel.Application
        MyExcel.Workbooks.Open(Me.TxtBoxPracticeFile.Text)

        MyExcel.Range("L2").Activate()
        Dim stmp As String

        Dim counter As Integer

        ' ******  Count Number of dogs 
        Dim row_cnt As Integer = 2
        Dim col_cnt As Integer = 12

        Dim tdog As New DogClass  ' *** the Class way
        Dim DogsList As New DogsListClass   ' *** the Class way



        MyExcel.Range("L2").Activate()
        counter = 0
        Do
            'If counter < MAX_NUM_OF_DOGS And MyExcel.ActiveCell.Text <> "END" Then
            If counter < MAX_NUM_OF_DOGS And MyExcel.Cells(row_cnt, col_cnt).text <> "END" Then

                '  tdog.Name = MyExcel.Cells(row_cnt, col_cnt).text      ' *** the class way
                '  tdog.Dob = MyExcel.Cells(row_cnt, col_cnt + 1).text      ' *** the class way
                tdog.SetDogName(MyExcel.Cells(row_cnt, col_cnt).text)
                tdog.SetDogDOB(MyExcel.Cells(row_cnt, col_cnt + 1).value)

                DogsList.AddDog(tdog)                                    ' *** the class way

                stmp = CStr(MyExcel.ActiveCell.Row) + " " + CStr(MyExcel.ActiveCell.Column)
                ' MsgBox(stmp)

                'MsgBox(MyExcel.ActiveCell.Row + " " + MyExcel.ActiveCell.Column)
                'MsgBox(MyExcel.ActiveCell.Text)
                counter = counter + 1
                row_cnt = row_cnt + 1
                MyExcel.ActiveCell.Offset(1, 0).Activate() ' move to col 2

                TxtNumOfDogs.Text = counter

            Else
                Exit Do
            End If
        Loop


        ReDim dogs(0 To counter - 1)

        ' 12 Feb using the new Dogs_struct to replace the dogs array  
        ' at this stage we know how many dogs are there
        ' time to rad them into database

        Dogs_records.dogs_cnt = counter
        ReDim Dogs_records.dogs_list(0 To counter - 1)


        Dim i As Integer
        Dim td As Date
        Dim ageindays As TimeSpan
        Dim curTime As DateTime = DateTime.Now

        ' ******  Read dogs and DOB into dogs array
        MyExcel.Range("L2").Activate()
        For i = 0 To counter - 1
            dogs(i).Name = MyExcel.ActiveCell.Text
            MyExcel.ActiveCell.Offset(0, 1).Activate()
            stmp = MyExcel.ActiveCell.Text
            td = MyExcel.ActiveCell.Value
            ' td = CDate(stmp)
            dogs(i).DOB = MyExcel.ActiveCell.Value

            ' calculate age and store
            ageindays = curTime - dogs(i).DOB



            dogs(i).Age = Int(ageindays.Days / 7)

            'dogs(i).Age = CInt(DateDiff("ww", Now, dogs(i).DOB))

            'add to list on form
            BoxDogsList.Items.Add(dogs(i).Name.PadRight(8, " ") + "*" + CStr(dogs(i).DOB) + "*" + CStr(dogs(i).Age))

            MyExcel.ActiveCell.Offset(1, -1).Activate()
            AddToDogsGrid(DGV_Dogs_list, i + 1, dogs(i).Name, dogs(i).DOB, dogs(i).Age)

        Next i
        ProgressBar1.Value = 50

        ' ***************************************************
        ' ******  Count Practices types table
        counter = 0
        row_cnt = 2
        col_cnt = 9
        Do
            stmp = MyExcel.Cells(row_cnt, col_cnt).text ' get Practice name
            If counter < MAX_NUM_OF_PRACTICES_TYPES And stmp <> "END" Then
                counter = counter + 1
                row_cnt = row_cnt + 1
                TxtPracticeTypes.Text = counter
            Else
                Exit Do
            End If
        Loop

        ReDim Practice_Types(0 To counter - 1)
        ProgressBar1.Value = 55

        ' read practice types into an array
        For i = 1 To counter
            Practice_Types(i - 1).Practice_Name = MyExcel.Cells(i + 1, col_cnt).text
            Practice_Types(i - 1).Practice_Code = MyExcel.Cells(i + 1, col_cnt + 1).value
        Next i
        ProgressBar1.Value = 60


        ' ***************************************************
        ' count practices list
        counter = 0
        row_cnt = 2
        col_cnt = 1
        Do
            stmp = MyExcel.Cells(row_cnt, col_cnt).text ' get dog's name
            If counter < MAX_NUM_OF_PRACTICES And stmp <> "END" Then
                counter = counter + 1
                row_cnt = row_cnt + 1
                TxtPracticesNum.Text = counter
            Else
                Exit Do
            End If
        Loop

        ReDim practices_list(0 To counter - 1)
        ProgressBar1.Value = 65

        ' read practice list 
        For i = 0 To counter - 1

            practices_list(i).Pract_dog = MyExcel.Cells(i + 2, col_cnt).text ' get dog's name
            practices_list(i).Pract_Date = MyExcel.Cells(i + 2, col_cnt + 1).value ' get practice day
            practices_list(i).Pract_Type = MyExcel.Cells(i + 2, col_cnt + 2).text ' get practice type
            practices_list(i).Pract_Start = CDate(MyExcel.Cells(i + 2, col_cnt + 3).text) ' get practice start
            practices_list(i).Pract_End = CDate(MyExcel.Cells(i + 2, col_cnt + 4).text) ' get practice end

            'add to list on form
            BoxPracticeList.Items.Add(practices_list(i).Pract_dog.PadRight(8, " ") +
                CStr(practices_list(i).Pract_Date) + CStr(practices_list(i).Pract_Start) +
                CStr(practices_list(i).Pract_End).PadRight(10, " "))
            ' AddToPracticesListGrid(DGV_Dogs_list, i + 1, dogs(i).Name, dogs(i).DOB, dogs(i).Age)





            AddToPracticesListGrid(DGV_Practices_list,
                                   i,
                                        practices_list(i).Pract_dog,
                                        practices_list(i).Pract_Date.Date.ToString("dd MM yyyy"),
                                        practices_list(i).Pract_Type,
                                        practices_list(i).Pract_Start.ToString("HH:mm"),
                                        practices_list(i).Pract_End.ToString("HH:mm"),
                                        practices_list(i).Pract_Video)
            DGV_Practices_list.AutoResizeColumns()


            Console.BackgroundColor = ConsoleColor.Blue
            Console.WriteLine(" ......STARTING.................")
            Console.WriteLine(i)
            Console.WriteLine(practices_list(i).Pract_Date.Date)
            Console.WriteLine(practices_list(i).Pract_Date.Hour)
            Console.WriteLine(practices_list(i).Pract_Date.ToString("HH:mm"))
            Console.WriteLine("start" & practices_list(i).Pract_Start.ToString("HH:mm"))
            Console.WriteLine("end  " & practices_list(i).Pract_End)
            Console.BackgroundColor = ConsoleColor.White







        Next i





        ProgressBar1.Value = 70

        ' read dog's practices TBD

        MyExcel.Workbooks.Close()
        MyExcel = Nothing

        'MyExcel.Workbooks.Close(Me.TxtBoxPracticeFile.Text)
        ProgressBar1.Value = 60
        RdPracticeFile.BackColor = Color.Green

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles ButCLose.Click
        Me.Close()
    End Sub


    Private Sub Button1_Click_2(sender As Object, e As EventArgs)
        BoxDogsList.Items.Add("xxx".PadRight(10, " ") + CStr(17))
    End Sub

    Private Sub TxtBoxWorkDir_TextChanged(sender As Object, e As EventArgs) Handles TxtBoxWorkDir.TextChanged

    End Sub

    Private Sub ReadPracticeFile()

        Dim practice_connection As System.Data.OleDb.OleDbConnection
        Dim DtSet As System.Data.DataSet
        Dim my_command As System.Data.OleDb.OleDbDataAdapter

        practice_connection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data source='C:\\Users\\yigal\\Documents\\Yigal\\DogsProj\\practice_list.xlsx';Extended Properties = Excel 8.0")
        my_command = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", practice_connection)
        my_command.TableMappings.Add("Table", "TestTable")
        DtSet = New System.Data.DataSet()
        my_command.Fill(DtSet)

        DataGridView1.DataSource = DtSet.Tables
        practice_connection.Close()


    End Sub

    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles Button1.Click
        ReadPracticeFile()
    End Sub
End Class
