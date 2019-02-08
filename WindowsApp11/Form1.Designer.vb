<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNumOfDogs = New System.Windows.Forms.TextBox()
        CType(Me.TxtPreTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPostTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TxtBoxNumOfFiles.Location = New System.Drawing.Point(633, 99)
        Me.TxtBoxNumOfFiles.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtBoxNumOfFiles.Name = "TxtBoxNumOfFiles"
        Me.TxtBoxNumOfFiles.Size = New System.Drawing.Size(68, 20)
        Me.TxtBoxNumOfFiles.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(494, 99)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Number of files detected"
        '
        'ButtonSelectWorkFolder
        '
        Me.ButtonSelectWorkFolder.Location = New System.Drawing.Point(364, 46)
        Me.ButtonSelectWorkFolder.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonSelectWorkFolder.Name = "ButtonSelectWorkFolder"
        Me.ButtonSelectWorkFolder.Size = New System.Drawing.Size(126, 25)
        Me.ButtonSelectWorkFolder.TabIndex = 5
        Me.ButtonSelectWorkFolder.Text = "Select work folder"
        Me.ButtonSelectWorkFolder.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(364, 85)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(126, 26)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Select sessions folder"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtPreTime
        '
        Me.TxtPreTime.Location = New System.Drawing.Point(635, 50)
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
        Me.TxtPostTime.Location = New System.Drawing.Point(635, 71)
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
        Me.RdPracticeFile.Text = "Read Practice file"
        Me.RdPracticeFile.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(364, 4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(351, 23)
        Me.ProgressBar1.TabIndex = 15
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(565, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Label4"
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
        Me.TxtNumOfDogs.Location = New System.Drawing.Point(633, 127)
        Me.TxtNumOfDogs.Name = "TxtNumOfDogs"
        Me.TxtNumOfDogs.Size = New System.Drawing.Size(68, 20)
        Me.TxtNumOfDogs.TabIndex = 19
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 500)
        Me.Controls.Add(Me.TxtNumOfDogs)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
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
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtNumOfDogs As TextBox
End Class
