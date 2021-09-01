using AgmApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgmApp.Infrastructure.Repositories
{
    public class Repository
    {

        public readonly AgmAppContext _context;

        public Repository(AgmAppContext context)
        {
            this._context = context;
        }

    }
}
