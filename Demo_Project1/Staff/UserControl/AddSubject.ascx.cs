using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Demo_Project1.Staff.UserControl
{
	public partial class AddSubject : System.Web.UI.UserControl
	{
		SqlConnection con;
		SqlCommand cmd;
		public AddSubject()
		{
			con = new SqlConnection();
			con.ConnectionString = ConfigurationManager.ConnectionStrings["Dbconnection"].ToString();
			cmd = new SqlCommand();

		}

		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				con.Open();
				cmd.CommandText = "INSERT into Subject_table (SubjectName) VALUES (@SubjectName)";
				//cmd.Parameters.AddWithValue("@SubjectName", subjecttxt.Text);
				cmd.Connection = con;
				int a = cmd.ExecuteNonQuery();
				if (a > 0)
				{
					Label1.Text = "Add record Successfully";

				}
				else
				{
					Label1.Text = "Record Error";
				}
			}
			catch (Exception ex)
			{
				Label1.Text = " Error in Connection" + ex.Message;
			}
			finally
			{
				con.Close();
			}
		}

		protected void subjecttxt_TextChanged(object sender, EventArgs e)
		{

		}
	}
}