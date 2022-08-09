using System;
using System.Data.SqlClient;

namespace POC.Webcam.js.Infra.Data.Interfaces.DataContexts
{
    public interface IDataContext : IDisposable
    {
        SqlConnection Connection { get; }
    }
}