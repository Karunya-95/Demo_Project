using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Demo_Project1
{
	public class questions
	{
		public int QuestionId { get; set; }
		public string Questions{ get; set; }
		public string OptionA { get; set; }
		public string OptionB { get; set; }
		public string OptionC { get; set; }
		public string OptionD { get; set; }
		public string OptionE { get; set; }
		public string Correct_Answer { get; set; }
		public string User_Name { get; set; }
	}
}