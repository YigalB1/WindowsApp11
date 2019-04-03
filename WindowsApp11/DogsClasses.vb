Imports System.Collections.Specialized





Public Class DogClass
    Public Name As String
    Public Dob As Date
    Public Age As Integer
    Public Sex As String

    Public Sub SetDogName(ByVal _name As String)
        Name = _name
    End Sub
    Public Sub SetDogDOB(ByVal _dob As Date)
        Dob = _dob
    End Sub
    Public Sub SetDogAge()
        Dim curTime As DateTime = DateTime.Now
        Dim ageindays As TimeSpan

        ageindays = curTime - Dob
        Age = Int(ageindays.Days / 7)

    End Sub
    Public Sub SetDogSex(ByVal _sex As String)
        Sex = _sex
    End Sub
End Class ' of DogClass

Public Class DogsListClass
    Public dogs_List As New List(Of DogClass)

    Public Function DodgsCnt() As Integer
        DodgsCnt = dogs_List.Count()
    End Function

    Public Function DogExsists(_dogName As String) As Boolean
        Dim res As Boolean = False
        For Each item As DogClass In dogs_List
            If item.Name = _dogName Then
                res = True
            End If
        Next
        Return res
    End Function

    Public Sub AddDog(_dog As DogClass)
        dogs_List.Add(_dog)
    End Sub

    Public Sub Print_dogs_list()
        ' Create a string array with the lines of text
        ' String[] lines = { "First line", "Second line", "Third line" };

        '  Set a variable to the Documents path.
        ' docPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim docPath = "C:\\Users\\yigal\\Documents\\Yigal\DogsProj\\dogs_list.txt"

        Dim file As System.IO.StreamWriter

        file = My.Computer.FileSystem.OpenTextFileWriter(docPath, False)
        Dim cnt As Integer = 0
        For Each item In dogs_List
            cnt = cnt + 1
            file.WriteLine(cnt.ToString() + " " + item.Name + " " + item.Age.ToString())
        Next
        file.Close()
    End Sub ' Print_dogs_list

End Class  ' of DogsListClass

Public Class PracticeClass

    Public praticeName As String
    Public practiceNum As Integer

    Public Sub setDogPractice(ByVal _name As String, ByVal _num As Integer)
        praticeName = _name
        practiceNum = _num
    End Sub

End Class ' of Practice

Public Class PracticesList

    Dim practicesList As New List(Of PracticeClass)
    Public Sub add_practice(_pract As String, _num As Integer)
        Dim p As New PracticeClass
        p.praticeName = _pract
        p.practiceNum = _num
        practicesList.Add(p)
    End Sub ' of add_practice sub

    Public Function get_prtactice_num(_practName As String) As Integer

        Dim num = -1 ' default is failed
        For Each item As PracticeClass In practicesList
            If item.praticeName = _practName Then
                num = item.practiceNum
            End If
        Next
        get_prtactice_num = num
    End Function

    Public Sub Print_practices_list()
        Dim docPath = "C:\\Users\\yigal\\Documents\\Yigal\DogsProj\\practices_list.txt"

        Dim file As System.IO.StreamWriter

        file = My.Computer.FileSystem.OpenTextFileWriter(docPath, False)
        Dim cnt As Integer = 0
        For Each item In practicesList
            cnt = cnt + 1
            file.WriteLine(cnt.ToString() + " " + item.praticeName + " " + item.practiceNum.ToString())
        Next
        file.Close()
    End Sub ' Print_dogs_list

End Class ' of class PracticesList

