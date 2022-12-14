using Cinema.DTO.InnerModels.Templates;

namespace Cinema.DTO.InnerModels.CinemaAddressModel
{
    public partial class CinemaAddress : ComponentModelTemplate
    {
        private const string TableName = "cinema_addresses",
                             AddressColumnName = "address",
                             MapLinkColumnName = "map_link";
    }
}