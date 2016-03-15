<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="restaurants_list.aspx.cs" Inherits="restaurant_order_from" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Redjinni - Food Delivery Surat, Food Delivery Surat, Food at Home, Online Food Order in Surat, Online Food Order</title>
    <style>
        input[type="checkbox"] {
            -webkit-appearance: checkbox;
        }

        .ratingEmpty {
            background-image: url(./ratingStarEmpty.gif);
            width: 19px;
            height: 19px;
        }

        .ratingFilled {
            background-image: url(./ratingStarFilled.gif);
            width: 19px;
            height: 19px;
        }

        .ratingSaved {
            background-image: url(./ratingStarSaved.gif);
            width: 19px;
            height: 19px;
        }

        .dropdown {
            margin-left: 8%;
            margin-bottom: 8px;
            margin-top: 15px;
        }

        .ribbon-wrapper-green {
            height: 106px;
            left: -1px;
            overflow: hidden;
            position: absolute;
            top: 0;
            width: 100px;
        }

        .MyCalendar {
            border: 1px solid #646464;
            background-color: lemonchiffon;
            color: red;
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

        .ribbon-green {
            font-weight: bold;
            font-size: 14px;
            color: #000;
            text-align: center;
            -webkit-transform: rotate(-45deg);
            -moz-transform: rotate(-45deg);
            -ms-transform: rotate(-45deg);
            -o-transform: rotate(-45deg);
            position: relative;
            padding: 8px 0;
            left: -28px;
            top: 15px;
            width: 120px;
            right: 10px;
            background-color: #7fbf00;
            background-image: -webkit-gradient(linear, left top, left bottom, from(#ED1B24), to(#ED1B24));
            background-image: -webkit-linear-gradient(top,#ED1B24, #ED1B24);
            background-image: -moz-linear-gradient(top, #ED1B24, #ED1B24);
            background-image: -ms-linear-gradient(top, #ED1B24,#ED1B24);
            background-image: -o-linear-gradient(top,#ED1B24,#ED1B24);
            color: #FFFFFF;
            -webkit-box-shadow: 0px 0px 3px rgba(0,0,0,0.3);
            -moz-box-shadow: 0px 0px 3px rgba(0,0,0,0.3);
            box-shadow: 0px 0px 3px rgba(0,0,0,0.3);
        }

            i .ribbon-green:before, .ribbon-green:after {
                content: "";
                border-top: 6px solid #000;
                border-left: 6px solid transparent;
                border-right: 6px solid transparent;
                position: absolute;
                bottom: -6px;
            }

            .ribbon-green:before {
                left: 0;
            }

            .ribbon-green:after {
                right: 0;
            }

        .scrollcss {
            max-height: 400px;
            overflow: auto;
            width: 415px;
        }
        .chekbox5 {
            padding: 2% 1% 0 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="clearfix">
        <div class="main-wrapper-item blog-template">
            <div class="bread-title-holder">
                <div class="bread-title-bg-image full-bg-breadimage-fixed"></div>
                <div class="container">
                    <div class="row-fluid">
                        <div class="container_inner clearfix">
                            <h1 class="title"><span>Restaurants List</span></h1>
                            <section class="cont_nav">
                                <div class="cont_nav_inner">
                                    <p><a href="Default.aspx">Home</a>&nbsp;<span class="skt-breadcrumbs-separator"> &gt;&gt; </span>&nbsp;Restaurants List</p>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container post-wrap">
                <div class="row-fluid">
                    <div id="sidebar" class="span4" style="float: left; margin-left: 0;">
                        <div id="sidebar_2" class="ske_widget">
                            <ul class="skeside">
                                <li id="Li2" class="ske-container skt-opening-hours-widget chekbox_location">
                                    <h3 class="ske-title">Location </h3>
                                    <ul class="opening-hours-list" style="margin-right: 23%;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" class="chekbox5">
                                            <ContentTemplate>
                                                <asp:CheckBoxList ID="chk_location" runat="server" DataTextField="location" DataValueField="intglcode" Style="margin-left: 16px; margin-bottom: 1px; color: #ED1B24;" AutoPostBack="true" OnSelectedIndexChanged="chk_location_SelectedIndexChanged"></asp:CheckBoxList>
                                                <asp:CheckBoxList ID="chk_location1" runat="server" DataTextField="location" DataValueField="intglcode" Style="margin-left: 16px; margin-bottom: 1px; color: #ED1B24;" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="chk_location_SelectedIndexChanged"></asp:CheckBoxList>
                                                <asp:LinkButton ID="lnk_Close" Style="color: #ED1B24; margin-left: 5%;" Visible="false" runat="server" OnClick="lnk_Close_Click">Close</asp:LinkButton>
                                                <asp:LinkButton ID="lnk_Seemore" Style="color: #ED1B24; margin-left: 5%;" runat="server" OnClick="lnk_Seemore_Click">SeeMore</asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lnk_Seemore" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="lnk_Close" EventName="Click" />
                                                <asp:PostBackTrigger ControlID="chk_location" />
                                                <asp:PostBackTrigger ControlID="chk_location1" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </ul>
                                </li>
                                <li id="Li3" class="ske-container skt-opening-hours-widget chekbox_cuisines">
                                    <h3 class="ske-title">Cuisines </h3>
                                    <ul class="opening-hours-list chekbox5" style="margin-right: 23%;">
                                        <asp:CheckBoxList ID="chk_cusion" runat="server" Style="margin-left: 16px; margin-bottom: 1px; color: #ED1B24;" AutoPostBack="true" OnSelectedIndexChanged="chk_cusion_SelectedIndexChanged">
                                            <asp:ListItem>Veg</asp:ListItem>
                                            <asp:ListItem>Non Veg</asp:ListItem>
                                            <asp:ListItem>Jain</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ul>
                                </li>
                                <li id="Li1" class="ske-container skt-opening-hours-widget chekbox_foodtype">
                                    <h3 class="ske-title">Food Type </h3>
                                    <ul class="opening-hours-list chekbox5" style="margin-right: 23%;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:CheckBoxList ID="chk_food_type" runat="server" DataTextField="food_category" DataValueField="intglcode" Style="margin-left: 16px; margin-bottom: 1px; color: #ED1B24;" AutoPostBack="true" OnSelectedIndexChanged="chk_food_type_SelectedIndexChanged"></asp:CheckBoxList>
                                                <asp:CheckBoxList ID="chk_food_type1" runat="server" DataTextField="food_category" DataValueField="intglcode" Style="margin-left: 16px; margin-bottom: 1px; margin-bottom: 1px; color: #ED1B24;" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="chk_location_SelectedIndexChanged"></asp:CheckBoxList>
                                                <asp:LinkButton ID="lnk_Close1" Style="color: #ED1B24; margin-left: 5%;" Visible="false" runat="server" OnClick="lnk_Close1_Click">Close</asp:LinkButton>
                                                <asp:LinkButton ID="lnk_Seemore1" Style="color: #ED1B24; margin-left: 5%;" runat="server" OnClick="lnk_Seemore1_Click">SeeMore</asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lnk_Seemore1" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="lnk_Close1" EventName="Click" />
                                                <asp:PostBackTrigger ControlID="chk_food_type" />
                                                <asp:PostBackTrigger ControlID="chk_food_type1" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <!-- #sidebar_2 .ske_widget -->
                    </div>
                    <div id="container" class="span8">
                        <div class="sortby2 sortby">
                            <a style="color: #ED1B24; font-size: 16px; font-weight: 700; color: #ED1B24">Sort by :</a>


                            <asp:LinkButton ID="lnk_reting" runat="server" Style="color: #ED1B24; font-size: 16px; color: #ED1B24" OnClick="lnk_reting_Click">Ratings</asp:LinkButton>
                            |
                                         
                             <asp:LinkButton ID="lnk_min_order_amt" runat="server" Style="color: #ED1B24; font-size: 16px; color: #ED1B24" OnClick="lnk_min_order_amt_Click">Minimum order value</asp:LinkButton>
                            |
                                        
                             <asp:LinkButton ID="lnk_delivery_free" runat="server" Style="color: #ED1B24; font-size: 16px; color: #ED1B24" OnClick="lnk_delivery_free_Click">Delivery free</asp:LinkButton>
                            |
                             <asp:LinkButton ID="lnk_fast_delivery" runat="server" Style="color: #ED1B24; font-size: 16px; color: #ED1B24" OnClick="lnk_fast_delivery_Click">Fastest delivery</asp:LinkButton>
                        </div>
                        <br />
                        <div id="content">
                            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                <ItemTemplate>
                                    <div class="post-99 skt_menu_items type-skt_menu_items status-publish has-post-thumbnail hentry post clearfix" id="post-99">
                                        <div class="featured-image-shadow-box blog-menu-items span8" style="margin-left: -7%;">
                                            <!-- normal -->
                                            <div class="skepost clearfix">
                                                <div class="address2">
                                                    Address : &nbsp;
                                                </div>
                                                <asp:Label ID="Literal1" Text='<%#Eval("location") %>' Style="color: #333333; margin-left:12%;" runat="server"></asp:Label>
                                            </div>
                                            <div class="ih-item square effect6 from_top_and_bottom ">
                                                <a><span style="height: auto; width: 100%;" class="imag2">
                                                    <asp:Image ID="image_news" runat="server" class="skin-border imag2 imageset" ImageUrl='<%#Eval("image")%>' alt="Menu Thumbnail" />
                                                </span>
                                                    <div id="datatime" runat="server" class="ribbon-wrapper-green">
                                                        <div class="ribbon-green" style="left: -31px; right: 8px; top: 9px;">New</div>
                                                    </div>
                                                </a>
                                            </div>
                                            <!-- end normal -->
                                        </div>
                                        <!-- span4 -->
                                        <div class="span4" style="margin-left: 4%;">
                                            <div style="float: left;">
                                                <h1 class="post-title"><%#Eval("resturant_name") %></h1>
                                            </div>
                                            <div id="deals" runat="server" style="float: right;">
                                                <img src="Images/Deals.png" class="dealsiamge" style="margin: -18% 1% 1% 79%;  width: auto;"
                                                    title="Deals" />
                                            </div>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("intglcode") %>' />
                                            <div class="skepost clearfix">
                                            </div>
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("intglcode") %>' />
                                            <img src="Images/Delivery%20in.png" style="width: 6%; margin-bottom: -1%;" />

                                            <a style="color: #333333">Delivery in <%#Eval("Delivery_time") %>m
                                            </a>
                                            <br />

                                            <div id="freedilivery" runat="server" visible="false">
                                                <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Image ID="Image1" ImageUrl="Images/free%20diliver.png" runat="server" Style="width: 6%; margin-bottom: -1%;"></asp:Image>
                                                <a style="color: #333333">
                                                    <asp:Label ID="lbl_free_Delivery" runat="server" Text="Free Delivery"></asp:Label></a>
                                            </div>

                                            <img src="Images/diliver%20man.png" style="width: 6%; margin-bottom: -1%;" />
                                            <a style="color: #333333">Delivery min :  Rs.<asp:Label ID="lbl_Delivery_min_rs" runat="server" Text="Label"></asp:Label></a>
                                            <br />

                                            <div style="color: #333333;">
                                                Cuisines :
                                                <asp:Label ID="lbl_foodcuisnie" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="timeing">
                                                Morning time : 
                                                <asp:Label ID="lbl_restuarnts_time" runat="server" Text=""></asp:Label>
                                                To
                                              
                                                <asp:Label ID="lbl_opentime" runat="server" Text=""></asp:Label>
                                                <br />
                                                Afternoon time : 
                                                <asp:Label ID="lbl_Afternoonopentime" runat="server" Text=""></asp:Label>
                                                To
                                              
                                                <asp:Label ID="lbl_Afternoonclosetime" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div>
                                                <cc1:Rating ID="Rating1" OnChanged="Rating1_Changed" runat="server" AutoPostBack="true" ReadOnly="true"
                                                    StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="Star"
                                                    FilledStarCssClass="ratingFilled" CurrentRating='<%# Eval("star") %>'>
                                                </cc1:Rating>
                                                <a>
                                                    <div style="float: left;">
                                                        <%#Eval("review") %>
                                                        <asp:LinkButton ID="btn_review" runat="server" CommandArgument='<%#Eval("intglcode") %>' OnClick="btn_review_Click" Text="Ratings"></asp:LinkButton>
                                                    </div>
                                                    <div id="Div1" style="float: right; margin: -5% 5% 10%;">
                                                        <%--   <asp:Label ID="Label2" runat="server" Text='<%#Eval("foodtype") %>' Style="color: #333333;" Visible="false"></asp:Label>--%>
                                                        <asp:Image ID="veg" ImageUrl="wp-content/themes/foodeez/images/veg.jpg" title="Veg" runat="server" Visible="false" Style="margin-bottom: -9px; margin-left: 12px; margin-top: 13px;"></asp:Image>
                                                        <asp:Image ID="nonveg" ImageUrl="wp-content/themes/foodeez/images/cup-rate-active.jpg" title="Non Veg" runat="server" Visible="false" Style="margin-bottom: -9px; margin-left: -1px; margin-top: 13px;"></asp:Image>
                                                    </div>
                                                </a>
                                            </div>

                                            <div id="goto_menu" runat="server" style="margin-top: 20px;">
                                                <a>
                                                    <asp:Button ID="btn_gotomenu" Style="font-size: 20px; font-weight: bolder; margin: -11% 5% -8% -1%; padding: 5% 17% 3%;"
                                                        runat="server" OnClick="btn_gotomenu_Click" CommandArgument='<%#Eval("intglcode") %>' Text="Go To Menu "></asp:Button></a>
                                            </div>

                                            <div id="preorder" runat="server" style="margin-top: 20px;">
                                                <a>
                                                    <asp:Button ID="btn_preorder" Style="font-size: 20px; font-weight: bolder; margin: -10% 5% -8% -1%; padding: 5% 23% 3% 27%;"
                                                        runat="server" OnClick="btn_preorder_Click" CommandArgument='<%#Eval("intglcode") %>' Text="Preorder"></asp:Button></a>
                                            </div>

                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
                            <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="hiddenTargetControlForModalPopup"
                                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                            </cc1:ModalPopupExtender>
                            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup scrollcss" Style="left: 374.5px; padding: 28px 152px 25px 20px; position: fixed; top: 25px; display: none; z-index: 100001;">
                                <div class="header" style="color: #ed1b24; font-size: 24px; font-weight: bold; margin: -3% -31% 9% 3%; text-align: center;">
                                    Select your delivery time
                                </div>
                                <div class="standard-form row-fluid" style="color: #333333; font-size: 17px">
                                    <table style="margin-left: 66px;">
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddl_day" runat="server" Style="font-size: 9px; margin-left: 41%; padding: 1% 1% 1% 0; width: 50%;">
                                                    <asp:ListItem>-- Date --</asp:ListItem>
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
                                                    <asp:ListItem>13</asp:ListItem>
                                                    <asp:ListItem>14</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>16</asp:ListItem>
                                                    <asp:ListItem>17</asp:ListItem>
                                                    <asp:ListItem>18</asp:ListItem>
                                                    <asp:ListItem>19</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>21</asp:ListItem>
                                                    <asp:ListItem>22</asp:ListItem>
                                                    <asp:ListItem>23</asp:ListItem>
                                                    <asp:ListItem>24</asp:ListItem>
                                                    <asp:ListItem>25</asp:ListItem>
                                                    <asp:ListItem>26</asp:ListItem>
                                                    <asp:ListItem>27</asp:ListItem>
                                                    <asp:ListItem>28</asp:ListItem>
                                                    <asp:ListItem>29</asp:ListItem>
                                                    <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>31</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rb_list" runat="server" RepeatDirection="Horizontal" Style="color: #ED1B24;" RepeatColumns="2" class="wpcf7-form-control wpcf7-text"></asp:RadioButtonList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" runat="server" ErrorMessage="Please Select Time"
                                                    ControlToValidate="rb_list" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="SlotDuration_DDL" Visible="false" runat="server" Style="color: #727272 !important; font-size: 24px; font-weight: 100;" CssClass="span2" OnSelectedIndexChanged="SlotDuration_DDL_SelectedIndexChanged">
                                                    <asp:ListItem>60</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--<asp:Label ID="Label1" runat="server"></asp:Label>--%>
                                </div>
                                <div style="margin-bottom: -3px; margin-left: 14px;">
                                    <asp:Button ID="btn_send" runat="server" Text="Submit" class="btn" ValidationGroup="btnsubmit" CommandArgument='<%#Eval("intglcode") %>' Style="float: none; float: none; margin: -5% 5% -24% 38%;"
                                        OnClick="btn_send_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnClose" runat="server" Text="Close" class="btn" Style="float: none;" OnClick="btnClose_Click" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="btnsubmit" />
                                </div>

                            </asp:Panel>
                        </div>
                        <!-- content -->
                    </div>

                    <!-- container -->
                </div>
                <!-- row-fluid -->
            </div>
            <!-- container -->
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

