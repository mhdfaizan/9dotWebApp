using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _9dotWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataObject.DbConnection conn;
        MySqlConnection sqlconn;

        //cc rate textbox lists
        List<TextBox> myr_cc_tb_list = new List<TextBox>();
        List<TextBox> idr_cc_tb_list = new List<TextBox>();
        List<TextBox> lkr_cc_tb_list = new List<TextBox>();
        List<TextBox> bdt_cc_tb_list = new List<TextBox>();
        List<TextBox> inr_cc_tb_list = new List<TextBox>();
        List<TextBox> aud_cc_tb_list = new List<TextBox>();

        //cc rate textbox lists for editing
        List<TextBox> cc_rate_edit_tb_list = new List<TextBox>();

        //actual for report quarter textbox lists
        List<TextBox> myr_q1_tb_list = new List<TextBox>();
        List<TextBox> idr_q1_tb_list = new List<TextBox>();
        List<TextBox> lkr_q1_tb_list = new List<TextBox>();
        List<TextBox> bdt_q1_tb_list = new List<TextBox>();
        List<TextBox> inr_q1_tb_list = new List<TextBox>();
        List<TextBox> aud_q1_tb_list = new List<TextBox>();

        List<TextBox> myr_q2_tb_list = new List<TextBox>();
        List<TextBox> idr_q2_tb_list = new List<TextBox>();
        List<TextBox> lkr_q2_tb_list = new List<TextBox>();
        List<TextBox> bdt_q2_tb_list = new List<TextBox>();
        List<TextBox> inr_q2_tb_list = new List<TextBox>();
        List<TextBox> aud_q2_tb_list = new List<TextBox>();

        List<TextBox> myr_q3_tb_list = new List<TextBox>();
        List<TextBox> idr_q3_tb_list = new List<TextBox>();
        List<TextBox> lkr_q3_tb_list = new List<TextBox>();
        List<TextBox> bdt_q3_tb_list = new List<TextBox>();
        List<TextBox> inr_q3_tb_list = new List<TextBox>();
        List<TextBox> aud_q3_tb_list = new List<TextBox>();

        List<TextBox> myr_q4_tb_list = new List<TextBox>();
        List<TextBox> idr_q4_tb_list = new List<TextBox>();
        List<TextBox> lkr_q4_tb_list = new List<TextBox>();
        List<TextBox> bdt_q4_tb_list = new List<TextBox>();
        List<TextBox> inr_q4_tb_list = new List<TextBox>();
        List<TextBox> aud_q4_tb_list = new List<TextBox>();

        //actual for report ytd avg textbox lists
        List<TextBox> myr_ytd_tb_list = new List<TextBox>();
        List<TextBox> idr_ytd_tb_list = new List<TextBox>();
        List<TextBox> lkr_ytd_tb_list = new List<TextBox>();
        List<TextBox> bdt_ytd_tb_list = new List<TextBox>();
        List<TextBox> inr_ytd_tb_list = new List<TextBox>();
        List<TextBox> aud_ytd_tb_list = new List<TextBox>();

        //actual for budget textbox lists
        List<TextBox> myr_acb_tb_list = new List<TextBox>();
        List<TextBox> idr_acb_tb_list = new List<TextBox>();
        List<TextBox> lkr_acb_tb_list = new List<TextBox>();
        List<TextBox> bdt_acb_tb_list = new List<TextBox>();
        List<TextBox> inr_acb_tb_list = new List<TextBox>();
        List<TextBox> aud_acb_tb_list = new List<TextBox>();

        //actual monthly textbox lists
        List<TextBox> jan_tb_list = new List<TextBox>();
        List<TextBox> feb_tb_list = new List<TextBox>();
        List<TextBox> mar_tb_list = new List<TextBox>();
        List<TextBox> apr_tb_list = new List<TextBox>();
        List<TextBox> may_tb_list = new List<TextBox>();
        List<TextBox> jun_tb_list = new List<TextBox>();
        List<TextBox> jul_tb_list = new List<TextBox>();
        List<TextBox> aug_tb_list = new List<TextBox>();
        List<TextBox> sep_tb_list = new List<TextBox>();
        List<TextBox> oct_tb_list = new List<TextBox>();
        List<TextBox> nov_tb_list = new List<TextBox>();
        List<TextBox> dec_tb_list = new List<TextBox>();

        List<List<TextBox>> months_tb_list_list = new List<List<TextBox>>();

        List<TextBox> allActualTextBoxes = new List<TextBox>();
        List<TextBox> allActualTextBoxesForEdit = new List<TextBox>();

        Dictionary<TextBox, int> ac_edit_mode_map = new Dictionary<TextBox, int>();

        List<String> currencies = new List<String> { "MYR", "IDR", "LKR", "BDT", "INR", "AUD" };
        List<String> months = new List<String> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        int finalEditCheck = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                createACMonthlyTextBoxLists();
                createYTDAvgTextBoxLists();
                createQ1AvgTextBoxLists();
                createQ2AvgTextBoxLists();
                createQ3AvgTextBoxLists();
                createQ4AvgTextBoxLists();
                createCCTextBoxLists();
                createACBTextBoxLists();
                createAllActualTextBoxesList();
                createAllActualTextBoxesForEditList();
                createCCEditTextBoxList();
                disableAllNonEditFieldsForCC();

                if (!IsPostBack)
                {
                    DataObject.HelperClass helper = new DataObject.HelperClass();
                    helper.populateYearDropDown(DropDownList1);
                    helper.changeTextBoxEditingMode(cc_rate_edit_tb_list, 0);
                    helper.changeTextBoxEditingMode(allActualTextBoxes, 0);
                    Session["edit_mode"] = -1;
                    Session["actual_edit_check"] = false;
                    //cc rate buttons
                    helper.changeButtonMode(Button5_edit_cc, 0);
                    helper.changeButtonMode(Button6_save_cc, 0);
                    helper.changeButtonMode(Button7_submit_cc, 0);

                    //actual rate buttons
                    helper.changeButtonMode(Button2_edit_actual, 0);
                    helper.changeButtonMode(Button3_save_actual, 0);
                    helper.changeButtonMode(Button4_submit_actual, 0);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button3_Click_SaveMonthData(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                if (Convert.ToBoolean(Session["actual_edit_check"]) == false)
                {
                    for (int i = 0; i < months.Count; i++)
                    {
                        for (int j = 0; j < currencies.Count; j++)
                        {
                            List<TextBox> list = months_tb_list_list[i];
                            TextBox textbox = list[j];

                            String currency = currencies[j];
                            String month = months[i];
                            String year = DropDownList1.SelectedValue;
                            String value = textbox.Text.Trim();
                            String quarter = helper.getQuarterForMonth(months[i]);
                            String month_id = helper.getMonthIdForMonth(months[i]);
                            String edit_mode = "1";

                            insertActualData(currency, month, year, quarter, value, month_id, edit_mode);

                        }
                    }
                    calculateAllAvgForActual();
                }
                else if (Convert.ToBoolean(Session["actual_edit_check"]) == true) {
                    for (int i = 0; i < months.Count; i++)
                    {
                        for (int j = 0; j < currencies.Count; j++)
                        {
                            List<TextBox> list = months_tb_list_list[i];
                            TextBox textbox = list[j];
                            if (textbox.Enabled == true)
                            {
                                String edit_mode = "1";
                                String currency = currencies[j];
                                String month = months[i];
                                String year = DropDownList1.SelectedValue;
                                String value = textbox.Text.Trim();
                                String quarter = helper.getQuarterForMonth(months[i]);
                                String month_id = helper.getMonthIdForMonth(months[i]);

                                updateActualData(currency, month, year, quarter, value, edit_mode, "updated");
                            } else if (textbox.Enabled == false)
                            {
                                String edit_mode = "0";
                                String currency = currencies[j];
                                String month = months[i];
                                String year = DropDownList1.SelectedValue;
                                String value = textbox.Text.Trim();
                                String quarter = helper.getQuarterForMonth(months[i]);
                                String month_id = helper.getMonthIdForMonth(months[i]);

                                updateActualData(currency, month, year, quarter, value, edit_mode, "updated");
                            }
                        }
                    }
                    calculateAllAvgForActual();
                }

                helper.changeDropDownListMode(DropDownList1, 1);
                helper.changeButtonMode(Button1_view, 1);
                helper.changeButtonMode(Button2_edit_actual, 1);
                helper.changeButtonMode(Button3_save_actual, 0);
                helper.changeButtonMode(Button4_submit_actual, 1);
                helper.changeTextBoxEditingMode(allActualTextBoxesForEdit, 0);
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button6_Click_SaveCCData(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                if (Convert.ToInt32(Session["edit_mode"]) == -1)
                {
                    setAllCCGridData();
                    for (int i = 0; i < currencies.Count; i++)
                    {
                        for (int j = 0; j < months.Count; j++)
                        {
                            String currency = currencies[i];
                            String year = DropDownList1.SelectedValue;
                            String value = getCurrencyCCRateFromTextBox(currency);
                            String month = months[j];
                            String monthId = helper.getMonthIdForMonth(months[j]);
                            String edit_mode = "1";
                            insertCCData(currency, year, value, month, monthId, edit_mode);
                        }
                    }

                    helper.changeTextBoxEditingMode(cc_rate_edit_tb_list, 0);
                    helper.changeButtonMode(Button5_edit_cc, 1);
                    helper.changeButtonMode(Button6_save_cc, 0);
                    helper.changeButtonMode(Button7_submit_cc, 1);
                    helper.changeDropDownListMode(DropDownList1, 1);
                    helper.changeButtonMode(Button1_view, 1);
                }
                else if (Convert.ToInt32(Session["edit_mode"]) == 1)
                {
                    setAllCCGridData();
                    for (int i = 0; i < currencies.Count; i++)
                    {
                        for (int j = 0; j < months.Count; j++)
                        {
                            String currency = currencies[i];
                            String year = DropDownList1.SelectedValue;
                            String value = getCurrencyCCRateFromTextBox(currency);
                            String month = months[j];
                            String edit_mode = "1";
                            updateCCData(currency, year, value, month, edit_mode);
                        }
                    }

                    helper.changeTextBoxEditingMode(cc_rate_edit_tb_list, 0);
                    helper.changeButtonMode(Button5_edit_cc, 1);
                    helper.changeButtonMode(Button6_save_cc, 0);
                    helper.changeButtonMode(Button7_submit_cc, 1);
                    helper.changeDropDownListMode(DropDownList1, 1);
                    helper.changeButtonMode(Button1_view, 1);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }

        protected void Button4_Click_SubmitMonthData(object sender, EventArgs e)
        {
            try
            {
                int editableCheck = 0;
                DataObject.HelperClass helper = new DataObject.HelperClass();

                for (int i = 0; i < months.Count; i++)
                {
                    for (int j = 0; j < currencies.Count; j++)
                    {
                        List<TextBox> list = months_tb_list_list[i];
                        TextBox textbox = list[j];

                        String edit_mode = "";
                        String currency = currencies[j];
                        String month = months[i];
                        String year = DropDownList1.SelectedValue;
                        String value = textbox.Text.Trim();
                        String quarter = helper.getQuarterForMonth(months[i]);
                        String month_id = helper.getMonthIdForMonth(months[i]);

                        if (!String.IsNullOrWhiteSpace(value) && !String.IsNullOrEmpty(value))
                        {
                            edit_mode = "0";
                        }
                        else
                        {
                            edit_mode = "1";
                            editableCheck++;
                        }

                        updateActualData(currency, month, year, quarter, value, edit_mode, "submitted");
                    }
                }
                calculateAllAvgForActual();
                if (editableCheck == 0)
                {
                    helper.changeButtonMode(Button4_submit_actual, 0);
                    helper.changeButtonMode(Button2_edit_actual, 0);
                }
                else if (editableCheck > 0) {
                    helper.changeButtonMode(Button4_submit_actual, 1);
                    helper.changeButtonMode(Button2_edit_actual, 1);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button7_Click_SubmitCCData(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                setAllCCGridData();
                for (int i = 0; i < currencies.Count; i++)
                {
                    for (int j = 0; j < months.Count; j++)
                    {
                        String currency = currencies[i];
                        String year = DropDownList1.SelectedValue;
                        String value = getCurrencyCCRateFromTextBox(currency);
                        String month = months[j];
                        String edit_mode = "0";
                        updateCCData(currency, year, value, month, edit_mode);
                    }
                }

                helper.changeTextBoxEditingMode(cc_rate_edit_tb_list, 0);
                helper.changeButtonMode(Button5_edit_cc, 0);
                helper.changeButtonMode(Button6_save_cc, 0);
                helper.changeButtonMode(Button7_submit_cc, 0);
                helper.changeDropDownListMode(DropDownList1, 1);
                helper.changeButtonMode(Button1_view, 1);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button2_Click_EditMonthData(object sender, EventArgs e)
        {
            try {
                DataObject.HelperClass helper = new DataObject.HelperClass();
                if (Session["ac_edit_mode_list"] != null)
                {
                    for (int i = 0; i < months.Count; i++)
                    {
                        for (int j = 0; j < currencies.Count; j++)
                        {
                            String year = DropDownList1.SelectedValue;
                            String month = months[i];
                            String currency = currencies[j];
                            List<TextBox> list = months_tb_list_list[i];
                            TextBox textbox = list[j];

                            populateActualRateData(year, month, currency, textbox);
                        }
                    }
                    enableActualGridForEdit();
                    Session["actual_edit_check"] = true;
                }
                else {
                    Session["actual_edit_check"] = false;
                    helper.changeTextBoxEditingMode(allActualTextBoxesForEdit, 1);
                }

                helper.changeDropDownListMode(DropDownList1, 0);
                helper.changeButtonMode(Button1_view, 0);
                helper.changeButtonMode(Button4_submit_actual, 0);
                helper.changeButtonMode(Button2_edit_actual, 0);
                helper.changeButtonMode(Button3_save_actual, 1);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button5_Click_EditCCData(object sender, EventArgs e)
        {
            try {
                DataObject.HelperClass helper = new DataObject.HelperClass();
                helper.changeTextBoxEditingMode(cc_rate_edit_tb_list, 1);
                helper.changeButtonMode(Button5_edit_cc, 0);
                helper.changeButtonMode(Button6_save_cc, 1);
                helper.changeButtonMode(Button7_submit_cc, 0);
                helper.changeDropDownListMode(DropDownList1, 0);
                helper.changeButtonMode(Button1_view, 0);
                TextBox189.Focus();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button1_Click_ViewYearData(object sender, EventArgs e)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                Label9.Text = "Foreign Currencies to USD (Monthly, Quarterly & Yearly Average) - " + DropDownList1.SelectedValue;

                //populate actual data
                for (int i = 0; i < months.Count; i++) {
                    for (int j = 0; j < currencies.Count; j++) {
                        String year = DropDownList1.SelectedValue;
                        String month = months[i];
                        String currency = currencies[j];
                        List<TextBox> list = months_tb_list_list[i];
                        TextBox textbox = list[j];

                        populateActualRateData(year, month, currency, textbox);
                    }
                }

                helper.changeTextBoxEditingMode(allActualTextBoxes, 0);
                //enableActualGridForEdit();
                if (finalEditCheck >= 1)
                {
                    helper.changeButtonMode(Button4_submit_actual, 1);
                    helper.changeButtonMode(Button2_edit_actual, 1);
                }
                else if (finalEditCheck == -1) {
                    helper.changeButtonMode(Button4_submit_actual, 0);
                    helper.changeButtonMode(Button2_edit_actual, 1);
                }
                else if (finalEditCheck == 0)
                {
                    helper.changeButtonMode(Button4_submit_actual, 0);
                    helper.changeButtonMode(Button2_edit_actual, 0);
                }
                calculateAllAvgForActual();

                //populate cc rates data
                populateCCRateData(currencies[0], TextBox147);
                populateCCRateData(currencies[1], TextBox148);
                populateCCRateData(currencies[2], TextBox149);
                populateCCRateData(currencies[3], TextBox150);
                populateCCRateData(currencies[4], TextBox151);
                populateCCRateData(currencies[5], TextBox181);

                setAllCCGridData();
                helper.changeTextBoxEditingMode(cc_rate_edit_tb_list, 0);

                if (Convert.ToInt32(Session["edit_mode"]) == 0)
                {
                    helper.changeButtonMode(Button5_edit_cc, 0);
                    helper.changeButtonMode(Button6_save_cc, 0);
                    helper.changeButtonMode(Button7_submit_cc, 0);
                }
                else if (Convert.ToInt32(Session["edit_mode"]) == 1)
                {
                    helper.changeButtonMode(Button5_edit_cc, 1);
                    helper.changeButtonMode(Button6_save_cc, 0);
                    helper.changeButtonMode(Button7_submit_cc, 1);
                }
                else if (Convert.ToInt32(Session["edit_mode"]) == -1)
                {
                    clearAllCCData();
                    helper.changeButtonMode(Button5_edit_cc, 1);
                    helper.changeButtonMode(Button6_save_cc, 0);
                    helper.changeButtonMode(Button7_submit_cc, 0);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createCCTextBoxLists() {
            try
            {
                //MYR CC RATE TEXTBOXES
                myr_cc_tb_list.Add(TextBox87);
                myr_cc_tb_list.Add(TextBox92);
                myr_cc_tb_list.Add(TextBox97);
                myr_cc_tb_list.Add(TextBox102);
                myr_cc_tb_list.Add(TextBox107);
                myr_cc_tb_list.Add(TextBox112);
                myr_cc_tb_list.Add(TextBox117);
                myr_cc_tb_list.Add(TextBox122);
                myr_cc_tb_list.Add(TextBox127);
                myr_cc_tb_list.Add(TextBox132);
                myr_cc_tb_list.Add(TextBox137);
                myr_cc_tb_list.Add(TextBox142);

                //IDR CC RATE TEXTBOXES
                idr_cc_tb_list.Add(TextBox88);
                idr_cc_tb_list.Add(TextBox93);
                idr_cc_tb_list.Add(TextBox98);
                idr_cc_tb_list.Add(TextBox103);
                idr_cc_tb_list.Add(TextBox108);
                idr_cc_tb_list.Add(TextBox113);
                idr_cc_tb_list.Add(TextBox118);
                idr_cc_tb_list.Add(TextBox123);
                idr_cc_tb_list.Add(TextBox128);
                idr_cc_tb_list.Add(TextBox133);
                idr_cc_tb_list.Add(TextBox138);
                idr_cc_tb_list.Add(TextBox143);

                //LKR CC RATE TEXTBOXES
                lkr_cc_tb_list.Add(TextBox89);
                lkr_cc_tb_list.Add(TextBox94);
                lkr_cc_tb_list.Add(TextBox99);
                lkr_cc_tb_list.Add(TextBox104);
                lkr_cc_tb_list.Add(TextBox109);
                lkr_cc_tb_list.Add(TextBox114);
                lkr_cc_tb_list.Add(TextBox119);
                lkr_cc_tb_list.Add(TextBox124);
                lkr_cc_tb_list.Add(TextBox129);
                lkr_cc_tb_list.Add(TextBox134);
                lkr_cc_tb_list.Add(TextBox139);
                lkr_cc_tb_list.Add(TextBox144);

                //BDT CC RATE TEXTBOXES
                bdt_cc_tb_list.Add(TextBox90);
                bdt_cc_tb_list.Add(TextBox95);
                bdt_cc_tb_list.Add(TextBox100);
                bdt_cc_tb_list.Add(TextBox105);
                bdt_cc_tb_list.Add(TextBox110);
                bdt_cc_tb_list.Add(TextBox115);
                bdt_cc_tb_list.Add(TextBox120);
                bdt_cc_tb_list.Add(TextBox125);
                bdt_cc_tb_list.Add(TextBox130);
                bdt_cc_tb_list.Add(TextBox135);
                bdt_cc_tb_list.Add(TextBox140);
                bdt_cc_tb_list.Add(TextBox145);

                //INR CC RATE TEXTBOXES
                inr_cc_tb_list.Add(TextBox91);
                inr_cc_tb_list.Add(TextBox96);
                inr_cc_tb_list.Add(TextBox101);
                inr_cc_tb_list.Add(TextBox106);
                inr_cc_tb_list.Add(TextBox111);
                inr_cc_tb_list.Add(TextBox116);
                inr_cc_tb_list.Add(TextBox121);
                inr_cc_tb_list.Add(TextBox126);
                inr_cc_tb_list.Add(TextBox131);
                inr_cc_tb_list.Add(TextBox136);
                inr_cc_tb_list.Add(TextBox141);
                inr_cc_tb_list.Add(TextBox146);

                //AUD CC RATE TEXTBOXES
                aud_cc_tb_list.Add(TextBox169);
                aud_cc_tb_list.Add(TextBox170);
                aud_cc_tb_list.Add(TextBox171);
                aud_cc_tb_list.Add(TextBox172);
                aud_cc_tb_list.Add(TextBox173);
                aud_cc_tb_list.Add(TextBox174);
                aud_cc_tb_list.Add(TextBox175);
                aud_cc_tb_list.Add(TextBox176);
                aud_cc_tb_list.Add(TextBox177);
                aud_cc_tb_list.Add(TextBox178);
                aud_cc_tb_list.Add(TextBox179);
                aud_cc_tb_list.Add(TextBox180);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createYTDAvgTextBoxLists()
        {
            try
            {
                //MYR YTD AVG TEXTBOXES
                myr_ytd_tb_list.Add(TextBox2);
                myr_ytd_tb_list.Add(TextBox7);
                myr_ytd_tb_list.Add(TextBox12);
                myr_ytd_tb_list.Add(TextBox17);
                myr_ytd_tb_list.Add(TextBox22);
                myr_ytd_tb_list.Add(TextBox27);
                myr_ytd_tb_list.Add(TextBox32);
                myr_ytd_tb_list.Add(TextBox37);
                myr_ytd_tb_list.Add(TextBox42);
                myr_ytd_tb_list.Add(TextBox47);
                myr_ytd_tb_list.Add(TextBox52);
                myr_ytd_tb_list.Add(TextBox57);

                //IDR YTD AVG TEXTBOXES
                idr_ytd_tb_list.Add(TextBox3);
                idr_ytd_tb_list.Add(TextBox8);
                idr_ytd_tb_list.Add(TextBox13);
                idr_ytd_tb_list.Add(TextBox18);
                idr_ytd_tb_list.Add(TextBox23);
                idr_ytd_tb_list.Add(TextBox28);
                idr_ytd_tb_list.Add(TextBox33);
                idr_ytd_tb_list.Add(TextBox38);
                idr_ytd_tb_list.Add(TextBox43);
                idr_ytd_tb_list.Add(TextBox48);
                idr_ytd_tb_list.Add(TextBox53);
                idr_ytd_tb_list.Add(TextBox58);

                //LKR YTD AVG TEXTBOXES
                lkr_ytd_tb_list.Add(TextBox4);
                lkr_ytd_tb_list.Add(TextBox9);
                lkr_ytd_tb_list.Add(TextBox14);
                lkr_ytd_tb_list.Add(TextBox19);
                lkr_ytd_tb_list.Add(TextBox24);
                lkr_ytd_tb_list.Add(TextBox29);
                lkr_ytd_tb_list.Add(TextBox34);
                lkr_ytd_tb_list.Add(TextBox39);
                lkr_ytd_tb_list.Add(TextBox44);
                lkr_ytd_tb_list.Add(TextBox49);
                lkr_ytd_tb_list.Add(TextBox54);
                lkr_ytd_tb_list.Add(TextBox59);

                //BDT YTD AVG TEXTBOXES
                bdt_ytd_tb_list.Add(TextBox5);
                bdt_ytd_tb_list.Add(TextBox10);
                bdt_ytd_tb_list.Add(TextBox15);
                bdt_ytd_tb_list.Add(TextBox20);
                bdt_ytd_tb_list.Add(TextBox25);
                bdt_ytd_tb_list.Add(TextBox30);
                bdt_ytd_tb_list.Add(TextBox35);
                bdt_ytd_tb_list.Add(TextBox40);
                bdt_ytd_tb_list.Add(TextBox45);
                bdt_ytd_tb_list.Add(TextBox50);
                bdt_ytd_tb_list.Add(TextBox55);
                bdt_ytd_tb_list.Add(TextBox60);

                //INR YTD AVG TEXTBOXES
                inr_ytd_tb_list.Add(TextBox6);
                inr_ytd_tb_list.Add(TextBox11);
                inr_ytd_tb_list.Add(TextBox16);
                inr_ytd_tb_list.Add(TextBox21);
                inr_ytd_tb_list.Add(TextBox26);
                inr_ytd_tb_list.Add(TextBox31);
                inr_ytd_tb_list.Add(TextBox36);
                inr_ytd_tb_list.Add(TextBox41);
                inr_ytd_tb_list.Add(TextBox46);
                inr_ytd_tb_list.Add(TextBox51);
                inr_ytd_tb_list.Add(TextBox56);
                inr_ytd_tb_list.Add(TextBox61);

                //AUD YTD AVG TEXTBOXES
                aud_ytd_tb_list.Add(TextBox152);
                aud_ytd_tb_list.Add(TextBox153);
                aud_ytd_tb_list.Add(TextBox154);
                aud_ytd_tb_list.Add(TextBox155);
                aud_ytd_tb_list.Add(TextBox156);
                aud_ytd_tb_list.Add(TextBox157);
                aud_ytd_tb_list.Add(TextBox158);
                aud_ytd_tb_list.Add(TextBox159);
                aud_ytd_tb_list.Add(TextBox160);
                aud_ytd_tb_list.Add(TextBox161);
                aud_ytd_tb_list.Add(TextBox162);
                aud_ytd_tb_list.Add(TextBox163);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createQ1AvgTextBoxLists()
        {
            try
            {
                //MYR Q1 AVG TEXTBOXES
                myr_q1_tb_list.Add(TextBox2);
                myr_q1_tb_list.Add(TextBox7);
                myr_q1_tb_list.Add(TextBox12);


                //IDR Q1 AVG TEXTBOXES
                idr_q1_tb_list.Add(TextBox3);
                idr_q1_tb_list.Add(TextBox8);
                idr_q1_tb_list.Add(TextBox13);


                //LKR Q1 AVG TEXTBOXES
                lkr_q1_tb_list.Add(TextBox4);
                lkr_q1_tb_list.Add(TextBox9);
                lkr_q1_tb_list.Add(TextBox14);


                //BDT Q1 AVG TEXTBOXES
                bdt_q1_tb_list.Add(TextBox5);
                bdt_q1_tb_list.Add(TextBox10);
                bdt_q1_tb_list.Add(TextBox15);


                //INR Q1 AVG TEXTBOXES
                inr_q1_tb_list.Add(TextBox6);
                inr_q1_tb_list.Add(TextBox11);
                inr_q1_tb_list.Add(TextBox16);


                //AUD Q1 AVG TEXTBOXES
                aud_q1_tb_list.Add(TextBox152);
                aud_q1_tb_list.Add(TextBox153);
                aud_q1_tb_list.Add(TextBox154);


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createQ2AvgTextBoxLists()
        {
            try
            {
                //MYR Q2 AVG TEXTBOXES
                myr_q2_tb_list.Add(TextBox17);
                myr_q2_tb_list.Add(TextBox22);
                myr_q2_tb_list.Add(TextBox27);


                //IDR Q2 AVG TEXTBOXES
                idr_q2_tb_list.Add(TextBox18);
                idr_q2_tb_list.Add(TextBox23);
                idr_q2_tb_list.Add(TextBox28);


                //LKR Q2 AVG TEXTBOXES
                lkr_q2_tb_list.Add(TextBox19);
                lkr_q2_tb_list.Add(TextBox24);
                lkr_q2_tb_list.Add(TextBox29);


                //BDT Q2 AVG TEXTBOXES
                bdt_q2_tb_list.Add(TextBox20);
                bdt_q2_tb_list.Add(TextBox25);
                bdt_q2_tb_list.Add(TextBox30);


                //INR Q2 AVG TEXTBOXES
                inr_q2_tb_list.Add(TextBox21);
                inr_q2_tb_list.Add(TextBox26);
                inr_q2_tb_list.Add(TextBox31);


                //AUD Q2 AVG TEXTBOXES
                aud_q2_tb_list.Add(TextBox155);
                aud_q2_tb_list.Add(TextBox156);
                aud_q2_tb_list.Add(TextBox157);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createQ3AvgTextBoxLists()
        {
            try
            {
                //MYR Q3 AVG TEXTBOXES
                myr_q3_tb_list.Add(TextBox32);
                myr_q3_tb_list.Add(TextBox37);
                myr_q3_tb_list.Add(TextBox42);


                //IDR Q3 AVG TEXTBOXES
                idr_q3_tb_list.Add(TextBox33);
                idr_q3_tb_list.Add(TextBox38);
                idr_q3_tb_list.Add(TextBox43);

                //LKR Q3 AVG TEXTBOXES
                lkr_q3_tb_list.Add(TextBox34);
                lkr_q3_tb_list.Add(TextBox39);
                lkr_q3_tb_list.Add(TextBox44);

                //BDT Q3 AVG TEXTBOXES
                bdt_q3_tb_list.Add(TextBox35);
                bdt_q3_tb_list.Add(TextBox40);
                bdt_q3_tb_list.Add(TextBox45);

                //INR Q3 AVG TEXTBOXES
                inr_q3_tb_list.Add(TextBox36);
                inr_q3_tb_list.Add(TextBox41);
                inr_q3_tb_list.Add(TextBox46);

                //AUD Q3 AVG TEXTBOXES
                aud_q3_tb_list.Add(TextBox158);
                aud_q3_tb_list.Add(TextBox159);
                aud_q3_tb_list.Add(TextBox160);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createQ4AvgTextBoxLists()
        {
            try
            {
                //MYR Q4 AVG TEXTBOXES
                myr_q4_tb_list.Add(TextBox47);
                myr_q4_tb_list.Add(TextBox52);
                myr_q4_tb_list.Add(TextBox57);

                //IDR Q4 AVG TEXTBOXES
                idr_q4_tb_list.Add(TextBox48);
                idr_q4_tb_list.Add(TextBox53);
                idr_q4_tb_list.Add(TextBox58);

                //LKR Q4 AVG TEXTBOXES
                lkr_q4_tb_list.Add(TextBox49);
                lkr_q4_tb_list.Add(TextBox54);
                lkr_q4_tb_list.Add(TextBox59);

                //BDT Q4 AVG TEXTBOXES
                bdt_q4_tb_list.Add(TextBox50);
                bdt_q4_tb_list.Add(TextBox55);
                bdt_q4_tb_list.Add(TextBox60);

                //INR Q4 AVG TEXTBOXES
                inr_q4_tb_list.Add(TextBox51);
                inr_q4_tb_list.Add(TextBox56);
                inr_q4_tb_list.Add(TextBox61);

                //AUD Q4 AVG TEXTBOXES
                aud_q4_tb_list.Add(TextBox161);
                aud_q4_tb_list.Add(TextBox162);
                aud_q4_tb_list.Add(TextBox163);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createAllActualTextBoxesList() {
            try {
                allActualTextBoxes.Add(TextBox2);
                allActualTextBoxes.Add(TextBox3);
                allActualTextBoxes.Add(TextBox4);
                allActualTextBoxes.Add(TextBox5);
                allActualTextBoxes.Add(TextBox6);
                allActualTextBoxes.Add(TextBox7);
                allActualTextBoxes.Add(TextBox8);
                allActualTextBoxes.Add(TextBox9);
                allActualTextBoxes.Add(TextBox10);
                allActualTextBoxes.Add(TextBox11);
                allActualTextBoxes.Add(TextBox12);
                allActualTextBoxes.Add(TextBox13);
                allActualTextBoxes.Add(TextBox14);
                allActualTextBoxes.Add(TextBox15);
                allActualTextBoxes.Add(TextBox16);
                allActualTextBoxes.Add(TextBox17);
                allActualTextBoxes.Add(TextBox18);
                allActualTextBoxes.Add(TextBox19);
                allActualTextBoxes.Add(TextBox20);
                allActualTextBoxes.Add(TextBox21);
                allActualTextBoxes.Add(TextBox22);
                allActualTextBoxes.Add(TextBox23);
                allActualTextBoxes.Add(TextBox24);
                allActualTextBoxes.Add(TextBox25);
                allActualTextBoxes.Add(TextBox26);
                allActualTextBoxes.Add(TextBox27);
                allActualTextBoxes.Add(TextBox28);
                allActualTextBoxes.Add(TextBox29);
                allActualTextBoxes.Add(TextBox30);
                allActualTextBoxes.Add(TextBox31);
                allActualTextBoxes.Add(TextBox32);
                allActualTextBoxes.Add(TextBox33);
                allActualTextBoxes.Add(TextBox34);
                allActualTextBoxes.Add(TextBox35);
                allActualTextBoxes.Add(TextBox36);
                allActualTextBoxes.Add(TextBox37);
                allActualTextBoxes.Add(TextBox38);
                allActualTextBoxes.Add(TextBox39);
                allActualTextBoxes.Add(TextBox40);
                allActualTextBoxes.Add(TextBox41);
                allActualTextBoxes.Add(TextBox42);
                allActualTextBoxes.Add(TextBox43);
                allActualTextBoxes.Add(TextBox44);
                allActualTextBoxes.Add(TextBox45);
                allActualTextBoxes.Add(TextBox46);
                allActualTextBoxes.Add(TextBox47);
                allActualTextBoxes.Add(TextBox48);
                allActualTextBoxes.Add(TextBox49);
                allActualTextBoxes.Add(TextBox50);
                allActualTextBoxes.Add(TextBox51);
                allActualTextBoxes.Add(TextBox52);
                allActualTextBoxes.Add(TextBox53);
                allActualTextBoxes.Add(TextBox54);
                allActualTextBoxes.Add(TextBox55);
                allActualTextBoxes.Add(TextBox56);
                allActualTextBoxes.Add(TextBox57);
                allActualTextBoxes.Add(TextBox58);
                allActualTextBoxes.Add(TextBox59);
                allActualTextBoxes.Add(TextBox60);
                allActualTextBoxes.Add(TextBox61);
                allActualTextBoxes.Add(TextBox62);
                allActualTextBoxes.Add(TextBox63);
                allActualTextBoxes.Add(TextBox64);
                allActualTextBoxes.Add(TextBox65);
                allActualTextBoxes.Add(TextBox66);
                allActualTextBoxes.Add(TextBox67);
                allActualTextBoxes.Add(TextBox68);
                allActualTextBoxes.Add(TextBox69);
                allActualTextBoxes.Add(TextBox70);
                allActualTextBoxes.Add(TextBox71);
                allActualTextBoxes.Add(TextBox72);
                allActualTextBoxes.Add(TextBox73);
                allActualTextBoxes.Add(TextBox74);
                allActualTextBoxes.Add(TextBox75);
                allActualTextBoxes.Add(TextBox76);
                allActualTextBoxes.Add(TextBox77);
                allActualTextBoxes.Add(TextBox78);
                allActualTextBoxes.Add(TextBox79);
                allActualTextBoxes.Add(TextBox80);
                allActualTextBoxes.Add(TextBox81);
                allActualTextBoxes.Add(TextBox82);
                allActualTextBoxes.Add(TextBox83);
                allActualTextBoxes.Add(TextBox84);
                allActualTextBoxes.Add(TextBox85);
                allActualTextBoxes.Add(TextBox86);
                allActualTextBoxes.Add(TextBox152);
                allActualTextBoxes.Add(TextBox153);
                allActualTextBoxes.Add(TextBox154);
                allActualTextBoxes.Add(TextBox155);
                allActualTextBoxes.Add(TextBox156);
                allActualTextBoxes.Add(TextBox157);
                allActualTextBoxes.Add(TextBox158);
                allActualTextBoxes.Add(TextBox159);
                allActualTextBoxes.Add(TextBox160);
                allActualTextBoxes.Add(TextBox161);
                allActualTextBoxes.Add(TextBox162);
                allActualTextBoxes.Add(TextBox163);
                allActualTextBoxes.Add(TextBox164);
                allActualTextBoxes.Add(TextBox165);
                allActualTextBoxes.Add(TextBox166);
                allActualTextBoxes.Add(TextBox167);
                allActualTextBoxes.Add(TextBox168);
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createAllActualTextBoxesForEditList()
        {
            try
            {
                allActualTextBoxesForEdit.Add(TextBox2);
                allActualTextBoxesForEdit.Add(TextBox3);
                allActualTextBoxesForEdit.Add(TextBox4);
                allActualTextBoxesForEdit.Add(TextBox5);
                allActualTextBoxesForEdit.Add(TextBox6);
                allActualTextBoxesForEdit.Add(TextBox7);
                allActualTextBoxesForEdit.Add(TextBox8);
                allActualTextBoxesForEdit.Add(TextBox9);
                allActualTextBoxesForEdit.Add(TextBox10);
                allActualTextBoxesForEdit.Add(TextBox11);
                allActualTextBoxesForEdit.Add(TextBox12);
                allActualTextBoxesForEdit.Add(TextBox13);
                allActualTextBoxesForEdit.Add(TextBox14);
                allActualTextBoxesForEdit.Add(TextBox15);
                allActualTextBoxesForEdit.Add(TextBox16);
                allActualTextBoxesForEdit.Add(TextBox17);
                allActualTextBoxesForEdit.Add(TextBox18);
                allActualTextBoxesForEdit.Add(TextBox19);
                allActualTextBoxesForEdit.Add(TextBox20);
                allActualTextBoxesForEdit.Add(TextBox21);
                allActualTextBoxesForEdit.Add(TextBox22);
                allActualTextBoxesForEdit.Add(TextBox23);
                allActualTextBoxesForEdit.Add(TextBox24);
                allActualTextBoxesForEdit.Add(TextBox25);
                allActualTextBoxesForEdit.Add(TextBox26);
                allActualTextBoxesForEdit.Add(TextBox27);
                allActualTextBoxesForEdit.Add(TextBox28);
                allActualTextBoxesForEdit.Add(TextBox29);
                allActualTextBoxesForEdit.Add(TextBox30);
                allActualTextBoxesForEdit.Add(TextBox31);
                allActualTextBoxesForEdit.Add(TextBox32);
                allActualTextBoxesForEdit.Add(TextBox33);
                allActualTextBoxesForEdit.Add(TextBox34);
                allActualTextBoxesForEdit.Add(TextBox35);
                allActualTextBoxesForEdit.Add(TextBox36);
                allActualTextBoxesForEdit.Add(TextBox37);
                allActualTextBoxesForEdit.Add(TextBox38);
                allActualTextBoxesForEdit.Add(TextBox39);
                allActualTextBoxesForEdit.Add(TextBox40);
                allActualTextBoxesForEdit.Add(TextBox41);
                allActualTextBoxesForEdit.Add(TextBox42);
                allActualTextBoxesForEdit.Add(TextBox43);
                allActualTextBoxesForEdit.Add(TextBox44);
                allActualTextBoxesForEdit.Add(TextBox45);
                allActualTextBoxesForEdit.Add(TextBox46);
                allActualTextBoxesForEdit.Add(TextBox47);
                allActualTextBoxesForEdit.Add(TextBox48);
                allActualTextBoxesForEdit.Add(TextBox49);
                allActualTextBoxesForEdit.Add(TextBox50);
                allActualTextBoxesForEdit.Add(TextBox51);
                allActualTextBoxesForEdit.Add(TextBox52);
                allActualTextBoxesForEdit.Add(TextBox53);
                allActualTextBoxesForEdit.Add(TextBox54);
                allActualTextBoxesForEdit.Add(TextBox55);
                allActualTextBoxesForEdit.Add(TextBox56);
                allActualTextBoxesForEdit.Add(TextBox57);
                allActualTextBoxesForEdit.Add(TextBox58);
                allActualTextBoxesForEdit.Add(TextBox59);
                allActualTextBoxesForEdit.Add(TextBox60);
                allActualTextBoxesForEdit.Add(TextBox61);

                allActualTextBoxesForEdit.Add(TextBox152);
                allActualTextBoxesForEdit.Add(TextBox153);
                allActualTextBoxesForEdit.Add(TextBox154);
                allActualTextBoxesForEdit.Add(TextBox155);
                allActualTextBoxesForEdit.Add(TextBox156);
                allActualTextBoxesForEdit.Add(TextBox157);
                allActualTextBoxesForEdit.Add(TextBox158);
                allActualTextBoxesForEdit.Add(TextBox159);
                allActualTextBoxesForEdit.Add(TextBox160);
                allActualTextBoxesForEdit.Add(TextBox161);
                allActualTextBoxesForEdit.Add(TextBox162);
                allActualTextBoxesForEdit.Add(TextBox163);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createACBTextBoxLists()
        {
            try
            {
                //MYR ACB TEXTBOXES
                myr_acb_tb_list.Add(TextBox182);
                myr_acb_tb_list.Add(TextBox183);
                myr_acb_tb_list.Add(TextBox184);
                myr_acb_tb_list.Add(TextBox185);
                myr_acb_tb_list.Add(TextBox186);
                myr_acb_tb_list.Add(TextBox187);
                myr_acb_tb_list.Add(TextBox188);
                myr_acb_tb_list.Add(TextBox189);
                myr_acb_tb_list.Add(TextBox190);
                myr_acb_tb_list.Add(TextBox191);
                myr_acb_tb_list.Add(TextBox192);
                myr_acb_tb_list.Add(TextBox193);
                myr_acb_tb_list.Add(TextBox194);
                myr_acb_tb_list.Add(TextBox195);
                myr_acb_tb_list.Add(TextBox196);
                myr_acb_tb_list.Add(TextBox197);
                myr_acb_tb_list.Add(TextBox198);

                //IDR ACB TEXTBOXES
                idr_acb_tb_list.Add(TextBox199);
                idr_acb_tb_list.Add(TextBox200);
                idr_acb_tb_list.Add(TextBox201);
                idr_acb_tb_list.Add(TextBox202);
                idr_acb_tb_list.Add(TextBox203);
                idr_acb_tb_list.Add(TextBox204);
                idr_acb_tb_list.Add(TextBox205);
                idr_acb_tb_list.Add(TextBox206);
                idr_acb_tb_list.Add(TextBox207);
                idr_acb_tb_list.Add(TextBox208);
                idr_acb_tb_list.Add(TextBox209);
                idr_acb_tb_list.Add(TextBox210);
                idr_acb_tb_list.Add(TextBox211);
                idr_acb_tb_list.Add(TextBox212);
                idr_acb_tb_list.Add(TextBox213);
                idr_acb_tb_list.Add(TextBox214);
                idr_acb_tb_list.Add(TextBox215);

                //LKR ACB TEXTBOXES
                lkr_acb_tb_list.Add(TextBox216);
                lkr_acb_tb_list.Add(TextBox217);
                lkr_acb_tb_list.Add(TextBox218);
                lkr_acb_tb_list.Add(TextBox219);
                lkr_acb_tb_list.Add(TextBox220);
                lkr_acb_tb_list.Add(TextBox221);
                lkr_acb_tb_list.Add(TextBox222);
                lkr_acb_tb_list.Add(TextBox223);
                lkr_acb_tb_list.Add(TextBox224);
                lkr_acb_tb_list.Add(TextBox225);
                lkr_acb_tb_list.Add(TextBox226);
                lkr_acb_tb_list.Add(TextBox227);
                lkr_acb_tb_list.Add(TextBox228);
                lkr_acb_tb_list.Add(TextBox229);
                lkr_acb_tb_list.Add(TextBox230);
                lkr_acb_tb_list.Add(TextBox231);
                lkr_acb_tb_list.Add(TextBox232);

                //BDT ACB TEXTBOXES
                bdt_acb_tb_list.Add(TextBox233);
                bdt_acb_tb_list.Add(TextBox234);
                bdt_acb_tb_list.Add(TextBox235);
                bdt_acb_tb_list.Add(TextBox236);
                bdt_acb_tb_list.Add(TextBox237);
                bdt_acb_tb_list.Add(TextBox238);
                bdt_acb_tb_list.Add(TextBox239);
                bdt_acb_tb_list.Add(TextBox240);
                bdt_acb_tb_list.Add(TextBox241);
                bdt_acb_tb_list.Add(TextBox242);
                bdt_acb_tb_list.Add(TextBox243);
                bdt_acb_tb_list.Add(TextBox244);
                bdt_acb_tb_list.Add(TextBox245);
                bdt_acb_tb_list.Add(TextBox246);
                bdt_acb_tb_list.Add(TextBox247);
                bdt_acb_tb_list.Add(TextBox248);
                bdt_acb_tb_list.Add(TextBox249);

                //INR ACB TEXTBOXES
                inr_acb_tb_list.Add(TextBox250);
                inr_acb_tb_list.Add(TextBox251);
                inr_acb_tb_list.Add(TextBox252);
                inr_acb_tb_list.Add(TextBox253);
                inr_acb_tb_list.Add(TextBox254);
                inr_acb_tb_list.Add(TextBox255);
                inr_acb_tb_list.Add(TextBox256);
                inr_acb_tb_list.Add(TextBox257);
                inr_acb_tb_list.Add(TextBox258);
                inr_acb_tb_list.Add(TextBox259);
                inr_acb_tb_list.Add(TextBox260);
                inr_acb_tb_list.Add(TextBox261);
                inr_acb_tb_list.Add(TextBox262);
                inr_acb_tb_list.Add(TextBox263);
                inr_acb_tb_list.Add(TextBox264);
                inr_acb_tb_list.Add(TextBox265);
                inr_acb_tb_list.Add(TextBox266);


                //AUD ACB TEXTBOXES
                aud_acb_tb_list.Add(TextBox267);
                aud_acb_tb_list.Add(TextBox268);
                aud_acb_tb_list.Add(TextBox269);
                aud_acb_tb_list.Add(TextBox270);
                aud_acb_tb_list.Add(TextBox271);
                aud_acb_tb_list.Add(TextBox272);
                aud_acb_tb_list.Add(TextBox273);
                aud_acb_tb_list.Add(TextBox274);
                aud_acb_tb_list.Add(TextBox275);
                aud_acb_tb_list.Add(TextBox276);
                aud_acb_tb_list.Add(TextBox277);
                aud_acb_tb_list.Add(TextBox278);
                aud_acb_tb_list.Add(TextBox279);
                aud_acb_tb_list.Add(TextBox280);
                aud_acb_tb_list.Add(TextBox281);
                aud_acb_tb_list.Add(TextBox282);
                aud_acb_tb_list.Add(TextBox283);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createACMonthlyTextBoxLists()
        {
            try
            {
                //JAN TEXTBOXES
                jan_tb_list.Add(TextBox2);
                jan_tb_list.Add(TextBox3);
                jan_tb_list.Add(TextBox4);
                jan_tb_list.Add(TextBox5);
                jan_tb_list.Add(TextBox6);
                jan_tb_list.Add(TextBox152);

                //FEB TEXTBOXES
                feb_tb_list.Add(TextBox7);
                feb_tb_list.Add(TextBox8);
                feb_tb_list.Add(TextBox9);
                feb_tb_list.Add(TextBox10);
                feb_tb_list.Add(TextBox11);
                feb_tb_list.Add(TextBox153);

                //MAR TEXTBOXES
                mar_tb_list.Add(TextBox12);
                mar_tb_list.Add(TextBox13);
                mar_tb_list.Add(TextBox14);
                mar_tb_list.Add(TextBox15);
                mar_tb_list.Add(TextBox16);
                mar_tb_list.Add(TextBox154);

                //APR TEXTBOXES
                apr_tb_list.Add(TextBox17);
                apr_tb_list.Add(TextBox18);
                apr_tb_list.Add(TextBox19);
                apr_tb_list.Add(TextBox20);
                apr_tb_list.Add(TextBox21);
                apr_tb_list.Add(TextBox155);

                //MAY TEXTBOXES
                may_tb_list.Add(TextBox22);
                may_tb_list.Add(TextBox23);
                may_tb_list.Add(TextBox24);
                may_tb_list.Add(TextBox25);
                may_tb_list.Add(TextBox26);
                may_tb_list.Add(TextBox156);

                //JUN TEXTBOXES
                jun_tb_list.Add(TextBox27);
                jun_tb_list.Add(TextBox28);
                jun_tb_list.Add(TextBox29);
                jun_tb_list.Add(TextBox30);
                jun_tb_list.Add(TextBox31);
                jun_tb_list.Add(TextBox157);

                //JUL TEXTBOXES
                jul_tb_list.Add(TextBox32);
                jul_tb_list.Add(TextBox33);
                jul_tb_list.Add(TextBox34);
                jul_tb_list.Add(TextBox35);
                jul_tb_list.Add(TextBox36);
                jul_tb_list.Add(TextBox158);

                //AUG TEXTBOXES
                aug_tb_list.Add(TextBox37);
                aug_tb_list.Add(TextBox38);
                aug_tb_list.Add(TextBox39);
                aug_tb_list.Add(TextBox40);
                aug_tb_list.Add(TextBox41);
                aug_tb_list.Add(TextBox159);

                //SEP TEXTBOXES
                sep_tb_list.Add(TextBox42);
                sep_tb_list.Add(TextBox43);
                sep_tb_list.Add(TextBox44);
                sep_tb_list.Add(TextBox45);
                sep_tb_list.Add(TextBox46);
                sep_tb_list.Add(TextBox160);

                //OCT TEXTBOXES
                oct_tb_list.Add(TextBox47);
                oct_tb_list.Add(TextBox48);
                oct_tb_list.Add(TextBox49);
                oct_tb_list.Add(TextBox50);
                oct_tb_list.Add(TextBox51);
                oct_tb_list.Add(TextBox161);

                //NOV TEXTBOXES
                nov_tb_list.Add(TextBox52);
                nov_tb_list.Add(TextBox53);
                nov_tb_list.Add(TextBox54);
                nov_tb_list.Add(TextBox55);
                nov_tb_list.Add(TextBox56);
                nov_tb_list.Add(TextBox162);

                //DEC TEXTBOXES
                dec_tb_list.Add(TextBox57);
                dec_tb_list.Add(TextBox58);
                dec_tb_list.Add(TextBox59);
                dec_tb_list.Add(TextBox60);
                dec_tb_list.Add(TextBox61);
                dec_tb_list.Add(TextBox163);


                months_tb_list_list.Add(jan_tb_list);
                months_tb_list_list.Add(feb_tb_list);
                months_tb_list_list.Add(mar_tb_list);
                months_tb_list_list.Add(apr_tb_list);
                months_tb_list_list.Add(may_tb_list);
                months_tb_list_list.Add(jun_tb_list);
                months_tb_list_list.Add(jul_tb_list);
                months_tb_list_list.Add(aug_tb_list);
                months_tb_list_list.Add(sep_tb_list);
                months_tb_list_list.Add(oct_tb_list);
                months_tb_list_list.Add(nov_tb_list);
                months_tb_list_list.Add(dec_tb_list);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void createCCEditTextBoxList() {
            try {
                cc_rate_edit_tb_list.Add(TextBox147);
                cc_rate_edit_tb_list.Add(TextBox148);
                cc_rate_edit_tb_list.Add(TextBox149);
                cc_rate_edit_tb_list.Add(TextBox150);
                cc_rate_edit_tb_list.Add(TextBox151);
                cc_rate_edit_tb_list.Add(TextBox181);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void calculateYTDAverage(List<TextBox> list, TextBox textbox)
        {
            try
            {
                decimal total = 0;
                decimal ytd_avg = 0;
                int divisor = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    String stringValue = list[i].Text.Trim();
                    if (stringValue != null && stringValue != String.Empty)
                    {
                        //Debug.WriteLine(list[i].Text);
                        decimal value = 0;
                        Decimal.TryParse(stringValue, out value);
                        total += value;
                        divisor++;
                    }
                }

                ytd_avg = total / divisor;
                textbox.Text = Convert.ToString(Decimal.Round(ytd_avg, 5));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }

        private void calculateQtrAverage(List<TextBox> list, TextBox textbox)
        {
            try
            {
                decimal total = 0;
                decimal qtr_avg = 0;
                int divisor = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    String stringValue = list[i].Text.Trim();
                    if (stringValue != null && stringValue != String.Empty)
                    {
                        //Debug.WriteLine(list[i].Text);
                        decimal value = 0;
                        Decimal.TryParse(stringValue, out value);
                        total += value;
                        divisor++;
                    }
                }

                if (divisor == 3) {
                    qtr_avg = total / divisor;
                    textbox.Text = Convert.ToString(Decimal.Round(qtr_avg, 5));
                } else
                {
                    textbox.Text = "";
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }

        private int checkEmptyTextBoxForQtrAvg(List<TextBox> list)
        {
            int count = 0;
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Text != null && list[i].Text != String.Empty)
                    {
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return count;
        }

        private void populateCCRateData(String currency, TextBox textbox) {
            try {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "SELECT *"
                                + " FROM tb_cc_rate"
                                + " WHERE year = @year"
                                + " AND currency = @currency"
                                + " AND month = @month";

                MySqlCommand cmd_cc_data = new MySqlCommand();
                cmd_cc_data.Connection = sqlconn;
                cmd_cc_data.CommandText = query;
                cmd_cc_data.Parameters.AddWithValue("@year", DropDownList1.SelectedValue);
                cmd_cc_data.Parameters.AddWithValue("@month", "Jan");
                cmd_cc_data.Parameters.AddWithValue("@currency", currency);

                MySqlDataReader dr_data = cmd_cc_data.ExecuteReader();

                if (dr_data.HasRows)
                {
                    while (dr_data.Read())
                    {
                        textbox.Text = dr_data["cc_rate_value"].ToString();
                        Session["edit_mode"] = Convert.ToInt32(dr_data["edit_mode"].ToString());
                    }
                    dr_data.Close();
                    dr_data.Dispose();
                }
                else
                {
                    Session["edit_mode"] = -1;
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void populateActualRateData(String year, String month, String currency, TextBox textbox)
        {
            try
            {
                DataObject.HelperClass helper = new DataObject.HelperClass();

                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "SELECT *"
                                + " FROM tb_fc_to_usd_actual"
                                + " WHERE year = @year"
                                + " AND month = @month"
                                + " AND currency = @currency";

                MySqlCommand cmd_ac_data = new MySqlCommand();
                cmd_ac_data.Connection = sqlconn;
                cmd_ac_data.CommandText = query;
                cmd_ac_data.Parameters.AddWithValue("@year", year);
                cmd_ac_data.Parameters.AddWithValue("@month", month);
                cmd_ac_data.Parameters.AddWithValue("@currency", currency);

                MySqlDataReader dr_data = cmd_ac_data.ExecuteReader();

                if (dr_data.HasRows)
                {
                    while (dr_data.Read())
                    {
                        int editMode = Convert.ToInt32(dr_data["edit_mode"].ToString());
                        textbox.Text = dr_data["value"].ToString();

                        ac_edit_mode_map.Add(textbox, editMode);
                        Session["ac_edit_mode_list"] = ac_edit_mode_map;

                        finalEditCheck += editMode;
                    }
                    dr_data.Close();
                }
                else
                {
                    if (currency == currencies[5] && month == months[11])
                    {
                        clearAllActualData();
                        ac_edit_mode_map = null;
                        Session["ac_edit_mode_list"] = null;
                        finalEditCheck = -1;
                    }
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void setCCTextBoxValues(List<TextBox> list, String textboxValue)
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Text = textboxValue;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void setAllCCGridData() {
            try {
                setCCTextBoxValues(myr_cc_tb_list, TextBox147.Text);
                setCCTextBoxValues(idr_cc_tb_list, TextBox148.Text);
                setCCTextBoxValues(lkr_cc_tb_list, TextBox149.Text);
                setCCTextBoxValues(bdt_cc_tb_list, TextBox150.Text);
                setCCTextBoxValues(inr_cc_tb_list, TextBox151.Text);
                setCCTextBoxValues(aud_cc_tb_list, TextBox181.Text);

                setCCTextBoxValues(myr_acb_tb_list, TextBox147.Text);
                setCCTextBoxValues(idr_acb_tb_list, TextBox148.Text);
                setCCTextBoxValues(lkr_acb_tb_list, TextBox149.Text);
                setCCTextBoxValues(bdt_acb_tb_list, TextBox150.Text);
                setCCTextBoxValues(inr_acb_tb_list, TextBox151.Text);
                setCCTextBoxValues(aud_acb_tb_list, TextBox181.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void insertCCData(String currency, String year, String value, String month, String month_id, String edit_mode)
        {
            try {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "INSERT INTO tb_cc_rate("
                                + "currency"
                                + ", year"
                                + ", cc_rate_value"
                                + ", month"
                                + ", month_id"
                                + ", edit_mode"
                                + ") values ("
                                + " @currency"
                                + ", @year"
                                + ", @cc_rate_value"
                                + ", @month"
                                + ", @month_id"
                                + ", @edit_mode)";

                MySqlCommand cmd_cc_data_insert = new MySqlCommand();
                cmd_cc_data_insert.Connection = sqlconn;
                cmd_cc_data_insert.CommandText = query;
                cmd_cc_data_insert.Parameters.AddWithValue("@currency", currency);
                cmd_cc_data_insert.Parameters.AddWithValue("@year", year);
                cmd_cc_data_insert.Parameters.AddWithValue("@cc_rate_value", value);
                cmd_cc_data_insert.Parameters.AddWithValue("@month", month);
                cmd_cc_data_insert.Parameters.AddWithValue("@month_id", Convert.ToInt32(month_id));
                cmd_cc_data_insert.Parameters.AddWithValue("@edit_mode", edit_mode);

                int rowCount = cmd_cc_data_insert.ExecuteNonQuery();
                if (rowCount >= 1)
                {
                    DataObject.HelperClass helper = new DataObject.HelperClass();
                    helper.showAlert(this.Page, "Data saved successfully!");
                } else
                {
                    DataObject.HelperClass helper = new DataObject.HelperClass();
                    helper.showAlert(this.Page, "Please check your data for errors!");
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void updateCCData(String currency, String year, String value, String month, String edit_mode)
        {
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "UPDATE tb_cc_rate"
                                + " SET cc_rate_value = @cc_rate_value"
                                + ", edit_mode = @edit_mode"
                                + " WHERE currency = @currency"
                                + " AND year = @year"
                                + " AND month = @month";


                MySqlCommand cmd_cc_data_update = new MySqlCommand();
                cmd_cc_data_update.Connection = sqlconn;
                cmd_cc_data_update.CommandText = query;
                cmd_cc_data_update.Parameters.AddWithValue("@currency", currency);
                cmd_cc_data_update.Parameters.AddWithValue("@year", year);
                cmd_cc_data_update.Parameters.AddWithValue("@cc_rate_value", value);
                cmd_cc_data_update.Parameters.AddWithValue("@month", month);
                cmd_cc_data_update.Parameters.AddWithValue("@edit_mode", edit_mode);

                int rowCount = cmd_cc_data_update.ExecuteNonQuery();
                if (rowCount >= 1)
                {
                    if (Convert.ToInt32(edit_mode) == 0)
                    {
                        DataObject.HelperClass helper = new DataObject.HelperClass();
                        helper.showAlert(this.Page, "Data submitted successfully!");
                    }
                    else if (Convert.ToInt32(edit_mode) == 1)
                    {
                        DataObject.HelperClass helper = new DataObject.HelperClass();
                        helper.showAlert(this.Page, "Data updated successfully!");
                    }
                }
                else
                {
                    DataObject.HelperClass helper = new DataObject.HelperClass();
                    helper.showAlert(this.Page, "Please check your data for errors!");
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void insertActualData(String currency, String month, String year, String quarter, String value, String month_id, String edit_mode)
        {
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "INSERT INTO tb_fc_to_usd_actual("
                                + "currency"
                                + ", month"
                                + ", year"
                                + ", quarter"
                                + ", value"
                                + ", month_id"
                                + ", edit_mode"
                                + ") values ("
                                + " @currency"
                                + ", @month"
                                + ", @year"
                                + ", @quarter"
                                + ", @value"
                                + ", @month_id"
                                + ", @edit_mode)";

                MySqlCommand cmd_ac_data_insert = new MySqlCommand();
                cmd_ac_data_insert.Connection = sqlconn;
                cmd_ac_data_insert.CommandText = query;
                cmd_ac_data_insert.Parameters.AddWithValue("@currency", currency);
                cmd_ac_data_insert.Parameters.AddWithValue("@month", month);
                cmd_ac_data_insert.Parameters.AddWithValue("@year", year);
                cmd_ac_data_insert.Parameters.AddWithValue("@quarter", quarter);
                cmd_ac_data_insert.Parameters.AddWithValue("@value", value);
                cmd_ac_data_insert.Parameters.AddWithValue("@month_id", Convert.ToInt32(month_id));
                cmd_ac_data_insert.Parameters.AddWithValue("@edit_mode", edit_mode);

                int rowCount = cmd_ac_data_insert.ExecuteNonQuery();
                if (rowCount >= 1)
                {
                    DataObject.HelperClass helper = new DataObject.HelperClass();
                    helper.showAlert(this.Page, "Data saved successfully!");
                }
                else
                {
                    DataObject.HelperClass helper = new DataObject.HelperClass();
                    helper.showAlert(this.Page, "Please check your data for errors!");
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void updateActualData(String currency, String month, String year, String quarter, String value, String edit_mode, String state)
        {
            try
            {
                conn = new DataObject.DbConnection();
                sqlconn = conn.getDatabaseConnection();

                String query = "UPDATE tb_fc_to_usd_actual"
                                + " SET value = @value"
                                + ", edit_mode = @edit_mode"
                                + " WHERE currency = @currency"
                                + " AND month = @month"
                                + " AND year = @year"
                                + " AND quarter = @quarter";

                MySqlCommand cmd_ac_data_update = new MySqlCommand();
                cmd_ac_data_update.Connection = sqlconn;
                cmd_ac_data_update.CommandText = query;
                cmd_ac_data_update.Parameters.AddWithValue("@currency", currency);
                cmd_ac_data_update.Parameters.AddWithValue("@month", month);
                cmd_ac_data_update.Parameters.AddWithValue("@year", year);
                cmd_ac_data_update.Parameters.AddWithValue("@quarter", quarter);
                cmd_ac_data_update.Parameters.AddWithValue("@value", value);
                cmd_ac_data_update.Parameters.AddWithValue("@edit_mode", edit_mode);

                int rowCount = cmd_ac_data_update.ExecuteNonQuery();
                if (rowCount >= 1)
                {
                    DataObject.HelperClass helper = new DataObject.HelperClass();
                    helper.showAlert(this.Page, "Data " + state + " successfully!");
                }
                else
                {
                    DataObject.HelperClass helper = new DataObject.HelperClass();
                    helper.showAlert(this.Page, "Please check your data for errors!");
                }
                conn.closeConn(sqlconn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private String getCurrencyCCRateFromTextBox(String currency)
        {
            String returnValue = "";
            try
            {
                if (currency == "MYR")
                {
                    returnValue = TextBox147.Text;
                } else if (currency == "IDR")
                {
                    returnValue = TextBox148.Text;
                } else if (currency == "LKR")
                {
                    returnValue = TextBox149.Text;
                } else if (currency == "BDT")
                {
                    returnValue = TextBox150.Text;
                } else if (currency == "INR")
                {
                    returnValue = TextBox151.Text;
                } else if (currency == "AUD")
                {
                    returnValue = TextBox181.Text;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return returnValue;
        }

        private void calculateAllAvgForActual() {
            try
            {
                calculateYTDAverage(myr_ytd_tb_list, TextBox82);
                calculateYTDAverage(idr_ytd_tb_list, TextBox83);
                calculateYTDAverage(lkr_ytd_tb_list, TextBox84);
                calculateYTDAverage(bdt_ytd_tb_list, TextBox85);
                calculateYTDAverage(inr_ytd_tb_list, TextBox86);
                calculateYTDAverage(aud_ytd_tb_list, TextBox168);

                calculateQtrAverage(myr_q1_tb_list, TextBox62);
                calculateQtrAverage(idr_q1_tb_list, TextBox63);
                calculateQtrAverage(lkr_q1_tb_list, TextBox64);
                calculateQtrAverage(bdt_q1_tb_list, TextBox65);
                calculateQtrAverage(inr_q1_tb_list, TextBox66);
                calculateQtrAverage(aud_q1_tb_list, TextBox164);

                calculateQtrAverage(myr_q2_tb_list, TextBox67);
                calculateQtrAverage(idr_q2_tb_list, TextBox68);
                calculateQtrAverage(lkr_q2_tb_list, TextBox69);
                calculateQtrAverage(bdt_q2_tb_list, TextBox70);
                calculateQtrAverage(inr_q2_tb_list, TextBox71);
                calculateQtrAverage(aud_q2_tb_list, TextBox165);

                calculateQtrAverage(myr_q3_tb_list, TextBox72);
                calculateQtrAverage(idr_q3_tb_list, TextBox73);
                calculateQtrAverage(lkr_q3_tb_list, TextBox74);
                calculateQtrAverage(bdt_q3_tb_list, TextBox75);
                calculateQtrAverage(inr_q3_tb_list, TextBox76);
                calculateQtrAverage(aud_q3_tb_list, TextBox166);

                calculateQtrAverage(myr_q4_tb_list, TextBox77);
                calculateQtrAverage(idr_q4_tb_list, TextBox78);
                calculateQtrAverage(lkr_q4_tb_list, TextBox79);
                calculateQtrAverage(bdt_q4_tb_list, TextBox80);
                calculateQtrAverage(inr_q4_tb_list, TextBox81);
                calculateQtrAverage(aud_q4_tb_list, TextBox167);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void clearAllCCData() {
            try {
                setCCTextBoxValues(myr_cc_tb_list, "");
                setCCTextBoxValues(idr_cc_tb_list, "");
                setCCTextBoxValues(lkr_cc_tb_list, "");
                setCCTextBoxValues(bdt_cc_tb_list, "");
                setCCTextBoxValues(inr_cc_tb_list, "");
                setCCTextBoxValues(aud_cc_tb_list, "");

                setCCTextBoxValues(myr_acb_tb_list, "");
                setCCTextBoxValues(idr_acb_tb_list, "");
                setCCTextBoxValues(lkr_acb_tb_list, "");
                setCCTextBoxValues(bdt_acb_tb_list, "");
                setCCTextBoxValues(inr_acb_tb_list, "");
                setCCTextBoxValues(aud_acb_tb_list, "");

                TextBox147.Text = "";
                TextBox148.Text = "";
                TextBox149.Text = "";
                TextBox150.Text = "";
                TextBox151.Text = "";
                TextBox181.Text = "";
                TextBox147.Text = "";
                TextBox148.Text = "";
                TextBox149.Text = "";
                TextBox150.Text = "";
                TextBox151.Text = "";
                TextBox181.Text = "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }

        private void clearAllActualData()
        {
            try {
                setCCTextBoxValues(allActualTextBoxes, "");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void enableActualGridForEdit() {
            try {
                Dictionary<TextBox, int> map = Session["ac_edit_mode_list"] as Dictionary<TextBox, int>;

                foreach (var item in map)
                {
                    if (item.Value == 0)
                    {
                        TextBox textbox = item.Key as TextBox;
                        textbox.Enabled = false;
                    }
                    else if (item.Value == 1)
                    {
                        TextBox textbox = item.Key as TextBox;
                        textbox.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void disableAllNonEditFieldsForCC() {
            try
            {
                //actual for budget
                DataObject.HelperClass helper = new DataObject.HelperClass();
                helper.changeTextBoxEditingMode(myr_acb_tb_list, 0);
                helper.changeTextBoxEditingMode(idr_acb_tb_list, 0);
                helper.changeTextBoxEditingMode(lkr_acb_tb_list, 0);
                helper.changeTextBoxEditingMode(bdt_acb_tb_list, 0);
                helper.changeTextBoxEditingMode(inr_acb_tb_list, 0);
                helper.changeTextBoxEditingMode(aud_acb_tb_list, 0);

                helper.changeTextBoxEditingMode(myr_cc_tb_list, 0);
                helper.changeTextBoxEditingMode(idr_cc_tb_list, 0);
                helper.changeTextBoxEditingMode(lkr_cc_tb_list, 0);
                helper.changeTextBoxEditingMode(bdt_cc_tb_list, 0);
                helper.changeTextBoxEditingMode(inr_cc_tb_list, 0);
                helper.changeTextBoxEditingMode(aud_cc_tb_list, 0);
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }
    }   
}