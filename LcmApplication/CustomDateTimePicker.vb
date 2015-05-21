Public Class CustomDateTimePicker
    Inherits DateTimePicker

    Private mRecreating As Boolean

    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        If mRecreating Then Return
        mRecreating = True
        Me.RecreateHandle()
        mRecreating = False
        MyBase.OnEnter(e)
    End Sub
End Class