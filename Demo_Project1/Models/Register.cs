using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Web.Mvc;

namespace Demo_Project1.Models
{
	public class Register
	{
		//For Login Model
		public int ValidateUser(string user_name, string password)
		{
			string strcon = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
			int UserTypeId;
			SqlConnection con = new SqlConnection(strcon);
			SqlCommand cmd = new SqlCommand();
			try
			{
				cmd.Connection = con;
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = "LoginUser";
				cmd.Parameters.Add("@user_name", SqlDbType.VarChar).Value = user_name;
				cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
				cmd.Parameters.Add("@result", SqlDbType.Int);
				cmd.Parameters["@result"].Direction = ParameterDirection.Output;
				con.Open();
				cmd.ExecuteNonQuery();
				UserTypeId = Convert.ToInt32(cmd.Parameters["@result"].Value);
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				con.Close();
			}
			return UserTypeId;
		}

		//For Register Model
		public void Savedata(string user_name, DateTime dob, string mail_id, string password, string confirm_password, string phone_number, string Address)
		{

			string strcon = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
			SqlConnection DbConnection = new SqlConnection(strcon);
			DbConnection.Open();
			SqlCommand command = new SqlCommand("INSERT into Registration_Table (user_name,dob,mail_id,password,confirm_password,phone_number,Address) VALUES (@user_name,@dob,@mail_id,@password,@confirm_password,@phone_number,@Address)", DbConnection);
			command.Parameters.Add(new SqlParameter("@user_name", user_name));
			command.Parameters.Add(new SqlParameter("@dob", dob));
			command.Parameters.Add(new SqlParameter("@mail_id", mail_id));
			command.Parameters.Add(new SqlParameter("@password", password));
			command.Parameters.Add(new SqlParameter("@confirm_password", confirm_password));
			command.Parameters.Add(new SqlParameter("@phone_number", phone_number));
			command.Parameters.Add(new SqlParameter("@Address", Address));
			command.ExecuteNonQuery();
		}

		//For Questionniare Model
		public List<questions> Questionniare()
		{
			List<questions> listid = new List<questions>();
			
			string strcon = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
			SqlConnection conn = new SqlConnection(strcon);
			string queryString = " select * from QuestionsTable";
			conn.Open();
			SqlCommand cmd = new SqlCommand(queryString, conn);
			SqlDataReader dr = cmd.ExecuteReader();
			while (dr.Read())
			{
				questions question = new questions();
				question.QuestionId = Convert.ToInt32(dr["QuestionId"]);
				question.Questions = dr["Questions"].ToString();
				question.OptionA = dr["OptionA"].ToString();
				question.OptionB = dr["OptionB"].ToString();
				question.OptionC = dr["OptionC"].ToString();
				question.OptionD = dr["OptionD"].ToString();
				question.OptionE = dr["OptionE"].ToString();
				question.Correct_Answer = dr["Correct_Answer"].ToString();
				listid.Add(question);
			}
			return listid;
		}

        //For Save Table
        public void SaveDataFromUser(List<SelectListItem> list, List<questions> listids, string User_Id)
        {

            string strcon = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            SqlConnection DbConnection = new SqlConnection(strcon);
            DbConnection.Open();

            for (int i = 0; i <= 19; i++)
            {
                SqlCommand command = new SqlCommand("insert into Save_Table (User_Id , QuestionId ,Questions, Correct_Answer) values('" + User_Id + "'," + list[i].Text + ",'" + listids[i].Questions + "','" + list[i].Value + "')", DbConnection);

                command.ExecuteNonQuery();
            }
        }
    }
}

	
				

