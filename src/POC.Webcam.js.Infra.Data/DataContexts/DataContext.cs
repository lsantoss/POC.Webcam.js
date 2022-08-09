using POC.Webcam.js.Infra.Data.Interfaces.DataContexts;
using POC.Webcam.js.Infra.Settings;
using System.Data;
using System.Data.SqlClient;

namespace POC.Webcam.js.Infra.Data.DataContexts
{
    public class DataContext : IDataContext
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