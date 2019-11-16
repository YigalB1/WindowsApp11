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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RdSessionFiles = New System.Windows.Forms.Button()
        Me.chk_sessions_button = New System.Windows.Forms.Button()
        Me.Create_results_button = New System.Windows.Forms.Button()
        Me.Create_stats_button = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.num_of_lines_TextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.output_lines_textbox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.PreChecks = New System.Windows.Forms.Button()
        CType(Me.TxtPreTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPostTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtBoxHeader
        '
        Me.TxtBoxHeader.Location = New System.Drawing.Point(155, 8)
        Me.TxtBoxHeader.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtBoxHeader.Name = "TxtBoxHeader"
        Me.TxtBoxHeader.Size = New System.Drawing.Size(153, 20)
        Me.TxtBoxHeader.TabIndex = 0
        Me.TxtBoxHeader.Text = "Dogs Project"
        '
        'TxtBoxWorkDir
        '
        Me.TxtBoxWorkDir.Location = New System.Drawing.Point(20, 49)
        Me.TxtBoxWorkDir.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtBoxWorkDir.Name = "TxtBoxWorkDir"
        Me.TxtBoxWorkDir.Size = New System.Drawing.Size(321, 20)
        Me.TxtBoxWorkDir.TabIndex = 1
        Me.TxtBoxWorkDir.Text = "Work Directory"
        '
        'TxtBoxSessionDir
        '
        Me.TxtBoxSessionDir.Location = New System.Drawing.Point(20, 89)
        Me.TxtBoxSessionDir.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtBoxSessionDir.Name = "TxtBoxSessionDir"
        Me.TxtBoxSessionDir.Size = New System.Drawing.Size(321, 20)
        Me.TxtBoxSessionDir.TabIndex = 2
        Me.TxtBoxSessionDir.Text = "Dogs Sessions directory"
        '
        'TxtBoxNumOfFiles
        '
        Me.TxtBoxNumOfFiles.Location = New System.Drawing.Point(639, 99)
        Me.TxtBoxNumOfFiles.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtBoxNumOfFiles.Name = "TxtBoxNumOfFiles"
        Me.TxtBoxNumOfFiles.Size = New System.Drawing.Size(68, 20)
        Me.TxtBoxNumOfFiles.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(510, 99)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Number of files detected"
        '
        'ButtonSelectWorkFolder
        '
        Me.ButtonSelectWorkFolder.Location = New System.Drawing.Point(364, 32)
        Me.ButtonSelectWorkFolder.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonSelectWorkFolder.Name = "ButtonSelectWorkFolder"
        Me.ButtonSelectWorkFolder.Size = New System.Drawing.Size(126, 25)
        Me.ButtonSelectWorkFolder.TabIndex = 5
        Me.ButtonSelectWorkFolder.Text = "Select work folder"
        Me.ButtonSelectWorkFolder.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(364, 66)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(126, 26)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Select sessions folder"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtPreTime
        '
        Me.TxtPreTime.Location = New System.Drawing.Point(641, 50)
        Me.TxtPreTime.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtPreTime.Name = "TxtPreTime"
        Me.TxtPreTime.Size = New System.Drawing.Size(80, 20)
        Me.TxtPreTime.TabIndex = 7
        Me.TxtPreTime.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(196, 255)
        Me.NumericUpDown2.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(5, 20)
        Me.NumericUpDown2.TabIndex = 8
        '
        'TxtPostTime
        '
        Me.TxtPostTime.Location = New System.Drawing.Point(641, 71)
        Me.TxtPostTime.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtPostTime.Name = "TxtPostTime"
        Me.TxtPostTime.Size = New System.Drawing.Size(80, 20)
        Me.TxtPostTime.TabIndex = 9
        Me.TxtPostTime.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(565, 53)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Pre time "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(565, 75)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Post time"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SelectPracticeFile
        '
        Me.SelectPracticeFile.Location = New System.Drawing.Point(364, 128)
        Me.SelectPracticeFile.Name = "SelectPracticeFile"
        Me.SelectPracticeFile.Size = New System.Drawing.Size(126, 23)
        Me.SelectPracticeFile.TabIndex = 12
        Me.SelectPracticeFile.Text = "Select Practice file"
        Me.SelectPracticeFile.UseVisualStyleBackColor = True
        '
        'TxtBoxPracticeFile
        '
        Me.TxtBoxPracticeFile.Location = New System.Drawing.Point(20, 128)
        Me.TxtBoxPracticeFile.Name = "TxtBoxPracticeFile"
        Me.TxtBoxPracticeFile.Size = New System.Drawing.Size(321, 20)
        Me.TxtBoxPracticeFile.TabIndex = 13
        '
        'RdPracticeFile
        '
        Me.RdPracticeFile.Location = New System.Drawing.Point(364, 170)
        Me.RdPracticeFile.Name = "RdPracticeFile"
        Me.RdPracticeFile.Size = New System.Drawing.Size(126, 23)
        Me.RdPracticeFile.TabIndex = 14
        Me.RdPracticeFile.Text = "1) Read Practice file"
        Me.RdPracticeFile.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(364, 4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(351, 23)
        Me.ProgressBar1.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(531, 133)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Number of dogs"
        '
        'TxtNumOfDogs
        '
        Me.TxtNumOfDogs.Location = New System.Drawing.Point(639, 127)
        Me.TxtNumOfDogs.Name = "TxtNumOfDogs"
        Me.TxtNumOfDogs.Size = New System.Drawing.Size(68, 20)
        Me.TxtNumOfDogs.TabIndex = 19
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WindowsApp11.My.Resources.Resources._20140331_085909
        Me.PictureBox1.Location = New System.Drawing.Point(786, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(352, 230)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'ButCLose
        '
        Me.ButCLose.Location = New System.Drawing.Point(986, 313)
        Me.ButCLose.Name = "ButCLose"
        Me.ButCLose.Size = New System.Drawing.Size(170, 63)
        Me.ButCLose.TabIndex = 20
        Me.ButCLose.Text = "Close"
        Me.ButCLose.UseVisualStyleBackColor = True
        '
        'BoxDogsList
        '
        Me.BoxDogsList.FormattingEnabled = True
        Me.BoxDogsList.Location = New System.Drawing.Point(215, 471)
        Me.BoxDogsList.Name = "BoxDogsList"
        Me.BoxDogsList.Size = New System.Drawing.Size(162, 56)
        Me.BoxDogsList.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(531, 188)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Number of practices"
        '
        'TxtPracticesNum
        '
        Me.TxtPracticesNum.Location = New System.Drawing.Point(639, 182)
        Me.TxtPracticesNum.Name = "TxtPracticesNum"
        Me.TxtPracticesNum.Size = New System.Drawing.Size(68, 20)
        Me.TxtPracticesNum.TabIndex = 23
        '
        'BoxPracticeList
        '
        Me.BoxPracticeList.FormattingEnabled = True
        Me.BoxPracticeList.Location = New System.Drawing.Point(568, 313)
        Me.BoxPracticeList.Name = "BoxPracticeList"
        Me.BoxPracticeList.Size = New System.Drawing.Size(348, 56)
        Me.BoxPracticeList.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(531, 159)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Type of practices"
        '
        'TxtPracticeTypes
        '
        Me.TxtPracticeTypes.Location = New System.Drawing.Point(639, 156)
        Me.TxtPracticeTypes.Name = "TxtPracticeTypes"
        Me.TxtPracticeTypes.Size = New System.Drawing.Size(68, 20)
        Me.TxtPracticeTypes.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label7.Location = New System.Drawing.Point(212, 455)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Dogs list"
        '
        'Label8
        '
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label8.Location = New System.Drawing.Point(565, 297)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Practices list"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(754, 471)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(160, 97)
        Me.DataGridView1.TabIndex = 32
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(227, 393)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 40)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RdSessionFiles
        '
        Me.RdSessionFiles.Location = New System.Drawing.Point(364, 205)
        Me.RdSessionFiles.Margin = New System.Windows.Forms.Padding(2)
        Me.RdSessionFiles.Name = "RdSessionFiles"
        Me.RdSessionFiles.Size = New System.Drawing.Size(126, 24)
        Me.RdSessionFiles.TabIndex = 34
        Me.RdSessionFiles.Text = "2) Read Session files"
        Me.RdSessionFiles.UseVisualStyleBackColor = True
        '
        'chk_sessions_button
        '
        Me.chk_sessions_button.Location = New System.Drawing.Point(364, 244)
        Me.chk_sessions_button.Name = "chk_sessions_button"
        Me.chk_sessions_button.Size = New System.Drawing.Size(126, 23)
        Me.chk_sessions_button.TabIndex = 35
        Me.chk_sessions_button.Text = "3)  Check Sessions"
        Me.chk_sessions_button.UseVisualStyleBackColor = True
        '
        'Create_results_button
        '
        Me.Create_results_button.Location = New System.Drawing.Point(364, 284)
        Me.Create_results_button.Name = "Create_results_button"
        Me.Create_results_button.Size = New System.Drawing.Size(126, 23)
        Me.Create_results_button.TabIndex = 36
        Me.Create_results_button.Text = "4) Create results"
        Me.Create_results_button.UseVisualStyleBackColor = True
        '
        'Create_stats_button
        '
        Me.Create_stats_button.Location = New System.Drawing.Point(364, 323)
        Me.Create_stats_button.Name = "Create_stats_button"
        Me.Create_stats_button.Size = New System.Drawing.Size(126, 23)
        Me.Create_stats_button.TabIndex = 37
        Me.Create_stats_button.Text = "5) Create statistics"
        Me.Create_stats_button.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(298, 179)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(42, 166)
        Me.Button3.TabIndex = 38
        Me.Button3.Text = "Run ALL"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'num_of_lines_TextBox
        '
        Me.num_of_lines_TextBox.Location = New System.Drawing.Point(639, 208)
        Me.num_of_lines_TextBox.Name = "num_of_lines_TextBox"
        Me.num_of_lines_TextBox.Size = New System.Drawing.Size(68, 20)
        Me.num_of_lines_TextBox.TabIndex = 39
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(534, 208)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 13)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Number of lines read"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(534, 239)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 13)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Num of output lines"
        '
        'output_lines_textbox
        '
        Me.output_lines_textbox.Location = New System.Drawing.Point(639, 235)
        Me.output_lines_textbox.Name = "output_lines_textbox"
        Me.output_lines_textbox.Size = New System.Drawing.Size(100, 20)
        Me.output_lines_textbox.TabIndex = 42
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 170)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(161, 82)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select projects"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(7, 41)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(64, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "2017-18"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(7, 14)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(64, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "2016-17"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'PreChecks
        '
        Me.PreChecks.Location = New System.Drawing.Point(364, 103)
        Me.PreChecks.Name = "PreChecks"
        Me.PreChecks.Size = New System.Drawing.Size(138, 19)
        Me.PreChecks.TabIndex = 45
        Me.PreChecks.Text = "Check Files and Folders"
        Me.PreChecks.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1189, 556)
        Me.Controls.Add(Me.PreChecks)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.output_lines_textbox)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.num_of_lines_TextBox)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Create_stats_button)
        Me.Controls.Add(Me.Create_results_button)
        Me.Controls.Add(Me.chk_sessions_button)
        Me.Controls.Add(Me.RdSessionFiles)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
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
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.TxtPreTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPostTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents RdSessionFiles As Button
    Friend WithEvents chk_sessions_button As Button
    Friend WithEvents Create_results_button As Button
    Friend WithEvents Create_stats_button As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents num_of_lines_TextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents output_lines_textbox As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents PreChecks As Button
End Class
