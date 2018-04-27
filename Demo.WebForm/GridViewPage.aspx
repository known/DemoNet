<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViewPage.aspx.cs" Inherits="Demo.WebForm.GridViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>With XSL</h4>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="XmlDataSource1">
                <Columns>
                    <asp:BoundField HeaderText="TaskId" DataField="TaskId" SortExpression="TaskId" />
                    <asp:BoundField HeaderText="TaskName" DataField="TaskName" SortExpression="TaskName" />
                </Columns>
            </asp:GridView>
            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Data.xml" TransformFile="~/Data.xslt" />
        </div>

        <div>
            <h4>With Attribute</h4>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="XmlDataSource2">
                <Columns>
                    <asp:BoundField HeaderText="TaskId" DataField="taskId" SortExpression="taskId" />
                    <asp:BoundField HeaderText="TaskName" DataField="taskName" SortExpression="taskName" />
                </Columns>
            </asp:GridView>
            <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/Data1.xml" />
        </div>
    </form>
</body>
</html>
