<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="shoping_cart.aspx.cs" Inherits="shoping_cart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Redjinni - Food Delivery Surat, Food Delivery Surat, Food at Home, Online Food Order in Surat, Online Food Order</title>
    <style>
        .chekbox {
            color: #7fbf00;
            font-size: 21px;
        }

        .btton {
            margin-top: 10%;
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
            max-width: 400px;
            min-width: 280px;
            height: auto;
        }

        .MyCalendar {
            border: 1px solid #646464;
            background-color: lemonchiffon;
            color: red;
        }

        .scrollcss {
            max-height: 400px;
            overflow: auto;
            width: 415px;
        }
    </style>
    <script type="text/javascript">
        function calendarShown(sender, args) {
            sender._popupBehavior._element.style.zIndex = 100005;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="txtSource" runat="server" />
    <asp:HiddenField ID="txtDestination" runat="server" />
    <div id="main" class="clearfix">
        <div id="contact_page_temp" class="main-wrapper-item">
            <div class="bread-title-holder">
                <div class="bread-title-bg-image full-bg-breadimage-fixed"></div>
                <div class="container">
                    <div class="row-fluid">
                        <div class="container_inner clearfix">
                            <h1 class="title"><span style="font-family: fontawesome;">Order Tray</span></h1>
                            <section class="cont_nav">
                                <div class="cont_nav_inner">
                                    <p><a href="Default.aspx">Home</a>&nbsp;<span class="skt-breadcrumbs-separator"> &gt;&gt; </span>&nbsp;<span><a href="restaurants_list.aspx">Restaurants List</a></span>&nbsp;<span class="skt-breadcrumbs-separator"> &gt;&gt; </span>&nbsp;<span><asp:LinkButton ID="LinkButton1" OnClick="btn_submit_Click" runat="server">Restaurants Menu</asp:LinkButton></span>&nbsp;<span class="skt-breadcrumbs-separator"> &gt;&gt; </span>&nbsp;<span>Order Tray</span></p>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
            <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="hiddenTargetControlForModalPopup" CancelControlID="btn_cancel"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup scrollcss" Style="display: none; left: -203.5px; padding: 19px 329px 110px 11px; position: fixed; top: -95px; z-index: 100000;">
                <div class="header chooseshppingadrress2 chooseshppingadrress">
                    Choose Your Previews Address
                </div>
                <div class="standard-form row-fluid radiobutton radiobutton2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:RadioButtonList ID="rb_adrress_list" runat="server" DataTextField="address" DataValueField="intglcode" AutoPostBack="true" OnSelectedIndexChanged="rb_adrress_list_SelectedIndexChanged" RepeatColumns="2" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="rb_adrress_list" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div id="Div3"></div>
                <div id="Div4" class="span7" runat="server">
                    <div class="post clearfix" id="Div5">
                        <div class="skepost shiping2">
                            <div class="contact_form_title"><span class="shipingdetails shipingdetails2">Delivery Address</span></div>
                            <div class="wpcf7" id="wpcf7-f19-p26-o1" lang="en-US" dir="ltr">
                                <div class="screen-reader-response"></div>
                                <div name="" method="post" class="wpcf7-form" novalidate="novalidate">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <div id="foodeez_contform">
                                                <p class="one_half">
                                                    <span class="wpcf7-form-control-wrap your-email">
                                                        <asp:Label ID="Label5" runat="server" Style="color: #333333; font-size: 17px;" Text="Your first name :"></asp:Label>
                                                        <asp:TextBox runat="server" name="text-379" value="" size="40" Style="height: 35px; padding: 0 3%;" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" ID="txt_yourname" aria-required="true" aria-invalid="false" placeholder="Your first name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter your first name"
                                                            ControlToValidate="txt_yourname" Display="None" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>
                                                <p class="one_half last">
                                                    <span class="wpcf7-form-control-wrap your-email">
                                                        <asp:Label ID="Label13" runat="server" Style="color: #333333; font-size: 17px;" Text="Your last name :"></asp:Label>
                                                        <asp:TextBox runat="server" value="" size="40" Style="height: 35px; padding: 0 3%;" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" ID="txt_last_name" aria-required="true" aria-invalid="false" placeholder="Your last name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please enter your last name"
                                                            ControlToValidate="txt_last_name" Display="None" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <p class="one_half">
                                                            <span class="wpcf7-form-control-wrap tel-480">
                                                                <asp:Label ID="Label6" runat="server" Style="color: #333333; font-size: 17px;" Text="Adrress :"></asp:Label>
                                                                <asp:TextBox runat="server" name="text-379" value="" size="40" Style="height: 35px; padding: 0 3%;" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" ID="txt_adrress" aria-required="true" aria-invalid="false" placeholder="Adrress"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" runat="server" ErrorMessage="Please enter adrress"
                                                                    ControlToValidate="txt_adrress" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                            </span>
                                                        </p>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="txt_adrress" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <p class="one_half last">
                                                    <span class="wpcf7-form-control-wrap your-email">
                                                        <asp:Label ID="Label14" runat="server" Style="color: #333333; font-size: 17px;" Text="Enter your landmark:"></asp:Label>
                                                        <asp:TextBox runat="server" value="" size="40" Style="height: 35px; padding: 0 3%;" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" ID="txt_landmark" aria-required="true" aria-invalid="false" placeholder="Enter your landmark"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please enter your landmark"
                                                            ControlToValidate="txt_landmark" Display="None" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>
                                                <p class="one_half">
                                                    <span class="wpcf7-form-control-wrap your-email">
                                                        <asp:Label ID="Label7" runat="server" Style="color: #333333; font-size: 17px;" Text="City :"></asp:Label>
                                                        <asp:DropDownList ID="ddl_city" runat="server" DataTextField="city" DataValueField="intglcode" Style="height: 35px; padding: 0 3%; margin: 0; border-color: #ED1B24;" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="None" InitialValue="--- Select ---" runat="server" ErrorMessage="Please select city"
                                                            ControlToValidate="ddl_city" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                        <p class="one_half last">
                                                            <span class="wpcf7-form-control-wrap tel-480">
                                                                <span class="wpcf7-form-control-wrap your-subject">
                                                                    <asp:Label ID="Label8" runat="server" Style="color: #333333; font-size: 17px;" Text="Your location :"></asp:Label>
                                                                    <asp:DropDownList ID="ddl_googel_area" runat="server" DataTextField="nickname" DataValueField="intglcode" Style="height: 35px; padding: 0 3%; margin: 0; border-color: #ED1B24;" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" AutoPostBack="true" OnSelectedIndexChanged="ddl_googel_area_SelectedIndexChanged"></asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="--- Select your location ---" Display="None" runat="server" ErrorMessage="Please select your location"
                                                                        ControlToValidate="ddl_googel_area" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                                </span>
                                                        </p>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddl_googel_area" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <p class="one_half">
                                                    <span class="wpcf7-form-control-wrap your-email">
                                                        <span class="wpcf7-form-control-wrap your-subject">
                                                            <asp:Label ID="Label9" runat="server" Style="color: #333333; font-size: 17px;" Text="EmailID :"></asp:Label>
                                                            <asp:TextBox ID="txt_emailid" runat="server" Style="height: 35px; padding: 0 3%;" class="wpcf7-form-control wpcf7-text" placeholder="EmailID"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="rev1" runat="server" Display="None" ErrorMessage="Enter proper email iD" ControlToValidate="txt_emailid" ValidationGroup="btnsubmit" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </span>
                                                </p>
                                                <p class="one_half last">
                                                    <span class="wpcf7-form-control-wrap tel-480">
                                                        <span class="wpcf7-form-control-wrap your-subject">
                                                            <asp:Label ID="Label10" runat="server" Style="color: #333333; font-size: 17px;" Text="Mobile no :"></asp:Label>
                                                            <asp:TextBox ID="txt_mobileno" runat="server" Style="height: 35px; padding: 0 3%;" class="wpcf7-form-control wpcf7-text" placeholder="Mobile no"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_mobileno" FilterType="Numbers">
                                                            </cc1:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="None" runat="server" ErrorMessage="Please enter mobile no"
                                                                ControlToValidate="txt_mobileno" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="None" runat="server" ErrorMessage="Please enter 10 digit mobile no"
                                                                ControlToValidate="txt_mobileno" ValidationGroup="btnsubmit" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                                                        </span>
                                                </p>
                                                <p class="one_half">
                                                    <span class="wpcf7-form-control-wrap tel-480">
                                                        <span class="wpcf7-form-control-wrap your-subject">
                                                            <asp:Label ID="Label11" runat="server" Style="color: #333333; font-size: 17px;" Text="Pincode :"></asp:Label>
                                                            <asp:TextBox ID="txt_pincode" runat="server" aria-invalid="false" Style="height: 35px; padding: 0 3%;" class="wpcf7-form-control wpcf7-text" name="your-subject" placeholder="Pincode" size="40" value=""></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_pincode" FilterType="Numbers">
                                                            </cc1:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_pincode" Display="None" ErrorMessage="Please enter pincode" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" runat="server" ErrorMessage="Please enter 6 digit pincode"
                                                                ControlToValidate="txt_pincode" ValidationGroup="btnsubmit" ValidationExpression="^[0-9]{6}$"></asp:RegularExpressionValidator>
                                                            <br />
                                                            <br />


                                                        </span>
                                                </p>
                                                <p class="one_half last">
                                                    <span class="wpcf7-form-control-wrap tel-480">
                                                        <span class="wpcf7-form-control-wrap your-subject">
                                                            <asp:Label ID="Label12" runat="server" Style="color: #333333; font-size: 17px;" Text="Comment :"></asp:Label>

                                                            <asp:TextBox ID="txt_comment" runat="server" aria-invalid="false" class="wpcf7-form-control wpcf7-text" name="your-subject" placeholder="Comment" size="40" Style="border-color: #ed1b24; color: #333333; height: 31%; margin-left: 0.4%; padding: 8px 3px 0 8px;"
                                                                TextMode="MultiLine" value=""></asp:TextBox>
                                                        </span>
                                                </p>
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                        <p class="one_half" style="margin-top: -5%;">
                                                            <span class="wpcf7-form-control-wrap tel-480">
                                                                <span class="wpcf7-form-control-wrap your-subject">
                                                                    <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="true" OnCheckedChanged="RadioButton1_CheckedChanged" Text="As soon as posible" />
                                                                    <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="true" OnCheckedChanged="RadioButton2_CheckedChanged" Text="Later" />
                                                                    <br />
                                                                    <br />
                                                                    <asp:TextBox ID="txt_calender" runat="server" aria-invalid="false" class="wpcf7-form-control wpcf7-text" name="your-subject" Style="height: 35px; padding: 0 1px 0 10px;" placeholder="Delivery time" size="40" value="" Visible="false" Width="40%"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_calender" Display="None" ErrorMessage="Please select calender" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" Format="MMMM d, yyyy" OnClientShown="calendarShown" PopupButtonID="Image1" TargetControlID="txt_calender">
                                                                    </cc1:CalendarExtender>
                                                                    <asp:DropDownList ID="ddl_time" runat="server" Style="padding: 0;" Visible="false" Width="27%">
                                                                        <asp:ListItem>--- Select ---</asp:ListItem>
                                                                        <asp:ListItem>1</asp:ListItem>
                                                                        <asp:ListItem>2</asp:ListItem>
                                                                        <asp:ListItem>3</asp:ListItem>
                                                                        <asp:ListItem>4</asp:ListItem>
                                                                        <asp:ListItem>5</asp:ListItem>
                                                                        <asp:ListItem>6</asp:ListItem>
                                                                        <asp:ListItem>7</asp:ListItem>
                                                                        <asp:ListItem>8</asp:ListItem>
                                                                        <asp:ListItem>9</asp:ListItem>
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                        <asp:ListItem>11</asp:ListItem>
                                                                        <asp:ListItem>12</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddl_time" InitialValue="--- Select ---" Display="None" ErrorMessage="Please select time" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                                    <asp:DropDownList ID="ddl_category" runat="server" Style="padding: 3px 0 4px;" Visible="false" Width="30%">
                                                                        <asp:ListItem>--- Select ---</asp:ListItem>
                                                                        <asp:ListItem>Am</asp:ListItem>
                                                                        <asp:ListItem>Pm</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" InitialValue="--- Select ---" ControlToValidate="ddl_category" Display="None" ErrorMessage="Please select am/pm" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>

                                                                </span>
                                                        </p>
                                                        </span>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="RadioButton2" EventName="CheckedChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="RadioButton1" EventName="CheckedChanged" />
                                                        <asp:PostBackTrigger ControlID="txt_calender" />
                                                        <asp:PostBackTrigger ControlID="ddl_time" />
                                                        <asp:PostBackTrigger ControlID="ddl_category" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <p class="one_half">
                                                    <span class="wpcf7-form-control-wrap tel-480">
                                                        <span class="wpcf7-form-control-wrap your-subject">
                                                            <asp:Button ID="Button2" runat="server" Text="Submit" ValidationGroup="btnsubmit" OnClick="Button2_Click" Style="margin: -5% 2px -1% 10.5%;" class="wpcf7-form-control wpcf7-submit"></asp:Button>
                                                            <%--   <asp:Button ID="Button6" runat="server" Visible="false" Text="Submit" ValidationGroup="btnsubmit" style="display:block;"  class="wpcf7-form-control wpcf7-submit"></asp:Button>--%>
                                                            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="Button2_Click" class="wpcf7-form-control wpcf7-submit"></asp:Button>
                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="btnsubmit" />
                                                            <br />
                                                            <asp:Label ID="Literal1" runat="server" Style="color: #ED1B24;"></asp:Label>

                                                        </span>
                                                    </span>
                                                </p>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddl_googel_area" EventName="SelectedIndexChanged" />
                                            <asp:PostBackTrigger ControlID="Button2" />
                                            <asp:PostBackTrigger ControlID="btn_cancel" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <div class="wpcf7-response-output wpcf7-display-none"></div>
                                </div>
                            </div>
                        </div>
                        <!-- skepost -->
                    </div>
                    <!-- post -->

                    <div class="clearfix"></div>
                </div>
            </asp:Panel>
            <div class="page-content fullwidth-temp">
                <div class="container post-wrap">
                    <div class="row-fluid1">
                        <div id="content" class="span12">
                            <div class="post" id="post-169">
                                <div class="skepost shoping2">
                                    <div class="contact_form_title">
                                        <span style="color: #ED1B24; border-color: #FFFFFF; font-family: fontawesome; font-size: 35px; margin-left: 42%; text-align: center;">Order Tray</span>
                                    </div>
                                    <table style="border: 1px solid #FFFFFF; border-color: #FFFFFF; margin: 0 -2px -1px; text-align: left; width: 100%;">
                                        <tbody style="border: 1px solid #FFFFFF; border-color: #FFFFFF; margin: 0 -2px -1px; text-align: left; width: 100%; background-color: #ED1B24;">
                                            <tr style="border-color: #FFFFFF;">
                                                <th style="width: 10%; color: white; font-size: 15px; padding-right: 0;">Restaurants Name</th>
                                                <th style="width: 10%; color: white; font-size: 15px; padding: 0;">Product Name</th>
                                                <th style="width: 10%; color: white; font-size: 15px; padding: 0;">Quantity</th>
                                                <th style="width: 10%; color: white; font-size: 15px; padding: 0;">Unit Price</th>
                                                <th style="padding-right: 3%; width: 10%; color: white; font-size: 15px; padding: 0;">Total</th>
                                                <th style="width: 10%; color: white; font-size: 15px; padding: 0;">Delete</th>
                                            </tr>
                                            <asp:GridView ID="grd_shoping" runat="server" Width="100%" DataKeyNames="productcode" AutoGenerateColumns="false" AllowPaging="true" OnRowDeleting="grd_shoping_RowDeleting1" OnRowDataBound="grd_shoping_RowDataBound" ShowHeader="false" ForeColor="Black">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <tr style="font-size: 17px; border-color: #FFFFFF;">
                                                                <td class="shoping3" style="font-size: 17px; border-color: #FFFFFF; color: #333333; width: 10%;"><a>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("restro_id") %>'></asp:Label></a></td>
                                                                <td class="shoping3" style="font-size: 17px; border-color: #FFFFFF; color: #333333; width: 10%;"><a><%#Eval("productname") %></a></td>

                                                                <td class="shoping3" style="font-size: 17px; border-color: #FFFFFF; color: #333333; width: 10%;"><a>
                                                                    <asp:DropDownList ID="drpquantity" runat="server" AutoPostBack="true" class="drp drp2" OnSelectedIndexChanged="drpquantity_SelectedIndexChanged">
                                                                        <asp:ListItem>1</asp:ListItem>
                                                                        <asp:ListItem>2</asp:ListItem>
                                                                        <asp:ListItem>3</asp:ListItem>
                                                                        <asp:ListItem>4</asp:ListItem>
                                                                        <asp:ListItem>5</asp:ListItem>
                                                                        <asp:ListItem>6</asp:ListItem>
                                                                        <asp:ListItem>7</asp:ListItem>
                                                                        <asp:ListItem>8</asp:ListItem>
                                                                        <asp:ListItem>9</asp:ListItem>
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                    </asp:DropDownList></a></td>
                                                                <td class="shoping3" style="font-size: 17px; border-color: #FFFFFF; color: #333333; width: 10%;"><a><%#Eval("actualprice") %></a></td>
                                                                <td class="shoping3" style="font-size: 17px; border-color: #FFFFFF; color: #333333; width: 10%;"><a><%#Eval("totalprice") %></a></td>
                                                                <td class="shoping3" style="font-size: 17px; border-color: #FFFFFF; color: #333333; width: 10%;">
                                                                    <asp:ImageButton ID="btn_delete_item" runat="server" CommandArgument='<%#Eval("productcode") %>' ImageUrl="~/Images/remove.png" OnClick="btn_delete_item_Click" />
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </tbody>
                                    </table>
                                    <asp:Panel ID="pnl_shoping_cart" runat="server" Visible="false">
                                        <asp:GridView ID="grd_shopingcart" AllowPaging="true" AutoGenerateColumns="false"
                                            DataKeyNames="productcode" runat="server" Width="100%" GridLines="None">
                                            <Columns>
                                                <asp:BoundField HeaderText="Product Name" DataField="productname" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Font-Bold="false" />
                                                <asp:BoundField HeaderText="Resturant Name" DataField="restro_id" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Font-Bold="false" />
                                                <asp:BoundField HeaderText="Quantity" DataField="drpquantity" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Font-Bold="false" />
                                                <asp:BoundField HeaderText="Price" DataField="totalprice" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Font-Bold="false" />
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                    <asp:Panel ID="pnl_shiping_adrress_fill" runat="server" Visible="false">
                                        <div id="Div2" class="shiping_adrress span6 ">
                                            <div id="sidebar_2" class="ske_widget">
                                                <ul class="skeside ">
                                                    <li id="sktopening_hours-2" class="ske-container skt-opening-hours-widget lblmenu2">
                                                        <h3 class="ske-title ">SHIPPING INFORMATION</h3>
                                                        <ul style="color: #ED1B24;">
                                                            <li class=""><span class="head">Your name</span><span>:</span><span class="time">
                                                                <asp:Label ID="lbl_firstname" runat="server" Text=""></asp:Label></span></li>
                                                            <li class=""><span class="head ">Adrress</span><span class="ohr_coln">:</span><span class="time">
                                                                <asp:Label ID="lbl_adrress" runat="server" Text=""></asp:Label></span></li>
                                                            <li class=""><span class="head ">Landmark</span><span class="ohr_coln">:</span><span class="time">
                                                                <asp:Label ID="lbl_landmark" runat="server" Text=""></asp:Label></span></li>
                                                            <li class=""><span class="head ">Pincode</span><span class="ohr_coln">:</span><span class="time">
                                                                <asp:Label ID="lbl_pincode" runat="server" Text=""></asp:Label></span></li>
                                                            <li class=""><span class="head ">Emailid</span><span class="ohr_coln">:</span><span class="time">
                                                                <asp:Label ID="lbl_emailid" runat="server" Text=""></asp:Label></span></li>
                                                            <li class=""><span class="head ">Mobile no</span><span class="ohr_coln">:</span><span class="time">
                                                                <asp:Label ID="lbl_phoneon" runat="server" Text=""></asp:Label></span></li>
                                                            <li class=""><span class="head ">Delivery time</span><span class="ohr_coln">:</span><span class="time">
                                                                <asp:Label ID="lbl_calender" runat="server" Text=""></asp:Label></span></li>
                                                        </ul>
                                                    </li>
                                                </ul>
                                            </div>
                                            <!-- #sidebar_2 .ske_widget -->
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnl_menu_cart" runat="server" Visible="false">
                                        <div class="sub_total2 sub_total3">
                                            Sub Total : र
                                        <asp:Label ID="lbl_subtotle" runat="server" Text=""></asp:Label>
                                        </div>
                                        <br />
                                        <div class="multi_resro multi_restro2">
                                            <asp:Label ID="Label2" runat="server" Text="0" Visible="false"></asp:Label>
                                        </div>
                                        <br />
                                        <asp:Panel ID="Panel2" runat="server">
                                            <h2 class="voucher2 voucher">Enter your voucher code here :
                                    <asp:TextBox ID="txt_promocode" runat="server" class="textbox2" Style="padding: 0 1%;" Height="30" Width="100"></asp:TextBox>
                                                &nbsp;&nbsp; 
                                       <asp:Button ID="btn_apply" runat="server" Text="Apply" OnClick="btn_apply_Click" Style="margin: 7px 1px 1px; padding: 4px 6px 1px;"></asp:Button>
                                            </h2>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel3" runat="server" Visible="false">
                                            <h2 style="color: #ED1B24; float: right; font-size: 19px;">Your discount amount is :
                                                 <asp:Label ID="lbl_pro_amt" runat="server" Text=""></asp:Label>
                                            </h2>
                                        </asp:Panel>
                                        <br />
                                        <br />
                                        <div class="total total2">
                                            Total : र
                                        <asp:Label ID="lbltotal_amt" runat="server" Text=""></asp:Label>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="sub_total2 sub_total">
                                            Packing  Charge : र
                                       
                                        <asp:Label ID="lbl_packing" runat="server" Text=""></asp:Label>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="sub_total2 sub_total">
                                            Restaurant Taxes : र
                                        <asp:Label ID="lbl_service_tex" runat="server" Text="0"></asp:Label>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="sub_total2 sub_total">
                                            Delivery  Charge : र
                                       
                                        <asp:Label ID="lbl_delivery_fee" runat="server" Text=""></asp:Label>
                                        </div>
                                        <br />
                                        <br />

                                        <div class="sub_total2 sub_total">
                                            Grand Total : र
                                        <asp:Label ID="lbl_grand_total" runat="server" Text=""></asp:Label>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnl_cart" runat="server">
                                        <div style="color: #ED1B24; float: right; color: #ed1b24; float: right; font-size: 22px; margin: 2% 37% 1% 2%;">
                                            Your Order Tray is empty!
                                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                        </div>
                                    </asp:Panel>
                                    <%--<asp:Label ID="Label3" runat="server" Text="" Visible="false"></asp:Label>--%>
                                </div>

                                <!-- skepost -->
                            </div>
                            <!-- post -->
                        </div>
                        <p>
                            <div class="add_restro2" style="float: left;">
                                <asp:Button ID="btn_submit" runat="server" Text="Add more item from same restaurants" Style="margin-left: 9%;" OnClick="btn_submit_Click" class="wpcf7-form-control wpcf7-submit  add_restro"></asp:Button>
                            </div>
                            <div style="float: right;">
                                <asp:Button ID="btn_chekout" runat="server" Text="Chekout" OnClick="btn_chekout_Click" class="wpcf7-form-control wpcf7-submit"></asp:Button>
                                <asp:Button ID="btn_order" runat="server" Text="Process To Payment" Visible="false" OnClick="btn_order_Click1" class="wpcf7-form-control wpcf7-submit"></asp:Button>
                            </div>
                        </p>

                        <%-- </asp:Panel>--%>
                        <!-- content -->
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
    <asp:Button runat="server" ID="Button1" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel4" TargetControlID="Button1" CancelControlID="btn_cancel"
        BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panel4" runat="server" CssClass="modalPopup scrollcss" Style="left: 169px; display: none; padding: 31px 329px 25px 24px; position: fixed; top: 101px; z-index: 100001;">
        <div class="header" style="color: #ED1B24; font-size: 24px; font-weight: bold; margin: 2% -94% 9% -9%; text-align: center;">
            Choose Your Combo Item       
        </div>
        <div id="Div1"></div>
        <div id="Div6" class="span7" runat="server">
            <div class="post clearfix" id="Div7">
                <div class="skepost shiping2">
                    <%--<div style="color: #ED1B24; font-size: 21px;">
                                        <asp:CheckBox ID="CheckBox1"
                                            Text=" Delivery at my default adrress " Style="color: #ED1B24; font-size: 15px; margin: 3% 8% -33% 0;"
                                            class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required chekbox" runat="server" AutoPostBack="True" OnCheckedChanged="chk_same_as_above_CheckedChanged" />
                                </div>--%>
                    <div class="wpcf7" id="Div8" lang="en-US" dir="ltr">
                        <div class="screen-reader-response"></div>
                        <div name="" method="post" class="wpcf7-form" novalidate="novalidate">
                            <div id="Div9">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <p class="one_half">
                                            <span class="wpcf7-form-control-wrap your-email">
                                                <asp:Label ID="lbl_errore_msg" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                <asp:ListBox ID="CheckBoxList1" runat="server" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required list1 list3" SelectionMode="Multiple" DataTextField="item_name" DataValueField="intglcode"></asp:ListBox>
                                                <asp:Button ID="Button4" runat="server" class="wpcf7-form-control wpcf7-submit" Style="margin-left: 15%;" Text="Add" OnClick="Button4_Click" />
                                            </span>
                                        </p>
                                        <p class="one_half last">
                                            <span class="wpcf7-form-control-wrap tel-480">
                                                <asp:ListBox ID="lstRight" runat="server" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required list2 list3" SelectionMode="Multiple"></asp:ListBox>
                                                <asp:Button ID="Button5" runat="server" class="wpcf7-form-control wpcf7-submit" Style="margin-left: 9%;" Text="Remove" OnClick="Button5_Click" />
                                            </span>
                                        </p>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="Button4" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="Button5" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <p>
                                    <asp:Label ID="Label4" runat="server" Text="" Font-Bold="true"></asp:Label>
                                    <asp:Button ID="Button3" runat="server" class="wpcf7-form-control wpcf7-submit" Style="margin: 1% 1% -2% 40%;" Text="Submit" OnClick="Button3_Click" />
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </asp:Panel>
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

