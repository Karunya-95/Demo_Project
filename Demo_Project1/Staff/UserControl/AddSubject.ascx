<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddSubject.ascx.cs" Inherits="Demo_Project1.Staff.UserControl.AddSubject" %>
<style type="text/css">
	.auto-style1 {
		width: 145px;
	}
	.auto-style2 {
		width: 30px;
	}
	.auto-style3 {
		width: 145px;
		height: 31px;
	}
	.auto-style4 {
		width: 30px;
		height: 31px;
	}
	.auto-style5 {
		height: 31px;
	}
</style>

<table style="width:100%;">
	<tr>
		<td class="auto-style1">Enter Subject Name:</td>
		<td class="auto-style2">tamil<br />
		</td>
		<td>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="subjecttxt" ErrorMessage="Please Enter the Subject Name" ForeColor="Red" ValidationGroup="subjectvalidation">*</asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<td class="auto-style3"></td>
		<td class="auto-style4">
			<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" ValidationGroup="subjectvalidation" />
		</td>
		<td class="auto-style5"></td>
	</tr>
	<tr>
		<td class="auto-style1">&nbsp;</td>
		<td class="auto-style2">
			<asp:Label ID="Label1" runat="server"></asp:Label>
		</td>
		<td>&nbsp;</td>
	</tr>
</table>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="subjectvalidation" />

