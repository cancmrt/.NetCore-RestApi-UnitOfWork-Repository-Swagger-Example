using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Connection.Abstract
{
    public interface IConnectionFactory:IDisposable
    {
        IDbConnection Connect { get; }

        String GetConnectionString();

    }
}
