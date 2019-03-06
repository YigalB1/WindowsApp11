<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TxtBoxHeader = New System.Windows.Forms.TextBox()
        Me.TxtBoxWorkDir = New System.Windows.Forms.TextBox()
        Me.TxtBoxSessionDir = New System.Windows.Forms.TextBox()
        Me.TxtBoxNumOfFiles = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonSelectWorkFolder = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TxtPreTime = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.TxtPostTime = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SelectPracticeFile = New System.Windows.Forms.Button()
        Me.TxtBoxPracticeFile = New System.Windows.Forms.TextBox()
        Me.RdPracticeFile = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNumOfDogs = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButCLose = New System.Windows.Forms.Button()
        Me.BoxDogsList = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPracticesNum = New System.Windows.Forms.TextBox()
        Me.BoxPracticeList = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtPracticeTypes = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DGV_Dogs_list = New System.Windows.Forms.DataGridView()
        Me.DGV_Practices_list = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.TxtPreTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPostTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Dogs_list, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Practices_list, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtBoxHeader
        '
        Me.TxtBoxHeader.Location = New System.Drawing.Point(232, 12)
        Me.TxtBoxHeader.Name = "TxtBoxHeader"
        Me.TxtBoxHeader.Size = New System.Drawing.Size(228, 26)
        Me.TxtBoxHeader.TabIndex = 0
        Me.TxtBoxHeader.Text = "Dogs Project"
        '
        'TxtBoxWorkDir
        '
        Me.TxtBoxWorkDir.Location = New System.Drawing.Point(30, 75)
        Me.TxtBoxWorkDir.Name = "TxtBoxWorkDir"
        Me.TxtBoxWorkDir.Size = New System.Drawing.Size(480, 26)
        Me.TxtBoxWorkDir.TabIndex = 1
        Me.TxtBoxWorkDir.Text = "Work Directory"
        '
        'TxtBoxSessionDir
        '
        Me.TxtBoxSessionDir.Location = New System.Drawing.Point(30, 137)
        Me.TxtBoxSessionDir.Name = "TxtBoxSessionDir"
        Me.TxtBoxSessionDir.Size = New System.Drawing.Size(480, 26)
        Me.TxtBoxSessionDir.TabIndex = 2
        Me.TxtBoxSessionDir.Text = "Dogs Sessions directory"
        '
        'TxtBoxNumOfFiles
        '
        Me.TxtBoxNumOfFiles.Location = New System.Drawing.Point(950, 152)
        Me.TxtBoxNumOfFiles.Name = "TxtBoxNumOfFiles"
        Me.TxtBoxNumOfFiles.Size = New System.Drawing.Size(100, 26)
        Me.TxtBoxNumOfFiles.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(741, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Number of files detected"
        '
        'ButtonSelectWorkFolder
        '
        Me.ButtonSelectWorkFolder.Location = New System.Drawing.Point(546, 71)
        Me.ButtonSelectWorkFolder.Name = "ButtonSelectWorkFolder"
        Me.ButtonSelectWorkFolder.Size = New System.Drawing.Size(189, 38)
        Me.ButtonSelectWorkFolder.TabIndex = 5
        Me.ButtonSelectWorkFolder.Text = "Select work folder"
        Me.ButtonSelectWorkFolder.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(546, 131)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(189, 40)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Select sessions folder"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtPreTime
        '
        Me.TxtPreTime.Location = New System.Drawing.Point(952, 77)
        Me.TxtPreTime.Name = "TxtPreTime"
        Me.TxtPreTime.Size = New System.Drawing.Size(120, 26)
        Me.TxtPreTime.TabIndex = 7
        Me.TxtPreTime.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(294, 392)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(8, 26)
        Me.NumericUpDown2.TabIndex = 8
        '
        'TxtPostTime
        '
        Me.TxtPostTime.Location = New System.Drawing.Point(952, 109)
        Me.TxtPostTime.Name = "TxtPostTime"
        Me.TxtPostTime.Size = New System.Drawing.Size(120, 26)
        Me.TxtPostTime.TabIndex = 9
        Me.TxtPostTime.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(848, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Pre time "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(848, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Post time"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SelectPracticeFile
        '
        Me.SelectPracticeFile.Location = New System.Drawing.Point(546, 197)
        Me.SelectPracticeFile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SelectPracticeFile.Name = "SelectPracticeFile"
        Me.SelectPracticeFile.Size = New System.Drawing.Size(189, 35)
        Me.SelectPracticeFile.TabIndex = 12
        Me.SelectPracticeFile.Text = "Select Practice file"
        Me.SelectPracticeFile.UseVisualStyleBackColor = True
        '
        'TxtBoxPracticeFile
        '
        Me.TxtBoxPracticeFile.Location = New System.Drawing.Point(30, 197)
        Me.TxtBoxPracticeFile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtBoxPracticeFile.Name = "TxtBoxPracticeFile"
        Me.TxtBoxPracticeFile.Size = New System.Drawing.Size(480, 26)
        Me.TxtBoxPracticeFile.TabIndex = 13
        '
        'RdPracticeFile
        '
        Me.RdPracticeFile.Location = New System.Drawing.Point(546, 262)
        Me.RdPracticeFile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdPracticeFile.Name = "RdPracticeFile"
        Me.RdPracticeFile.Size = New System.Drawing.Size(189, 35)
        Me.RdPracticeFile.TabIndex = 14
        Me.RdPracticeFile.Text = "Read Practice file"
        Me.RdPracticeFile.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(546, 6)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(526, 35)
        Me.ProgressBar1.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(796, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 20)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Number of dogs"
        '
        'TxtNumOfDogs
        '
        Me.TxtNumOfDogs.Location = New System.Drawing.Point(950, 195)
        Me.TxtNumOfDogs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtNumOfDogs.Name = "TxtNumOfDogs"
        Me.TxtNumOfDogs.Size = New System.Drawing.Size(100, 26)
        Me.TxtNumOfDogs.TabIndex = 19
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WindowsApp11.My.Resources.Resources._20140331_085909
        Me.PictureBox1.Location = New System.Drawing.Point(1179, 12)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(528, 354)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'ButCLose
        '
        Me.ButCLose.Location = New System.Drawing.Point(1479, 482)
        Me.ButCLose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButCLose.Name = "ButCLose"
        Me.ButCLose.Size = New System.Drawing.Size(255, 97)
        Me.ButCLose.TabIndex = 20
        Me.ButCLose.Text = "Close"
        Me.ButCLose.UseVisualStyleBackColor = True
        '
        'BoxDogsList
        '
        Me.BoxDogsList.FormattingEnabled = True
        Me.BoxDogsList.ItemHeight = 20
        Me.BoxDogsList.Location = New System.Drawing.Point(852, 351)
        Me.BoxDogsList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BoxDogsList.Name = "BoxDogsList"
        Me.BoxDogsList.Size = New System.Drawing.Size(241, 84)
        Me.BoxDogsList.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(796, 289)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 20)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Number of pracices"
        '
        'TxtPracticesNum
        '
        Me.TxtPracticesNum.Location = New System.Drawing.Point(950, 280)
        Me.TxtPracticesNum.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPracticesNum.Name = "TxtPracticesNum"
        Me.TxtPracticesNum.Size = New System.Drawing.Size(100, 26)
        Me.TxtPracticesNum.TabIndex = 23
        '
        'BoxPracticeList
        '
        Me.BoxPracticeList.FormattingEnabled = True
        Me.BoxPracticeList.ItemHeight = 20
        Me.BoxPracticeList.Location = New System.Drawing.Point(852, 482)
        Me.BoxPracticeList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BoxPracticeList.Name = "BoxPracticeList"
        Me.BoxPracticeList.Size = New System.Drawing.Size(520, 84)
        Me.BoxPracticeList.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(796, 245)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 20)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Type of practices"
        '
        'TxtPracticeTypes
        '
        Me.TxtPracticeTypes.Location = New System.Drawing.Point(950, 240)
        Me.TxtPracticeTypes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPracticeTypes.Name = "TxtPracticeTypes"
        Me.TxtPracticeTypes.Size = New System.Drawing.Size(100, 26)
        Me.TxtPracticeTypes.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label7.Location = New System.Drawing.Point(855, 326)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 20)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Dogs list"
        '
        'Label8
        '
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label8.Location = New System.Drawing.Point(848, 457)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 20)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Practices list"
        '
        'DGV_Dogs_list
        '
        Me.DGV_Dogs_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Dogs_list.Location = New System.Drawing.Point(30, 431)
        Me.DGV_Dogs_list.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DGV_Dogs_list.Name = "DGV_Dogs_list"
        Me.DGV_Dogs_list.Size = New System.Drawing.Size(357, 289)
        Me.DGV_Dogs_list.TabIndex = 30
        '
        'DGV_Practices_list
        '
        Me.DGV_Practices_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Practices_list.Location = New System.Drawing.Point(424, 431)
        Me.DGV_Practices_list.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DGV_Practices_list.Name = "DGV_Practices_list"
        Me.DGV_Practices_list.Size = New System.Drawing.Size(398, 289)
        Me.DGV_Practices_list.TabIndex = 31
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(1131, 724)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView1.TabIndex = 32
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1159, 676)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1784, 856)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DGV_Practices_list)
        Me.Controls.Add(Me.DGV_Dogs_list)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtPracticeTypes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BoxPracticeList)
        Me.Controls.Add(Me.TxtPracticesNum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BoxDogsList)
        Me.Controls.Add(Me.ButCLose)
        Me.Controls.Add(Me.TxtNumOfDogs)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.RdPracticeFile)
        Me.Controls.Add(Me.TxtBoxPracticeFile)
        Me.Controls.Add(Me.SelectPracticeFile)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtPostTime)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.TxtPreTime)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ButtonSelectWorkFolder)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtBoxNumOfFiles)
        Me.Controls.Add(Me.TxtBoxSessionDir)
        Me.Controls.Add(Me.TxtBoxWorkDir)
        Me.Controls.Add(Me.TxtBoxHeader)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.TxtPreTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPostTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Dogs_list, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Practices_list, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtBoxHeader As TextBox
    Friend WithEvents TxtBoxWorkDir As TextBox
    Friend WithEvents TxtBoxSessionDir As TextBox
    Friend WithEvents TxtBoxNumOfFiles As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonSelectWorkFolder As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TxtPreTime As NumericUpDown
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents TxtPostTime As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents SelectPracticeFile As Button
    Friend WithEvents TxtBoxPracticeFile As TextBox
    Friend WithEvents RdPracticeFile As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtNumOfDogs As TextBox
    Friend WithEvents ButCLose As Button
    Friend WithEvents BoxDogsList As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtPracticesNum As TextBox
    Friend WithEvents BoxPracticeList As ListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtPracticeTypes As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents DGV_Dogs_list As DataGridView
    Friend WithEvents DGV_Practices_list As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
End Class
