// IN THE NAME OF ALLAH THE MOST BENEFICIENT THE MERCIFUL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;

namespace _9dotWebApp
{
    public partial class index : System.Web.UI.Page
    {

        DataObject.DbConnection conn;
        MySqlConnection sqlconn;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new DataObject.DbConnection();

                sqlconn = conn.getDatabaseConnection();
                //MySqlCommand cmd = new MySqlCommand("select * from tb_fc_to_usd_actual", sqlconn);
                //DataSet ds = new DataSet();
                //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                //da.Fill(ds);
                //GridView1.Columns[0].HeaderText = "currencies";
                ////GridView1.Columns.Add(ds.Tables[0].Columns[1]);
                //GridView1.DataSource = ds;
                //GridView1.DataBind();

                //conn.closeConn(sqlconn);
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn = conn.getDatabaseConnection();
                string SelectQuery = "SELECT * FROM actor";
                MySqlDataReader reader = conn.getData(SelectQuery, sqlconn);
                while (reader.Read())
                {

                    string Column1 = reader[0].ToString();
                    string Column2 = reader[1].ToString();

                    Response.Write(Column1 + "|" + Column2 + "\n");
                    Response.Write("\n*****************************\n");

                }
                conn.closeReader(reader);
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}