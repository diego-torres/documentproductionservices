﻿Imports dtorres.dps.dpkg.domain
Imports dtorres.dps.dpkg.packagers.impl
Imports dtorres.dps.dpkg.exceptions

Namespace packagers
    Public Class PackagerFactory
        Public Shared Function GetInstance(ByVal fileDestination As Destination) As IPackager
            Select Case fileDestination
                Case Destination.EMAIL
                    Return New EmailPackager()
                Case Destination.FAX
                    ' TODO: Implement a fax method
                    Throw New DocumentPackagerException("Not Implemented yet")
                Case Destination.FTP
                    ' TODO: Implement an ftp method
                    Throw New DocumentPackagerException("Not Implemented yet")
                Case Destination.PRINT
                    ' TODO: Implement a printer method
                    Throw New DocumentPackagerException("Not Implemented yet")
                Case Destination.SYSFOLDER
                    Return New HosterFileSystem()
                Case Else
                    Throw New DocumentPackagerException("The specified destination [" + fileDestination.ToString() + "] can not be recognized")
            End Select
        End Function
    End Class
End Namespace