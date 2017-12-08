// IN THE NAME OF ALLAH THE MOST BENEFICIENT THE MERCIFUL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;

namespace _9dotWebApp.DataObject
{

    public class DbConnection
    {

        String constr = null;
        /// <summary>
        /// Below constructor contain the database connection info
        /// </summary>
        public DbConnection()
        {
            // Below database connection for local machine
            //constr = "Server=localhost;Port=3306;Database=axiata;User ID=faizan;Password=admin123";
            //constr = "Server=localhost;Port=3306;Database=axiata_changes;User ID=faizan;Password=admin123";
            constr = ConfigurationManager.ConnectionStrings["AxiataConnectionString"].ConnectionString;
        }

        /// <summary>
        /// This function return Sql Connection object
        /// </summary>
        /// <returns></returns>
        public MySqlConnection getDatabaseConnection()
        {
            MySqlConnection sqlconn = new MySqlConnection();
            try
            {
                sqlconn.ConnectionString = constr;
                sqlconn.Open();
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
            return sqlconn;
        }

        /// <summary>
        /// This function use for DML operation.
        /// </summary>
        /// <param name="str_sql"></param>
        /// <param name="sqlconn"></param>
        /// <returns></returns>
        public int doInsertUpdateDelete(String str_sql, MySqlConnection sqlconn)
        {
            int i = 0;
            MySqlCommand insert_command = new MySqlCommand(str_sql, sqlconn);
            i = insert_command.ExecuteNonQuery();
            return i;
        }

        /// <summary>
        /// This function return Sql data reader object
        /// </summary>
        /// <param name="str_sql"></param>
        /// <param name="sqlconn"></param>
        /// <returns></returns>
        public MySqlDataReader getData(String str_sql, MySqlConnection sqlconn)
        {
            MySqlCommand selectcommand = sqlconn.CreateCommand();
            selectcommand.CommandText = str_sql;
            MySqlDataReader selectreader = selectcommand.ExecuteReader();
            return selectreader;
        }

        /// <summary>
        /// This function return data table 
        /// </summary>
        /// <param name="str_sql"></param>
        /// <param name="sqlconn"></param>
        /// <returns></returns>
        public DataTable getDataTable(String str_sql, MySqlConnection sqlconn)
        {
            MySqlCommand selectedcommand = new MySqlCommand();
            selectedcommand = sqlconn.CreateCommand();
            selectedcommand.CommandText = str_sql;
            selectedcommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable("DataTable");
            MySqlDataAdapter da = new MySqlDataAdapter(selectedcommand);
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// This function close the Sql data reader object
        /// </summary>
        /// <param name="sqlreader"></param>
        public void closeReader(MySqlDataReader sqlreader)
        {

            sqlreader.Close();
            sqlreader.Dispose();
        }

        /// <summary>
        /// This function close the Sql connection object.
        /// </summary>
        /// <param name="sqlconn"></param>
        public void closeConn(MySqlConnection sqlconn)
        {
            sqlconn.Close();
            sqlconn.Dispose();
        }






    }
}