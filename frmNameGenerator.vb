Public Class frmNameGenerator
    Private CollctNamePath As String = Application.StartupPath & "\NameList.txt"
    Private objHash As Hashtable
    Private NameCollection() As String
    Private RandomCollection As New List(Of String)

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        Dim rand As New Random()
        Dim RandomValue As Integer

        lvGenerate.Items.Clear()

        For i As Integer = 0 To 9
DoRandomValue:
            RandomValue = rand.Next(0, NameCollection.Length - 1)
            'While CheckIfExistNumber(RandomValue)
            '    RandomValue = rand.Next(0, NameCollection.Length - 1)
            'End While

            RandomValue += 1
            If CheckIfExistNumber(RandomValue) = True Then GoTo DoRandomValue

            RandomCollection.Add(RandomValue)
            Dim lv As ListViewItem = lvGenerate.Items.Add(RandomValue)
            lv.SubItems.Add(NameCollection(RandomValue))
            Application.DoEvents()
        Next
    End Sub

    Private Sub frmNameGenerator_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.Text & " | " & Me.GetType.Assembly.GetName.Version.ToString
        If System.IO.File.Exists(CollctNamePath) = True Then
            NameCollection = IO.File.ReadAllLines(CollctNamePath)
        Else
            MsgBox("Could find Name List", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Function CheckIfExistNumber(ByVal intNumber As Integer)
        If RandomCollection.Contains(intNumber) Then Return True

        Return False
    End Function
End Class
