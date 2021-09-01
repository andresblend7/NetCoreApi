using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgmApp.Infrastructure.Data
{
    public partial class Roles
    {
        public Roles()
        {
            RolesUsuario = new HashSet<RolesUsuario>();
        }

        public int Id { get; set; }
        public string RolRowId { get; set; }
        public string RolName { get; set; }

        public virtual ICollection<RolesUsuario> RolesUsuario { get; set; }
    }
}
