using System;
using Cinema.Common.Enums;
using Cinema.Common.Helpers;
using Cinema.Common.Helpers.Mail;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.VacancyResponseModel;

namespace Cinema.Domain.Implementations
{
    public class PostmanRepository : TemplateRepository, IExternalServiceRepository
    {
        private const string EmailMessageSection = "ServiceSettings:Email:MessageTemplates:",
            InviteMessage = $"{EmailMessageSection}InterviewInvitation:",
            RejectMessage = $"{EmailMessageSection}InterviewRejection:",
            TicketMessage = $"{EmailMessageSection}Ticket:",
            TextMessage = "Text",
            SubjectMessage = "Subject";

        private MailHelper _mailHelper;
        public PostmanRepository(ConfigurationHelper configurationHelper, MailHelper mailHelper) : base(configurationHelper)
        {
            this._mailHelper = mailHelper;
        }
        public void Execute(Enum command, params object[] parameters)
        {
            var receiver = parameters[0] as string;
            var content = default(string);
            var subject = default(string);
            
            switch ((PostmanActions) command)
            {
                case PostmanActions.SendInviteMessage:
                {
                    content = string.Format(ConfigurationHelper.GetValue($"{InviteMessage}{TextMessage}"),
                        parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);
                    subject = ConfigurationHelper.GetValue($"{InviteMessage}{SubjectMessage}");
                    
                    break;
                }
                case PostmanActions.SendRejectMessage:
                {
                    content = string.Format(ConfigurationHelper.GetValue($"{RejectMessage}{TextMessage}"),
                        parameters[1], parameters[2]);
                    subject = ConfigurationHelper.GetValue($"{InviteMessage}{SubjectMessage}");
                    
                    break;
                }
                case PostmanActions.SendTicket:
                {
                    content = string.Format(ConfigurationHelper.GetValue($"{TicketMessage}{TextMessage}"),
                        parameters[2]);
                    subject = string.Format(ConfigurationHelper.GetValue($"{TicketMessage}{SubjectMessage}"), parameters[1]);
                    
                    break;
                }
            }
            
            this._mailHelper.SendMessage(receiver, subject, content);
        }
    }
}