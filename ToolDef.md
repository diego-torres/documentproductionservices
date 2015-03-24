# DocumentProductionServices #

Are a group of services that will produce word or pdf documents based on the web service request contents and system configuration. The services that will interact are:

REQUESTOR -> GATEWAY (dg) -> EVALUATOR(de) -> PRODUCER(dpd) -> PACKAGER(dpk)

  * **Requestor**: Represents the client caller that will consume the gateway service, specify the scope of the request? possible scope: produce or package.
  * **Gateway**: Presents the input and output contracts for the doc producer. invokes the evaluator, producer and packager.
  * **Evaluator**: Receives the document details request that will be used to produce the document and evaluates if all required information has been provided.
Should receive or load configuration that will help it to complete the information.
  * **Producer**: Creates the file and respond as base64 coded. Uses configuration methods to know and retrieve different templates and replace the known variables in the content.
  * **Packager**: Receives a base64 coded file and send it to email, ftp, fax, printer, sysfolder and the email, ftp and sysfolder can be zipped.

---

## Doc producer. ##
Should use a pdf/tiff/text generator to create a configured format (html or xml).
Replace variables with request values.

---

Different destinations:
  * FAX
  * PRINT


---

### ZIPABLES ###
  * EMAIL
  * FTP
  * SYSFOLDER (DONE)
  * SFTP