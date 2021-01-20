<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Site1.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="Sasip5.pages.users" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>

    <script type="text/javascript">
        //Saved Alert
        function successalert() {
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'User has been registered',
                showConfirmButton: false,
                timer: 4500
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2 col-sm-2">
                    <div class="pull-right">
                        <button id="btn_add"  class="btn btn-success" data-toggle="modal" data-target="#add_new_record_modal">Add New Record</button>
                    </div>
                </div>
                 <!--Set hidden Id for check update or delete-->
                        <div class="col-md-6 col-sm-6">
                           
                            <asp:Label CssClass="btn btn-warning" ForeColor="White" ID="hidden_id" runat="server"></asp:Label>
                        </div>
                            
                        <!--End hidden ID-->
            </div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="records_content"></div>
                </div>
            </div>
            <!-- Bootstrap Modal - To Add New Record -->
            <!-- Modal -->
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <form method="get" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:Panel ID="panel1" runat="Server">
                            <div class="modal fade" id="add_new_record_modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                <div class="modal-dialog modal-dialog-scrollable" role="document">

                                    <div class="modal-content">
                                        <div>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true"><i class="material-icons">highlight_off </i></span></button>

                                        </div>
                                        <div class="modal-body">

                                            <div class="row">
                                                <div class="col-md-12 col-sm-12">
                                                    <div class="card">
                                                        <div class="card-header card-header-primary">
                                                            <h4 id="header_add" runat="server" class="card-title">Add Profile</h4>
                                                            <h4 id="header_update" runat="server" class="card-title">Update Profile</h4>
                                                            <p class="card-category">Complete user profile</p>
                                                        </div>
                                                        <div class="card-body">


                                                            <div class="row">
                                                                <div class="col-md-3 col-sm-3">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px;">ID</label>
                                                                        <asp:TextBox type="text" ID="txt_id" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-9 col-sm-9">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px;">Full Name</label>
                                                                        <asp:TextBox type="text"  runat="server" ID="txt_name" class="form-control">
                                                                        </asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="Vali_save" id="reqName" controltovalidate="txt_name" CssClass="badge badge-danger" errormessage="Please enter your Name..!" />                                                                
                                                                        </div>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-md-12 col-sm-12">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px">Address</label>
                                                                        <asp:TextBox type="text" runat="server" ID="txt_address" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="Vali_save" id="RequiredFieldValidator1" controltovalidate="txt_address" CssClass="badge badge-danger" errormessage="Please enter your Address..!" /> 
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-4 col-sm-4">
                                                                    <div class="form-group">


                                                                        <asp:DropDownList formControlName="type" class="browser-default custom-select" ID="drop_etype" runat="server">
                                                                            <asp:ListItem Value="Select Employee Type"></asp:ListItem>
                                                                            <asp:ListItem Value="Receptionist">Receptionist</asp:ListItem>
                                                                            <asp:ListItem Value="Branch Manager">Branch Manager</asp:ListItem>
                                                                            <asp:ListItem Value="Full-Time Lecture">Full-Time Lecture</asp:ListItem>
                                                                            <asp:ListItem Value="Part-Time Lecture">Part-Time Lecture</asp:ListItem>
                                                                        </asp:DropDownList>
                                      <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" ValidationGroup="Vali_save" controltovalidate="drop_etype" CssClass="badge badge-danger" InitialValue="Select Employee Type" errormessage="Please Select Employee Type..!" /> 

                                                                    </div>
                                                                </div>


                                                                <div class="col-md-4 col-sm-4">
                                                                    <div class="form-group">

                                                                        <asp:DropDownList formControlName="type" runat="server" ID="drop_branch" class="browser-default custom-select">
                                                                            <asp:ListItem Value="Select Branch"></asp:ListItem>
                                                                            <asp:ListItem Value="Kurunegala">Kurunegala</asp:ListItem>
                                                                            <asp:ListItem Value="Nugegoda">Nugegoda</asp:ListItem>
                                                                            <asp:ListItem Value="Galle">Galle</asp:ListItem>
                                                                            <asp:ListItem Value="Gampaha">Gampaha</asp:ListItem>
                                                                            <asp:ListItem Value="Anuradhapura">Anuradhapura</asp:ListItem>
                                                                        </asp:DropDownList>
                                      <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator5" ValidationGroup="Vali_save" controltovalidate="drop_branch" CssClass="badge badge-danger" InitialValue="Select Branch" errormessage="Please Select Your Branch..!" /> 

                                                                    </div>
                                                                </div>

                                                                <div class="col-md-4 col-sm-4">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px">Mobile</label>
                                                                        <asp:TextBox ID="txt_mobile" type="number" class="form-control" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px">User Name</label>
                                                                        <asp:TextBox ID="txt_uname" type="text" class="form-control" runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="Vali_save" id="RequiredFieldValidator2" controltovalidate="txt_uname" CssClass="badge badge-danger" errormessage="Please enter your User Name..!" /> 

                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px">Password</label>
                                                                        <asp:TextBox ID="txt_pass" runat="server" type="password" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="Vali_save" id="RequiredFieldValidator3" controltovalidate="txt_pass" CssClass="badge badge-danger" errormessage="Please enter your Password..!" /> 

                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-12 col-sm-12">
                                                                    <div class="form-group">
                                                                        <label>About User</label>
                                                                        <div class="form-group">
                                                                            <label class="bmd-label-floating" style="margin-left: 10px">Educational Qualification, Work Experiance and etc</label>
                                                                            <asp:TextBox ID="txt_about" TextMode="MultiLine" class="form-control" Rows="5" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-9 col-sm-9">
                                                                    <asp:LinkButton class="btn btn-primary pull-right" ValidationGroup="Vali_save" runat="server" ID="btn_re_new" Text="Register" OnClick="btn_re_click">

                                                                    </asp:LinkButton>
                                                                    <asp:LinkButton class="btn btn-primary pull-right" ValidationGroup="Vali_save" runat="server" ID="btn_update" Text="Update" OnClick="btn_update_Click"></asp:LinkButton>
                                                                    <asp:Button ID="btn_clears" runat="server" OnClick="btn_clear_click" class="btn btn-primary" Text="Clear"></asp:Button>
                                                                    <button type="button" data-dismiss="modal" runat="server" id="btn_exit" class="btn btn-primary">Exit</button>

                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <!-- /Popup Form-End -->

                       
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
                                                    <asp:TextBox ID="txt_search" runat="server" Width="186px" class="form-control" placeholder="Search User" OnTextChanged="btnsearch_Click"></asp:TextBox></td>
                                                <td>
                                                    <asp:Button ID="btnsearch" runat="server" Text="Search" class="btn btn-info" OnClick="btnsearch_Click" /></td>
                                                <td>
                                                    <asp:Button ID="btnReset" runat="server" Text="X" class="btn btn-warning" OnClick="btnReset_Click1" /></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="row">
                                        <br />
                                    </div>
                                    <div class="row" style="width: 1025px;">
                                        <div class="col-md-12 col-sm-12">

                                            <asp:GridView ID="dgvItems" runat="server" CssClass="table table-hover table-striped table-responsive" GridLines="None" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnClientClick="return false;" Width="1050px" OnSelectedIndexChanged="dgvItems_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btn_add2" Width="70px" Height="20px" runat="server" class="badge badge-pill badge-primary" CausesValidation="false" OnClientClick="return false;" data-toggle="modal" data-target="#add_new_record_modal">Update<span class="glyphicon glyphicon-pencil"></asp:LinkButton>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btn_add3" Width="70px" Height="20px" runat="server" class="badge badge-pill badge-danger" CausesValidation="false" OnClientClick="return false;" data-toggle="modal" data-target="#delete"><span class="glyphicon glyphicon-trash">DELETE</span></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="E_id" HeaderText="ID" />
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="Address" HeaderText="Address" />
                                                    <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                                    <asp:BoundField DataField="E_type" HeaderText="Em.Type" />
                                                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                                    <asp:BoundField DataField="User_name" HeaderText="User_name" />
                                                    <asp:BoundField DataField="Password" HeaderText="Password" />
                                                    <asp:BoundField DataField="About" HeaderText="About" />
                                                    <asp:BoundField DataField="Date" HeaderText="Reg.Date" />

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

                            <asp:Panel ID="Panel2" runat="server" BackColor="#9c27b0" BorderColor="#336699">
                            <!-- Delete button Validation -->
                            <div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
                                            <asp:Label class="modal-title align-content-md-center" id="txt_del_name" runat="server" CssClass="h4">Please Select a user</asp:Label>
                                        </div>
                                        <div class="modal-body">

                                            <div class="alert alert-danger"><span class="glyphicon glyphicon-warning-sign"></span>Are you sure you want to delete this Record?</div>

                                        </div>
                                        <div class="modal-footer ">
                                            <asp:LinkButton runat="server" ID="btn_delete_yes"  OnClick="btn_delete_yes_Click1" class="btn btn-success" Text="Yes"></asp:LinkButton>
                                            <asp:LinkButton runat="server" type="button" class="btn btn-default" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>No</asp:LinkButton>
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                                </asp:Panel>
                        </div>


                    </form>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

