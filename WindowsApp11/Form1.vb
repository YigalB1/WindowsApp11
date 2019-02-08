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



    Public Sub ShowEvent(sender As Object, e As EventArgs) Handles Me.Shown

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

        PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)

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

    Private Sub TxtBoxSessionDir_TextChanged(sender As Object, e As EventArgs) Handles TxtBoxSessionDir.TextChanged

    End Sub

    Private Sub TxtBoxWorkDir_TextChanged(sender As Object, e As EventArgs) Handles TxtBoxWorkDir.TextChanged


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
        ' Open excel file
        Dim MyExcel As New Microsoft.Office.Interop.Excel.Application
        MyExcel.Workbooks.Open(Me.TxtBoxPracticeFile.Text)

        MyExcel.Range("L2").Activate()
        'MyExcel.ActiveCell.Select(12, 2)

        'MyExcel.ActiveCell.Offset(11, 1).Activate() ' move to line 12 (L)  col 2

        'Dim range As Microsoft.Office.Interop.Excel.Range

        'range = MyExcel.ActiveSheet

        'MsgBox(range.Rows.Count.ToString)

        'MsgBox(MyExcel.Name)
        'MsgBox(MyExcel.Workbooks.ToString)

        'MsgBox(MyExcel.ActiveCell.Name)
        'MsgBox(MyExcel.ActiveSheet.ToString)
        'MsgBox(MyExcel.ActiveWorkbook)


        'MyExcel.Sheets("Sheet1").activate()
        'MyExcel.Range("L2").Activate()
        Dim stmp As String

        Dim counter As Integer
        counter = 0
        MyExcel.Range("L2").Activate()

        Do
            If counter < 20 And MyExcel.ActiveCell.Text <> "END" Then
                stmp = CStr(MyExcel.ActiveCell.Row) + " " + CStr(MyExcel.ActiveCell.Column)
                ' MsgBox(stmp)

                'MsgBox(MyExcel.ActiveCell.Row + " " + MyExcel.ActiveCell.Column)
                'MsgBox(MyExcel.ActiveCell.Text)
                counter = counter + 1
                MyExcel.ActiveCell.Offset(1, 0).Activate() ' move to col 2

            Else
                Exit Do
            End If
        Loop
        TxtNumOfDogs.Text = counter

        ReDim dogs(0 To counter - 1)
        Dim i As Integer
        Dim td As Date

        MyExcel.Range("L2").Activate()
        For i = 0 To counter - 1
            dogs(i).Name = MyExcel.ActiveCell.Text
            MyExcel.ActiveCell.Offset(0, 1).Activate()
            stmp = MyExcel.ActiveCell.Text
            td = MyExcel.ActiveCell.Value
            ' td = CDate(stmp)
            dogs(i).DOB = MyExcel.ActiveCell.Value
            MyExcel.ActiveCell.Offset(1, -1).Activate()

        Next i


        MyExcel.Workbooks.Close()
        MyExcel = Nothing

        'MyExcel.Workbooks.Close(Me.TxtBoxPracticeFile.Text)
        ProgressBar1.Value = 50

    End Sub


End Class
