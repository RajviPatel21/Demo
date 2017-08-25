using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestLibrary;
using System.Configuration;
using System.Windows.Forms;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         Class1 objClass = new Class1();
    string qry;
    SqlConnection cn = new SqlConnection();
    SqlDataReader dr;
    DataSet ds = new DataSet();

    #region Page Control Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if(!IsPostBack)
            {
                BindRepeater();
            }
        }
        catch(Exception er)
        {
            MessageBox.Show("Load Event on Color -> " + er.ToString());
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if(string.IsNullOrEmpty(hdnColorId.Value))
            {
                objClass.conopen();
                qry = "Insert Into ColorMaster(colorName) Values ('" + txtColorName.Text + "')";
                objClass.aed(qry);
                objClass.conclose();
                //lblStatus.Text = "Item Color Add Successfully";
            }
            else
            {
                objClass.conopen();
                qry = "Update ColorMaster set colorName='" + txtColorName.Text + "' where colorId ='" + Convert.ToInt32(hdnColorId.Value) + "'";
                objClass.aed(qry);
                objClass.conclose();
                //lblStatus.Text = "Item Color Updated Successfully";
            }
            txtColorName.Text = "";
            hdnColorId.Value = "";
            BindRepeater();
        }
        catch(Exception er)
        {
            MessageBox.Show("Submit Button Error on Item Color -> " + er.ToString());
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtColorName.Text = "";
        hdnColorId.Value = "";
    }
    #endregion

    #region Methods
    protected void BindRepeater()
    {
        try
        {
            string qry = "";
            objClass.conopen();
            qry = "Select * From ColorMaster ";
            ds = objClass.adp(qry);
            repColorDetails.DataSource = ds;
            repColorDetails.DataBind();

            ds.Clear();
            ds.Dispose();


            objClass.conclose();
        }
        catch(Exception er)
        {
            MessageBox.Show("Color.cs->FillDDL" + er);
        }

    }
    #endregion

    }
}