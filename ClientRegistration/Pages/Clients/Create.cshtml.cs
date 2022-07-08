using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClientRegistration.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            clientInfo.name = Request.Form["name"];
            clientInfo.gender = Request.Form["gender"];

            if(clientInfo.name.Length == 0 || clientInfo.age.ToString().Length == 0 ||
                ((String)Request.Form["age"]).Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }
            clientInfo.age = Int32.Parse(Request.Form["age"]);
            if (clientInfo.age <= 0 || clientInfo.age.GetType() == 1.5.GetType())
            {
                errorMessage = "Invalid Age";
                return;
            }
            
            try
            {
                string connetionString = "Data Source=GIPL-NTB072;Initial Catalog=registrationDetails;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO clients (name, age, gender) VALUES " +
                        "(@name, @age, @gender);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", clientInfo.name);
                        command.Parameters.AddWithValue("@age", clientInfo.age);
                        command.Parameters.AddWithValue("@gender", clientInfo.gender);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            clientInfo.name = ""; clientInfo.age = 0; clientInfo.gender = "";
            successMessage = "New Client Added Correctly";

            Response.Redirect("/Clients/Index");
        }
    }
}
