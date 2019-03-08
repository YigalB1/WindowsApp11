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
    Public dogName As String
    Public practiceDate As Date
    Public practiceType As String
    Public startTime As Date
    Public endTime As Date
    Public videoNum As String
    Public sessionOnAday As Integer
End Class ' a Session

Class List_of_Sessions
    Dim sessionsList As New List(Of Session)

    Public Sub add_session(ByVal _p As Session)
        sessionsList.Add(_p)
    End Sub ' of add_practice sub


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





End Class   ' of List_of_Dog_practices