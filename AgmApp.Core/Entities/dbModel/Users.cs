// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgmApp.Core.Entities
{
    public partial class Users
    {
        public int Id { get; set; }
        public string UsrIdPk { get; set; }
        public string UsrNombres { get; set; }
        public string UsrUsername { get; set; }
        public string UsrPassword { get; set; }
    }
}
