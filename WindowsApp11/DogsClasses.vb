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
    Public Sub SetDogAge(ByVal _age As String)
        Age = _age
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
End Class  ' of DogsListClass

Public Class Practice

    Public Name As String
    Public practiceNum As Integer

    '   Public Sub setDogPractice(ByVal _name As String, ByVal _num As Integer)
    '       Name = _name
    '   End Sub
End Class ' of Practice

Public Class PracticesList

    Dim practicesList As New List(Of Practice)
    Public Sub add_practice(_pract As String, _num As Integer)
        Dim p As New Practice
        p.Name = _num
        p.practiceNum = _pract
        practicesList.Add(p)
    End Sub ' of add_practice sub

    Public Function get_prtactice_num(_practName As String) As Integer

        Dim num = -1 ' default is failed
        For Each item As Practice In practicesList
            If item.Name = _practName Then
                num = item.practiceNum
            End If
        Next
        get_prtactice_num = num
    End Function


End Class ' of class PracticesList
