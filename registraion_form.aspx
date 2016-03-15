<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="registraion_form.aspx.cs" Inherits="registraion_form" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Redjinni - Food Delivery Surat, Food Delivery Surat, Food at Home, Online Food Order in Surat, Online Food Order</title>
    <style type="text/css">
        input[type="checkbox"] {
            -webkit-appearance: checkbox;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            width: auto;
            height: auto;
        }

        .modalBackground1 {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.6;
        }

        .modalPopup1 {
            /*background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;*/
            width: auto;
            height: auto;
        }

        .btn1 {
            background: linear-gradient(to bottom, #f15a23, #f15a23) repeat scroll 0 0 #7FBF00;
            border: 2px solid #7FBF00;
            border-radius: 6px;
            color: #ffffff;
            font-family: Arial;
            font-size: 16px;
            margin-left: 14px;
            margin-top: 18px;
            padding: 2px 11px;
            text-decoration: none;
        }

            .btn1:hover {
                background: #7FBF00;
                background-image: -webkit-linear-gradient(top, #7FBF00, #7FBF00);
                background-image: -moz-linear-gradient(top, #7FBF00, #7FBF00);
                background-image: -ms-linear-gradient(top, #7FBF00, #7FBF00);
                background-image: -o-linear-gradient(top, #7FBF00, #7FBF00);
                background-image: linear-gradient(to bottom, #7FBF00, #7FBF00);
                text-decoration: none;
                color: #fff;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="clearfix">
        <div id="contact_page_temp" class="main-wrapper-item">
            <div class="bread-title-holder">
                <div class="bread-title-bg-image full-bg-breadimage-fixed"></div>
                <div class="container">
                    <div class="row-fluid">
                        <div class="container_inner clearfix">
                            <h1 class="title"><span style="font-family: fontawesome;">Registration Form</span></h1>
                            <section class="cont_nav">
                                <div class="cont_nav_inner">
                                    <p><a href="Default.aspx">Home</a>&nbsp;<span class="skt-breadcrumbs-separator"> &gt;&gt; </span>&nbsp;<span>Registration Form</span></p>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
            <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none">
                <div>
                    <div style="background-color: #db0200; font-size: 15px; font-weight: 700; color: white; height: 20px; padding: 10px;">Forgot Password</div>

                    <div style="margin-left: -50px; margin-top: 26px; text-align: left; padding-left: 94px; padding-right: 47px;">
                        <asp:Label ID="Label1" runat="server" Text="Enter your mobile no :" CssClass="span2" Style="margin-left: 0;"></asp:Label>
                        <asp:TextBox ID="txt_email_id" runat="server" CssClass="span3" Style="margin-right: -2px; margin-bottom: 25px;"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_email_id" FilterType="Numbers">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="None" runat="server" ErrorMessage="Please enter mobile no"
                            ControlToValidate="txt_email_id" ValidationGroup="btnsubmit11">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="None" runat="server" ErrorMessage="Please enter 10 digit mobile no"
                            ControlToValidate="txt_email_id" ValidationGroup="btnsubmit11" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div style="margin-bottom: 10px; margin-left: 108px;">
                    <asp:Button ID="btn_sumbit1" runat="server" Text="Submit" CssClass="btn1" ValidationGroup="btnsubmit11" Style="float: none;" OnClick="btn_forgot_submit_Click" />
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="btnsubmit11" />
                    <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn1" Style="float: none;" />
                </div>
            </asp:Panel>
            <div class="page-content default-pagetemp">
                <div class="container post-wrap">
                    <div class="row-fluid">
                        <div id="content" class="span4">
                            <div id="sidebar_2" class="ske_widget">
                                <ul class="skeside">
                                    <li id="text-3" class="ske-container widget_text">
                                        <span style="font-size: 35px; font-family: fontawesome; color: #ED1B24">Login Form</span>
                                        <div method="post" class="wpcf7-form" novalidate="novalidate">
                                            <div id="skepost">
                                                <div class="clearfix">
                                                    <br />
                                                    <p class="wpcf7-form-control-wrap your-subject">
                                                        <span class="wpcf7-form-control-wrap your-email">
                                                            <asp:TextBox runat="server" name="your-email" ID="txt_login_emailid" size="40" class="wpcf7-form-control wpcf7-text wpcf7-email wpcf7-validates-as-required wpcf7-validates-as-email" placeholder="Enter mobile no"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt_login_emailid" FilterType="Numbers">
                                                            </cc1:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="None" runat="server" ErrorMessage="Please enter mobile no"
                                                                ControlToValidate="txt_login_emailid" ValidationGroup="btnsubmit1">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="None" runat="server" ErrorMessage="Please enter 10 digit mobile no"
                                                                ControlToValidate="txt_login_emailid" ValidationGroup="btnsubmit1" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                                                        </span>
                                                    </p>
                                                    <p class="wpcf7-form-control-wrap your-subject">
                                                        <span class="wpcf7-form-control-wrap tel-480">
                                                            <asp:TextBox ID="txt_login_password" runat="server" class="wpcf7-form-control wpcf7-text wpcf7-tel wpcf7-validates-as-tel" TextMode="Password" placeholder="Enter password"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="None" ErrorMessage="Please enter password"
                                                                ControlToValidate="txt_login_password" ValidationGroup="btnsubmit1"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </p>
                                                </div>
                                                <p>
                                                    <asp:Button ID="btn_login" runat="server" Text="Login" ValidationGroup="btnsubmit1" OnClick="btn_login_Click" class="wpcf7-form-control wpcf7-submit"></asp:Button>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;  <a href="#" style="color: #7FBF00;">
                                                        <asp:LinkButton ID="btnShow" runat="server" ForeColor="#ED1B24">Forgot password ?</asp:LinkButton></a>
                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="btnsubmit1" />
                                                </p>
                                            </div>
                                            <div class="wpcf7-response-output wpcf7-display-none"></div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <!-- #sidebar_2 .ske_widget -->
                        </div>
                        <div id="sidebar" class="span8">
                            <div class="post clearfix" id="post-26">
                                <div class="skepost">
                                    <div class="contact_form_title"><span style="font-size: 35px; font-family: fontawesome; color: #ed1b24">Registration Form</span></div>
                                    <div class="wpcf7" id="wpcf7-f19-p26-o1" lang="en-US" dir="ltr">
                                        <div class="screen-reader-response"></div>
                                        <div id="foodeez_contform">
                                            <div class="clearfix">
                                                <p class="one_half">
                                                    <span class="wpcf7-form-control-wrap text-379">
                                                        <asp:TextBox runat="server" name="text-379" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" ID="txt_firstname" aria-required="true" aria-invalid="false" placeholder="Enter first name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter first name"
                                                            ControlToValidate="txt_firstname" Display="None" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>
                                                <p class="one_half last">
                                                    <span class="wpcf7-form-control-wrap text-379">
                                                        <asp:TextBox runat="server" name="text-379" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" ID="txt_lastname" aria-required="true" aria-invalid="false" placeholder="Enter last name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" runat="server" ErrorMessage="Please enter last name"
                                                            ControlToValidate="txt_lastname" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>
                                            </div>
                                            <div class="clearfix">
                                                <p class="one_half">
                                                    <span class="wpcf7-form-control-wrap your-email">
                                                        <asp:TextBox runat="server" name="your-email" ID="txt_emailid" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-email wpcf7-validates-as-required wpcf7-validates-as-email" aria-required="true" aria-invalid="false" placeholder="Enter email iD"></asp:TextBox>
                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="None" runat="server" ErrorMessage="Please enter email address"
                                                                ControlToValidate="txt_emailid" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>--%>
                                                        <asp:RegularExpressionValidator ID="rev1" runat="server" Display="None" ErrorMessage="Enter Proper email ID" ControlToValidate="txt_emailid" ValidationGroup="btnsubmit" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    </span>
                                                </p>
                                                <p class="one_half last">
                                                    <span class="wpcf7-form-control-wrap tel-480">
                                                        <asp:TextBox ID="txt_phoneno" runat="server" name="tel-480" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-tel wpcf7-validates-as-tel" aria-invalid="false" placeholder="Enter mobile no"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_phoneno" FilterType="Numbers">
                                                        </cc1:FilteredTextBoxExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="None" runat="server" ErrorMessage="Please enter mobile no"
                                                            ControlToValidate="txt_phoneno" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="None" runat="server" ErrorMessage="Please enter 10 digit mobile no"
                                                            ControlToValidate="txt_phoneno" ValidationGroup="btnsubmit" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                                                    </span>
                                                </p>
                                            </div>
                                            <p>
                                                <span class="wpcf7-form-control-wrap your-subject">
                                                    <asp:TextBox ID="txt_adress" runat="server" name="your-subject" value="" size="40" class="wpcf7-form-control wpcf7-text" aria-invalid="false" placeholder="Enter address"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Display="None" runat="server" ErrorMessage="Please enter your address"
                                                        ControlToValidate="txt_adress" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                </span>
                                            </p>
                                            <div class="clearfix">
                                                <p class="one_half">
                                                    <span class="wpcf7-form-control-wrap your-email">
                                                        <asp:TextBox runat="server" name="your-email" ID="txt_landmark" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-email wpcf7-validates-as-required wpcf7-validates-as-email" aria-required="true" aria-invalid="false" placeholder="Enter landmark"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" Display="None" runat="server" ErrorMessage="Please enter your landmark"
                                                            ControlToValidate="txt_landmark" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>
                                                <p class="one_half last">
                                                    <span class="wpcf7-form-control-wrap your-subject">
                                                        <asp:DropDownList ID="ddl_googel_area" runat="server" DataTextField="nickname" DataValueField="intglcode" Style="margin: 0; border-color: #ed1b24;" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" InitialValue="--- Select your area  ---" Display="None" runat="server" ErrorMessage="Please select your area"
                                                            ControlToValidate="ddl_googel_area" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>

                                            </div>
                                            <%-- <p>
                                                    <span class="wpcf7-form-control-wrap your-subject">
                                                        <asp:TextBox ID="txt_direction" runat="server" name="tel-480" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-tel wpcf7-validates-as-tel" aria-invalid="false" placeholder="Enter your Direction"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Display="None" runat="server" ErrorMessage="Please enter your direction"
                                                                ControlToValidate="txt_direction" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>--%>
                                            <p class="one_half">
                                                <span class="wpcf7-form-control-wrap your-email">
                                                    <asp:DropDownList ID="ddl_city" runat="server" DataTextField="city" DataValueField="intglcode" Style="margin: 0; border-color: #ed1b24;" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="None" InitialValue="--- Select ---" runat="server" ErrorMessage="Please select city"
                                                        ControlToValidate="ddl_city" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                </span>
                                            </p>
                                            <p class="one_half last">
                                                <span class="wpcf7-form-control-wrap tel-480">
                                                    <asp:TextBox ID="txt_pincode" runat="server" name="your-subject" value="" size="40" class="wpcf7-form-control wpcf7-text" aria-invalid="false" placeholder="Enter pincode"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_pincode" FilterType="Numbers">
                                                    </cc1:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Display="None" runat="server" ErrorMessage="Please enter your pincode"
                                                        ControlToValidate="txt_pincode" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="None" runat="server" ErrorMessage="Please enter 6 digit pincode"
                                                        ControlToValidate="txt_pincode" ValidationGroup="btnsubmit" ValidationExpression="^[0-9]{6}$"></asp:RegularExpressionValidator>
                                                </span>
                                            </p>



                                            <p>
                                                <span class="wpcf7-form-control-wrap your-subject">
                                                    <asp:TextBox ID="txt_password" TextMode="Password" runat="server" name="your-subject" value="" size="40" class="wpcf7-form-control wpcf7-text" aria-invalid="false" placeholder="Enter password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="None" runat="server" ErrorMessage="Please enter your password"
                                                        ControlToValidate="txt_password" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" runat="server" ErrorMessage="Password length must be between 6 to 80 characters"
                                                        ControlToValidate="txt_password" ValidationGroup="btnsubmit" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,80}$"></asp:RegularExpressionValidator>
                                                </span>
                                            </p>
                                            <p>
                                                <span class="wpcf7-form-control-wrap your-subject">
                                                    <asp:TextBox ID="txt_confrompassword" TextMode="Password" runat="server" class="wpcf7-form-control wpcf7-text" placeholder="Enter your confrom password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="None" runat="server" ErrorMessage="Please enter your confirm password"
                                                        ControlToValidate="txt_confrompassword" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None"
                                                        ControlToCompare="txt_password" ControlToValidate="txt_confrompassword" ErrorMessage="Password does not match" ValidationGroup="btnsubmit"></asp:CompareValidator>
                                                </span>
                                            </p>
                                            <p>
                                                <span class="wpcf7-form-control-wrap your-subject" style="color: #333;">
                                                    <asp:CheckBox ID="CheckBox1" runat="server" />I agree <a href="Privacy_Policy.aspx" target="_blank">Privacy policy</a> & <a href="term_condition.aspx" target="_blank">Terms and conditions</a>. &nbsp;&nbsp;&nbsp;
                                                          <asp:CheckBox ID="CheckBox2" runat="server" />send me notifications about offers and deals.
                                                </span>
                                            </p>
                                            <p>
                                                <span class="wpcf7-form-control-wrap your-subject"></span>
                                            </p>
                                            <p>
                                                <asp:Button ID="btn_submit" runat="server" Text="Submit" ValidationGroup="btnsubmit" OnClick="btn_submit_Click" class="wpcf7-form-control wpcf7-submit"></asp:Button>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="btnsubmit" />
                                            </p>

                                        </div>

                                        <div class="wpcf7-response-output wpcf7-display-none"></div>
                                    </div>
                                </div>
                            </div>
                            <!-- skepost -->
                        </div>
                        <!-- post -->

                        <div class="clearfix"></div>
                    </div>
                    <!-- content -->

                    <!-- Sidebar -->

                    <div class="clearfix"></div>
                    <!-- Sidebar -->
                </div>
            </div>
        </div>
    </div>

    <div class="clearfix"></div>
    </div>
     <script>
         (function (i, s, o, g, r, a, m) {
             i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                 (i[r].q = i[r].q || []).push(arguments)
             }, i[r].l = 1 * new Date(); a = s.createElement(o),
             m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
         })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

         ga('create', 'UA-63984286-1', 'auto');
         ga('send', 'pageview');

     </script>
</asp:Content>

