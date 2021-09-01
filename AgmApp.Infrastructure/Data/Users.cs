using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgmApp.Infrastructure.Data
{
    public partial class Users
    {
        public Users()
        {
            RolesUsuario = new HashSet<RolesUsuario>();
        }

        public int Id { get; set; }
        public string UsrIdPk { get; set; }
        public string UsrNombres { get; set; }
        public string UsrUsername { get; set; }
        public string UsrPassword { get; set; }

        public virtual ICollection<RolesUsuario> RolesUsuario { get; set; }
    }
}
