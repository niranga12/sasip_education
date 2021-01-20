<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Site1.Master" AutoEventWireup="true" CodeBehind="profit_reports.aspx.cs" Inherits="Sasip5.pages.profit_reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2 col-sm-2">
                </div>

            </div>

            <!-- Bootstrap Modal - To Add New Record -->
            <!-- Modal -->
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <form method="get" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                                     <div class="row">
                                         <div class="col-md-3 col-sm-3">
                                        <asp:Label ID="btn_Employee" runat="server" Text="Course Summery" class="btn btn-info" />
                                             </div>
                                    </div>
                        <!-- Data table -->
                        <div class="row" style="margin-top: 20px;">
                         
                            <asp:Panel ID="DGVpanal" runat="server" BackColor="#9c27b0" BorderColor="#336699">

                                <div class="col-md-12 col-sm-12" style="margin: auto;">
                                   

                                    <div class="row">
                                        <br />
                                    </div>
                                    <div class="row">

                                                                <div class="col-md-3 col-sm-4">
                                                                    <div class="form-group">
                                                                          <asp:DropDownList formControlName="type" class="browser-default custom-select" ID="drop_month" runat="server">
                                                                            <asp:ListItem Value="">Select Month</asp:ListItem>
                                                                            <asp:ListItem Value="1">January</asp:ListItem>
                                                                            <asp:ListItem Value="2">February</asp:ListItem>
                                                                            <asp:ListItem Value="3">March</asp:ListItem>
                                                                            <asp:ListItem Value="4">April</asp:ListItem>
                                                                              <asp:ListItem Value="5">May</asp:ListItem>
                                                                            <asp:ListItem Value="6">June</asp:ListItem>
                                                                            <asp:ListItem Value="7">July</asp:ListItem>
                                                                                 <asp:ListItem Value="8">August</asp:ListItem>
                                                                            <asp:ListItem Value="9">September</asp:ListItem>
                                                                            <asp:ListItem Value="10">October</asp:ListItem>
                                                                              <asp:ListItem Value="11">November</asp:ListItem>
                                                                            <asp:ListItem Value="12">December</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>

                                              <asp:Button ID="btn_filterMonth" Width="200px" runat="server" Text="Filter By Month" class="btn btn-success" OnClick="btn_filterMonth_Click" />

                                                                </div>

                                        <div class="col-md-2 col-sm-2">
                                            <div>

                                                <asp:Button Height="70px" ID="btnReset" Width="150px" runat="server" Text="Clear Filters" class="btn btn-danger" OnClick="btn_clears_Click" />
                                            </div>
                                        </div>

                                        <div class="col-md-2 col-sm-2">
                                            <div>

                                                <asp:Button Height="70px" ID="btn_report" Width="200px" runat="server" Text="Genarate Report" OnClick="btn_report_Click" class="btn btn-info" />
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <br />
                                    </div>
                    <div class="row" >
                                        <div class="col-md-12 col-sm-12">
                                            <div style="width:1200px;">
                                            <asp:GridView ID="dgvItems" runat="server" CssClass="table table-hover table-striped table-responsive" GridLines="None" Width="1050px">
                 
                                                <RowStyle CssClass="cursor-pointer" />
                                            </asp:GridView>
                                             <ajaxToolkit:RoundedCornersExtender ID="dgvItems_RoundedCornersExtender" runat="server" BehaviorID="dgvItems_RoundedCornersExtender" Color="WhiteSmoke" TargetControlID="dgvItems">
                                            </ajaxToolkit:RoundedCornersExtender>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-md-12 col-sm-12">
                                    <br />
                                </div>

                            </asp:Panel>

                        </div>


                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
