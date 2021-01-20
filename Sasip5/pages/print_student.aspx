<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Site1.Master" AutoEventWireup="true" CodeBehind="print_student.aspx.cs" Inherits="Sasip5.pages.print_student" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../assets/crystalreportviewers13/js/crviewer/crv.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="content">
        <div class="container-fluid">
            <div class="row">

                 <form id="Form1" runat="server">

            <div id="dvReport"  >
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ToolPanelView="None" style="overflow-y:scroll;overflow-y:scroll;width: 1000px; height: 700px;"/>
            </div>
                 
        </form>
              </div>
        </div>
    </div>
</asp:Content>
