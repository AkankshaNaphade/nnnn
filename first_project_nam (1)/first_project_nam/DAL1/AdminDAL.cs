using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BOL;

namespace DAL1
{
    public static class AdminDAL
    {
        
        public static bool ValidateAdmin(string Email, string Password)
        {
            bool status = false;
             string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\nam adjava\dot_net\first_project_nam\WPFEcomm\App_Data\Admin.mdf;Integrated Security=True";

        SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            string cmdString = "select *from Admin where Email=@Email and Password=@Password ";
            cmd.CommandText = cmdString;

            cmd.Parameters.Add(new SqlParameter("@Email", Email));
            cmd.Parameters.Add(new SqlParameter("@Password", Password));
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    status = true;
                }
                reader.Close();
            }
            catch (SqlException exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
                con.Close();
            }
            return status;
        }
        public static bool Register(int Id,string Email,string Password)
        {
            bool status = false;
            string query = "insert into Admin values(@Id,@Email,@Password)";
           string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\nam adjava\dot_net\first_project_nam\WPFEcomm\App_Data\Admin.mdf;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(conString))
            {
                
             using (SqlCommand cmd = new SqlCommand(query))
                {
                   
                    cmd.Parameters.Add(new SqlParameter("@Id",Id));
                    cmd.Parameters.Add(new SqlParameter("@Email",Email));
                    cmd.Parameters.Add(new SqlParameter("@Password",Password));

                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    status = true;
                  }
            }
            return status;

        }
      
        public static bool Update(int Id, string Password)
        {
            bool status = false;

            string query = "update Admin set Password=@Password where Id=@Id";
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\nam adjava\dot_net\first_project_nam\WPFEcomm\App_Data\Admin.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    status = true;
                }
            }
            return status;
        }
        public static bool Delete(int Id)
        {
            bool status = false;
            string query = "delete from Admin where @Id=Id";
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\nam adjava\dot_net\first_project_nam\WPFEcomm\App_Data\Admin.mdf;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(conString))
            {

                using (SqlCommand cmd = new SqlCommand(query))
                {

                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
    

                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    status = true;
                }
            }
            return status;

        }
    }
}


