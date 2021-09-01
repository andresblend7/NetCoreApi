using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgmApp.Infrastructure.Data
{
    public partial class RolesUsuario
    {
        public int Id { get; set; }
        public int IdUsuarioFk { get; set; }
        public int IdRolFk { get; set; }
        public bool Status { get; set; }

        public virtual Roles IdRolFkNavigation { get; set; }
        public virtual Users IdUsuarioFkNavigation { get; set; }
    }
}
