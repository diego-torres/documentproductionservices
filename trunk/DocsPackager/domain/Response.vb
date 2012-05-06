Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Namespace domain

    Public Class Response
        Private eId As String
        Private eDescription As String

        Private Const SUCCESS_DESCRIPTION As String = "SUCCESS"
        Private Const SUCCESS_CODE As String = "0"

        ''' <summary>
        ''' Defaulted construction as 0/success, defaulted for no errors found.
        ''' </summary>
        ''' <remarks>You can specify that an error has been found by changing the ErrorId and ErrorDescription values.</remarks>
        Public Sub New()
            eId = SUCCESS_CODE
            eDescription = SUCCESS_DESCRIPTION
        End Sub

        ''' <summary>
        ''' Create an instance of a error by specifiying the error id and description to be set.
        ''' You can use 0/success values to specify clean of exceptions result.
        ''' </summary>
        ''' <param name="errorId">ErrorId to be set.</param>
        ''' <param name="errorDescription">ErrorDescription to be set.</param>
        Public Sub New(ByVal errorId As String, ByVal errorDescription As String)
            eId = errorId
            eDescription = errorDescription
        End Sub

        ''' <summary>
        ''' Represents the error id resulting of the execution of the web service.
        ''' </summary>
        ''' <value>0 - None. Any other value will state a exception.</value>
        ''' <returns></returns>
        ''' <remarks>Define short ids for exceptions. State the details on the <see cref="dtorres.dps.dpkg.domain.Response.ErrorDescription">error description</see>.</remarks>
        Public Property ErrorId As String
            Get
                Return eId
            End Get
            Set(value As String)
                eId = value
            End Set
        End Property
        ''' <summary>
        ''' Represents the error description of the execution of the web service.
        ''' </summary>
        ''' <value>Success - means that no exception was found.</value>
        ''' <remarks></remarks>
        Public Property ErrorDescription As String
            Get
                Return eDescription
            End Get
            Set(value As String)
                eDescription = value
            End Set
        End Property
    End Class
End Namespace
