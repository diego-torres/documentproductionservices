Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.IO
Imports System.Web.Script.Services

Imports dtorres.dps.dpkg.domain
Imports dtorres.dps.dpkg.exceptions
Imports dtorres.dps.dpkg.packagers


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<ScriptService()> _
<WebService(Namespace:="http://dtorres.dps.dpkg/services")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class DocumentPackagerService
    Inherits WebService

    ''' <summary>
    ''' This method is used to package a file in an specified destination.
    ''' </summary>
    ''' <param name="req">States the details to package the file.</param>
    ''' <returns>As result of the package process, the service will return 0/success 
    ''' code or the details of any found exceptions.</returns>
    ''' <remarks>The file provided should be coded in base64.</remarks>
    <WebMethod()> _
    Public Function PackageFile(req As Request) As Response
        Dim packager As IPackager = PackagerFactory.GetInstance(req.File_Destination)
        packager.package(req)
        Return New Response("0", "Success")
    End Function

End Class
