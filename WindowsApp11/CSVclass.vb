Public Class CSV_file_header
    ' this class handles a single CSV file header
    Public csv_fname As String
    Public dog_name As String
    Public dog_id As String
    Public start_day As Date
    Public end_day As Date
    'Public match_csv_file_name As String

    Public Function CSV_header_read(_fname As String) As CSV_file_header
        Dim cur_csv_header As New CSV_file_header
        Dim csv_Excel As New Microsoft.Office.Interop.Excel.Application


        csv_Excel.Workbooks.Open(_fname)    '** Open CSV file
        ' ** Get pet & date info about this session
        cur_csv_header.csv_fname = _fname
        cur_csv_header.dog_name = csv_Excel.Cells(2, 1).text.Replace("Pet name: ", "").Replace(" ", "")
        cur_csv_header.dog_id = csv_Excel.Cells(2, 2).text.Replace("Pet id: ", "").Replace(" ", "")

        ' **************************************************************************
        Dim csv_start_date As DateTime
        Dim csv_end_date As DateTime
        ' get the start date & end date of this session file
        Dim s1 As String = csv_Excel.Cells(1, 1).text.Replace("From:", "").Replace(" ", "")
        Dim t_bool As Boolean = Date.TryParseExact(s1, "MM/dd/yyyy",
                               Globalization.CultureInfo.InvariantCulture,
                               Globalization.DateTimeStyles.None, csv_start_date)
        cur_csv_header.start_day = csv_start_date
        If (t_bool = False) Then
            MessageBox.Show("Error E1 while checking CSV file date")
            Console.WriteLine("Error E1 while checking CSV file date")
        End If

        s1 = csv_Excel.Cells(1, 2).text.Replace("To:", "").Replace(" ", "")
        t_bool = Date.TryParseExact(s1, "MM/dd/yyyy",
                               Globalization.CultureInfo.InvariantCulture,
                               Globalization.DateTimeStyles.None, csv_end_date)
        cur_csv_header.end_day = csv_end_date ' Oct 23 2019
        If (t_bool = False) Then
            MessageBox.Show("Error E2 while checking CSV file date")
            Console.WriteLine("Error E2 while checking CSV file date")
        End If

        csv_Excel.Workbooks.Close()
        csv_Excel = Nothing


        Return (cur_csv_header)
    End Function




End Class


Public Class CSVclass
    ' this class should handle CSV reading
    ' for start: CSV fast read and analyse vs the required session list
    Public lines_read As New List(Of CSV_file_header)






End Class
