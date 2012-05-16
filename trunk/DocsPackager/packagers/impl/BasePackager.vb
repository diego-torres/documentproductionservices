Imports System.Web.Configuration
Imports System.IO.Packaging
Imports System.IO

Imports dtorres.dps.dpkg.exceptions
Imports dtorres.dps.dpkg.domain

Namespace packagers.impl
    Public MustInherit Class BasePackager
        ''' <summary>
        ''' Zips a file in a given zip package.
        ''' </summary>
        ''' <param name="zip">The zip file where the byte array will be appended</param>
        ''' <param name="fileBytes">The byte array of the file to be zipped</param>
        ''' <param name="fileName">The name of the file to be included in the zip</param>
        ''' <remarks>fileName should be only the file name with extension, no path included.</remarks>
        Protected Sub zipFile(ByRef zip As Package, ByVal fileBytes As Byte(), ByVal fileName As String)
            Dim zipUri As String = String.Concat("/", fileName)
            Dim partUri As New Uri(zipUri, UriKind.Relative)
            Dim contentType As String = Net.Mime.MediaTypeNames.Application.Zip

            Dim pkgPart As PackagePart = zip.CreatePart(partUri, contentType, CompressionOption.Normal)
            pkgPart.GetStream().Write(fileBytes, 0, fileBytes.Length)
        End Sub

        ''' <summary>
        ''' Retrieves a value from the web.config
        ''' </summary>
        ''' <param name="propertyName">value key to be retrieved.</param>
        ''' <returns>the configured value in web.config</returns>
        ''' <remarks>When the property is not found, will result in Nothing value.</remarks>
        Protected Function readProperty(ByVal propertyName As String) As String
            Return System.Web.Configuration.WebConfigurationManager.AppSettings.Item(propertyName)
        End Function
    End Class
End Namespace
