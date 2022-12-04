namespace Cinema.Common.Helpers.Mail
{
    public partial class MailHelper
    {
        private const string MailSection = "ServiceSettings:Email:",
                             MailCredentials = $"{MailSection}Credentials:",
                             Host = $"{MailSection}Host",
                             Port = $"{MailSection}Port",
                             SenderName = $"{MailSection}SenderName",
                             UserName = $"{MailCredentials}UserName",
                             Password = $"{MailCredentials}Password";
    }
}