Class Session
    Public dogName As String        ' read from practice file
    Public practiceDate As Date     ' read from practice file
    Public practiceType As String   ' read from practice file
    Public startTime As Date        ' read from practice file
    Public endTime As Date          ' read from practice file
    Public videoNum As String       ' read from practice file
    Public sessionOnAday As Integer ' read from practice file

    Public list_of_CSV_matches As New List(Of Integer) ' to be filled after reading CSV files
    ' with CSVs that match this session


    Public Sub SetdogName(ByVal _name As String)
        dogName = _name
    End Sub

    Public Sub SetPracticeDate(ByVal _date As Date)
        practiceDate = _date
    End Sub

    Public Sub SetpracticeType(ByVal _type As String)
        practiceType = _type
    End Sub

    Public Sub SetstartTime(ByVal _start_time As Date)
        ' because the date comes as string from the practice file 
        ' TBD - check if string comes as string or as date and act accordingly

        startTime = _start_time
    End Sub


    Public Sub SetendTime(ByVal _end_time As Date)
        endTime = _end_time
    End Sub

    Public Sub SetvideoNum(ByVal _videoNum As String)
        videoNum = _videoNum
    End Sub

    Public Sub SetSessiomOnAday(ByVal _Sessiononaday As Integer)
        sessionOnAday = _Sessiononaday
    End Sub

End Class ' a Session

Class List_of_Sessions
    Public sessionsList As New List(Of Session)

    Public Sub add_session(_p As Session)
        sessionsList.Add(_p)
    End Sub ' of add_practice sub

    Public Function Is_Session_Needed(_name As String, _date As Date) As Integer
        ' cecks if a session file read is part of the required sessions list 
        ' from practice file (in sessionsList variable)
        ' need to extract the date as it is as string mm/dd/yyy

        Dim is_needed As Integer = -1 ' default is false
        Dim cnt As Integer
        'Try
        For cnt = 0 To sessionsList.Count() - 1
            If sessionsList(cnt).dogName = _name Then
                If sessionsList(cnt).practiceDate = _date Then
                    is_needed = cnt
                    Exit For
                End If
            End If
        Next cnt
        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try

        Return is_needed
    End Function

    Public Sub Print_sessions_list()
        Dim docPath = "C:\\Users\\yigal\\Documents\\Yigal\DogsProj\\sessions_list.txt"

        Dim file As System.IO.StreamWriter

        file = My.Computer.FileSystem.OpenTextFileWriter(docPath, False)
        Dim cnt As Integer = 0
        For Each item In sessionsList
            cnt = cnt + 1
            file.WriteLine(cnt.ToString() + " " + item.dogName + " " +
                item.practiceDate.ToString("dd-MMM-yy") + " " + item.practiceType + " " +
                item.startTime.ToString("HH:mm") + " " + item.endTime.ToString("HH:mm") +
                " " + " " + item.videoNum.ToString() + " " +
                item.sessionOnAday.ToString())
        Next
        file.Close()
    End Sub ' Print_dogs_list


End Class   ' List_of_Sessions

Class Session_file
    Public session_file_name As String
    Public session_start_time As DateTime
    Public session_end_time As DateTime
    Public pet_name As String
    Public pet_ID As String
    Public pet_gender As Char
    Public pet_species As String
    Public pet_breed As String
    Public pet_owner As String
    Public pet_weight As String
    Public sessio_pre_start As DateTime
    Public session_post_end As DateTime

    Public Class dog_data
        Public pract_type As String
        Public pract_time As DateTime
        Public pract_source As String
        Public fever_indication As String
        Public position As String
        Public position_duration As Integer
        Public activity As Double
        Public activity_group As String
        Public pulse As Integer
        Public respiration As Integer
        Public vvti As Double
        Public Manual_data_note As String
        Public Manual_data_value As String
    End Class


    Public List_of_dog_data As New List(Of dog_data)



    Public Sub Set_file_name(ByVal _fname As String)
        session_file_name = _fname
    End Sub

    Public Sub Set_start_end_date(ByVal _start As String, ByVal _end As String)
        session_start_time = _start
        session_end_time = _end
    End Sub

    Public Sub Set_pet_date(ByVal _name As String, ByVal _ID As String, ByVal _gender As Char, ByVal _species As String,
                            ByVal _breed As String, ByVal _owner As String, ByVal _weight As String)
        pet_name = _name
        pet_ID = _ID
        pet_gender = _gender
        pet_species = _species
        pet_breed = _breed
        pet_owner = _owner
        pet_weight = _weight
    End Sub

End Class ' of Session_file

Class List_of_session_files
    Public session_files As New List(Of Session_file)
End Class






