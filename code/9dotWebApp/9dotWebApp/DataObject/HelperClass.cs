using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Data;

namespace _9dotWebApp.DataObject
{
    public class HelperClass
    {
        DataObject.DbConnection conn;
        MySqlConnection sqlconn;

        public HelperClass() {

        }

        public String getMonthIdForMonth(String month_name)
        {
            String m_id = "";

            try
            {
                switch (month_name)
                {
                    case "Jan":
                        m_id = "1";
                        break;
                    case "Feb":
                        m_id = "2";
                        break;
                    case "Mar":
                        m_id = "3";
                        break;
                    case "Apr":
                        m_id = "4";
                        break;
                    case "May":
                        m_id = "5";
                        break;
                    case "Jun":
                        m_id = "6";
                        break;
                    case "Jul":
                        m_id = "7";
                        break;
                    case "Aug":
                        m_id = "8";
                        break;
                    case "Sep":
                        m_id = "9";
                        break;
                    case "Oct":
                        m_id = "10";
                        break;
                    case "Nov":
                        m_id = "11";
                        break;
                    case "Dec":
                        m_id = "12";
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return m_id;
        }

        public String getQuarterForMonth(String month_name)
        {
            String m_id = "";

            try
            {
                switch (month_name)
                {
                    case "Jan":
                        m_id = "Q1";
                        break;
                    case "Feb":
                        m_id = "Q1";
                        break;
                    case "Mar":
                        m_id = "Q1";
                        break;
                    case "Apr":
                        m_id = "Q2";
                        break;
                    case "May":
                        m_id = "Q2";
                        break;
                    case "Jun":
                        m_id = "Q2";
                        break;
                    case "Jul":
                        m_id = "Q3";
                        break;
                    case "Aug":
                        m_id = "Q3";
                        break;
                    case "Sep":
                        m_id = "Q3";
                        break;
                    case "Oct":
                        m_id = "Q4";
                        break;
                    case "Nov":
                        m_id = "Q4";
                        break;
                    case "Dec":
                        m_id = "Q4";
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return m_id;
        }

        public void changeTextBoxEditingMode(List<TextBox> list, int editMode)
        {
            try
            {
                if (editMode == 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].Enabled = false;
                        list[i].CssClass = "input-field-disabled";
                    }
                }
                else if (editMode == 1)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].Enabled = true;
                        list[i].CssClass = "input-field-enabled";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void changeTextBoxEditingMode(TextBox textbox, int editMode)
        {
            try
            {
                if (editMode == 0)
                {
                    textbox.Enabled = false;
                    textbox.CssClass = "input-field-disabled";
                }
                else if (editMode == 1)
                {
                    textbox.Enabled = true;
                    textbox.CssClass = "input-field-enabled";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void changeButtonMode(Button button, int editMode)
        {
            try
            {
                if (editMode == 0)
                {
                    button.Enabled = false;
                    button.CssClass = "btn-sub-disabled";
                }
                else if (editMode == 1)
                {
                    button.Enabled = true;
                    button.CssClass = "btn-sub-enabled";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void changeDropDownListMode(DropDownList dropdownlist, int editMode)
        {
            try
            {
                if (editMode == 0)
                {
                    dropdownlist.Enabled = false;
                }
                else if (editMode == 1)
                {
                    dropdownlist.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void showAlert(Page page, String message) {
            try {
                ScriptManager.RegisterStartupScript(page, page.GetType(),
                    "err_msg",
                    "alert('"+message+"');",
                    true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void showDialog(Page page, String dialog)
        {
            try
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(),
                    "err_msg",
                    dialog,
                    true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void populateYearDropDown(DropDownList dropdownlist)
        {
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                // Years Dropdownlist
                String query = "SELECT year FROM tb_years";
                MySqlCommand cmd_years = new MySqlCommand();
                cmd_years.Connection = sqlconn;
                cmd_years.CommandText = query;

                MySqlDataAdapter da_years = new MySqlDataAdapter(cmd_years);
                DataTable dt_years = new DataTable();
                da_years.Fill(dt_years);

                dropdownlist.DataSource = dt_years;
                dropdownlist.DataValueField = dt_years.Columns[0].ColumnName;
                dropdownlist.DataTextField = dt_years.Columns[0].ColumnName;
                dropdownlist.DataBind();

                ListItem item = new ListItem("", "");
                dropdownlist.Items.Insert(0, item);

                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void populateCountries(DropDownList dropdownlist)
        {
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                // Countries/Subsidiaries Dropdownlist
                String query = "SELECT DISTINCT country_name FROM tb_verticals";
                MySqlCommand cmd_countries = new MySqlCommand();
                cmd_countries.Connection = sqlconn;
                cmd_countries.CommandText = query;

                MySqlDataAdapter da_countries = new MySqlDataAdapter(cmd_countries);
                DataTable dt_countries = new DataTable();
                da_countries.Fill(dt_countries);

                dropdownlist.DataSource = dt_countries;
                dropdownlist.DataValueField = dt_countries.Columns[0].ColumnName;
                dropdownlist.DataTextField = dt_countries.Columns[0].ColumnName;
                dropdownlist.DataBind();

                ListItem item = new ListItem("", "");
                dropdownlist.Items.Insert(0, item);

                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void populateVerticals(String country, DropDownList dropdownlist)
        {

            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                // Verticals Dropdownlist
                String query = "SELECT vertical_name FROM tb_verticals where country_name=@country";
                MySqlCommand cmd_verticals = new MySqlCommand();
                cmd_verticals.Connection = sqlconn;
                cmd_verticals.CommandText = query;
                cmd_verticals.Parameters.AddWithValue("@country", country);

                MySqlDataAdapter da_verticals = new MySqlDataAdapter(cmd_verticals);
                DataTable dt_verticals = new DataTable();
                da_verticals.Fill(dt_verticals);

                dropdownlist.DataSource = dt_verticals;
                dropdownlist.DataValueField = dt_verticals.Columns[0].ColumnName;
                dropdownlist.DataTextField = dt_verticals.Columns[0].ColumnName;
                dropdownlist.DataBind();

                ListItem item = new ListItem("", "");
                dropdownlist.Items.Insert(0, item);

                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public String getCurrencyForCountry(String country, String vertical)
        {
            String curr = "";
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "SELECT currency_name"
                                + " FROM tb_verticals"
                                + " WHERE country_name = @country"
                                + " AND vertical_name = @vertical";
                MySqlCommand cmd_currency = new MySqlCommand();
                cmd_currency.Connection = sqlconn;
                cmd_currency.CommandText = query;
                cmd_currency.Parameters.AddWithValue("@country", country);
                cmd_currency.Parameters.AddWithValue("@vertical", vertical);

                MySqlDataReader dr_data = cmd_currency.ExecuteReader();

                if (dr_data.HasRows)
                {
                    while (dr_data.Read())
                    {
                        curr = dr_data["currency_name"].ToString();
                    }
                    dr_data.Close();
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return curr;
        }

        public void updateDimensionOnSubmission(String tableName)
        {
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "SET SQL_SAFE_UPDATES = 0;"
                                + " update "+ tableName +" tb"
                                + " set tb.DateId = (select d.id from dim_time d where d.year = tb.year and d.month = tb.month_id)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = sqlconn;
                cmd.CommandText = query;

                int rowCount = cmd.ExecuteNonQuery();

                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public Boolean checkRatesData(String year, String month, String currency, String valuesToCheck)
        {
            Boolean exists = false;
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();
                if (currency == "USD")
                {
                    exists = true;
                }
                else
                {
                    if (valuesToCheck == "CC")
                    {
                        String query = "SELECT cc_rate_value"
                                   + " FROM tb_cc_rate"
                                   + " WHERE year = @year"
                                   + " AND month = @month"
                                   + " AND currency = @currency"
                                   + " AND edit_mode = '0'";

                        MySqlCommand cmd_currency = new MySqlCommand();
                        cmd_currency.Connection = sqlconn;
                        cmd_currency.CommandText = query;
                        cmd_currency.Parameters.AddWithValue("@year", year);
                        cmd_currency.Parameters.AddWithValue("@month", month);
                        cmd_currency.Parameters.AddWithValue("@currency", currency);

                        MySqlDataReader dr_data = cmd_currency.ExecuteReader();

                        if (dr_data.HasRows)
                        {
                            exists = true;
                        }
                        else
                        {
                            exists = false;
                        }

                    }
                    else if (valuesToCheck == "Actual")
                    {
                        String query = "SELECT value"
                                   + " FROM tb_fc_to_usd_actual"
                                   + " WHERE year = @year"
                                   + " AND month = @month"
                                   + " AND currency = @currency"
                                   + " AND edit_mode = '0'";

                        MySqlCommand cmd_currency = new MySqlCommand();
                        cmd_currency.Connection = sqlconn;
                        cmd_currency.CommandText = query;
                        cmd_currency.Parameters.AddWithValue("@year", year);
                        cmd_currency.Parameters.AddWithValue("@month", month);
                        cmd_currency.Parameters.AddWithValue("@currency", currency);

                        MySqlDataReader dr_data = cmd_currency.ExecuteReader();

                        if (dr_data.HasRows)
                        {
                            exists = true;
                        }
                        else
                        {
                            exists = false;
                        }
                    }
                    conn.closeConn(sqlconn);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return exists;
        }

        public Decimal fetchRates(String year, String month, String currency, String valuesToCheck)
        {
            Decimal rate = 0;

            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                if (currency == "USD")
                {
                    rate = 1;
                }
                else
                {
                    if (valuesToCheck == "CC")
                    {
                        String query = "SELECT cc_rate_value"
                                    + " FROM tb_cc_rate cc "
                                    + " WHERE year = @year"
                                    + " AND month = @month"
                                    + " AND currency = @currency";

                        MySqlCommand cmd_currency = new MySqlCommand();
                        cmd_currency.Connection = sqlconn;
                        cmd_currency.CommandText = query;
                        cmd_currency.Parameters.AddWithValue("@year", year);
                        cmd_currency.Parameters.AddWithValue("@month", month);
                        cmd_currency.Parameters.AddWithValue("@currency", currency);

                        MySqlDataReader dr_data = cmd_currency.ExecuteReader();

                        if (dr_data.HasRows)
                        {
                            while (dr_data.Read())
                            {
                                Decimal.TryParse(dr_data["cc_rate_value"].ToString(), out rate);
                            }
                            dr_data.Close();
                        }
                        else
                        {
                            rate = 1;
                        }
                    }
                    else if (valuesToCheck == "Actual")
                    {
                        String query = "SELECT value"
                                    + " FROM tb_fc_to_usd_actual"
                                    + " WHERE year = @year"
                                    + " AND month = @month"
                                    + " AND currency = @currency";

                        MySqlCommand cmd_currency = new MySqlCommand();
                        cmd_currency.Connection = sqlconn;
                        cmd_currency.CommandText = query;
                        cmd_currency.Parameters.AddWithValue("@year", year);
                        cmd_currency.Parameters.AddWithValue("@month", month);
                        cmd_currency.Parameters.AddWithValue("@currency", currency);

                        MySqlDataReader dr_data = cmd_currency.ExecuteReader();

                        if (dr_data.HasRows)
                        {
                            while (dr_data.Read())
                            {
                                Decimal.TryParse(dr_data["value"].ToString(), out rate);
                            }
                            dr_data.Close();
                        }
                        else
                        {
                            rate = 1;
                        }
                    }
                    conn.closeConn(sqlconn);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return rate;
        }

        public String applyRate(String value, Decimal rateApplied, Decimal adsShare, String page)
        {
            String returnValue = "";
            Decimal appliedValue;
            Decimal lc_value;
            try
            {
                Decimal.TryParse(value.Trim().TrimStart('0'), out lc_value);
                appliedValue = lc_value / rateApplied;
                if (page == "report")
                {
                    if (adsShare == 0)
                    {
                        appliedValue = appliedValue * 1;
                    }
                    else {
                        appliedValue = appliedValue * (adsShare / 100);
                    }
                    
                }
                returnValue = Convert.ToString(Decimal.Round(appliedValue, 3));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return returnValue;
        }

        public String applyAdsShare(String value, Decimal adsShare)
        {
            String returnValue = "";
            Decimal appliedValue;
            Decimal lc_value;
            try
            {
                Decimal.TryParse(value.Trim().TrimStart('0'), out lc_value);
                if (adsShare == 0)
                {
                    appliedValue = lc_value * 1;
                }
                else {
                    appliedValue = lc_value * (adsShare / 100);
                }
                returnValue = Convert.ToString(Decimal.Round(appliedValue, 3));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return returnValue;
        }

        public String applyThousandFormat(String value)
        {
            String returnValue = "";
            Decimal lc_value;
            try
            {
                Decimal.TryParse(value, out lc_value);
                returnValue = String.Format("{0:N}", lc_value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return returnValue;
        }
   
        public void clearZeroStrings(List<TextBox> list) {
            try {
                for (int i = 0; i < list.Count; i++) {
                    list[i].Text.Trim().TrimStart('0');
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

    }
}