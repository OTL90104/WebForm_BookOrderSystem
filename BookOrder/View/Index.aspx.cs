using BookOrder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookOrder.View
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
                UpdateBind();
            }
        }

        private void PageInit()
        {
            ParametersDetail detailPay = new ParametersDetail(6);
            IEnumerable<ParametersDetail> listPay = detailPay.SelectByPid();
            rblPay.DataTextField = "KeyName";
            rblPay.DataValueField = "Value";
            rblPay.DataSource = listPay;
            rblPay.DataBind();

            ParametersDetail detailDeliver = new ParametersDetail(7);
            IEnumerable<ParametersDetail> listDeliver = detailDeliver.SelectByPid();
            rblDeliver.DataTextField = "KeyName";
            rblDeliver.DataValueField = "Value";
            rblDeliver.DataSource = listDeliver;
            rblDeliver.DataBind();
        }

        private void UpdateBind()
        {
            if (Page.Request.QueryString["ID"] != null)
            {

                string QueryID = Page.Request.QueryString["ID"].ToString();
                if (int.TryParse(QueryID, out int ID))
                {
                    Book book = new Book(ID);
                    book = book.SelectById();
                    if (book != null)
                    {
                        tbxName.Text = book.Name;
                        tbxPrice.Text = book.Price;
                        tbxAmount.Text = book.Amount;
                        rblStatus.SelectedValue = book.Status;
                        tbxDate.Text = book.Date.ToString("yyyy-MM-dd");
                        rblPay.SelectedValue = book.Pay;
                        tbxTransfer.Text = book.Transfer;
                        rblDeliver.SelectedValue = book.Deliver;
                        btnSubmit.CommandName = "Update";
                        btnSubmit.CommandArgument = book.ID.ToString();
                        btnSubmit.Text = "更新";
                    }
                }
            }
        }

            protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            var command = btn.CommandName;
            if (command != "Update")
            {
                Book book = new Book();
                book.Name = tbxName.Text;
                book.Price = tbxPrice.Text;
                book.Amount = tbxAmount.Text;
                book.Status = rblStatus.SelectedValue;
                book.Date = DateTime.Parse(tbxDate.Text);
                book.Pay = rblPay.SelectedValue;
                book.Transfer = tbxTransfer.Text;
                book.Deliver = rblDeliver.SelectedValue;

                int count = book.Insert();
                if (count > 0)
                {
                    Response.Redirect("List.aspx");
                }
            }
            else
            {
                Book book = new Book(int.Parse(btn.CommandArgument));
                book.Name = tbxName.Text;
                book.Price = tbxPrice.Text;
                book.Amount = tbxAmount.Text;
                book.Status = rblStatus.SelectedValue;
                book.Date = DateTime.Parse(tbxDate.Text);
                book.Pay = rblPay.SelectedValue;
                book.Transfer = tbxTransfer.Text;
                book.Deliver = rblDeliver.SelectedValue;
                int count = book.Update();
                if (count > 0)
                {
                    Response.Redirect("List.aspx");
                }
            }
        }
    }
}