<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Site1.Master" AutoEventWireup="true" CodeBehind="lecturer_class.aspx.cs" Inherits="Sasip5.pages.lecturer_class" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
         

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content">
				<div class="container-fluid">
					<div class="row">
                            <!--Set hidden Id for check update or delete-->
                <div class="col-md-6 col-sm-6">

                    <asp:Label CssClass="btn btn-warning" ForeColor="White" ID="hidden_id" runat="server"></asp:Label>
                </div>

                <!--End hidden ID-->

						</ div>
						<div class="row">
							<div class="col-md-12">
								<div class="records_content"></div>
							</div>
						</div>

                     <form method="get" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:Panel ID="panel1" runat="Server">

										<div class="row">
											<div class="col-md-12">
												<div class="card">
													<div class="card-header card-header-primary">
														<h4  id="header_add" runat="server" class="card-title">Assign Subjects to Lecturers</h4>
														<p class="card-category">Subjects</p>
													</div>
													<div class="card-body">
													

															<div class="row">
																<div class="col-md-3">
																	<div class="form-group">
																		<label class="bmd-label-floating" style="margin-left: 10px;">ID</label>
																		<asp:TextBox runat="server" type="text" id="txt_id" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ValidationGroup="Vali_save" runat="server" id="RequiredFieldValidator4" controltovalidate="txt_id" CssClass="badge badge-danger" errormessage="Please Search a Lecturer first..!" /> 

																	</div>
																</div>
                                                                <div class="col-md-3">
																	<div class="form-group">
																		<asp:Button type="button"  OnClick="btn_search_Click" runat="server" ID="btn_search" class="btn btn-dark" style="height:35px;" Text-="Search"></asp:Button>

																	</div>
																</div>
																<div class="col-md-6">
																	<div class="form-group">
																		<label class="bmd-label-floating" style="margin-left: 10px;">Lecturer's Name</label>
																		<asp:TextBox type="text" id="txt_lname" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
																	</div>
																</div>
															</div>

															<div class="row">
																<div class="col-md-6">
																	<div class="form-group">
																		 <asp:DropDownList class="form-control" ID="drop_subject" OnSelectedIndexChanged="drop_subject_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                                              <asp:ListItem Value="0">--Choose one--</asp:ListItem>
                                                                            </asp:DropDownList>
                                      <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator5" ValidationGroup="Vali_save" controltovalidate="drop_subject" CssClass="badge badge-danger" InitialValue="-- choose a Subject--" errormessage="Please Select a Subject..!" /> 

																	</div>
																</div>
														

																<div class="col-md-6">
																	<div class="form-group">
															<div class="form-group">
																		<asp:Button runat="server" class="btn btn-dark form-control" ID="btn_AddNewSub" OnClick="btn_AddNewSub_Click" Text="Add New Subject"></asp:Button>
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
																		<asp:TextBox id="txt_c_fee" type="text" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
																	</div>
																</div>
															</div>
															<asp:Button runat="server" class="btn btn-primary pull-right" ID="btn_LAddToClass" OnClick="btn_LAddToClass_Click" ValidationGroup="Vali_save" Text="Assign Lecturer"></asp:Button>

															
                                                        <asp:Button runat="server" id="btn_clear" type="button" OnClick="btn_clear_Click1" class="btn btn-primary" Text="Clear"></asp:Button>

													

													</div>
												</div>
											</div>
										</div>

                        </asp:Panel>
						<!-- /Popup Form-button -->

                    
                <!-- Data table -->
                <div class="row" style="margin-top: 20px;">
                    <asp:Panel ID="DGVpanal" runat="server" BackColor="#9c27b0" BorderColor="#336699">

                        <div class="col-md-12" style="margin: auto;">
                            <div class="row">
                                <br />
                            </div>
                            <div class="row">
                                <table style="width: 200px; margin-left: 20px;">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txt_search" runat="server" Width="186px" class="form-control" placeholder="Search User" ></asp:TextBox></td>
                                        <td>
                                            <asp:Button ID="btnsearch"  runat="server" OnClick="btnsearch_Click" Text="Search" class="btn btn-info" /></td>
                                        <td>
                                            <asp:Button ID="btnReset"  runat="server" Text="X" OnClick="btnReset_Click1" class="btn btn-warning" /></td>
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
                                                            <asp:LinkButton ID="btn_add2" Width="70px" Height="20px" runat="server" class="badge badge-pill badge-primary" CausesValidation="false" OnClientClick="return false;" data-toggle="modal" data-target="#add_new_record_modal">Assign<span class="glyphicon glyphicon-pencil"></asp:LinkButton>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btn_add3" Width="70px" Height="20px" runat="server" class="badge badge-pill badge-danger" CausesValidation="false" OnClientClick="return false;" data-toggle="modal" data-target="#delete"><span class="glyphicon glyphicon-trash">Unassign</span></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                                    <asp:BoundField DataField="L_ID" HeaderText="Lecturer ID" />
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="Sub" HeaderText="Subject" />
                                                    <asp:BoundField DataField="Year" HeaderText="Year" />
                                                    <asp:BoundField DataField="Month" HeaderText="Month" />
                                                    <asp:BoundField DataField="Fee" HeaderText="Fee" />

                                                </Columns>
                                                <RowStyle CssClass="cursor-pointer" />
                                            </asp:GridView>
                                            <ajaxToolkit:RoundedCornersExtender ID="dgvItems_RoundedCornersExtender" runat="server" BehaviorID="dgvItems_RoundedCornersExtender" Color="WhiteSmoke" TargetControlID="dgvItems">
                                            </ajaxToolkit:RoundedCornersExtender>

                                        </div>
                                    </div>
                        </div>


                        <div class="row">
                            <br />
                        </div>

                    </asp:Panel>

                    <!-- Delete button Validation -->
                    <div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
                                    <asp:Label class="modal-title align-content-md-center" id="txt_del_name" runat="server" CssClass="h4">Please Select a user</asp:Label>

                                </div>
                                <div class="modal-body">

                                    <div class="alert alert-danger"><span class="glyphicon glyphicon-warning-sign"></span>Are you sure you want to Unassign this Lecturer?</div>

                                </div>
                                <div class="modal-footer ">
                                    <asp:LinkButton runat="server" ID="btn_delete_yes"  OnClick="btn_delete_yes_Click" type="button" class="btn btn-success"><span class="glyphicon glyphicon-ok-sign"></span>Yes</asp:LinkButton>
                                    <asp:LinkButton runat="server" type="button" class="btn btn-default" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>No</asp:LinkButton>
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                </div>
     
					
                         </form>
                         </div>
				</div>
</asp:Content>
