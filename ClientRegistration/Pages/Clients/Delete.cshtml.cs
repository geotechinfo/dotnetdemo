using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClientRegistration.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string errorMessage = "";
        public void OnGet()
        {
            String id = Request.Query["id"];
            try
            {
                string connetionString = "Data Source=GIPL-NTB072;Initial Catalog=registrationDetails;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    connection.Open();
                    String sql = "DELETE FROM clients WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader dataReader = command.ExecuteReader();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            Response.Redirect("/Clients/Index");
        }
    }
}
