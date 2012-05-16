Imports System.Net
Imports dtorres.dps.dpkg.exceptions
Imports System.IO
Imports System.Net.Mime
Imports System.IO.Packaging

Namespace packagers.impl
    Public Class FTPPackager
        Inherits BasePackager
        Implements IPackager

        Private Const PROPERTIES_PREFIX As String = "ftp"

        Public Sub package(req As domain.Request) Implements IPackager.package
            Dim bt64 As Byte() = System.Convert.FromBase64String(req.File)

            Dim fileName As String = req.File_Name & "." & req.File_Type
            Dim zipFileName As String = req.File_Name & ".zip"

            Dim confId As String = req.Configuration_Id
            If (req.Configuration_Id = "") Then
                confId = "default"
            End If

            Dim serverAddress As String = readProperty(PROPERTIES_PREFIX & "." & confId & ".address")
            Dim userName As String = readProperty(PROPERTIES_PREFIX & "." & confId & ".user")
            Dim password As String = readProperty(PROPERTIES_PREFIX & "." & confId & ".password")

            If serverAddress = Nothing Then
                Throw New DocumentPackagerException("File destination path can not be read from web.config [" & PROPERTIES_PREFIX & "." & confId & ".address" & "] property")
            End If

            If userName = Nothing Then
                Throw New DocumentPackagerException("FTP User can not be read from web.config [" & PROPERTIES_PREFIX & "." & confId & ".user" & "] property")
            End If

            If password = Nothing Then
                Throw New DocumentPackagerException("FTP Password can not be read from web.config [" & PROPERTIES_PREFIX & "." & confId & ".password" & "] property")
            End If

            Dim request As FtpWebRequest

            If req.Zippable Then
                request = DirectCast(WebRequest.Create(serverAddress & "/" & zipFileName), FtpWebRequest)
            Else
                request = DirectCast(WebRequest.Create(serverAddress & "/" & fileName), FtpWebRequest)
            End If

            request.Credentials = New NetworkCredential(userName, password)
            request.Method = WebRequestMethods.Ftp.UploadFile

            Dim rStream As Stream = request.GetRequestStream()

            If req.Zippable Then
                'Zip and attach
                Dim zip As Packaging.Package = ZipPackage.Open(rStream, IO.FileMode.Create)

                ' zipped in super class (BasePackager)
                zipFile(zip, bt64, fileName)
                zip.Close()
            Else
                rStream.Write(bt64, 0, bt64.Length)
            End If

            rStream.Close()
            rStream.Dispose()
        End Sub
    End Class
End Namespace
