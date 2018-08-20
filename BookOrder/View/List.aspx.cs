using BookOrder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookOrder.View
{
    public partial class Lists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                PageInit();
            }

        }

        private void PageInit()
        {
            ParametersDetail detailPay = new ParametersDetail(6);
            IEnumerable<ParametersDetail> listPay = detailPay.SelectByPid();
            detailPay.KeyName = "全部";
            detailPay.Value = "%";
            List<ParametersDetail> list = new List<ParametersDetail>() { detailPay };
            list.AddRange(listPay);
            ddlPay.DataTextField = "KeyName";
            ddlPay.DataValueField = "Value";
            ddlPay.DataSource = list;
            ddlPay.DataBind();

            ParametersDetail detailDeliver = new ParametersDetail(7);
            IEnumerable<ParametersDetail> listDeliver = detailDeliver.SelectByPid();
            detailDeliver.KeyName = "全部";
            detailDeliver.Value = "%";
            List<ParametersDetail> list2 = new List<ParametersDetail>() { detailDeliver };
            list2.AddRange(listDeliver);
            ddlDeliver.DataTextField = "KeyName";
            ddlDeliver.DataValueField = "Value";
            ddlDeliver.DataSource = list2;
            ddlDeliver.DataBind();

            ParametersDetail detailStatus = new ParametersDetail();
            detailStatus.KeyName = "全部";
            detailStatus.Value = "%";
            ParametersDetail detailStatusNEW = new ParametersDetail();
            detailStatusNEW.KeyName = "全新";
            detailStatusNEW.Value = "全新";
            ParametersDetail detailStatusOLD = new ParametersDetail();
            detailStatusOLD.KeyName = "二手";
            detailStatusOLD.Value = "二手";
            List<ParametersDetail> list3 = new List<ParametersDetail>() { detailStatus };
            list3.Add(detailStatusNEW);
            list3.Add(detailStatusOLD);
            ddlStatus.DataTextField = "KeyName";
            ddlStatus.DataValueField = "Value";
            ddlStatus.DataSource = list3;
            ddlStatus.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<Book> list = new List<Book>();
            foreach (GridViewRow row in gvList.Rows)
            {
                CheckBox chk = row.FindControl("chkItem") as CheckBox;
                if (chk.Checked)
                {
                    LinkButton lkb = row.FindControl("lkbID") as LinkButton;
                    Book book = new Book(int.Parse(lkb.Text));
                    list.Add(book);
                }
            }
            if (list.Count > 0)
            {
                Book book = new Book();
                book.Delete(list);
                Response.Redirect(Page.Request.RawUrl, false);
            }
        }

        protected void AllCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                for (int i = 0; i < gvList.Rows.Count; i++)
                {
                    CheckBox checkBoxRow = (CheckBox)gvList.Rows[i].Cells[0].FindControl("chkItem");
                    checkBoxRow.Checked = true;
                }
            }
            else if (!checkBox.Checked)
            {
                for (int i = 0; i < gvList.Rows.Count; i++)
                {
                    CheckBox checkBoxRow = (CheckBox)gvList.Rows[i].Cells[0].FindControl("chkItem");
                    checkBoxRow.Checked = false;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}