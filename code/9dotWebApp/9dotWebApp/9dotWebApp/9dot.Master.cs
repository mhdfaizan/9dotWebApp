using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _9dotWebApp
{
    public partial class _9dot : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string url = Request.Url.AbsoluteUri;
                Debug.WriteLine("TESTING : "+url);
                if (url.ToLower().Contains("forex")) {
                    SetupCurrencyLink.Attributes["class"] = "tabs-btn-enabled";
                    SetupBudgetLink.Attributes["class"] = "tabs-btn-dissabled";
                    ReportDataLink.Attributes["class"] = "tabs-btn-dissabled";
                } else if (url.ToLower().Contains("budget"))
                {
                    SetupCurrencyLink.Attributes["class"] = "tabs-btn-dissabled";
                    SetupBudgetLink.Attributes["class"] = "tabs-btn-enabled";
                    ReportDataLink.Attributes["class"] = "tabs-btn-dissabled";
                } else if (url.ToLower().Contains("pandl"))
                {
                    SetupCurrencyLink.Attributes["class"] = "tabs-btn-dissabled";
                    SetupBudgetLink.Attributes["class"] = "tabs-btn-dissabled";
                    ReportDataLink.Attributes["class"] = "tabs-btn-enabled";
                }
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Forex.aspx");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Budget.aspx");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("PandL.aspx");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}