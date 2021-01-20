<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Site1.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Sasip5.pages.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-4 col-sm-4">
              <div class="card card-stats">
                <div class="card-header card-header-warning card-header-icon">
                  <div class="card-icon">
                    <i class="material-icons">school</i>
                  </div>
                  <p class="card-category">Students</p>
                  <h3 id="lbl_student" runat="server" class="card-title">Not Load
                    <small></small>
                  </h3>
                </div>
                <div class="card-footer">
                  <div class="stats">
                    <i class="material-icons">person_add_alt_1 </i> Already Registered
                  </div>
                </div>
              </div>
            </div>
            <div class="col-md-4 col-sm-4">
              <div class="card card-stats">
                <div class="card-header card-header-success card-header-icon">
                  <div class="card-icon">
                    <i class="material-icons">person_add_alt_1</i>
                  </div>
                  <p class="card-category">Employees</p>
                 <h3 class="card-title" runat="server" id="lbl_employee">Not Load</h3>
              
                    </div>
                <div class="card-footer">
                  <div class="stats">
                    <i class="material-icons">person_add_alt_1</i> Already Working
                  </div>
                </div>
              </div>
            </div>

                <div class="col-md-4 col-sm-4">
              <div class="card card-stats">
                <div class="card-header card-header-success card-header-icon">
                  <div class="card-icon">
                    <i class="material-icons">cast_for_education</i>
                  </div>
                  <p class="card-category">Total Classess / Courses</p>
                  <h3 class="card-title" runat="server" id="lbl_courses">Not Load</h3>
                </div>
                <div class="card-footer">
                  <div class="stats">
                    <i class="material-icons">person_add_alt_1</i> Already Working
                  </div>
                </div>
              </div>
            </div>

              </div>
            <div class="row">
            <div class="col-md-4 col-sm-4">
              <div class="card card-stats">
                <div class="card-header card-header-danger card-header-icon">
                  <div class="card-icon">
                    <i class="material-icons">monetization_on</i>
                  </div>
                  <p class="card-category">Monthly Income</p>
                  <h3 class="card-title" runat="server" id="lbl_M_Income">Not Load</h3>
                </div>
                <div class="card-footer">
                  <div class="stats">
                    <i class="material-icons">update</i> Just Updated
                  </div>
                </div>
              </div>
            </div>
            <div class="col-md-4 col-sm-4">
              <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                  <div class="card-icon">
                    <i class="material-icons">attach_money</i>
                  </div>
                  <p class="card-category">Monthly Net Profit</p>
                  <h3 class="card-title" runat="server" id="lbl_M_Net_income">Not Load</h3>
                </div>
                <div class="card-footer">
                  <div class="stats">
                    <i class="material-icons">update</i> Just Updated
                  </div>
                </div>
              </div>
            </div>
                   <div class="col-md-4 col-sm-4">
              <div class="card card-stats">
                <div class="card-header card-header-danger card-header-icon">
                  <div class="card-icon">
                    <i class="material-icons">monetization_on</i>
                  </div>
                  <p class="card-category">Yearly Net Profit</p>
                  <h3 class="card-title" runat="server" id="lbl_year_net_profit">Not Load</h3>
                </div>
                <div class="card-footer">
                  <div class="stats">
                    <i class="material-icons">update</i> Just Updated
                  </div>
                </div>
              </div>
            </div>
            
          </div>
          <div class="row">
            <div class="col-md-4">
              <div class="card card-chart">
                <div class="card-header card-header-success">
                  <div class="ct-chart" id="dailySalesChart"></div>
                </div>
                <div class="card-body">
                  <h4 class="card-title">Student Enroll Chart</h4>
                  <p class="card-category">
                    <span class="text-success"><i class="fa fa-long-arrow-up"></i> 55% </span> increase in this month.</p>
                </div>
                <div class="card-footer">
                  <div class="stats">
                    <i class="material-icons">access_time</i> updated today
                  </div>
                </div>
              </div>
            </div>
            <div class="col-md-4">
              <div class="card card-chart">
                <div class="card-header card-header-warning">
                  <div class="ct-chart" id="websiteViewsChart"></div>
                </div>
                <div class="card-body">
                  <h4 class="card-title">Monthly Income</h4>
                  <p class="card-category">Last Campaign Performance</p>
                </div>
                <div class="card-footer">
                  <div class="stats">
                    <i class="material-icons">access_time</i>updated today
                  </div>
                </div>
              </div>
            </div>
            <div class="col-md-4">
              <div class="card card-chart">
                <div class="card-header card-header-danger">
                  <div class="ct-chart" id="completedTasksChart"></div>
                </div>
                <div class="card-body">
                  <h4 class="card-title">Net Profit</h4>
                  <p class="card-category">Last Campaign Performance</p>
                </div>
                <div class="card-footer">
                  <div class="stats">
                    <i class="material-icons">access_time</i>updated today
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="row">
          <div class="col-lg-6 col-md-12">
              <div class="card">
                <div class="card-header card-header-success">
                  <h4 class="card-title">Special Meetings</h4>
                  <p class="card-category">New employees on Past 30 Days</p>
                </div>
                <div class="card-body table-responsive">
                  <table class="table table-hover">
                    <thead class="text-warning">
                      <th>ID</th>
                      <th>Remark</th>
                      <th>Branch</th>
                      <th>Time</th>
                    </thead>
                    <tbody>
                      <tr>
                        <td>1</td>
                        <td>Kurunegala branch class shedule meeting</td>
                        <td>Kurunegala</td>
                        <td>7.00 A.M. - 8.00 A.M</td>
                      </tr>
                      <tr>
                        <td>2</td>
                        <td>Finalize Monthly Report</td>
                        <td>Nugegoda</td>
                        <td>10.00 A.M - 12.00 P.M.</td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
            <div class="col-lg-6 col-md-12">
              <div class="card">
                <div class="card-header card-header-warning">
                  <h4 class="card-title">Newly Joined Employees</h4>
                  <p class="card-category">New employees on Past 30 Days</p>
                </div>
                <div class="card-body table-responsive">
                  <table class="table table-hover">
                    <thead class="text-warning">
                      <th>ID</th>
                      <th>Name</th>
                      <th>Branch</th>
                      <th>Employee Type</th>
                    </thead>
                    <tbody>
                      <tr>
                        <td>1</td>
                        <td>Sameera Lakmal</td>
                        <td>Kurunegala</td>
                        <td>Full-Time Lecture</td>
                      </tr>
                      <tr>
                        <td>2</td>
                        <td>Semini Dimanthika</td>
                        <td>Nugegoda</td>
                        <td>Receptionist</td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
</asp:Content>
