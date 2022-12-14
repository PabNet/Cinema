using Cinema.DTO.InnerModels.Templates;

namespace Cinema.DTO.InnerModels.AccountModel
{
    public partial class Account : PersonModelTemplate
    {
        private const string TableName = "accounts",
                             LoginColumnName = "login",
                             PasswordColumnName = "password";
        
    }
}