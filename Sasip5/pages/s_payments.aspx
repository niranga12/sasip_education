<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Site1.Master" AutoEventWireup="true" CodeBehind="s_payments.aspx.cs" Inherits="Sasip5.pages.classes.s_payments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>
    <script type="text/javascript">

      
        function erroralert() {
            Swal.fire({
                icon: 'question',
                title: 'NOT FOUND.!',
                text: 'Student Not Found.!',
              
            })
        }
    </script>


    <div class="content">
      
         <div class="col-md-12 col-sm-12">
             <form method="get" runat="server">

                 <div class="row">
                                                <div class="col-md-8 col-sm-8">
                                                    <div class="card">
                                                        <div class="card-header card-header-primary">
                                                            <h4 id="header_add" runat="server" class="card-title">Payment Form</h4>
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
                                                                                        <asp:Button Text="Search" runat="server" ID="btn_search" OnClick="btn_search_Click" CssClass="btn btn-primary" />
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
                                                                        <asp:DropDownList class="form-control" OnSelectedIndexChanged="drop_subject_SelectedIndexChanged" ID="drop_subject" AutoPostBack="true" runat="server">
                                                                              <asp:ListItem Value="0">--Choose one--</asp:ListItem>
                                                                            </asp:DropDownList>

                                                                    </div>
                                                                </div>

                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px">Course Fee</label>
                                                                        <asp:TextBox ID="txt_fee" ReadOnly="true" type="number" class="form-control" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px">Year</label>
                                                                        <asp:TextBox ID="txt_year" type="text" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px">Month</label>
                                                                        <asp:TextBox ID="txt_month" runat="server" type="text" ReadOnly="true" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                                    <div class="row">
                                                                <div class="col-md-3 col-sm-3">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px">Pay</label>
                                                                        <asp:TextBox ID="txt_pay" type="text" class="form-control" runat="server"></asp:TextBox>

                                                                    </div>
                                                                </div>

                                                                 <div class="col-md-3 col-sm-3">
                                                                    <div class="form-group">
                                                                        <asp:Button ID="btn_add" runat="server" class="btn btn-primary" OnClick="btn_add_Click" Text="Add To Bill"></asp:Button>

                                                                    </div>
                                                                </div>

                                                                <div class="col-md-3 col-sm-3">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px">OverDue</label>
                                                                        <asp:TextBox ID="txt_overdue" runat="server" type="text"  ReadOnly="true"  class="form-control">0.00</asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-md-12 col-sm-12">
                                                                    <div class="form-group">
                                                                        <asp:label runat="server" ID="lbl_status" class="btn btn-info" Width="100%" Font-Bold="true">Make A payment</asp:label>

                                                                    </div>
                                                                </div>
                                                        
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-md-9 col-sm-9">
                                                                    <asp:LinkButton class="btn btn-primary pull-right" ValidationGroup="Vali_save" runat="server" ID="btn_Pay" Text="Pay" OnClick="btn_Pay_Click" >

                                                                    </asp:LinkButton>
                                                                    <asp:LinkButton class="btn btn-primary pull-right" ValidationGroup="Vali_save" runat="server" ID="btn_PayPrint" Text="Pay & Print" OnClick="btn_PayPrint_Click" ></asp:LinkButton>
                                                                    <asp:Button ID="btn_clears" runat="server" class="btn btn-primary" Text="Clear" OnClick="btn_clears_Click"></asp:Button>

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
