using LabTask3.Utils;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabTask3.Views
{
    public partial class InstantSearch : System.Web.UI.Page
    {
        DbContext contex=new DbContext();
        Timer timer=new Timer();
        protected void Page_Load(object sender, EventArgs e)
        {
            SynchData();
        }

        void SynchData(string name=default)
        {
            string query = "select * from Students";
            if(!string.IsNullOrEmpty(name))
              query = $"select * from Students where Name like '%{name}%'";
            var data=contex.FetchTable(query);
            if(data!=null)
            {
                searchList.DataSource = data; 
                searchList.DataBind();  
            }
        }
        protected void srchbx_TextChanged(object sender, EventArgs e)
        {
           
            var txt=srchbx.Text.ToLower();
            
            SynchData(txt);
        }
    }
}