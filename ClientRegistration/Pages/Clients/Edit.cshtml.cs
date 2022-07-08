using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClientRegistration.Pages.Clients
{
    public class EditModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
            String id = Request.Query["id"];
            try
            {
                string connetionString = "Data Source=GIPL-NTB072;Initial Catalog=registrationDetails;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                clientInfo.id = "" + dataReader.GetInt32(0);
                                clientInfo.name = dataReader.GetString(1);
                                clientInfo.age = dataReader.GetInt32(2);
                                clientInfo.gender = dataReader.GetString(3);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        public void OnPost()
        {
            clientInfo.id = "" + Request.Form["id"];
            clientInfo.name = Request.Form["name"];
            clientInfo.age = Int32.Parse(Request.Form["age"]);
            clientInfo.gender = Request.Form["gender"];

            if (clientInfo.name.Length == 0 || clientInfo.age.ToString().Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }
            else if (clientInfo.age <= 0 || clientInfo.age.GetType() == 1.5.GetType())
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
                    String sql = "UPDATE clients SET name=@name, age=@age, gender=@gender " +
                        "WHERE id=@id;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", clientInfo.id);
                        command.Parameters.AddWithValue("@name", clientInfo.name);
                        command.Parameters.AddWithValue("@age", clientInfo.age);
                        command.Parameters.AddWithValue("@gender", clientInfo.gender);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            clientInfo.name = ""; clientInfo.age = 0; clientInfo.gender = "";
            successMessage = "Client details updated succesfully";
            Response.Redirect("/Clients/Index");
         }
    }
}
