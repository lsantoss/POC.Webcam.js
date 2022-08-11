using System;
using System.Data.SqlClient;

namespace POC.Webcam.js.Infra.Data.DataContexts.Interfaces
{
    public interface IDataContext : IDisposable
    {
        SqlConnection Connection { get; }
    }
}