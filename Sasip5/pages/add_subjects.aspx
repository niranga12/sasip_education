<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Site1.Master" AutoEventWireup="true" CodeBehind="add_subjects.aspx.cs" Inherits="Sasip5.pages.add_subjects" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6 col-sm-6">
                    <div class="pull-right">
                        <button class="btn btn-success" data-toggle="modal" data-target="#add_new_record_modal">Add New Subjects</button>
                    </div>

                    <div>

                    </div>
                </div>


                <!--Set hidden Id for check update or delete-->
                <div class="col-md-6 col-sm-6">

                    <asp:Label CssClass="btn btn-warning" ForeColor="White" ID="hidden_id" runat="server"></asp:Label>
                </div>
            </div>
            <!--End hidden ID-->

            <div class="row">
                <div class="col-md-12">
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
                                                            <h4 id="header_add" runat="server" class="card-title">Add New Subject</h4>
                                                            <h4 id="header_update" runat="server" class="card-title">Update Subject</h4>
                                                            <p class="card-category">Complete Course / Subject Details</p>
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
                                                                        <label class="bmd-label-floating" style="margin-left: 10px;">Add New Subject</label>
                                                                        <asp:TextBox type="text" runat="server" ID="txt_name" class="form-control">
                                                                        </asp:TextBox>
                                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="Vali_save" ID="reqName" ControlToValidate="txt_name" CssClass="badge badge-danger" ErrorMessage="Please Enter Subject Name..!" />
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="row">

                                                                 <div class="col-md-12 col-sm-12">
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

                                                              
                                                                </div>

                                                            <div class="row">
                                                              <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">


                                                                        <asp:DropDownList formControlName="type" class="browser-default custom-select" ID="drop_year" runat="server">
                                                                            <asp:ListItem Value="Select Years"></asp:ListItem>
                                                                            <asp:ListItem Value="None">None</asp:ListItem>
                                                                            <asp:ListItem Value="1 Year">1 Year</asp:ListItem>
                                                                            <asp:ListItem Value="2 Year">2 Year</asp:ListItem>
                                                                            <asp:ListItem Value="3 Year">3 Year</asp:ListItem>
                                                                            <asp:ListItem Value="4 Year">4 Year</asp:ListItem>
                                                                            <asp:ListItem Value="5 Year">5 Year</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ValidationGroup="Vali_save" ControlToValidate="drop_year" CssClass="badge badge-danger" InitialValue="Select Years" ErrorMessage="Please Select Years..!" />

                                                                    </div>
                                                                  </div>
                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="form-group">


                                                                        <asp:DropDownList formControlName="type" class="browser-default custom-select" ID="drop_month" runat="server">
                                                                            <asp:ListItem Value="Select Months"></asp:ListItem>
                                                                            <asp:ListItem Value="0">None</asp:ListItem>
                                                                            <asp:ListItem Value="1 Month">1 Month</asp:ListItem>
                                                                            <asp:ListItem Value="2 Month">2 Month</asp:ListItem>
                                                                            <asp:ListItem Value="3 Month">3 Month</asp:ListItem>
                                                                            <asp:ListItem Value="4 Month">4 Month</asp:ListItem>
                                                                            <asp:ListItem Value="5 Month">5 Month</asp:ListItem>
                                                                            <asp:ListItem Value="6 Month">6 Month</asp:ListItem>
                                                                            <asp:ListItem Value="7 Month">7 Month</asp:ListItem>
                                                                            <asp:ListItem Value="8 Month">8 Month</asp:ListItem>
                                                                            <asp:ListItem Value="9 Month">9 Month</asp:ListItem>
                                                                            <asp:ListItem Value="10 Month">10 Month</asp:ListItem>
                                                                            <asp:ListItem Value="11 Month">11 Month</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ValidationGroup="Vali_save" ControlToValidate="drop_month" CssClass="badge badge-danger" InitialValue="Select Months" ErrorMessage="Please Select Months..!" />

                                                                    </div>
                                                                </div>




                                                            </div>
                                                            <div class="row">

                                                                <div class="col-md-5 col-sm-5">
                                                                    <div class="form-group">

                                                                        <asp:DropDownList formControlName="type" class="browser-default custom-select" ID="drop_grade" runat="server">
                                                                            <asp:ListItem Value="Select Grade"></asp:ListItem>
                                                                            <asp:ListItem Value="0">None</asp:ListItem>
                                                                            <asp:ListItem Value="Grade 10">Grade 10</asp:ListItem>
                                                                            <asp:ListItem Value="Grade 11">Grade 11</asp:ListItem>
                                                                            <asp:ListItem Value="Grade 12">Grade 12</asp:ListItem>
                                                                            <asp:ListItem Value="Grade 13">Grade 13</asp:ListItem>
                                                                            <asp:ListItem Value="School Leavers">School Leavers</asp:ListItem>
                                                                            <asp:ListItem Value="Elders">Elders</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ValidationGroup="Vali_save" ControlToValidate="drop_grade" CssClass="badge badge-danger" InitialValue="Select Grade" ErrorMessage="Please Select Grade..!" />

                                                                    </div>
                                                                </div>
                                                                <div class="col-md-7 col-sm-7">
                                                                    <div class="form-group">
                                                                        <label class="bmd-label-floating" style="margin-left: 10px">Course Fee (monthly or Full fee)</label>
                                                                        <asp:TextBox ID="txt_fee" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="Vali_save" ID="RequiredFieldValidator3" ControlToValidate="txt_fee" CssClass="badge badge-danger" ErrorMessage="Please Enter Course / Subject Fee..!" />

                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-12 col-sm-12">
                                                                    <div class="form-group">
                                                                        <label>About Course / Subject</label>
                                                                        <div class="form-group">
                                                                            <label class="bmd-label-floating" style="margin-left: 10px">Course Content and Entry Requirements</label>
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
                                                                    <asp:Button ID="btn_clears" runat="server" OnClick="btn_clears_Click" class="btn btn-primary" Text="Clear"></asp:Button>
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
                        <!-- /Popup Form-button -->
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
                                                    <asp:TextBox ID="txt_search" runat="server" Width="186px" class="form-control" placeholder="Search by Subject" OnTextChanged="btnsearch_Click"></asp:TextBox></td>
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
                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                    <asp:BoundField DataField="Name" HeaderText="Subject Name" />
                                                    <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                                    <asp:BoundField DataField="Year" HeaderText="Years" />
                                                    <asp:BoundField DataField="Month" HeaderText="Months" />
                                                    <asp:BoundField DataField="Grade" HeaderText="Grade" />
                                                    <asp:BoundField DataField="Fee" HeaderText="Fees" />
                                                    <asp:BoundField DataField="About" HeaderText="About" HeaderStyle-Width="300px" />

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
                                                <asp:Label class="modal-title align-content-md-center" ID="txt_del_name" runat="server" CssClass="h4">Please Select a user</asp:Label>
                                            </div>
                                            <div class="modal-body">

                                                <div class="alert alert-danger"><span class="glyphicon glyphicon-warning-sign"></span>Are you sure you want to delete this Record?</div>

                                            </div>
                                            <div class="modal-footer ">
                                                <asp:LinkButton runat="server" ID="btn_delete_yes" OnClick="btn_delete_yes_Click1" class="btn btn-success" Text="Yes"></asp:LinkButton>
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
