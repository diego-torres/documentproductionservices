Imports System.IO.Packaging
Imports dtorres.dps.dpkg.exceptions

Namespace packagers.impl
    Public Class HosterFileSystem
        Inherits BasePackager
        Implements IPackager

        Private Const PROPERTIES_PREFIX As String = "hfs"
        Private Const LOCAL_FOLDER_PROP_NAME As String = "localFolder"

        Public Sub package(ByVal req As domain.Request) Implements IPackager.package

            Dim bt64 As Byte() = System.Convert.FromBase64String(req.File)

            Dim fileName As String = req.File_Name & "." & TranslateDocType(req.File_Type)
            Dim zipFileName As String = req.File_Name & ".zip"

            Dim confId As String = req.Configuration_Id
            If (req.Configuration_Id = "") Then
                confId = "default"
            End If

            Dim confName As String = PROPERTIES_PREFIX & "." & confId & "." & LOCAL_FOLDER_PROP_NAME

            ' Load destination from configuration
            Dim fileDestinationPath As String = readProperty(confName)

            If fileDestinationPath = Nothing Then
                Throw New DocumentPackagerException("File destination path can not be read from web.config [" & confName & "] property")
            End If

            'Avoid exception if folder does not exists
            If Not IO.Directory.Exists(fileDestinationPath) Then
                'Could throw exception if permision is denied.
                IO.Directory.CreateDirectory(fileDestinationPath)
            End If

            If (req.Zippable) Then
                ' Create local zip file if zippable is enabled
                Dim zip As Package = ZipPackage.Open(fileDestinationPath & zipFileName, _
                                                     IO.FileMode.Create, IO.FileAccess.ReadWrite)
                ' zipped in super class (BasePackager)
                zipFile(zip, bt64, fileName)
                zip.Close()
            Else
                ' Create local file with contents if zippable is disabled
                If IO.File.Exists(fileDestinationPath & fileName) Then
                    IO.File.Delete(fileDestinationPath & fileName)
                End If

                Dim fs As New IO.FileStream(fileDestinationPath & fileName, IO.FileMode.Create)
                fs.Write(bt64, 0, bt64.Length)
                fs.Close()
            End If
        End Sub
    End Class
End Namespace
