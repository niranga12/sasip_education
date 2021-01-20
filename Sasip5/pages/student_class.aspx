<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Site1.Master" AutoEventWireup="true" CodeBehind="student_class.aspx.cs" Inherits="Sasip5.pages.student_class" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content">
        <div class="container-fluid">
            <div class="row">

                 <!--Set hidden Id for check update or delete-->
                        <div class="col-md-6 col-sm-6">
                           
                            <asp:Label CssClass="btn btn-warning" ForeColor="White" ID="hidden_id" Visible="false" runat="server"></asp:Label>
                        </div>
                            
                        <!--End hidden ID-->
            </div>

            <div class="row">
                <div class="col-md-8 col-sm-8">
                    <form method="get" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:Panel ID="panel1" runat="Server">
                            

                                    <div >
                                       
                                   
										<div class="row">
											<div class="col-md-12">
												<div class="card">
													<div class="card-header card-header-primary">
														<h4 class="card-title">Assign Students to Subject</h4>
														<p class="card-category">Complete Student Registrations</p>
													</div>
													<div class="card-body">
														<form method="post">

															<div class="row">
																<div class="col-md-3">
																	<div class="form-group">
																		<label class="bmd-label-floating" style="margin-left: 10px;">ID</label>
																		<asp:TextBox type="text" id="txt_id" class="form-control" runat="server"></asp:TextBox>
																	</div>
																</div>
                                                                <div class="col-md-3">
																	<div class="form-group">
																	<asp:Button type="button" OnClick="btn_search_Click" runat="server" ID="btn_search" class="btn btn-dark" style="height:35px" Text-="Search"></asp:Button>

																	</div>
																</div>
																<div class="col-md-6">
																	<div class="form-group">
																		<label class="bmd-label-floating" style="margin-left: 10px;">Student's Name</label>
																		<asp:TextBox runat="server" ReadOnly="true" type="text" id="txt_SName" class="form-control"></asp:TextBox>
																	</div>
																</div>
															</div>

															<div class="row">
															     <div class="col-md-12">
																	<div class="form-group">
																		 <asp:DropDownList class="form-control" ID="drop_subject" OnSelectedIndexChanged="drop_subject_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                                              <asp:ListItem Value="0">--Choose one--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                     <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator5" ValidationGroup="Vali_save" controltovalidate="drop_subject" CssClass="badge badge-danger" InitialValue="-- choose a Subject--" errormessage="Please Select a Subject..!" /> 

																	</div>
                                                                     </div>
														</div>
                                                            <div class="row">

																<div class="col-md-12">
																	<div class="form-group">
															        <div class="form-group">
																		<label class="bmd-label-floating" style="margin-left: 10px;">Lecture's Name</label>
																		<asp:TextBox type="text" id="txt_LName" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
																	</div>
																	</div>
																</div>
															</div>

                                                             <div class="row">
																<div class="col-md-6">
																	<div class="form-group">
																		<label class="bmd-label-floating" style="margin-left: 10px;">Year</label>
																		<asp:TextBox type="text" id="txt_year" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
																	</div>
																</div>

                                                                <div class="col-md-6">
																	<div class="form-group">
																		<label class="bmd-label-floating" style="margin-left: 10px;">Month</label>
																		<asp:TextBox type="text" id="txt_month" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
																	</div>
																</div>
															</div>

															<div class="row">
																<div class="col-md-6">
																	<div class="form-group">
																		<label class="bmd-label-floating" style="margin-left: 10px">Course Fee</label>
																		<asp:TextBox id="txt_CFee" runat="server" type="text" ReadOnly="true" class="form-control"></asp:TextBox>
																	</div>
																</div>
														
															</div>
															<div class="row">
													
															</div>
															<asp:Button runat="server" class="btn btn-primary pull-right" ID="btn_SAddToClass" OnClick="btn_SAddToClass_Click" ValidationGroup="Vali_save" Text="Assign Students"></asp:Button>

															
                                                        <asp:Button runat="server" id="btn_clear" type="button" OnClick="btn_clear_Click1" class="btn btn-primary" Text="Clear"></asp:Button>

														</form>

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
                                                    <asp:TextBox ID="txt_search" runat="server" Width="186px" class="form-control"  placeholder="Search User"></asp:TextBox></td>
                                                <td>
                                                    <asp:Button ID="btnsearch" runat="server" Text="Search" class="btn btn-info" OnClick="btnsearch_Click" />

                                                </td>
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
                                                            <asp:LinkButton ID="btn_add2" Width="70px" Height="20px" runat="server" class="badge badge-pill badge-danger" CausesValidation="false" OnClientClick="return false;" data-toggle="modal" data-target="#delete">Unassign<span class="glyphicon glyphicon-pencil"></asp:LinkButton>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                    <asp:BoundField DataField="Stu_ID" HeaderText="Student ID" />
                                                    <asp:BoundField DataField="Student" HeaderText="Name" />
                                                    <asp:BoundField DataField="Subject" HeaderText="Subject" />
                                                    <asp:BoundField DataField="Date" HeaderText="Register Date" />

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

                                            <div class="alert alert-danger"><span class="glyphicon glyphicon-warning-sign"></span>Are you sure you want to unassign this student?</div>

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
