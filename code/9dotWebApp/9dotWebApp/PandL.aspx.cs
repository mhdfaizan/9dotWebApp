using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _9dotWebApp
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        DataObject.DbConnection conn;
        MySqlConnection sqlconn;
        int edit_mode = -1;
        String currency = "";
        String monthId = "";

        List<TextBox> textBoxList = new List<TextBox>();
        List<Label> budgetLabelList = new List<Label>();

        protected void Page_Load(object sender, EventArgs e)
        {

            try {
                createTextBoxEditingModeList();
                createBudgetLabelList();

                if (!IsPostBack)
                {
                    DataObject.HelperClass helper = new DataObject.HelperClass();

                    helper.populateYearDropDown(DropDownList5_year);
                    helper.populateCountries(DropDownList1_country);
                    helper.changeDropDownListMode(DropDownList3_type, 0);
                    helper.changeTextBoxEditingMode(textBoxList, 0);
                    helper.changeButtonMode(Button2_edit, 0);
                    helper.changeButtonMode(Button3_save, 0);
                    helper.changeButtonMode(Button4_submit, 0);
                    helper.changeButtonMode(Button5_clear_all, 0);

                    ListItem item = new ListItem("", "");
                    DropDownList2_vertical.Items.Insert(0, item);

                    helper.changeDropDownListMode(DropDownList2_vertical, 0);
                }
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void DropDownList5_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();
                helper.changeButtonMode(Button2_edit, 0);

                Label33.Text = DropDownList4_month.Text + ", " + DropDownList5_year.Text;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void DropDownList4_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();
                helper.changeButtonMode(Button2_edit, 0);

                Label33.Text = DropDownList4_month.Text + ", " + DropDownList5_year.Text;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                helper.changeButtonMode(Button2_edit, 0);

                if (DropDownList1_country.SelectedIndex == 0)
                {
                    DropDownList2_vertical.SelectedIndex = 0;
                    helper.changeDropDownListMode(DropDownList2_vertical, 0);
                    Label1.Text = "Vertical";
                }
                else
                {
                    Label1.Text = "Vertical";
                    helper.changeDropDownListMode(DropDownList2_vertical, 1);
                    helper.populateVerticals(DropDownList1_country.SelectedValue, DropDownList2_vertical);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                if (DropDownList2_vertical.SelectedIndex == 0)
                {
                    Label1.Text = "Vertical";
                }
                else
                {
                    String country = DropDownList1_country.SelectedValue;
                    String vertical = DropDownList2_vertical.SelectedValue;

                    String currency = helper.getCurrencyForCountry(country, vertical);

                    Label1.Text = vertical + " - " + currency;
                }
                helper.changeButtonMode(Button2_edit, 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button5_Click_ClearAllData(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ReportData.aspx");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button2_Click_EditData(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();
                conn = new DataObject.DbConnection();

                if (Session["rowId"] != null && !Session["rowId"].Equals("-1"))
                {
                    Session["updateRow"] = true;

                    helper.changeDropDownListMode(DropDownList5_year, 0);
                    helper.changeDropDownListMode(DropDownList4_month, 0);
                    helper.changeDropDownListMode(DropDownList1_country, 0);
                    helper.changeDropDownListMode(DropDownList2_vertical, 0);
                    helper.changeDropDownListMode(DropDownList3_type, 0);

                    helper.changeButtonMode(Button6_view, 0);
                    helper.changeButtonMode(Button2_edit, 0);

                    helper.changeTextBoxEditingMode(textBoxList, 1);
                    helper.changeButtonMode(Button5_clear_all, 1);
                    helper.changeButtonMode(Button3_save, 1);
                    helper.changeButtonMode(Button4_submit, 0);
                }
                else
                {
                    Session["updateRow"] = false;

                    String year = DropDownList5_year.SelectedValue;
                    String month = DropDownList4_month.SelectedValue;
                    String country = DropDownList1_country.SelectedValue;
                    String vertical = DropDownList2_vertical.SelectedValue;
                    String type = DropDownList3_type.SelectedValue;

                    Boolean check = checkBudgetData(year, month, country, vertical, type);

                    if (check)
                    {
                        helper.changeDropDownListMode(DropDownList5_year, 0);
                        helper.changeDropDownListMode(DropDownList4_month, 0);
                        helper.changeDropDownListMode(DropDownList1_country, 0);
                        helper.changeDropDownListMode(DropDownList2_vertical, 0);
                        helper.changeDropDownListMode(DropDownList3_type, 0);

                        helper.changeButtonMode(Button6_view, 0);
                        helper.changeButtonMode(Button2_edit, 0);

                        helper.changeTextBoxEditingMode(textBoxList, 1);
                        helper.changeButtonMode(Button5_clear_all, 1);
                        helper.changeButtonMode(Button3_save, 1);
                        helper.changeButtonMode(Button4_submit, 0);
                    }
                    else
                    {
                        clearBudgetValues(budgetLabelList);
                        clearAllTextBoxes(textBoxList);
                        helper.showAlert(this.Page, "Please enter BUDGET to proceed!");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button3_Click_SaveData(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();
                helper.clearZeroStrings(textBoxList);

                conn = new DataObject.DbConnection();

                currency = helper.getCurrencyForCountry(DropDownList1_country.SelectedValue, DropDownList2_vertical.SelectedValue);
                Boolean isEdit;
                if (Session["updateRow"] != null && !Session["updateRow"].Equals("-1"))
                {
                    isEdit = Convert.ToBoolean(Session["updateRow"].ToString());
                }
                else
                {
                    isEdit = false;
                }

                if (isEdit)
                {
                    //write code to update row data
                    calculateValues();
                    monthId = helper.getMonthIdForMonth(DropDownList4_month.SelectedValue);
                    updateData();
                }
                else
                {
                    String year = DropDownList5_year.SelectedValue;
                    String month = DropDownList4_month.SelectedValue;
                    String country = DropDownList1_country.SelectedValue;
                    String vertical = DropDownList2_vertical.SelectedValue;
                    String type = DropDownList3_type.SelectedValue;

                    Boolean dataCheck = checkDataExistsForRefresh(year, month, country, vertical, type);
                    if (dataCheck == false)
                    {
                        calculateValues();
                        monthId = helper.getMonthIdForMonth(DropDownList4_month.SelectedValue);
                        saveData();
                    }
                    else if (dataCheck == true)
                    {
                        helper.changeDropDownListMode(DropDownList5_year, 1);
                        helper.changeDropDownListMode(DropDownList4_month, 1);
                        helper.changeDropDownListMode(DropDownList1_country, 1);
                        helper.changeDropDownListMode(DropDownList2_vertical, 1);

                        helper.changeTextBoxEditingMode(textBoxList, 0);

                        helper.changeButtonMode(Button5_clear_all, 0);
                        helper.changeButtonMode(Button2_edit, 1);
                        helper.changeButtonMode(Button3_save, 0);
                        helper.changeButtonMode(Button4_submit, 1);
                        helper.changeButtonMode(Button6_view, 1);

                        populateReportData(year, month, country, vertical, type);
                        calculateDCandOPEX(1);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button4_Click_SubmitData(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();
                helper.clearZeroStrings(textBoxList);

                String year = DropDownList5_year.SelectedValue;
                String month = DropDownList4_month.SelectedValue;
                String country = DropDownList1_country.SelectedValue;
                String vertical = DropDownList2_vertical.SelectedValue;
                String type = DropDownList3_type.SelectedValue;

                conn = new DataObject.DbConnection();

                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    //write code to submit data with multiplications
                    Boolean dataCheck = checkDataExistsForRefresh(year, month, country, vertical, "Actual");
                    if (dataCheck == false)
                    {
                        currency = helper.getCurrencyForCountry(DropDownList1_country.SelectedValue, DropDownList2_vertical.SelectedValue);
                        monthId = helper.getMonthIdForMonth(DropDownList4_month.SelectedValue);
                        calculateValues();
                        updateSubmitData();
                        insertDataWithRatesApplied("Actual");
                        insertDataWithRatesApplied("CC");
                    }
                    else if (dataCheck == true)
                    {
                        //do nothing
                    }
                }
                else
                {
                    //let the dialog dismiss
                    helper.changeButtonMode(Button4_submit, 1);
                    helper.changeButtonMode(Button2_edit, 1);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button6_Click_ViewData(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();
                conn = new DataObject.DbConnection();

                String year = DropDownList5_year.SelectedValue;
                String month = DropDownList4_month.SelectedValue;
                String country = DropDownList1_country.SelectedValue;
                String vertical = DropDownList2_vertical.SelectedValue;
                String type = DropDownList3_type.SelectedValue;
                currency = helper.getCurrencyForCountry(country, vertical);

                
                Boolean ratesCheck = helper.checkRatesData(year, month, currency, "Actual");
                if (ratesCheck)
                {
                    Boolean budgetCheck = checkBudgetData(year, month, country, vertical, type);
                    if (budgetCheck)
                    {
                        populateBudgetData(year, month, country, vertical, type);
                        calculateValuesForBudget();
                        populateReportData(year, month, country, vertical, type);
                        calculateDCandOPEX(edit_mode);

                        if (edit_mode == 0)
                        {
                            helper.changeTextBoxEditingMode(textBoxList, 0);
                            helper.changeDropDownListMode(DropDownList3_type, 1);

                            helper.changeButtonMode(Button5_clear_all, 0);
                            helper.changeButtonMode(Button2_edit, 0);
                            helper.changeButtonMode(Button3_save, 0);
                            helper.changeButtonMode(Button4_submit, 0);
                        }
                        else if (edit_mode == 1)
                        {
                            helper.changeTextBoxEditingMode(textBoxList, 0);
                            helper.changeDropDownListMode(DropDownList3_type, 0);

                            helper.changeButtonMode(Button5_clear_all, 0);
                            helper.changeButtonMode(Button2_edit, 1);
                            helper.changeButtonMode(Button3_save, 0);
                            helper.changeButtonMode(Button4_submit, 1);
                        }
                        else if (edit_mode == -1)
                        {
                            clearAllTextBoxes(textBoxList);
                            helper.changeTextBoxEditingMode(textBoxList, 0);
                            clearAllTextBoxes(textBoxList);

                            helper.changeButtonMode(Button5_clear_all, 0);
                            helper.changeButtonMode(Button3_save, 0);
                            helper.changeButtonMode(Button2_edit, 1);
                        }
                    }
                    else
                    {
                        clearBudgetValues(budgetLabelList);
                        clearAllTextBoxes(textBoxList);
                        helper.changeButtonMode(Button4_submit, 0);
                        helper.showAlert(this.Page, "Please enter BUDGET to proceed!");
                    }
                }
                else
                {
                    clearBudgetValues(budgetLabelList);
                    clearAllTextBoxes(textBoxList);
                    helper.changeButtonMode(Button4_submit, 0);
                    helper.showAlert(this.Page, "Please enter FOREX RATES to proceed!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createTextBoxEditingModeList()
        {
            try
            {
                textBoxList.Add(TextBox1);
                textBoxList.Add(TextBox2);
                textBoxList.Add(TextBox3);
                textBoxList.Add(TextBox4);
                textBoxList.Add(TextBox5);
                textBoxList.Add(TextBox6);
                textBoxList.Add(TextBox8);
                textBoxList.Add(TextBox9);
                textBoxList.Add(TextBox10);
                textBoxList.Add(TextBox11);
                textBoxList.Add(TextBox12);
                textBoxList.Add(TextBox13);
                textBoxList.Add(TextBox15);
                textBoxList.Add(TextBox16);
                textBoxList.Add(TextBox17);
                textBoxList.Add(TextBox18);
                textBoxList.Add(TextBox19);
                textBoxList.Add(TextBox20);
                textBoxList.Add(TextBox7);
                textBoxList.Add(TextBox14);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void clearAllTextBoxes(List<TextBox> list)
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Text = "";
                }
                Label6.Text = "";
                Label7.Text = "";
                Label8.Text = "";
                Label9.Text = "";
                Label10.Text = "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private Boolean checkBudgetData(String year, String month, String country, String vertical, String type) {
            Boolean budgetExists = false;
            try
            {
                sqlconn = conn.getDatabaseConnection();

                String query = "SELECT edit_mode"
                                + " FROM tb_setup_budget"
                                + " WHERE year = @year"
                                + " AND month = @month"
                                + " AND country = @country"
                                + " AND vertical = @vertical"
                                + " AND type = @type";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = sqlconn;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@vertical", vertical);
                cmd.Parameters.AddWithValue("@type", type);

                MySqlDataReader dr_data = cmd.ExecuteReader();

                if (dr_data.HasRows)
                {
                    while (dr_data.Read())
                    {
                        int editMode = Convert.ToInt32(dr_data["edit_mode"].ToString());
                        if (editMode == 0)
                        {
                            budgetExists = true;
                        }
                        else if (editMode == 1)
                        {
                            budgetExists = false;
                        }
                    }
                    dr_data.Close();
                }
                else {
                    budgetExists = false;
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return budgetExists;
        }

        private Boolean checkActualReportData(String year, String month, String country, String vertical, String type)
        {
            Boolean actualExists = false;
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "SELECT edit_mode"
                                + " FROM tb_fc_to_usd_actual"
                                + " WHERE year = @year"
                                + " AND month = @month"
                                + " AND currency = @currency";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = sqlconn;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@currency", currency);

                MySqlDataReader dr_data = cmd.ExecuteReader();

                if (dr_data.HasRows)
                {
                    while (dr_data.Read())
                    {
                        int editMode = Convert.ToInt32(dr_data["edit_mode"].ToString());
                        if (editMode == 0)
                        {
                            actualExists = true;
                        }
                        else if (editMode == 1)
                        {
                            actualExists = false;
                        }
                    }
                    dr_data.Close();
                }
                else
                {
                    actualExists = false;
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return actualExists;
        }

        private void populateBudgetData(String year, String month, String country, String vertical, String type)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();
                sqlconn = conn.getDatabaseConnection();

                String query = "SELECT *"
                                + " FROM tb_setup_budget"
                                + " WHERE year = @year"
                                + " AND month = @month"
                                + " AND country = @country"
                                + " AND vertical = @vertical"
                                + " AND type = @type"
                                + " ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = sqlconn;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@vertical", vertical);
                cmd.Parameters.AddWithValue("@type", type);

                MySqlDataReader dr_data = cmd.ExecuteReader();

                if (dr_data.HasRows)
                {
                    while (dr_data.Read())
                    {
                        Label11.Text = helper.applyThousandFormat(dr_data["r_gmv"].ToString());
                        Label12.Text = helper.applyThousandFormat(dr_data["r_gr"].ToString());

                        Label14.Text = helper.applyThousandFormat(dr_data["dc_network"].ToString());
                        Label15.Text = helper.applyThousandFormat(dr_data["dc_direct_labor"].ToString());
                        Label16.Text = helper.applyThousandFormat(dr_data["dc_commissions"].ToString());
                        Label17.Text = helper.applyThousandFormat(dr_data["dc_others"].ToString());
                        Label18.Text = helper.applyThousandFormat(dr_data["dc_gross_profit"].ToString());

                        Label20.Text = helper.applyThousandFormat(dr_data["o_manpower"].ToString());
                        Label5.Text = helper.applyThousandFormat(dr_data["o_incidental_opex"].ToString());
                        Label34.Text = helper.applyThousandFormat(dr_data["o_network_cost"].ToString());
                        Label21.Text = helper.applyThousandFormat(dr_data["o_travelling"].ToString());
                        Label22.Text = helper.applyThousandFormat(dr_data["o_it_charges"].ToString());
                        Label23.Text = helper.applyThousandFormat(dr_data["o_marketing_costs"].ToString());
                        Label24.Text = helper.applyThousandFormat(dr_data["o_professional_charges"].ToString());
                        Label25.Text = helper.applyThousandFormat(dr_data["o_others"].ToString());
                        Label26.Text = helper.applyThousandFormat(dr_data["ebitda"].ToString());

                        Label27.Text = helper.applyThousandFormat(dr_data["depreciation"].ToString());
                        Label28.Text = helper.applyThousandFormat(dr_data["net_interest"].ToString());
                        Label29.Text = helper.applyThousandFormat(dr_data["others"].ToString());
                        Label30.Text = helper.applyThousandFormat(dr_data["share_of_results"].ToString());
                        Label31.Text = helper.applyThousandFormat(dr_data["tax"].ToString());
                        Label32.Text = helper.applyThousandFormat(dr_data["profit_after_tax"].ToString());
                    }
                    dr_data.Close();
                }
                else
                {

                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void populateReportData(String year, String month, String country, String vertical, String type)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();
                
                sqlconn = conn.getDatabaseConnection();

                String query = "SELECT *"
                                + " FROM tb_report_data"
                                + " WHERE year = @year"
                                + " AND month = @month"
                                + " AND country = @country"
                                + " AND vertical = @vertical"
                                + " AND type = @type"
                                + " ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = sqlconn;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@vertical", vertical);
                cmd.Parameters.AddWithValue("@type", type);

                MySqlDataReader dr_data = cmd.ExecuteReader();

                if (dr_data.HasRows)
                {
                    while (dr_data.Read())
                    {
                        edit_mode = Convert.ToInt32(dr_data["edit_mode"].ToString());

                        if (edit_mode == 0)
                        {
                            TextBox1.Text = helper.applyThousandFormat(dr_data["r_gmv"].ToString());
                            TextBox2.Text = helper.applyThousandFormat(dr_data["r_gr"].ToString());

                            TextBox3.Text = helper.applyThousandFormat(dr_data["dc_network"].ToString());
                            TextBox4.Text = helper.applyThousandFormat(dr_data["dc_direct_labor"].ToString());
                            TextBox5.Text = helper.applyThousandFormat(dr_data["dc_commissions"].ToString());
                            TextBox6.Text = helper.applyThousandFormat(dr_data["dc_others"].ToString());
                            Label6.Text = helper.applyThousandFormat(dr_data["dc_gross_profit"].ToString());

                            TextBox8.Text = helper.applyThousandFormat(dr_data["o_manpower"].ToString());
                            TextBox7.Text = helper.applyThousandFormat(dr_data["o_incidental_opex"].ToString());
                            TextBox14.Text = helper.applyThousandFormat(dr_data["o_network_cost"].ToString());
                            TextBox9.Text = helper.applyThousandFormat(dr_data["o_travelling"].ToString());
                            TextBox10.Text = helper.applyThousandFormat(dr_data["o_it_charges"].ToString());
                            TextBox11.Text = helper.applyThousandFormat(dr_data["o_marketing_costs"].ToString());
                            TextBox12.Text = helper.applyThousandFormat(dr_data["o_professional_charges"].ToString());
                            TextBox13.Text = helper.applyThousandFormat(dr_data["o_others"].ToString());
                            Label7.Text = helper.applyThousandFormat(dr_data["ebitda"].ToString());

                            TextBox15.Text = helper.applyThousandFormat(dr_data["depreciation"].ToString());
                            TextBox16.Text = helper.applyThousandFormat(dr_data["net_interest"].ToString());
                            TextBox17.Text = helper.applyThousandFormat(dr_data["others"].ToString());
                            TextBox18.Text = helper.applyThousandFormat(dr_data["share_of_results"].ToString());
                            TextBox19.Text = helper.applyThousandFormat(dr_data["tax"].ToString());
                            Label8.Text = helper.applyThousandFormat(dr_data["profit_after_tax"].ToString());

                            TextBox20.Text = helper.applyThousandFormat(dr_data["ads_equity_share"].ToString());
                        }
                        else if (edit_mode == 1)
                        {
                            Session["rowId"] = Convert.ToInt32(dr_data["id"].ToString());
                            TextBox1.Text = dr_data["r_gmv"].ToString();
                            TextBox2.Text = dr_data["r_gr"].ToString();

                            TextBox3.Text = dr_data["dc_network"].ToString();
                            TextBox4.Text = dr_data["dc_direct_labor"].ToString();
                            TextBox5.Text = dr_data["dc_commissions"].ToString();
                            TextBox6.Text = dr_data["dc_others"].ToString();
                            Label6.Text = dr_data["dc_gross_profit"].ToString();

                            TextBox8.Text = dr_data["o_manpower"].ToString();
                            TextBox7.Text = dr_data["o_incidental_opex"].ToString();
                            TextBox14.Text = dr_data["o_network_cost"].ToString();
                            TextBox9.Text = dr_data["o_travelling"].ToString();
                            TextBox10.Text = dr_data["o_it_charges"].ToString();
                            TextBox11.Text = dr_data["o_marketing_costs"].ToString();
                            TextBox12.Text = dr_data["o_professional_charges"].ToString();
                            TextBox13.Text = dr_data["o_others"].ToString();
                            Label7.Text = dr_data["ebitda"].ToString();

                            TextBox15.Text = dr_data["depreciation"].ToString();
                            TextBox16.Text = dr_data["net_interest"].ToString();
                            TextBox17.Text = dr_data["others"].ToString();
                            TextBox18.Text = dr_data["share_of_results"].ToString();
                            TextBox19.Text = dr_data["tax"].ToString();
                            Label8.Text = dr_data["profit_after_tax"].ToString();

                            TextBox20.Text = dr_data["ads_equity_share"].ToString();
                        }
                    }
                    dr_data.Close();
                }
                else
                {
                    edit_mode = -1;
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void saveData()
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();
                
                sqlconn = conn.getDatabaseConnection();

                String query = "INSERT"
                                + " INTO tb_report_data("
                                + " year"
                                + ", month"
                                + ", country"
                                + ", vertical"
                                + ", type"
                                + ", r_gmv"
                                + ", r_gr"
                                + ", dc_network"
                                + ", dc_direct_labor"
                                + ", dc_commissions"
                                + ", dc_others"
                                + ", dc_gross_profit"
                                + ", o_manpower"
                                + ", o_incidental_opex"
                                + ", o_network_cost"
                                + ", o_travelling"
                                + ", o_it_charges"
                                + ", o_marketing_costs"
                                + ", o_professional_charges"
                                + ", o_others"
                                + ", ebitda"
                                + ", depreciation"
                                + ", net_interest"
                                + ", others"
                                + ", share_of_results"
                                + ", tax"
                                + ", profit_after_tax"
                                + ", ads_equity_share"
                                + ", month_id"
                                + ", currency"
                                + ", edit_mode"
                                + ") values ("
                                + " @year"
                                + ", @month"
                                + ", @country"
                                + ", @vertical"
                                + ", @type"
                                + ", @r_gmv"
                                + ", @r_gr"
                                + ", @dc_network"
                                + ", @dc_direct_labor"
                                + ", @dc_commissions"
                                + ", @dc_others"
                                + ", @dc_gross_profit"
                                + ", @o_manpower"
                                + ", @o_incidental_opex"
                                + ", @o_network_cost"
                                + ", @o_travelling"
                                + ", @o_it_charges"
                                + ", @o_marketing_costs"
                                + ", @o_professional_charges"
                                + ", @o_others"
                                + ", @ebitda"
                                + ", @depreciation"
                                + ", @net_interest"
                                + ", @others"
                                + ", @share_of_results"
                                + ", @tax"
                                + ", @profit_after_tax"
                                + ", @ads_equity_share"
                                + ", @month_id"
                                + ", @currency"
                                + ", @edit_mode)";

                MySqlCommand cmd_insert = new MySqlCommand();
                cmd_insert.Connection = sqlconn;
                cmd_insert.CommandText = query;
                cmd_insert.Parameters.AddWithValue("@year", DropDownList5_year.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@month", DropDownList4_month.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@country", DropDownList1_country.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@vertical", DropDownList2_vertical.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@type", DropDownList3_type.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@r_gmv", TextBox1.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@r_gr", TextBox2.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@dc_network", TextBox3.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@dc_direct_labor", TextBox4.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@dc_commissions", TextBox5.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@dc_others", TextBox6.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@dc_gross_profit", Label6.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_manpower", TextBox8.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_incidental_opex", TextBox7.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_network_cost", TextBox14.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_travelling", TextBox9.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_it_charges", TextBox10.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_marketing_costs", TextBox11.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_professional_charges", TextBox12.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_others", TextBox13.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@ebitda", Label7.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@depreciation", TextBox15.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@net_interest", TextBox16.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@others", TextBox17.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@share_of_results", TextBox18.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@tax", TextBox19.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@profit_after_tax", Label8.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@ads_equity_share", TextBox20.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@month_id", Convert.ToInt32(monthId));
                cmd_insert.Parameters.AddWithValue("@currency", currency);
                cmd_insert.Parameters.AddWithValue("@edit_mode", "1");

                int rowCount = cmd_insert.ExecuteNonQuery();
                if (rowCount >= 1)
                {
                    helper.showAlert(this.Page, "Data saved successfully!");

                    helper.changeDropDownListMode(DropDownList5_year, 1);
                    helper.changeDropDownListMode(DropDownList4_month, 1);
                    helper.changeDropDownListMode(DropDownList1_country, 1);
                    helper.changeDropDownListMode(DropDownList2_vertical, 1);

                    helper.changeTextBoxEditingMode(textBoxList, 0);

                    helper.changeButtonMode(Button5_clear_all, 0);
                    helper.changeButtonMode(Button2_edit, 1);
                    helper.changeButtonMode(Button3_save, 0);
                    helper.changeButtonMode(Button4_submit, 1);
                    helper.changeButtonMode(Button6_view, 1);

                    String year = DropDownList5_year.SelectedValue;
                    String month = DropDownList4_month.SelectedValue;
                    String country = DropDownList1_country.SelectedValue;
                    String vertical = DropDownList2_vertical.SelectedValue;
                    String type = DropDownList3_type.SelectedValue;

                    populateReportData(year, month, country, vertical, type);
                    calculateDCandOPEX(1);
                }
                else
                {
                    helper.showAlert(this.Page, "Please check your data for errors!");
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void updateData()
        {
            DataObject.HelperClass helper = new DataObject.HelperClass();
            try
            {
                sqlconn = conn.getDatabaseConnection();

                String query = "UPDATE tb_report_data"
                                + " SET year = @year"
                                + ", month = @month"
                                + ", country = @country"
                                + ", vertical = @vertical"
                                + ", type = @type"
                                + ", r_gmv = @r_gmv"
                                + ", r_gr = @r_gr"
                                + ", dc_network = @dc_network"
                                + ", dc_direct_labor = @dc_direct_labor"
                                + ", dc_commissions = @dc_commissions"
                                + ", dc_others = @dc_others"
                                + ", dc_gross_profit = @dc_gross_profit"
                                + ", o_manpower = @o_manpower"
                                + ", o_incidental_opex = @o_incidental_opex"
                                + ", o_network_cost = @o_network_cost"
                                + ", o_travelling = @o_travelling"
                                + ", o_it_charges = @o_it_charges"
                                + ", o_marketing_costs = @o_marketing_costs"
                                + ", o_professional_charges = @o_professional_charges"
                                + ", o_others = @o_others"
                                + ", ebitda = @ebitda"
                                + ", depreciation = @depreciation"
                                + ", net_interest = @net_interest"
                                + ", others = @others"
                                + ", share_of_results = @share_of_results"
                                + ", tax = @tax"
                                + ", profit_after_tax = @profit_after_tax"
                                + ", ads_equity_share = @ads_equity_share"
                                + ", month_id = @month_id"
                                + ", currency = @currency"
                                + ", edit_mode = @edit_mode"
                                + " WHERE id = @id";

                MySqlCommand cmd_insert = new MySqlCommand();
                cmd_insert.Connection = sqlconn;
                cmd_insert.CommandText = query;
                cmd_insert.Parameters.AddWithValue("@id", Session["rowId"]);
                cmd_insert.Parameters.AddWithValue("@year", DropDownList5_year.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@month", DropDownList4_month.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@country", DropDownList1_country.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@vertical", DropDownList2_vertical.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@type", DropDownList3_type.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@r_gmv", TextBox1.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@r_gr", TextBox2.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@dc_network", TextBox3.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@dc_direct_labor", TextBox4.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@dc_commissions", TextBox5.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@dc_others", TextBox6.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@dc_gross_profit", Label6.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_manpower", TextBox8.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_incidental_opex", TextBox7.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_network_cost", TextBox14.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_travelling", TextBox9.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_it_charges", TextBox10.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_marketing_costs", TextBox11.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_professional_charges", TextBox12.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@o_others", TextBox13.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@ebitda", Label7.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@depreciation", TextBox15.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@net_interest", TextBox16.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@others", TextBox17.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@share_of_results", TextBox18.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@tax", TextBox19.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@profit_after_tax", Label8.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@ads_equity_share", TextBox20.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@month_id", Convert.ToInt32(monthId));
                cmd_insert.Parameters.AddWithValue("@currency", currency);
                cmd_insert.Parameters.AddWithValue("@edit_mode", "1");

                int rowCount = cmd_insert.ExecuteNonQuery();
                if (rowCount >= 1)
                {
                    helper.showAlert(this.Page, "Data updated successfully!");

                    helper.changeDropDownListMode(DropDownList5_year, 1);
                    helper.changeDropDownListMode(DropDownList4_month, 1);
                    helper.changeDropDownListMode(DropDownList1_country, 1);
                    helper.changeDropDownListMode(DropDownList2_vertical, 1);

                    helper.changeTextBoxEditingMode(textBoxList, 0);

                    helper.changeButtonMode(Button5_clear_all, 0);
                    helper.changeButtonMode(Button2_edit, 1);
                    helper.changeButtonMode(Button3_save, 0);
                    helper.changeButtonMode(Button4_submit, 1);
                    helper.changeButtonMode(Button6_view, 1);

                    Session["updateRow"] = false;
                   
                }
                else
                {
                    helper.showAlert(this.Page, "Please check your data for errors!");
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                helper.showAlert(this.Page, "Please check your data for errors!");
            }
        }

        private void updateSubmitData()
        {
            DataObject.HelperClass helper = new DataObject.HelperClass();
            try
            {
                Decimal ads_equity_share;
                Decimal.TryParse(TextBox20.Text.Trim().TrimStart('0'), out ads_equity_share);

                sqlconn = conn.getDatabaseConnection();

                String query = "UPDATE tb_report_data"
                                + " SET year = @year"
                                + ", month = @month"
                                + ", country = @country"
                                + ", vertical = @vertical"
                                + ", type = @type"
                                + ", r_gmv = @r_gmv"
                                + ", r_gr = @r_gr"
                                + ", dc_network = @dc_network"
                                + ", dc_direct_labor = @dc_direct_labor"
                                + ", dc_commissions = @dc_commissions"
                                + ", dc_others = @dc_others"
                                + ", dc_gross_profit = @dc_gross_profit"
                                + ", o_manpower = @o_manpower"
                                + ", o_incidental_opex = @o_incidental_opex"
                                + ", o_network_cost = @o_network_cost"
                                + ", o_travelling = @o_travelling"
                                + ", o_it_charges = @o_it_charges"
                                + ", o_marketing_costs = @o_marketing_costs"
                                + ", o_professional_charges = @o_professional_charges"
                                + ", o_others = @o_others"
                                + ", ebitda = @ebitda"
                                + ", depreciation = @depreciation"
                                + ", net_interest = @net_interest"
                                + ", others = @others"
                                + ", share_of_results = @share_of_results"
                                + ", tax = @tax"
                                + ", profit_after_tax = @profit_after_tax"
                                + ", ads_equity_share = @ads_equity_share"
                                + ", month_id = @month_id"
                                + ", currency = @currency"
                                + ", edit_mode = @edit_mode"
                                + " WHERE id = @id";

                MySqlCommand cmd_insert = new MySqlCommand();
                cmd_insert.Connection = sqlconn;
                cmd_insert.CommandText = query;
                cmd_insert.Parameters.AddWithValue("@id", Session["rowId"]);
                cmd_insert.Parameters.AddWithValue("@year", DropDownList5_year.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@month", DropDownList4_month.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@country", DropDownList1_country.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@vertical", DropDownList2_vertical.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@type", DropDownList3_type.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@r_gmv", helper.applyAdsShare(TextBox1.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@r_gr", helper.applyAdsShare(TextBox2.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@dc_network", helper.applyAdsShare(TextBox3.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@dc_direct_labor", helper.applyAdsShare(TextBox4.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@dc_commissions", helper.applyAdsShare(TextBox5.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@dc_others", helper.applyAdsShare(TextBox6.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@dc_gross_profit", helper.applyAdsShare(Label6.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@o_incidental_opex", helper.applyAdsShare(TextBox7.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@o_network_cost", helper.applyAdsShare(TextBox14.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@o_manpower", helper.applyAdsShare(TextBox8.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@o_travelling", helper.applyAdsShare(TextBox9.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@o_it_charges", helper.applyAdsShare(TextBox10.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@o_marketing_costs", helper.applyAdsShare(TextBox11.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@o_professional_charges", helper.applyAdsShare(TextBox12.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@o_others", helper.applyAdsShare(TextBox13.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@ebitda", helper.applyAdsShare(Label7.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@depreciation", helper.applyAdsShare(TextBox15.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@net_interest", helper.applyAdsShare(TextBox16.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@others", helper.applyAdsShare(TextBox17.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@share_of_results", helper.applyAdsShare(TextBox18.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@tax", helper.applyAdsShare(TextBox19.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@profit_after_tax", helper.applyAdsShare(Label8.Text, ads_equity_share));
                cmd_insert.Parameters.AddWithValue("@ads_equity_share", TextBox20.Text.Trim().TrimStart('0'));
                cmd_insert.Parameters.AddWithValue("@month_id", Convert.ToInt32(monthId));
                cmd_insert.Parameters.AddWithValue("@currency", currency);
                cmd_insert.Parameters.AddWithValue("@edit_mode", "0");

                int rowCount = cmd_insert.ExecuteNonQuery();
                if (rowCount >= 1)
                {
                    helper.showAlert(this.Page, "Data submitted successfully!");

                    Session["rowId"] = null;
                }
                else
                {
                    helper.showAlert(this.Page, "Please check your data for errors!");
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                helper.showAlert(this.Page, "Please check your data for errors!");
            }
        }

        private void insertDataWithRatesApplied(String type)
        {
            DataObject.HelperClass helper = new DataObject.HelperClass();
            try
            {
                Decimal ads_equity_share;
                Decimal.TryParse(TextBox20.Text.Trim().TrimStart('0'), out ads_equity_share);
                String year = DropDownList5_year.SelectedValue;
                String month = DropDownList4_month.SelectedValue;
                String country = DropDownList1_country.SelectedValue;
                String vertical = DropDownList2_vertical.SelectedValue;

                Decimal rate = helper.fetchRates(year, month, currency, type);
                
                sqlconn = conn.getDatabaseConnection();
                


                String query = "INSERT"
                                + " INTO tb_report_data("
                                + " year"
                                + ", month"
                                + ", country"
                                + ", vertical"
                                + ", type"
                                + ", r_gmv"
                                + ", r_gr"
                                + ", dc_network"
                                + ", dc_direct_labor"
                                + ", dc_commissions"
                                + ", dc_others"
                                + ", dc_gross_profit"
                                + ", o_manpower"
                                + ", o_incidental_opex"
                                + ", o_network_cost"
                                + ", o_travelling"
                                + ", o_it_charges"
                                + ", o_marketing_costs"
                                + ", o_professional_charges"
                                + ", o_others"
                                + ", ebitda"
                                + ", depreciation"
                                + ", net_interest"
                                + ", others"
                                + ", share_of_results"
                                + ", tax"
                                + ", profit_after_tax"
                                + ", ads_equity_share"
                                + ", month_id"
                                + ", currency"
                                + ", edit_mode"
                                + ") values ("
                                + " @year"
                                + ", @month"
                                + ", @country"
                                + ", @vertical"
                                + ", @type"
                                + ", @r_gmv"
                                + ", @r_gr"
                                + ", @dc_network"
                                + ", @dc_direct_labor"
                                + ", @dc_commissions"
                                + ", @dc_others"
                                + ", @dc_gross_profit"
                                + ", @o_manpower"
                                + ", @o_incidental_opex"
                                + ", @o_network_cost"
                                + ", @o_travelling"
                                + ", @o_it_charges"
                                + ", @o_marketing_costs"
                                + ", @o_professional_charges"
                                + ", @o_others"
                                + ", @ebitda"
                                + ", @depreciation"
                                + ", @net_interest"
                                + ", @others"
                                + ", @share_of_results"
                                + ", @tax"
                                + ", @profit_after_tax"
                                + ", @ads_equity_share"
                                + ", @month_id"
                                + ", @currency"
                                + ", @edit_mode)";

                MySqlCommand cmd_insert = new MySqlCommand();
                cmd_insert.Connection = sqlconn;
                cmd_insert.CommandText = query;
                cmd_insert.Parameters.AddWithValue("@year", year);
                cmd_insert.Parameters.AddWithValue("@month", month);
                cmd_insert.Parameters.AddWithValue("@country", country);
                cmd_insert.Parameters.AddWithValue("@vertical", vertical);
                cmd_insert.Parameters.AddWithValue("@type", type);
                cmd_insert.Parameters.AddWithValue("@r_gmv", helper.applyRate(TextBox1.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@r_gr", helper.applyRate(TextBox2.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@dc_network", helper.applyRate(TextBox3.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@dc_direct_labor", helper.applyRate(TextBox4.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@dc_commissions", helper.applyRate(TextBox5.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@dc_others", helper.applyRate(TextBox6.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@dc_gross_profit", helper.applyRate(Label6.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@o_manpower", helper.applyRate(TextBox8.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@o_incidental_opex", helper.applyRate(TextBox7.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@o_network_cost", helper.applyRate(TextBox14.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@o_travelling", helper.applyRate(TextBox9.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@o_it_charges", helper.applyRate(TextBox10.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@o_marketing_costs", helper.applyRate(TextBox11.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@o_professional_charges", helper.applyRate(TextBox12.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@o_others", helper.applyRate(TextBox13.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@ebitda", helper.applyRate(Label7.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@depreciation", helper.applyRate(TextBox15.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@net_interest", helper.applyRate(TextBox16.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@others", helper.applyRate(TextBox17.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@share_of_results", helper.applyRate(TextBox18.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@tax", helper.applyRate(TextBox19.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@profit_after_tax", helper.applyRate(Label8.Text, rate, ads_equity_share, "report"));
                cmd_insert.Parameters.AddWithValue("@ads_equity_share", ads_equity_share);
                cmd_insert.Parameters.AddWithValue("@month_id", Convert.ToInt32(monthId));
                cmd_insert.Parameters.AddWithValue("@currency", currency);
                cmd_insert.Parameters.AddWithValue("@edit_mode", "0");

                int rowCount = cmd_insert.ExecuteNonQuery();
                if (rowCount >= 1)
                {

                    helper.showAlert(this.Page, "Data saved successfully!");

                    if (type == "CC")
                    {
                        helper.changeDropDownListMode(DropDownList3_type, 1);

                        helper.changeTextBoxEditingMode(textBoxList, 0);

                        helper.changeButtonMode(Button5_clear_all, 0);
                        helper.changeButtonMode(Button2_edit, 0);
                        helper.changeButtonMode(Button3_save, 0);
                        helper.changeButtonMode(Button4_submit, 0);
                        helper.changeButtonMode(Button6_view, 1);

                        helper.updateDimensionOnSubmission("tb_report_data");

                        insertAndApplyAdsOnBudget();

                        populateBudgetData(year, month, country, vertical, "Local Currency");
                        calculateValuesForBudget();
                        populateReportData(year, month, country, vertical, "Local Currency");
                        calculateDCandOPEX(0);
                    }
                }
                else
                {
                    helper.showAlert(this.Page, "Please check your data for errors!");
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                helper.showAlert(this.Page, "Please check your data for errors!");
            }
        }

        private void calculateValuesForBudget()
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                Decimal B_direct_costs, B1_network, B2_direct_labor, B3_commissions, B4_others;
                Decimal D_opex, D1_manpower, D2_travelling, D3_it_charges, D4_marketing_costs, D5_professional_charges, D6_others, D7_incidental_opex, D8_network_cost;


                Decimal.TryParse(Label14.Text, out B1_network);
                Decimal.TryParse(Label15.Text, out B2_direct_labor);
                Decimal.TryParse(Label16.Text, out B3_commissions);
                Decimal.TryParse(Label17.Text, out B4_others);

                B_direct_costs = B1_network + B2_direct_labor + B3_commissions + B4_others;
                Label13.Text = helper.applyThousandFormat(Convert.ToString(Decimal.Round(B_direct_costs, 5)));


                Decimal.TryParse(Label20.Text, out D1_manpower);
                Decimal.TryParse(Label21.Text, out D2_travelling);
                Decimal.TryParse(Label22.Text, out D3_it_charges);
                Decimal.TryParse(Label23.Text, out D4_marketing_costs);
                Decimal.TryParse(Label24.Text, out D5_professional_charges);
                Decimal.TryParse(Label25.Text, out D6_others);
                Decimal.TryParse(TextBox7.Text, out D7_incidental_opex);
                Decimal.TryParse(TextBox14.Text, out D8_network_cost);

                D_opex = D1_manpower + D2_travelling + D3_it_charges + D4_marketing_costs + D5_professional_charges + D6_others + D7_incidental_opex + D8_network_cost;
                Label19.Text = helper.applyThousandFormat(Convert.ToString(Decimal.Round(D_opex, 5)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void calculateValues()
        {
            try
            {
                Decimal A_gr;
                Decimal B_direct_costs, B1_network, B2_direct_labor, B3_commissions, B4_others;
                Decimal C_gross_profit;
                Decimal D_opex, D1_manpower, D2_travelling, D3_it_charges, D4_marketing_costs, D5_professional_charges, D6_others, D7_incidental_opex, D8_network_cost;
                Decimal E_ebitda;
                Decimal F_depreciation, G_net_interest, H_others, I_share_of_results, J_tax;
                Decimal K_profit_after_tax;


                Decimal.TryParse(TextBox2.Text, out A_gr);

                Decimal.TryParse(TextBox3.Text, out B1_network);
                Decimal.TryParse(TextBox4.Text, out B2_direct_labor);
                Decimal.TryParse(TextBox5.Text, out B3_commissions);
                Decimal.TryParse(TextBox6.Text, out B4_others);

                B_direct_costs = B1_network + B2_direct_labor + B3_commissions + B4_others;
                Label9.Text = Convert.ToString(Decimal.Round(B_direct_costs, 5));
                C_gross_profit = A_gr - B_direct_costs;

                Label6.Text = Convert.ToString(Decimal.Round(C_gross_profit, 5));


                Decimal.TryParse(TextBox8.Text, out D1_manpower);
                Decimal.TryParse(TextBox9.Text, out D2_travelling);
                Decimal.TryParse(TextBox10.Text, out D3_it_charges);
                Decimal.TryParse(TextBox11.Text, out D4_marketing_costs);
                Decimal.TryParse(TextBox12.Text, out D5_professional_charges);
                Decimal.TryParse(TextBox13.Text, out D6_others);
                Decimal.TryParse(TextBox7.Text, out D7_incidental_opex);
                Decimal.TryParse(TextBox14.Text, out D8_network_cost);

                D_opex = D1_manpower + D2_travelling + D3_it_charges + D4_marketing_costs + D5_professional_charges + D6_others + D7_incidental_opex + D8_network_cost;
                Label10.Text = Convert.ToString(Decimal.Round(D_opex, 5));
                E_ebitda = C_gross_profit - D_opex;

                Label7.Text = Convert.ToString(Decimal.Round(E_ebitda, 5));


                Decimal.TryParse(TextBox15.Text, out F_depreciation);
                Decimal.TryParse(TextBox16.Text, out G_net_interest);
                Decimal.TryParse(TextBox17.Text, out H_others);
                Decimal.TryParse(TextBox18.Text, out I_share_of_results);
                Decimal.TryParse(TextBox19.Text, out J_tax);

                K_profit_after_tax = E_ebitda - (F_depreciation + G_net_interest + H_others + I_share_of_results + J_tax);

                Label8.Text = Convert.ToString(Decimal.Round(K_profit_after_tax, 5));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void calculateDCandOPEX(int editMode)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                Decimal B_direct_costs, B1_network, B2_direct_labor, B3_commissions, B4_others;
                Decimal D_opex, D1_manpower, D2_travelling, D3_it_charges, D4_marketing_costs, D5_professional_charges, D6_others, D7_incidental_opex, D8_network_cost;

                Decimal.TryParse(TextBox3.Text, out B1_network);
                Decimal.TryParse(TextBox4.Text, out B2_direct_labor);
                Decimal.TryParse(TextBox5.Text, out B3_commissions);
                Decimal.TryParse(TextBox6.Text, out B4_others);

                B_direct_costs = B1_network + B2_direct_labor + B3_commissions + B4_others;
                if (editMode == 0)
                {
                    Label9.Text = helper.applyThousandFormat(Convert.ToString(Decimal.Round(B_direct_costs, 5)));
                }
                else if (editMode == 1)
                {
                    Label9.Text = Convert.ToString(Decimal.Round(B_direct_costs, 5));
                }

                Decimal.TryParse(TextBox8.Text, out D1_manpower);
                Decimal.TryParse(TextBox9.Text, out D2_travelling);
                Decimal.TryParse(TextBox10.Text, out D3_it_charges);
                Decimal.TryParse(TextBox11.Text, out D4_marketing_costs);
                Decimal.TryParse(TextBox12.Text, out D5_professional_charges);
                Decimal.TryParse(TextBox13.Text, out D6_others);
                Decimal.TryParse(TextBox7.Text, out D7_incidental_opex);
                Decimal.TryParse(TextBox14.Text, out D8_network_cost);

                D_opex = D1_manpower + D2_travelling + D3_it_charges + D4_marketing_costs + D5_professional_charges + D6_others + D7_incidental_opex + D8_network_cost;
                if (editMode == 0)
                {
                    Label10.Text = helper.applyThousandFormat(Convert.ToString(Decimal.Round(D_opex, 5)));
                }
                else if (editMode == 1)
                {
                    Label10.Text = Convert.ToString(Decimal.Round(D_opex, 5));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createBudgetLabelList() {
            try
            {
                budgetLabelList.Add(Label5);
                budgetLabelList.Add(Label11);
                budgetLabelList.Add(Label12);
                budgetLabelList.Add(Label13);
                budgetLabelList.Add(Label14);
                budgetLabelList.Add(Label15);
                budgetLabelList.Add(Label16);
                budgetLabelList.Add(Label17);
                budgetLabelList.Add(Label18);
                budgetLabelList.Add(Label19);
                budgetLabelList.Add(Label20);
                budgetLabelList.Add(Label21);
                budgetLabelList.Add(Label22);
                budgetLabelList.Add(Label23);
                budgetLabelList.Add(Label24);
                budgetLabelList.Add(Label25);
                budgetLabelList.Add(Label26);
                budgetLabelList.Add(Label27);
                budgetLabelList.Add(Label28);
                budgetLabelList.Add(Label29);
                budgetLabelList.Add(Label30);
                budgetLabelList.Add(Label31);
                budgetLabelList.Add(Label32);
                budgetLabelList.Add(Label34);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void clearBudgetValues(List<Label> list) {
            try {
                for (int i = 0; i < list.Count; i++) {
                    list[i].Text = "";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private Boolean checkDataExistsForRefresh(String year, String month, String country, String vertical, String type)
        {
            Boolean actualExists = false;
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "SELECT *"
                                + " FROM tb_report_data"
                                + " WHERE year = @year"
                                + " AND month = @month"
                                + " AND country = @country"
                                + " AND vertical = @vertical"
                                + " AND type = @type";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = sqlconn;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@vertical", vertical);
                cmd.Parameters.AddWithValue("@type", type);

                MySqlDataReader dr_data = cmd.ExecuteReader();

                if (dr_data.HasRows)
                {
                    actualExists = true;
                }
                else
                {
                    actualExists = false;
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return actualExists;
        }

        private void insertAndApplyAdsOnBudget() {
            DataObject.HelperClass helper = new DataObject.HelperClass();
            try
            {
                Decimal ads_equity_share;
                Decimal.TryParse(TextBox20.Text.Trim().TrimStart('0'), out ads_equity_share);

                sqlconn = conn.getDatabaseConnection();

                String query = "UPDATE tb_setup_budget"
                                + " SET ads_equity_share = @ads_equity_share"
                                + " WHERE year = @year"
                                + " and month = @month"
                                + " and country = @country"
                                + " and vertical = @vertical";

                MySqlCommand cmd_update = new MySqlCommand();
                cmd_update.Connection = sqlconn;
                cmd_update.CommandText = query;

                cmd_update.Parameters.AddWithValue("@year", DropDownList5_year.SelectedValue);
                cmd_update.Parameters.AddWithValue("@month", DropDownList4_month.SelectedValue);
                cmd_update.Parameters.AddWithValue("@country", DropDownList1_country.SelectedValue);
                cmd_update.Parameters.AddWithValue("@vertical", DropDownList2_vertical.SelectedValue);
                cmd_update.Parameters.AddWithValue("@ads_equity_share", TextBox20.Text.Trim().TrimStart('0'));

                int rowCount = cmd_update.ExecuteNonQuery();
                if (rowCount >= 1)
                {
                    String query2 = "update tb_setup_budget set"
                                    + " r_gmv=r_gmv*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " r_gr=r_gr*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " dc_network=dc_network*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " dc_direct_labor=dc_direct_labor*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " dc_commissions=dc_commissions*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " dc_others=dc_others*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " dc_gross_profit=dc_gross_profit*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " o_manpower=o_manpower*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " o_incidental_opex=o_incidental_opex*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " o_network_cost=o_network_cost*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " o_travelling=o_travelling*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " o_it_charges=o_it_charges*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " o_marketing_costs=o_marketing_costs*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " o_professional_charges=o_professional_charges*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " o_others=o_others*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " ebitda=ebitda*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " depreciation=depreciation*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " net_interest=net_interest*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " others=others*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " share_of_results=share_of_results*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " tax=tax*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100),"
                                    + " profit_after_tax=profit_after_tax*(case when ads_equity_share = 0 then 100 else ads_equity_share end / 100)"
                                    + " where year = @year"
                                    + " and month = @month"
                                    + " and country = @country"
                                    + " and vertical = @vertical";

                    MySqlCommand cmd_update2 = new MySqlCommand();
                    cmd_update2.Connection = sqlconn;
                    cmd_update2.CommandText = query2;

                    cmd_update2.Parameters.AddWithValue("@year", DropDownList5_year.SelectedValue);
                    cmd_update2.Parameters.AddWithValue("@month", DropDownList4_month.SelectedValue);
                    cmd_update2.Parameters.AddWithValue("@country", DropDownList1_country.SelectedValue);
                    cmd_update2.Parameters.AddWithValue("@vertical", DropDownList2_vertical.SelectedValue);

                    int rowCount2 = cmd_update2.ExecuteNonQuery();
                    if (rowCount2 >= 1)
                    {
                        helper.showAlert(this.Page, "Data submitted successfully!");
                    }
                    else
                    {
                        helper.showAlert(this.Page, "Please check your data for errors!");
                    }
                }
                else
                {
                    helper.showAlert(this.Page, "Please check your data for errors!");
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                helper.showAlert(this.Page, "Please check your data for errors!");
            }
        }
    }
}