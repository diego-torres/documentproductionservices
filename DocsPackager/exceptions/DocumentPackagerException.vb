Imports System.Exception
Namespace exceptions
    Public Class DocumentPackagerException
        Inherits Exception
        Sub New(ByVal ErrMsg As String)
            MyBase.New(ErrMsg)
        End Sub
        Sub New(ByVal ErrMsg As String, ByVal innerException As Exception)
            MyBase.New(ErrMsg, innerException)
        End Sub
    End Class
End Namespace
