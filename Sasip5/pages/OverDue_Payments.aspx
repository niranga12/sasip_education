<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Site1.Master" AutoEventWireup="true" CodeBehind="OverDue_Payments.aspx.cs" Inherits="Sasip5.pages.OverDue_Payments" %>

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
                                        <asp:Label ID="btn_Employee" runat="server" Text="Over Due Student Details" class="btn btn-success" />
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
                                        <div class="col-md-4 col-sm-4">
                                                <asp:TextBox class="form-control" ID="txt_ID"  placeholder="Enter Student ID" runat="server" ></asp:TextBox>
                                            
                                             <asp:Button ID="btn_search_ID" Width="200px" runat="server" Text="Filter By ID" class="btn btn-success" OnClick="btn_search_Click"/>
                                        </div>


                                        <div class="col-md-4 col-sm-4">
                                            <div>
                        
                                                <asp:Button Height="70px" ID="btnReset" Width="200px" runat="server" Text="Clear Filters" class="btn btn-danger" OnClick="btnReset_Click1"/>

                                            </div>
                                        </div>

                                         <div class="col-md-4 col-sm-4">
                                            <div>
                        
                                                <asp:Button Height="70px" ID="btn_overdue" Width="200px" runat="server" Text="Genarate Report" OnClick="btn_overdue_Click" class="btn btn-info" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <br />
                                    </div>
                    <div class="row" >
                                        <div class="col-md-12 col-sm-12">
                                            <div style="overflow-x:auto;">
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
