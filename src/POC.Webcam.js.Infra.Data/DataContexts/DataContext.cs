using POC.Webcam.js.Infra.Settings;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POC.Webcam.js.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection Connection { get; }

        public DataContext(AppSettings appSettings)
        {
            Connection = new SqlConnection(appSettings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}