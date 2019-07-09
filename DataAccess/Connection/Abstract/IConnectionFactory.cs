using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Connection.Abstract
{
    public interface IConnectionFactory:IDisposable
    {
        IDbConnection Connection {get;}

        String GetConnectionString();
    }
}
