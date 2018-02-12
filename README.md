# Team-Eta-2018
Team Eta 2018

Our project is a new toolset for developers to add license enforcement to customizations.  In a nutshell, we have a server-side (run from the software publishers Acumatica instance) that creates a license key for a customer and customization project, and then a client-side piece that allows the user to enter the License Key and validate (via Contract-based API) that it is accepted.  If the license is valid, the customization pages will display and work as expected.  If the license is not valid, the end user will not be allowed to use the customization and will receive an error page.
 
The customization will then contain the URL and credentials to validate.  
