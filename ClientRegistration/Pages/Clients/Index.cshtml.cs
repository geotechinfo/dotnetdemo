using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace ClientRegistration.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> clientList = new List<ClientInfo>();
        public void OnGet()
        {
            string sql = null;
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader dataReader;
            connetionString = "Data Source=GIPL-NTB072;Initial Catalog=registrationDetails;Integrated Security=True";
            sql = "Select * from clients";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    ClientInfo clientInfo = new ClientInfo();
                    clientInfo.id = "" + dataReader.GetInt32(0);
                    clientInfo.name = dataReader.GetString(1);
                    clientInfo.age = dataReader.GetInt32(2);
                    clientInfo.gender = dataReader.GetString(3);

                    clientList.Add(clientInfo);

                }
                Console.WriteLine(clientList);
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.ToString());
            }
        }
    }
    public class ClientInfo
    {
        public string id;
        public string name;
        public int age;
        public string gender;
    }
}
