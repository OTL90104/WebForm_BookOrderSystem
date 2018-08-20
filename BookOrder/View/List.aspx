<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BookOrder.View.Lists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="form-group row">
        <asp:Label ID="lblPay" CssClass="col-lg-3 col-form-label" Font-Bold="True" runat="server" Text="付款方式"></asp:Label>
        <asp:Label ID="lblDeliver" CssClass="col-lg-3 col-form-label" Font-Bold="True" runat="server" Text="出貨方式"></asp:Label>
        <asp:Label ID="lblStatus" CssClass="col-lg-3 col-form-label" Font-Bold="True" runat="server" Text="商品狀態"></asp:Label>
    </div>

    <div class="form-group row">
        <asp:DropDownList ID="ddlPay" CssClass="col-lg-3" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="ddlDeliver" CssClass="col-lg-3" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="ddlStatus" CssClass="col-lg-3" runat="server"></asp:DropDownList>
        <asp:Button ID="btnSearch" CssClass="col-lg-3" runat="server" Text="查詢" OnClick="btnSearch_Click" />
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testdbConnectionString %>" 
        SelectCommand="SELECT [ID]
                         ,[Name]
                         ,[Price]
                         ,[Amount]
                         ,[Status]
                         ,[Date]
                         ,p1.KeyName AS Pay
                         ,[Transfer]
                         ,p2.KeyName AS Deliver
                     FROM [Book] AS b
                     LEFT JOIN ParametersDetail AS p1
                     ON b.Pay = p1.Value AND p1.PID = 6

                     LEFT JOIN ParametersDetail AS p2
                     ON b.Deliver = p2.Value AND p2.PID = 7
                           WHERE (([Deliver] LIKE @Deliver ) 
                           AND ([Pay] LIKE @Pay) 
                           AND ([Status] LIKE @Status))">
        
                
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlDeliver" Name="Deliver" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="ddlPay" Name="Pay" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="ddlStatus" Name="Status" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:GridView ID="gvList" CssClass="table table-striped table-bordered word-break:break-all word-wrap:normal" runat="server" AllowSorting="True"
        AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" AllowPaging="True">
        <Columns>

             <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox runat="server" OnCheckedChanged="AllCheck_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                </HeaderTemplate>

                <ItemTemplate>
                    <asp:CheckBox ID="chkItem" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Name" SortExpression="ID">
                <ItemTemplate>
                    <asp:LinkButton ID="lkbID" runat="server" Text='<%#Eval("Name") %>'
                        PostBackUrl='<%# String.Concat("~/View/Index.aspx?ID=" +Eval("ID")) %>'>ID</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <%--<asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" />--%>
            <%--<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />--%>
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            <asp:BoundField DataField="Pay" HeaderText="Pay" SortExpression="Pay" />
            <asp:BoundField DataField="Transfer" HeaderText="Transfer" SortExpression="Transfer" />            
            <asp:BoundField DataField="Deliver" HeaderText="Deliver" SortExpression="Deliver" />
            
        </Columns>

        <EmptyDataTemplate>
            沒有資料喔~
        </EmptyDataTemplate>

    </asp:GridView>
    <br />
    <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="刪除" OnClick="btnDelete_Click" />

</asp:Content>
