<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BookOrder.View.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JS/jquery.js"></script>
    <script src="../JS/jquery-ui.min.js"></script>
    <link href="../Css/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Css/jquery-ui.theme.css" rel="stylesheet" />

    <script>
        $(function () {
            $(".datepicker").datepicker(
                {
                    dateFormat: 'yy-mm-dd'
                });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group">
        <asp:Label ID="lblName" CssClass="col-form-label" Font-Bold="True" runat="server" Text="商品名稱"></asp:Label>
        <div>
            <asp:TextBox ID="tbxName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <asp:Label ID="lblPrice" CssClass="col-form-label" Font-Bold="True" runat="server" Text="單價"></asp:Label>
        <div>
            <asp:TextBox ID="tbxPrice" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <asp:Label ID="lblAmount" CssClass="col-form-label" Font-Bold="True" runat="server" Text="庫存數量"></asp:Label>
        <div>
            <asp:TextBox ID="tbxAmount" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <div class="form-group">
        <asp:Label ID="lblStatus" CssClass="col-form-label" Font-Bold="True" runat="server" Text="商品狀態"></asp:Label>
        <div>
            <asp:RadioButtonList ID="rblStatus" CssClass="form-control" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="新品">新品</asp:ListItem>
                <asp:ListItem Value="二手">二手</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>

    <div class="form-group">
        <asp:Label ID="lblDate" CssClass="col-form-label" Font-Bold="True" runat="server" Text="購買日期"></asp:Label>
        <div>
            <asp:TextBox ID="tbxDate" runat="server" CssClass="form-control datepicker"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <asp:Label ID="lblPay" CssClass="col-form-label" Font-Bold="True" runat="server" Text="付款方式"></asp:Label>
        <div>
            <asp:RadioButtonList ID="rblPay" CssClass="form-control" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
               
            </asp:RadioButtonList>
        </div>        
    </div>

    <div class="form-group">
        <asp:Label ID="lblTransfer" CssClass="col-form-label" Font-Bold="True" runat="server" Text="運費"></asp:Label>
        <div>
           <asp:TextBox ID="tbxTransfer" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <asp:Label ID="lblDeliver" CssClass="col-form-label" Font-Bold="True" runat="server" Text="出貨方式"></asp:Label>
        <div>
            <asp:RadioButtonList ID="rblDeliver" CssClass="form-control" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              
            </asp:RadioButtonList>
        </div>
    </div>

     <asp:Button ID="btnSubmit" CssClass="btn btn-primary float-right" runat="server" Text="送出" OnClick="btnSubmit_Click" />

</asp:Content>
