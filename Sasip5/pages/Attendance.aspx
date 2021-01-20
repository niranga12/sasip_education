<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Site1.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="Sasip5.pages.classes.Attendance" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">

         <div class="col-md-12 col-sm-12">
                    <form method="get" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                      <div class="row">
                                                <div class="col-md-8 col-sm-8">
                                                    <div class="card">
                                                        <div class="card-header card-header-primary">
                                                            <h4 id="header_add" runat="server" class="card-title">Attendance Mark</h4>
                                                            <p class="card-category">Mark your attendance</p>
                                                        </div>
                                                        <div class="card-body">


                                                            <div class="row">
                                                                <div class="col-md-3 col-sm-3">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating">ID</label>
                                                                        <asp:TextBox type="text" ID="txt_id" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                    <div class="col-md-3 col-sm-3">
                                                                    <div class="form-group">
                                                                        <asp:Button Text="Search" runat="server" ID="btn_search" class="form-control" OnClick="btn_search_Click" CssClass="btn btn-primary"/>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" >Name</label>
                                                                        <asp:TextBox type="text" ReadOnly="true" runat="server" ID="txt_name" class="form-control">
                                                                        </asp:TextBox>
                                                                        </div>
                                                                </div>
                                                            </div>


                                                            <div class="row">
                                                                <div class="col-md-9 col-sm-9">
                                                                    <asp:LinkButton class="btn btn-primary pull-right" ValidationGroup="Vali_save" runat="server" ID="btn_in" Text="IN" OnClick="btn_in_click" >

                                                                    </asp:LinkButton>
                                                                    <asp:Button ID="btn_clear" runat="server" class="btn btn-primary" Text="Clear" OnClick="btn_clears_Click"></asp:Button>

                                                                </div>
                                                            </div>

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
                                        <table style="width: 200px; margin-left: 20px;">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txt_grid_id" runat="server" Width="186px" class="form-control"  placeholder="Search ID"></asp:TextBox></td>
                                                <td>
                                                    <asp:Button ID="btnsearch" runat="server" Text="Search" class="btn btn-info" OnClick="btnsearch_Click" />

                                                </td>
                                                <td>
                                                    <asp:Button ID="btnReset" runat="server" Text="X" class="btn btn-warning" OnClick="btn_grid_reset_Click" /></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="row">
                                        <br />
                                    </div>
                                    <div class="row" style="width: 1025px;">
                                        <div class="col-md-12 col-sm-12">

                                            <asp:GridView ID="dgvItems" runat="server" CssClass="table table-hover table-striped table-responsive" GridLines="None" AutoGenerateColumns="False" AutoGenerateSelectButton="false" OnClientClick="return false;" Width="1050px" >
                                                <Columns>


                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                    <asp:BoundField DataField="SID" HeaderText="Student ID" />
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                                    <asp:BoundField DataField="Date" HeaderText="Date" />

                                                </Columns>
                                                <RowStyle CssClass="cursor-pointer" />
                                            </asp:GridView>
                                            <ajaxToolkit:RoundedCornersExtender ID="dgvItems_RoundedCornersExtender" runat="server" BehaviorID="dgvItems_RoundedCornersExtender" Color="WhiteSmoke" TargetControlID="dgvItems">
                                            </ajaxToolkit:RoundedCornersExtender>

                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-12 col-sm-12">
                                    <br />
                                </div>

                            </asp:Panel>
                             
                        </div>
                                                </div>
                                            </div>
                     </form>
         </div>
</div>

</asp:Content>
