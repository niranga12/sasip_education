<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Site1.Master" AutoEventWireup="true" CodeBehind="Employee_pay.aspx.cs" Inherits="Sasip5.pages.Employee_pay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">

         <div class="col-md-12 col-sm-12">
                    <form method="get" runat="server">
                      <div class="row">
                                                <div class="col-md-8 col-sm-8">
                                                    <div class="card">
                                                        <div class="card-header card-header-primary">
                                                            <h4 id="header_add" runat="server" class="card-title">Employee Payment Form</h4>
                                                            <p class="card-category">Complete payment and Print Bill</p>
                                                        </div>
                                                        <div class="card-body">


                                                            <div class="row">
                                                                <div class="col-md-3 col-sm-3">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px;">ID</label>
                                                                        <asp:TextBox type="text" ID="txt_id" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                    <div class="col-md-3 col-sm-3">
                                                                    <div class="form-group">
                                                                        <asp:Button Text="Search" runat="server" ID="btn_search" OnClick="btn_search_Click" CssClass="btn btn-primary"/>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px;">Name</label>
                                                                        <asp:TextBox type="text" ReadOnly="true" runat="server" ID="txt_name" class="form-control">
                                                                        </asp:TextBox>
                                                                        </div>
                                                                </div>
                                                            </div>

                                                            <div class="row">
               <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px;">Branch</label>
                                                                        <asp:TextBox type="text" ReadOnly="true" runat="server" ID="txt_branch" class="form-control">
                                                                        </asp:TextBox>
                                                                        </div>
                                                                </div>

                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px">Designation</label>
                                                                        <asp:TextBox ID="txt_EType" type="text" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <div class="col-md-6 col-sm-6">
                                                                   <div class="form-group">
																		 <asp:DropDownList class="form-control" ID="drop_year" runat="server">
                                                                              <asp:ListItem Value="0">--Choose one--</asp:ListItem>
                                                                            </asp:DropDownList>

																	</div>
                                                                </div>

                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">
                                                                          <asp:DropDownList formControlName="type" class="browser-default custom-select" ID="drop_month" runat="server">
                                                                            <asp:ListItem Value="Select Month"></asp:ListItem>
                                                                            <asp:ListItem Value="January">January</asp:ListItem>
                                                                            <asp:ListItem Value="February">February</asp:ListItem>
                                                                            <asp:ListItem Value="March">March</asp:ListItem>
                                                                            <asp:ListItem Value="April">April</asp:ListItem>
                                                                              <asp:ListItem Value="May">May</asp:ListItem>
                                                                            <asp:ListItem Value="June">June</asp:ListItem>
                                                                            <asp:ListItem Value="July">July</asp:ListItem>
                                                                                 <asp:ListItem Value="August">August</asp:ListItem>
                                                                            <asp:ListItem Value="September">September</asp:ListItem>
                                                                            <asp:ListItem Value="October">October</asp:ListItem>
                                                                              <asp:ListItem Value="November">November</asp:ListItem>
                                                                            <asp:ListItem Value="December">December</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                                    <div class="row">
                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px">Payment</label>
                                                                        <asp:TextBox ID="txt_pay" type="text" class="form-control" runat="server"></asp:TextBox>

                                                                    </div>
                                                                </div>

                                                            </div>

                                                            

                                                            <div class="row">
                                                                <div class="col-md-9 col-sm-9">
                                                                    <asp:LinkButton class="btn btn-primary pull-right" ValidationGroup="Vali_save" runat="server" ID="btn_Pay" Text="Pay" OnClick="btn_Pay_Click" >

                                                                    </asp:LinkButton>
                                                                    <asp:LinkButton class="btn btn-primary pull-right" ValidationGroup="Vali_save" runat="server" ID="btn_PayPrint" Text="Pay & Print" OnClick="btn_PayPrint_Click" ></asp:LinkButton>
                                                                    <asp:Button ID="btn_clears" runat="server" OnClick="btn_clears_Click" class="btn btn-primary" Text="Clear"></asp:Button>

                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                     </form>
         </div>
</div>

</asp:Content>
