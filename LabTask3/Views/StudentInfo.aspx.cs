using LabTask3.Enums;
using LabTask3.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabTask3.Views
{
    public partial class StudentInfo : System.Web.UI.Page
    {
        DbContext context=new DbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FetchData();
                LoadDegress();
                LoadDepts();
            }
        }

        void FetchData(string query="select * from Students")
        {
           var table= context.FetchTable(query);
           listStudents.DataSource = table;
           listStudents.DataBind();
        }
       void LoadDegress()
        {
            programList.Items.Clear();
            foreach (var degree in Enum.GetValues(typeof(Degree)))
            {
                programList.Items.Add(degree.ToString());

            }
        }

        void LoadDepts()
        {
            optDept.Items.Clear();
            foreach (var dept in Enum.GetValues(typeof(OfferedDept)))
            {
                optDept.Items.Add(dept.ToString());
                filter.Items.Add(dept.ToString());
            }
            
        }


        protected void listStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = listStudents.SelectedRow;
            if(selectedRow!=null)
            {
               
                lblStdId.Text = listStudents.DataKeys[selectedRow.RowIndex]["ID"].ToString();    
                stdID.Text= listStudents.DataKeys[selectedRow.RowIndex]["ID"].ToString();
                stdName.Text= listStudents.DataKeys[selectedRow.RowIndex]["Name"].ToString();
                stdDOB.Text = DateTime.ParseExact(listStudents.DataKeys[selectedRow.RowIndex]["DOB"].ToString(), "MM/dd/yyyy h:mm:ss tt",CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
             //   stdDOB.Text = DateTime.ParseExact(dob, "dd-MM-yyyy",CultureInfo.InvariantCulture).ToString();
                lblStdDept.Text= listStudents.DataKeys[selectedRow.RowIndex]["Dept"].ToString();
                optDept.SelectedValue= listStudents.DataKeys[selectedRow.RowIndex]["Dept"].ToString();
                programList.SelectedValue= listStudents.DataKeys[selectedRow.RowIndex]["Program"].ToString();
           
            }
        }

        protected void programList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void OnStudentCreate(object o, EventArgs e)
        {
            var d =DateTime.ParseExact(stdDOB.Text.ToString(), "MM-dd-yyyy", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
            string query = $"insert into Students values('{stdID.Text}','{stdName.Text}','{optDept.SelectedValue}','{d}','{programList.SelectedValue}')";
            var res = context.InsertDataIntoTable(query);
            msg.Text = res.Message;
            FetchData();
        }

        protected void OnStudentUpdate(object o, EventArgs e)
        {
            var d =stdDOB.Text.ToString();
            string query = $"update Students set Name='{stdName.Text}',Dept='{optDept.SelectedValue}', Program='{programList.SelectedValue}',DOB='{d}' where ID='{lblStdId.Text}'";
            var res=context.UpdateDataInTable(query);
            msg.Text = res.Message;
            FetchData();
        }


        protected void OnStudentDelete(object o, EventArgs e)
        {
            var query = $"delete from Students where ID='{lblStdId.Text}'";
            var res=context.DeleteDataFromTable(query);
            msg.Text = res.Message;
            FetchData();
        }

        protected void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = $"select * from Students where Dept= '{filter.SelectedValue}'";
            FetchData(query);
        }
    }
}