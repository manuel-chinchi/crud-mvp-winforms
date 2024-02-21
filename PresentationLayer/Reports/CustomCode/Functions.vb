Public Function SortList(ByVal items As Object()) As Object()
    If items Is Nothing OrElse items.Length <= 1 Then
        Return items
    End If

    Array.Sort(items)
    Return items
End Function