using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace JobOfferWebApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            SqlConnection conn =new SqlConnection( @"Server=LAPTOP-14M4GSCP\SQLEXPRESS;Database=Job;Integrated Security=True");

          
                try
                {
                    conn.Open();

                
                    string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";

               SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        da.SelectCommand.Parameters.AddWithValue("@Username", username);
                        da.SelectCommand.Parameters.AddWithValue("@Password", password); 

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                           Response.Write("<script>alert('Login Successful!');</script>");
                        }
                        else
                        {
                         
                            Response.Write("<script>alert('Username or password incorrect !');</script>");
                        }
                    
                }
                catch (Exception ex)
                {
               
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", ex.Message, true);
                }
            
        }
    }
}
