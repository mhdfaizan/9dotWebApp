using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _9dotWebApp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DataObject.DbConnection conn;
        MySqlConnection sqlconn;
        int edit_mode = -1;
        String currency = "";
        String monthId = "";

        List<TextBox> textBoxList = new List<TextBox>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                createTextBoxEditingModeList();

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

        private void populateGridData(String year, String month, String country, String vertical, String type) {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "SELECT * "
                                + " FROM tb_setup_budget"
                                + " WHERE year = @year"
                                + " AND month = @month"
                                + " AND country = @country"
                                + " AND vertical = @vertical"
                                + " AND type = @type"
                                + " ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd_data = new MySqlCommand();
                cmd_data.Connection = sqlconn;
                cmd_data.CommandText = query;
                cmd_data.Parameters.AddWithValue("@year", year);
                cmd_data.Parameters.AddWithValue("@month", month);
                cmd_data.Parameters.AddWithValue("@country", country);
                cmd_data.Parameters.AddWithValue("@vertical", vertical);
                cmd_data.Parameters.AddWithValue("@type", type);

                MySqlDataReader dr_data = cmd_data.ExecuteReader();

                if (dr_data.HasRows)
                {
                    while (dr_data.Read())
                    {
                        //Revenue
                        ViewState["rowId"] = Convert.ToInt32(dr_data["id"].ToString());
                        TextBox1.Text = dr_data["r_gmv"].ToString();
                        TextBox2.Text = dr_data["r_gr"].ToString();

                        //Direct Costs
                        TextBox3.Text = dr_data["dc_network"].ToString();
                        TextBox4.Text = dr_data["dc_direct_labor"].ToString();
                        TextBox5.Text = dr_data["dc_commissions"].ToString();
                        TextBox6.Text = dr_data["dc_others"].ToString();
                        Label6.Text = dr_data["dc_gross_profit"].ToString();

                        //OPEX
                        TextBox8.Text = dr_data["o_manpower"].ToString();
                        TextBox9.Text = dr_data["o_travelling"].ToString();
                        TextBox10.Text = dr_data["o_it_charges"].ToString();
                        TextBox11.Text = dr_data["o_marketing_costs"].ToString();
                        TextBox12.Text = dr_data["o_professional_charges"].ToString();
                        TextBox13.Text = dr_data["o_others"].ToString();
                        Label7.Text = dr_data["ebitda"].ToString();

                        //LAST BOX
                        TextBox15.Text = dr_data["depreciation"].ToString();
                        TextBox16.Text = dr_data["net_interest"].ToString();
                        TextBox17.Text = dr_data["others"].ToString();
                        TextBox18.Text = dr_data["share_of_results"].ToString();
                        TextBox19.Text = dr_data["tax"].ToString();
                        Label8.Text = dr_data["profit_after_tax"].ToString();

                        edit_mode = Convert.ToInt32(dr_data["edit_mode"].ToString());
                    }
                    dr_data.Close();
                }
                else
                {
                    if (ViewState["rowId"] != null && !ViewState["rowId"].Equals("-1"))
                    {
                        ViewState["rowId"] = null;
                        DropDownList3_type.SelectedIndex = 0;
                        populateGridData(year, month, country, vertical, DropDownList3_type.SelectedValue);
                        helper.changeDropDownListMode(DropDownList3_type, 0);
                    }
                    else {
                        edit_mode = -1;
                    }
                    
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void saveData() {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "INSERT"
                                + " INTO tb_setup_budget("
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
                cmd_insert.Parameters.AddWithValue("@r_gmv", TextBox1.Text);
                cmd_insert.Parameters.AddWithValue("@r_gr", TextBox2.Text);
                cmd_insert.Parameters.AddWithValue("@dc_network", TextBox3.Text);
                cmd_insert.Parameters.AddWithValue("@dc_direct_labor", TextBox4.Text);
                cmd_insert.Parameters.AddWithValue("@dc_commissions", TextBox5.Text);
                cmd_insert.Parameters.AddWithValue("@dc_others", TextBox6.Text);
                cmd_insert.Parameters.AddWithValue("@dc_gross_profit", Label6.Text);
                cmd_insert.Parameters.AddWithValue("@o_manpower", TextBox8.Text);
                cmd_insert.Parameters.AddWithValue("@o_travelling", TextBox9.Text);
                cmd_insert.Parameters.AddWithValue("@o_it_charges", TextBox10.Text);
                cmd_insert.Parameters.AddWithValue("@o_marketing_costs", TextBox11.Text);
                cmd_insert.Parameters.AddWithValue("@o_professional_charges", TextBox12.Text);
                cmd_insert.Parameters.AddWithValue("@o_others", TextBox13.Text);
                cmd_insert.Parameters.AddWithValue("@ebitda", Label7.Text);
                cmd_insert.Parameters.AddWithValue("@depreciation", TextBox15.Text);
                cmd_insert.Parameters.AddWithValue("@net_interest", TextBox16.Text);
                cmd_insert.Parameters.AddWithValue("@others", TextBox17.Text);
                cmd_insert.Parameters.AddWithValue("@share_of_results", TextBox18.Text);
                cmd_insert.Parameters.AddWithValue("@tax", TextBox19.Text);
                cmd_insert.Parameters.AddWithValue("@profit_after_tax", Label8.Text);
                cmd_insert.Parameters.AddWithValue("@month_id", Convert.ToInt32(monthId));
                cmd_insert.Parameters.AddWithValue("@currency",currency);
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


                    populateGridData(year, month, country, vertical, type);
                    calculateDCandOPEX();

                    ViewState["updateRow"] = false;
                }
                else {
                    helper.showAlert(this.Page, "Please check your data for errors!");
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void updateSubmitData()
        {
            DataObject.HelperClass helper = new DataObject.HelperClass();
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "UPDATE tb_setup_budget"
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
                                + ", month_id = @month_id"
                                + ", currency = @currency"
                                + ", edit_mode = @edit_mode"
                                + " WHERE id = @id";

                MySqlCommand cmd_insert = new MySqlCommand();
                cmd_insert.Connection = sqlconn;
                cmd_insert.CommandText = query;
                cmd_insert.Parameters.AddWithValue("@id", ViewState["rowId"]);
                cmd_insert.Parameters.AddWithValue("@year", DropDownList5_year.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@month", DropDownList4_month.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@country", DropDownList1_country.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@vertical", DropDownList2_vertical.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@type", DropDownList3_type.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@r_gmv", TextBox1.Text);
                cmd_insert.Parameters.AddWithValue("@r_gr", TextBox2.Text);
                cmd_insert.Parameters.AddWithValue("@dc_network", TextBox3.Text);
                cmd_insert.Parameters.AddWithValue("@dc_direct_labor", TextBox4.Text);
                cmd_insert.Parameters.AddWithValue("@dc_commissions", TextBox5.Text);
                cmd_insert.Parameters.AddWithValue("@dc_others", TextBox6.Text);
                cmd_insert.Parameters.AddWithValue("@dc_gross_profit", Label6.Text);
                cmd_insert.Parameters.AddWithValue("@o_manpower", TextBox8.Text);
                cmd_insert.Parameters.AddWithValue("@o_travelling", TextBox9.Text);
                cmd_insert.Parameters.AddWithValue("@o_it_charges", TextBox10.Text);
                cmd_insert.Parameters.AddWithValue("@o_marketing_costs", TextBox11.Text);
                cmd_insert.Parameters.AddWithValue("@o_professional_charges", TextBox12.Text);
                cmd_insert.Parameters.AddWithValue("@o_others", TextBox13.Text);
                cmd_insert.Parameters.AddWithValue("@ebitda", Label7.Text);
                cmd_insert.Parameters.AddWithValue("@depreciation", TextBox15.Text);
                cmd_insert.Parameters.AddWithValue("@net_interest", TextBox16.Text);
                cmd_insert.Parameters.AddWithValue("@others", TextBox17.Text);
                cmd_insert.Parameters.AddWithValue("@share_of_results", TextBox18.Text);
                cmd_insert.Parameters.AddWithValue("@tax", TextBox19.Text);
                cmd_insert.Parameters.AddWithValue("@profit_after_tax", Label8.Text);
                cmd_insert.Parameters.AddWithValue("@month_id", Convert.ToInt32(monthId));
                cmd_insert.Parameters.AddWithValue("@currency", currency);
                cmd_insert.Parameters.AddWithValue("@edit_mode", "0");

                int rowCount = cmd_insert.ExecuteNonQuery();
                if (rowCount >= 1)
                {
                    helper.showAlert(this.Page, "Data submitted successfully!");

                    ViewState["rowId"] = null;
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
                Decimal rate = fetchRates();
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "INSERT"
                                + " INTO tb_setup_budget("
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
                cmd_insert.Parameters.AddWithValue("@type", type);
                cmd_insert.Parameters.AddWithValue("@r_gmv", applyRate(TextBox1.Text, rate));
                cmd_insert.Parameters.AddWithValue("@r_gr", applyRate(TextBox2.Text, rate));
                cmd_insert.Parameters.AddWithValue("@dc_network", applyRate(TextBox3.Text, rate));
                cmd_insert.Parameters.AddWithValue("@dc_direct_labor", applyRate(TextBox4.Text, rate));
                cmd_insert.Parameters.AddWithValue("@dc_commissions", applyRate(TextBox5.Text, rate));
                cmd_insert.Parameters.AddWithValue("@dc_others", applyRate(TextBox6.Text, rate));
                cmd_insert.Parameters.AddWithValue("@dc_gross_profit", applyRate(Label6.Text, rate));
                cmd_insert.Parameters.AddWithValue("@o_manpower", applyRate(TextBox8.Text, rate));
                cmd_insert.Parameters.AddWithValue("@o_travelling", applyRate(TextBox9.Text, rate));
                cmd_insert.Parameters.AddWithValue("@o_it_charges", applyRate(TextBox10.Text, rate));
                cmd_insert.Parameters.AddWithValue("@o_marketing_costs", applyRate(TextBox11.Text, rate));
                cmd_insert.Parameters.AddWithValue("@o_professional_charges", applyRate(TextBox12.Text, rate));
                cmd_insert.Parameters.AddWithValue("@o_others", applyRate(TextBox13.Text, rate));
                cmd_insert.Parameters.AddWithValue("@ebitda", applyRate(Label7.Text, rate));
                cmd_insert.Parameters.AddWithValue("@depreciation", applyRate(TextBox15.Text, rate));
                cmd_insert.Parameters.AddWithValue("@net_interest", applyRate(TextBox16.Text, rate));
                cmd_insert.Parameters.AddWithValue("@others", applyRate(TextBox17.Text, rate));
                cmd_insert.Parameters.AddWithValue("@share_of_results", applyRate(TextBox18.Text, rate));
                cmd_insert.Parameters.AddWithValue("@tax", applyRate(TextBox19.Text, rate));
                cmd_insert.Parameters.AddWithValue("@profit_after_tax", applyRate(Label8.Text, rate));
                cmd_insert.Parameters.AddWithValue("@month_id", Convert.ToInt32(monthId));
                cmd_insert.Parameters.AddWithValue("@currency", currency);
                cmd_insert.Parameters.AddWithValue("@edit_mode", "0");

                int rowCount = cmd_insert.ExecuteNonQuery();
                if (rowCount >= 1)
                {
                    
                    helper.showAlert(this.Page, "Data saved successfully!");

                    if (type == "CC") {
                        helper.changeDropDownListMode(DropDownList3_type, 1);

                        helper.changeTextBoxEditingMode(textBoxList, 0);

                        helper.changeButtonMode(Button5_clear_all, 0);
                        helper.changeButtonMode(Button2_edit, 0);
                        helper.changeButtonMode(Button3_save, 0);
                        helper.changeButtonMode(Button4_submit, 0);
                        helper.changeButtonMode(Button6_view, 1);
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

        private void updateData()
        {
            DataObject.HelperClass helper = new DataObject.HelperClass();
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "UPDATE tb_setup_budget"
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
                                + ", month_id = @month_id"
                                + ", currency = @currency"
                                + ", edit_mode = @edit_mode"
                                + " WHERE id = @id";

                MySqlCommand cmd_insert = new MySqlCommand();
                cmd_insert.Connection = sqlconn;
                cmd_insert.CommandText = query;
                cmd_insert.Parameters.AddWithValue("@id", ViewState["rowId"]);
                cmd_insert.Parameters.AddWithValue("@year", DropDownList5_year.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@month", DropDownList4_month.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@country", DropDownList1_country.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@vertical", DropDownList2_vertical.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@type", DropDownList3_type.SelectedValue);
                cmd_insert.Parameters.AddWithValue("@r_gmv", TextBox1.Text);
                cmd_insert.Parameters.AddWithValue("@r_gr", TextBox2.Text);
                cmd_insert.Parameters.AddWithValue("@dc_network", TextBox3.Text);
                cmd_insert.Parameters.AddWithValue("@dc_direct_labor", TextBox4.Text);
                cmd_insert.Parameters.AddWithValue("@dc_commissions", TextBox5.Text);
                cmd_insert.Parameters.AddWithValue("@dc_others", TextBox6.Text);
                cmd_insert.Parameters.AddWithValue("@dc_gross_profit", Label6.Text);
                cmd_insert.Parameters.AddWithValue("@o_manpower", TextBox8.Text);
                cmd_insert.Parameters.AddWithValue("@o_travelling", TextBox9.Text);
                cmd_insert.Parameters.AddWithValue("@o_it_charges", TextBox10.Text);
                cmd_insert.Parameters.AddWithValue("@o_marketing_costs", TextBox11.Text);
                cmd_insert.Parameters.AddWithValue("@o_professional_charges", TextBox12.Text);
                cmd_insert.Parameters.AddWithValue("@o_others", TextBox13.Text);
                cmd_insert.Parameters.AddWithValue("@ebitda", Label7.Text);
                cmd_insert.Parameters.AddWithValue("@depreciation", TextBox15.Text);
                cmd_insert.Parameters.AddWithValue("@net_interest", TextBox16.Text);
                cmd_insert.Parameters.AddWithValue("@others", TextBox17.Text);
                cmd_insert.Parameters.AddWithValue("@share_of_results", TextBox18.Text);
                cmd_insert.Parameters.AddWithValue("@tax", TextBox19.Text);
                cmd_insert.Parameters.AddWithValue("@profit_after_tax", Label8.Text);
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

                    ViewState["updateRow"] = false;
                    //ViewState["rowId"] = null;
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

                Label1.Text = DropDownList2_vertical.SelectedValue;
                helper.changeButtonMode(Button2_edit, 0);
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void DropDownList5_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                DataObject.HelperClass helper = new DataObject.HelperClass();
                helper.changeButtonMode(Button2_edit, 0);
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button2_Click_EditData(object sender, EventArgs e)
        {
            try {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                if (ViewState["rowId"] != null && !ViewState["rowId"].Equals("-1"))
                {
                    ViewState["updateRow"] = true;

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
                    ViewState["updateRow"] = false;

                    currency = helper.getCurrencyForCountry(DropDownList1_country.SelectedValue, DropDownList2_vertical.SelectedValue);
                    int ratesExists = checkRatesData(DropDownList5_year.SelectedValue, DropDownList4_month.SelectedValue, "cc");

                    if (ratesExists == 1)
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
                    else {
                        helper.showAlert(this.Page, "You do not have Setup Currency data entered for the selected year & month. \\nPlease add data before proceeding with Setup Budget!");
                        clearAllTextBoxes(textBoxList);
                    }
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button3_Click_SaveData(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                currency = helper.getCurrencyForCountry(DropDownList1_country.SelectedValue, DropDownList2_vertical.SelectedValue);
                Boolean isEdit;
                if (ViewState["updateRow"] != null && !ViewState["updateRow"].Equals("-1"))
                {
                    isEdit = Convert.ToBoolean(ViewState["updateRow"].ToString());
                }
                else {
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
                    calculateValues();
                    monthId = helper.getMonthIdForMonth(DropDownList4_month.SelectedValue);
                    saveData();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button4_Click_SubmitData(object sender, EventArgs e)
        {
            try {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    //write code to submit data with multiplications
                    currency = helper.getCurrencyForCountry(DropDownList1_country.SelectedValue, DropDownList2_vertical.SelectedValue);
                    monthId = helper.getMonthIdForMonth(DropDownList4_month.SelectedValue);
                    calculateValues();
                    updateSubmitData();
                    insertDataWithRatesApplied("Actual");
                    insertDataWithRatesApplied("CC");
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

        protected void Button5_Click_ClearAllData(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("SetupBudget.aspx");
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

                currency = helper.getCurrencyForCountry(DropDownList1_country.SelectedValue, DropDownList2_vertical.SelectedValue);
                int ratesExists = checkRatesData(DropDownList5_year.SelectedValue, DropDownList4_month.SelectedValue, "cc");

                if (ratesExists == 1)
                {
                    String year = DropDownList5_year.SelectedValue;
                    String month = DropDownList4_month.SelectedValue;
                    String country = DropDownList1_country.SelectedValue;
                    String vertical = DropDownList2_vertical.SelectedValue;
                    String type = DropDownList3_type.SelectedValue;


                    populateGridData(year, month, country, vertical, type);
                    calculateDCandOPEX();

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
                        helper.changeTextBoxEditingMode(textBoxList, 1);
                        clearAllTextBoxes(textBoxList);

                        helper.changeButtonMode(Button5_clear_all, 1);
                        helper.changeButtonMode(Button3_save, 1);
                        helper.changeButtonMode(Button2_edit, 0);
                    }
                }
                else
                {
                    helper.showAlert(this.Page, "You do not have Setup Currency data entered for the selected year & month. \\nPlease add data before proceeding with Setup Budget!");
                    clearAllTextBoxes(textBoxList);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void clearAllTextBoxes(List<TextBox> list) {
            try {
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void calculateValues() {
            try {
                Decimal A_gr;
                Decimal B_direct_costs, B1_network, B2_direct_labor, B3_commissions, B4_others;
                Decimal C_gross_profit;
                Decimal D_opex, D1_manpower, D2_travelling, D3_it_charges, D4_marketing_costs, D5_professional_charges, D6_others;
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

                D_opex = D1_manpower + D2_travelling + D3_it_charges + D4_marketing_costs + D5_professional_charges + D6_others;
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

        private void calculateDCandOPEX()
        {
            try
            {
                Decimal B_direct_costs, B1_network, B2_direct_labor, B3_commissions, B4_others;
                Decimal D_opex, D1_manpower, D2_travelling, D3_it_charges, D4_marketing_costs, D5_professional_charges, D6_others;
                
                Decimal.TryParse(TextBox3.Text, out B1_network);
                Decimal.TryParse(TextBox4.Text, out B2_direct_labor);
                Decimal.TryParse(TextBox5.Text, out B3_commissions);
                Decimal.TryParse(TextBox6.Text, out B4_others);

                B_direct_costs = B1_network + B2_direct_labor + B3_commissions + B4_others;
                Label9.Text = Convert.ToString(Decimal.Round(B_direct_costs, 5));

                Decimal.TryParse(TextBox8.Text, out D1_manpower);
                Decimal.TryParse(TextBox9.Text, out D2_travelling);
                Decimal.TryParse(TextBox10.Text, out D3_it_charges);
                Decimal.TryParse(TextBox11.Text, out D4_marketing_costs);
                Decimal.TryParse(TextBox12.Text, out D5_professional_charges);
                Decimal.TryParse(TextBox13.Text, out D6_others);

                D_opex = D1_manpower + D2_travelling + D3_it_charges + D4_marketing_costs + D5_professional_charges + D6_others;
                Label10.Text = Convert.ToString(Decimal.Round(D_opex, 5));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private int checkRatesData(String year, String month, String valuesToCheck) {
            int exists = 0;
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "SELECT value, cc_rate_value"
                                + " FROM tb_fc_to_usd_actual fcd, tb_cc_rate cc "
                                + " WHERE fcd.year = @year"
                                + " AND cc.year = @year"
                                + " AND fcd.month = @month"
                                + " AND cc.month = @month"
                                + " AND fcd.currency = @currency"
                                + " AND cc.currency = @currency";
                                
                MySqlCommand cmd_currency = new MySqlCommand();
                cmd_currency.Connection = sqlconn;
                cmd_currency.CommandText = query;
                cmd_currency.Parameters.AddWithValue("@year", DropDownList5_year.SelectedValue);
                cmd_currency.Parameters.AddWithValue("@month", DropDownList4_month.SelectedValue);
                cmd_currency.Parameters.AddWithValue("@currency", currency);

                MySqlDataReader dr_data = cmd_currency.ExecuteReader();

                if (dr_data.HasRows)
                {
                    if (valuesToCheck == "cc") {
                        if (dr_data["cc_rate_value"].ToString() != null)
                        {
                            exists = 1;
                        }
                        else {
                            exists = 0;
                        }
                    } else if (valuesToCheck == "cc_actual")
                    {
                        if (dr_data["cc_rate_value"].ToString() != null && dr_data["value"].ToString() != null)
                        {
                            exists = 1;
                        }
                        else
                        {
                            exists = 0;
                        }
                    }
                }
                else
                {
                    exists = 0;
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return exists;
        }

        private Decimal fetchRates() {
            Decimal cc_rate = 0; 

            try {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "SELECT cc_rate_value"
                                + " FROM tb_cc_rate cc "
                                + " WHERE year = @year"
                                + " AND month = @month"
                                + " AND currency = @currency";

                MySqlCommand cmd_currency = new MySqlCommand();
                cmd_currency.Connection = sqlconn;
                cmd_currency.CommandText = query;
                cmd_currency.Parameters.AddWithValue("@year", DropDownList5_year.SelectedValue);
                cmd_currency.Parameters.AddWithValue("@month", DropDownList4_month.SelectedValue);
                cmd_currency.Parameters.AddWithValue("@currency", currency);

                MySqlDataReader dr_data = cmd_currency.ExecuteReader();

                if (dr_data.HasRows)
                {
                    while (dr_data.Read())
                    {
                        Decimal.TryParse(dr_data["cc_rate_value"].ToString(), out cc_rate);
                    }
                    dr_data.Close();
                }
                else
                {
                    cc_rate = 1;
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return cc_rate;
        }

        private String applyRate(String value, Decimal rateApplied) {
            String returnValue = "";
            Decimal appliedValue;
            Decimal lc_value;
            try
            {
                Decimal.TryParse(value, out lc_value);
                appliedValue = lc_value / rateApplied;
                returnValue = Convert.ToString(Decimal.Round(appliedValue, 3));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return returnValue;
        }

        private Boolean checkDataExists()
        {
            {
                Boolean exists = false;
                try
                {
                    conn = new DataObject.DbConnection();
                    sqlconn = conn.getDatabaseConnection();

                    String query = "SELECT *"
                                    + " FROM tb_setup_budget"
                                    + " WHERE year = @year"
                                    + " AND month = @month"
                                    + " AND country = @country";

                    MySqlCommand cmd_exists = new MySqlCommand();
                    cmd_exists.Connection = sqlconn;
                    cmd_exists.CommandText = query;
                    cmd_exists.Parameters.AddWithValue("@year", DropDownList5_year.SelectedValue);
                    cmd_exists.Parameters.AddWithValue("@month", DropDownList4_month.SelectedValue);
                    cmd_exists.Parameters.AddWithValue("@country", DropDownList1_country.SelectedValue);

                    MySqlDataReader dr_data = cmd_exists.ExecuteReader();

                    if (dr_data.HasRows)
                    {
                        exists = true;
                    }
                    else
                    {
                        exists = false;
                    }
                    conn.closeConn(sqlconn);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
                return exists;
            }
        }

    }
}