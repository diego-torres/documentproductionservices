Namespace domain
    Public Class Request

        Private ft As String
        Private sendTo As Destination
        Private _fileName As String
        Private fileContent As String
        Private zipFile As Boolean = False
        Private config_id As String

        ''' <summary>
        ''' Represents the extension file type for the received base64 encoded file. Will save the file with this extension. 
        ''' </summary>
        ''' <value>Extension of the destination file</value>
        Public Property File_Type As String
            Get
                Return ft
            End Get
            Set(value As String)
                ft = value
            End Set
        End Property

        ''' <summary>
        ''' Represents the direction that our file will take, it can be send to an email, saved on an FTP or to a local folder (in the hosting server).
        ''' </summary>
        ''' <value>Destination for the file to be packaged</value>
        ''' <remarks>Only registered destinations in <see cref="dtorres.dps.dpkg.domain.Destination">Destination</see> enumeration.</remarks>
        Public Property File_Destination As Destination
            Get
                Return sendTo
            End Get
            Set(value As Destination)
                sendTo = value
            End Set
        End Property

        ''' <summary>
        ''' Represents the file to be packaged in base64 encoded string.
        ''' </summary>
        ''' <value>Base64 encoded file</value>
        Public Property File As String
            Get
                Return fileContent
            End Get
            Set(value As String)
                fileContent = value
            End Set
        End Property

        ''' <summary>
        ''' States if the file will be zipped before being saved in destination.
        ''' </summary>
        ''' <value>true if it will be zipped, false if it will not.</value>
        ''' <remarks>PRINT and FAX destinations are not suposed to be zipped.</remarks>
        Public Property Zippable As Boolean
            Get
                Return zipFile
            End Get
            Set(value As Boolean)
                zipFile = value
            End Set
        End Property
        ''' <summary>
        ''' Gets and sets the package instructions id. This Id will be used to retrieve specific properties in the web.config file.
        ''' </summary>
        Public Property Configuration_Id As String
            Get
                Return config_id
            End Get
            Set(value As String)
                config_id = value
            End Set
        End Property

        ''' <summary>
        ''' Gets and sets the file name that will be used to save the given file.
        ''' </summary>
        ''' <value>File Name</value>
        ''' <remarks>Do not include path symbols. Destination configuration is done through the Config_Impl_Name property.</remarks>
        Public Property File_Name As String
            Get
                Return _fileName
            End Get
            Set(value As String)
                _fileName = value
            End Set
        End Property

    End Class
    ''' <summary>
    ''' Possible values for file package destination.
    ''' </summary>
    ''' <remarks>Specifies the destinations where the file can be sent.</remarks>
    Public Enum Destination
        FAX
        PRINT
        EMAIL
        FTP
        SYSFOLDER
    End Enum
End Namespace


