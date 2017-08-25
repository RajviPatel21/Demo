using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestLibrary
{
    public class Class1
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter dp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public void ConnectionClass()
        {
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }
        public void conopen()
        {
            try
            {
                cn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Open Connection");
                throw;
            }
        }

        public void conclose()
        {
            try
            {
                cn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Close Connecton");
                throw;
            }
        }

        public void aed(string qry)
        {
            try
            {
                cmd.Connection = cn;
                cmd.CommandText = qry;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid ");
            }
        }

        public DataSet adp(string qry)
        {
            try
            {
                dp = new SqlDataAdapter(qry, cn);
                dp.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("invalid");
                throw;
            }
        }
        }

    }

