<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Redjinni - Food Delivery Surat, Food Delivery Surat, Food at Home, Online Food Order in Surat, Online Food Order</title>
    <style type="text/css">
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
                            <h1 class="title"><span style="font-family: fontawesome;">My Profile</span></h1>
                            <section class="cont_nav">
                                <div class="cont_nav_inner">
                                    <p><a href="Default.aspx">Home</a>&nbsp;<span class="skt-breadcrumbs-separator"> &gt;&gt; </span>&nbsp;<span>My Profile</span></p>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
            <div class="page-content default-pagetemp">
                <div class="container post-wrap">
                    <div class="row-fluid">
                        <div id="content" class="span12">
                            <div class="post clearfix" id="post-26">
                                <div class="skepost">
                                    <div class="contact_form_title"><span style="font-size: 35px; font-family: fontawesome; color: #ED1B24">My Profile</span></div>
                                    <div class="wpcf7" id="wpcf7-f19-p26-o1" lang="en-US" dir="ltr">
                                        <div class="screen-reader-response"></div>
                                        <div name="" method="post" class="wpcf7-form" novalidate="novalidate">
                                            <div style="display: none;">
                                                <input type="hidden" name="_wpcf7" value="19" />
                                                <input type="hidden" name="_wpcf7_version" value="3.9.3" />
                                                <input type="hidden" name="_wpcf7_locale" value="en_US" />
                                                <input type="hidden" name="_wpcf7_unit_tag" value="wpcf7-f19-p26-o1" />
                                                <input type="hidden" name="_wpnonce" value="119c7a428e" />
                                            </div>
                                            <div id="foodeez_contform">
                                                <p class="one_half">
                                                    <span class="wpcf7-form-control-wrap text-379">
                                                        <asp:TextBox runat="server" name="text-379" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" ID="txt_firstname" aria-required="true" aria-invalid="false" placeholder="Enter first name"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter first name"
                                                            ControlToValidate="txt_firstname" Display="None" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>
                                              <p class="one_half last">
                                                    <span class="wpcf7-form-control-wrap text-379">
                                                        <asp:TextBox runat="server" name="text-379" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" ID="txt_lastname" aria-required="true" aria-invalid="false" placeholder="Enter last name"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="None" runat="server" ErrorMessage="Please enter last name"
                                                            ControlToValidate="txt_lastname" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>
                                                <div class="clearfix">
                                                    <p class="one_half">
                                                        <span class="wpcf7-form-control-wrap your-email">
                                                            <asp:TextBox runat="server" name="your-email" ID="txt_emailid" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-email wpcf7-validates-as-required wpcf7-validates-as-email" aria-required="true" aria-invalid="false" placeholder="Enter your email id"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="rev1" runat="server" Display="None" ErrorMessage="Enter proper email ID" ControlToValidate="txt_emailid" ValidationGroup="btnsubmit" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </span>
                                                    </p>
                                                    <p class="one_half last">
                                                        <span class="wpcf7-form-control-wrap tel-480">
                                                            <asp:TextBox ID="txt_phoneno" runat="server" name="tel-480" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-tel wpcf7-validates-as-tel" aria-invalid="false" placeholder="Enter your phone no"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_phoneno" FilterType="Numbers">
                                                            </cc1:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="None" runat="server" ErrorMessage="Please enter phone mo"
                                                                ControlToValidate="txt_phoneno" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="None" runat="server" ErrorMessage="Please enter 10 digit mobile no"
                                                                ControlToValidate="txt_phoneno" ValidationGroup="btnsubmit" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                                                        </span>
                                                    </p>
                                                     <p class="one_half">
                                                        <span class="wpcf7-form-control-wrap your-email">
                                                            <asp:TextBox runat="server" name="your-email" ID="txt_landmark" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-email wpcf7-validates-as-required wpcf7-validates-as-email" aria-required="true" aria-invalid="false" placeholder="Enter your landmark"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="None" runat="server" ErrorMessage="Please enter landmark"
                                                                ControlToValidate="txt_landmark" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                        </span>
                                                    </p>
                                                    <p class="one_half last">
                                                        <span class="wpcf7-form-control-wrap tel-480">
                                                            <asp:TextBox ID="txt_pincode" runat="server" name="tel-480" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-tel wpcf7-validates-as-tel" aria-invalid="false" placeholder="Enter your pincode"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="None" runat="server" ErrorMessage="Please enter pincode"
                                                                ControlToValidate="txt_pincode" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                        
                                                        </span>
                                                    </p>
                                                      <p class="one_half">
                                                          <span class="wpcf7-form-control-wrap your-email">
                                                            <asp:TextBox runat="server" name="your-email" ID="txt_adrress" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-email wpcf7-validates-as-required wpcf7-validates-as-email" aria-required="true" aria-invalid="false" placeholder="Enter your address"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" runat="server" ErrorMessage="Please enter address"
                                                                ControlToValidate="txt_adrress" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                        </span>
                                                    </p>
                                                    <p class="one_half last">
                                                        <span class="wpcf7-form-control-wrap tel-480">
                                                            <asp:DropDownList ID="ddl_googel_area" runat="server" DataTextField="nickname" DataValueField="intglcode" Style="margin: 0; border-color: #ed1b24;" class="wpcf7-form-control wpcf7-text wpcf7-tel wpcf7-validates-as-tel"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" InitialValue="--- Select your area  ---" Display="None" runat="server" ErrorMessage="Please select your area"
                                                                ControlToValidate="ddl_googel_area" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                        </span>
                                                    </p>
                                                </div>
                                                <p class="one_half">
                                                    <span class="wpcf7-form-control-wrap your-subject">
                                                        <asp:TextBox ID="txt_old_password" runat="server" TextMode="Password" Style="border-color: #ED1B24;" name="your-subject" value="" size="40" class="wpcf7-form-control wpcf7-text" aria-invalid="false" placeholder="Enter old password"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" runat="server" ErrorMessage="Password length must be between 6 to 80 characters"
                                                            ControlToValidate="txt_old_password" ValidationGroup="btnsubmit" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,80}$"></asp:RegularExpressionValidator>
                                                    </span>
                                                </p>
                                                <p class="one_half last">
                                                    <span class="wpcf7-form-control-wrap your-subject">
                                                        <asp:TextBox ID="txt_new_password" runat="server" TextMode="Password" Style="border-color: #ED1B24;" class="wpcf7-form-control wpcf7-text" placeholder="Enter new password"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="None" runat="server" ErrorMessage="Password length must be between 6 to 80 characters"
                                                            ControlToValidate="txt_new_password" ValidationGroup="btnsubmit" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,80}$"></asp:RegularExpressionValidator>
                                                    </span>
                                                </p>
                                                <p style="color: #333;">
                                                    <asp:Button ID="btn_submit" runat="server" Text="Submit" ValidationGroup="btnsubmit" OnClick="btn_submit_Click" class="wpcf7-form-control wpcf7-submit"></asp:Button>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" Style="margin-left: 5%;" />send me notifications about offers and deals.
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


