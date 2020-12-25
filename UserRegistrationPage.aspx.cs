using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Shopping_Cart_Application
{
    public partial class UserRegistrationPage : System.Web.UI.Page
    {
        SqlConnection regcon = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=shopping;Integrated Security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            regcon.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into register values(" + TextBox5.Text + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox4.Text + "','" + TextBox7.Text + "')", regcon);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e2)
            {
                Response.Write("<script>alert('Already taken Userid try someother')</script>");
            }
            regcon.Close();
            Response.Write("<script>alert('Registered Sucessfully')</script>");
            
        }

        protected void passfn(object source, ServerValidateEventArgs args)
        {
            string s = args.Value;
            args.IsValid = false;
            bool f = false;
            if (s.Length >= 8 && s.Length <= 25)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] >= 'a' && s[i] <= 'z')
                    {
                        f = true;
                        args.IsValid = true;
                        break;
                    }
                }
                if (f == false)
                {
                    CustomValidator1.ErrorMessage = "should have min 1 lowercase char";
                }
            }
            else
            {
                CustomValidator1.ErrorMessage = "password should have min 8 char and max 25 char";
            }   
        }
    }
}