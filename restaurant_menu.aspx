<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="restaurant_menu.aspx.cs" Inherits="restaurant_menu" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Redjinni - Food Delivery Surat, Food Delivery Surat, Food at Home, Online Food Order in Surat, Online Food Order</title>
    <link href="css/f47581e-a075cb9.css" rel="stylesheet" />
    <style type="text/css">
        input[type="checkbox"] {
            -webkit-appearance: checkbox;
        }

        div.fixed-position {
            background-color: #F0F0F0;
            border: 1px solid #CCCCCC;
            height: 48px;
            line-height: 50px;
            position: fixed;
            text-align: center;
            width: 148px;
            z-index: 1000;
        }

        div.fixed-n {
            left: 50%;
            margin-left: -75px;
            top: 0px;
        }

        div.fixed-n-e {
            right: 0px;
            top: 0px;
        }

        div.fixed-e {
            margin-top: -25px;
            right: 0px;
            top: 50%;
        }

        div.fixed-s-e {
            bottom: 0px;
            right: 0px;
        }

        div.fixed-s {
            bottom: 0px;
            left: 50%;
            margin-left: -75px;
        }

        div.fixed-s-w {
            bottom: 0px;
            left: 0px;
        }

        div.fixed-w {
            margin-top: -25px;
            left: 0px;
            top: 50%;
        }

        div.fixed-n-w {
            left: 0px;
            top: 0px;
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

        .delete {
            margin: 7px;
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
    </style>
    <style type="text/css">
        body {
            _background-color: gold;
        }

        div.fixed-position {
            _position: absolute;
        }

        div.fixed-n-w,
        div.fixed-n,
        div.fixed-n-e {
            _top: expression( ie6 = (document.documentElement.scrollTop + "px") );
        }

        div.fixed-e,
        div.fixed-w {
            _top: expression( ie6 = (document.documentElement.scrollTop + (document.documentElement.clientHeight / 2) + "px") );
        }

        div.fixed-s-w,
        div.fixed-s,
        div.fixed-s-e {
            _bottom: auto;
            _top: expression( ie6 = (document.documentElement.scrollTop + document.documentElement.clientHeight - 52 + "px") );
        }
    </style>
    <style>
        .dropdown {
            margin-left: 8%;
            margin-bottom: 8px;
            margin-top: 15px;
            New;
        }

        .ribbon-wrapper-green {
            height: 106px;
            left: -5px;
            overflow: hidden;
            position: absolute;
            top: -5px;
            width: 100px;
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
            background-image: -webkit-gradient(linear, left top, left bottom, from(#7fbf00), to(#7fbf00));
            background-image: -webkit-linear-gradient(top,#ED1B24, #ED1B24);
            background-image: -moz-linear-gradient(top, #ED1B24, #ED1B24);
            background-image: -ms-linear-gradient(top, #ED1B24,#ED1B24);
            background-image: -o-linear-gradient(top,#ED1B24,#ED1B24);
            color: #FFFFFF;
            -webkit-box-shadow: 0px 0px 3px rgba(0,0,0,0.3);
            -moz-box-shadow: 0px 0px 3px rgba(0,0,0,0.3);
            box-shadow: 0px 0px 3px rgba(0,0,0,0.3);
        }

            .ribbon-green:before, .ribbon-green:after {
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

        .cart {
            margin-bottom: 20px;
            z-index: 961;
        }

        .table-bordered thead:first-child tr:first-child th:first-child, .table-bordered tbody:first-child tr:first-child td:first-child {
            border-top-left-radius: 4px;
        }

        .table-bordered caption + thead tr:first-child th, .table-bordered caption + tbody tr:first-child th, .table-bordered caption + tbody tr:first-child td, .table-bordered colgroup + thead tr:first-child th, .table-bordered colgroup + tbody tr:first-child th, .table-bordered colgroup + tbody tr:first-child td, .table-bordered thead:first-child tr:first-child th, .table-bordered tbody:first-child tr:first-child th, .table-bordered tbody:first-child tr:first-child td {
            border-top: 0 none;
        }

        .table-striped tbody tr:nth-child(2n+1) td, .table-striped tbody tr:nth-child(2n+1) th {
            background-color: #f9f9f9;
        }

        .table-bordered th, .table-bordered td {
            border-left: 1px solid #ddd;
        }

        .table th, .table td {
            border-top: 1px solid #ddd;
            line-height: 18px;
            padding: 8px;
            text-align: left;
            vertical-align: top;
        }

        .table-bordered {
            border-collapse: separate;
        }

        table {
            border-collapse: collapse;
            border-spacing: 0;
        }

        .scrollcss {
            overflow: auto;
            /*background-color: #21b81e;*/
            width: 350px;
            max-height: 400px;
        }


        /*.scrollcss2 {
            width: 50%;
            max-height: 550px;
            overflow: hidden;
        }*/
        /*::-webkit-scrollbar {
            display: block;
        }*/
    </style>

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    <script>
        function sticky_relocate() {
            var window_top = $(window).scrollTop();
            var div_top = $('#sticky-anchor').offset().top;
            if (window_top > div_top) {

                $('#sidebar').addClass('stick');
            }

            else {
                $('#sidebar').removeClass('stick');
            }
        }

        $(function () {
            $(window).scroll(sticky_relocate);
            sticky_relocate();
        });
    </script>
    <script type="text/javascript">
        function calendarShown(sender, args) {
            sender._popupBehavior._element.style.zIndex = 100005;
        }
    </script>
    <script src="js/218446f-766027b.js"></script>
    <script src="js/b646254-5b074b1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="js/218446f-766027b.js"></script>
    <script src="js/b646254-5b074b1.js"></script>
    <div id="main" class="clearfix">
        <div class="main-wrapper-item blog-template">
            <div class="bread-title-holder">
                <div class="bread-title-bg-image full-bg-breadimage-fixed"></div>
                <div class="container">
                    <div class="row-fluid">
                        <div class="container_inner clearfix">
                            <div class="cont_nav_inner">
                                <h1 class="title"><span>Restaurants Menu</span></h1>
                            </div>
                            <asp:Label ID="lbl_resturantsname" runat="server" Text="Your location is :" Style="color: #ffffff; font-size: 15px; font-weight: bold; margin-left: 11%; margin-top: 0.55%;"></asp:Label>
                            <asp:Label ID="lbl_location" runat="server" Text="" Style="color: #ffffff; color: #ffffff; font-size: 15px; font-weight: bold;"></asp:Label>
                            <asp:Button ID="Button2" runat="server" Text="Change Location" Style="background-color: #ffffff; color: red; font-size: 15px; font-weight: bold; margin: 0.55% 2% 0; padding: 0; text-transform: none;"
                                OnClick="Button2_Click"></asp:Button>
                            <section class="cont_nav">
                                <div class="cont_nav_inner">
                                    <p><a href="Default.aspx">Home</a>&nbsp;<span class="skt-breadcrumbs-separator"> &gt;&gt; &nbsp; <a href="restaurants_list.aspx">Restaurants List</a>&nbsp;<span class="skt-breadcrumbs-separator"> &gt;&gt; </span>&nbsp;Restaurants Menu</p>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container post-wrap">
            <div class="row-fluid">
                <div id="container" class="span12">
                    <div id="content">
                        <div class="post-99 skt_menu_items type-skt_menu_items status-publish has-post-thumbnail hentry post clearfix" id="post-99">
                            <div class="featured-image-shadow-box blog-menu-items span8">
                                <!-- normal -->
                                <asp:Repeater ID="Repeater4" runat="server" OnItemDataBound="Repeater4_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="ih-item square effect6 from_top_and_bottom">
                                            <a href="#"><span class="img">
                                                <asp:Image ID="image_news" runat="server" class="skin-border" ImageUrl='<%#Eval("image") %>' lt="Menu Thumbnail" />
                                            </span>
                                                <div id="datatime" runat="server" class="ribbon-wrapper-green">
                                                    <div class="ribbon-green">New</div>
                                                </div>
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("code") %>' />
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <!-- end normal -->
                            </div>
                            <div class="span4">
                                <h1 class="post-title"><a id="menu_title" runat="server" href="#"></a></h1>
                                <div class="skepost clearfix">
                                    <asp:Label ID="location" runat="server" Style="color: #333333;" Text="Label"></asp:Label>
                                </div>
                                <h1 class="post-title">Food Cuisines<a id="A1" runat="server" href="#" title="Location"></a></h1>
                                <div class="skepost clearfix">
                                    <ul>
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("foodtype1") %>' Style="color: #333333;" Visible="false"></asp:Label>
                                                <asp:Image ID="veg" ImageUrl="wp-content/themes/foodeez/images/veg.jpg" title="Veg" runat="server" Visible="false" Style="margin-bottom: -9px; margin-left: 12px; margin-top: 13px;"></asp:Image>
                                                <asp:Image ID="nonveg" ImageUrl="wp-content/themes/foodeez/images/cup-rate-active.jpg" title="Non Veg" runat="server" Visible="false" Style="margin-bottom: -9px; margin-left: 12px; margin-top: 13px;"></asp:Image>
                                                <br />
                                                <br />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <asp:Repeater ID="Repeater6" runat="server">
                                            <ItemTemplate>
                                                <div>
                                                    <img src="Images/Delivery%20in.png" style="width: 6%; margin-bottom: -1%;" />

                                                    <a style="color: #333333">Delivery in <%#Eval("Deliverym") %>m
                                                    </a>
                                                    <br />
                                                    <%--   <div id="freedilivery" runat="server">
                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("freedilivery") %>' Visible="false"></asp:Label>
                                                        <asp:Image ID="Image1" ImageUrl="Images/free%20diliver.png" runat="server" Style="width: 6%; margin-bottom: -1%;"></asp:Image>
                                                        <a style="color: #333333">
                                                            <asp:Label ID="lbl_free_Delivery" runat="server" Text="Free Delivery"></asp:Label></a>
                                                    </div>--%>
                                                    <img src="Images/diliver%20man.png" style="width: 6%; margin-bottom: -1%;" />
                                                    <a style="color: #333333">Delivery min : 
    Rs.<%#Eval("Deliverymin") %></a><br />
                                                    <div id="OnlinePayment_Available" runat="server">
                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("OnlinePayment_Available") %>' Visible="false"></asp:Label>
                                                        <asp:Image ID="Image1" ImageUrl="Images/online%20payment%20avalable.png" runat="server" Style="width: 6%; margin-bottom: -1%;"></asp:Image>
                                                        <a style="color: #333333">
                                                            <asp:Label ID="lbl_OnlinePayment_Available" runat="server" Text="Online Payment Available"></asp:Label>
                                                        </a>
                                                    </div>
                                                    <br />
                                                    <br />

                                                    <cc1:Rating ID="Rating1" OnChanged="Rating1_Changed" runat="server" AutoPostBack="true" ReadOnly="true"
                                                        StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="Star"
                                                        FilledStarCssClass="ratingFilled" CurrentRating='<%# Eval("Rating") %>'>
                                                    </cc1:Rating>

                                                    <a href="#reviews"><%#Eval("review") %>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btn_review_Click" Text="Ratings"></asp:LinkButton>
                                                        |
                                                        <asp:LinkButton ID="btn_review" runat="server" OnClick="btn_review_Click" Text="Write a review"></asp:LinkButton></a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <!-- span4 -->
                        </div>
                        <!-- content -->
                    </div>
                </div>
            </div>
        </div>
        <section class="row">
            <div class="vendor-body-container" style="float: left;">
                <ul class="nav nav-tabs nav-justified vendor-tabs">
                    <li class="vendor-tabs__menu active">
                        <a href="#menu">Menu</a>
                    </li>
                    <li class="vendor-tabs__reviews">
                        <a href="#reviews">Reviews</a>
                    </li>
                    <li class="vendor-tabs__info">
                        <a href="#info">Info</a>
                    </li>
                    <li class="vendor-tabs__info11">
                        <a href="#Deals">Deals</a>
                    </li>
                </ul>
                <section class="tab-content">
                    <div class="tab-pane" id="Deals">
                        <div class="vendor-info hidden-scrollbar">
                            <h2 class="vendor-info__title">Hot Offers</h2>
                            <div class="inner">
                                <asp:DataList ID="Repeater9" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Image1" runat="server" class="deals_image2 deals_image" Style="" ImageUrl='<%#Eval("image") %>' CommandArgument='<%#Eval("code") %>' OnClick="ImageButton1_Click" />
                                        <br />
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane hidden-scrollbar2" id="info">
                        <div class="vendor-info inner2">
                            <h2 class="vendor-info__title">
                                <asp:Label ID="lbl_resturants_name" runat="server" Text=""></asp:Label>
                                Info
                            </h2>
                            <div class="vendor-info__schedules">
                                <hr />
                                <div class="vendor-info__schedules__delivery">
                                    <div class="vendor-info__schedules__title">
                                        Delivery hours
                                    </div>
                                    <ul
                                        class="schedules"
                                        itemprop="openingHoursSpecification">
                                        <meta itemprop="description" content="Delivery hours">
                                        <li
                                            class="schedules__item  isToday"
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Monday">Monday Morning
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="lbl_monday_opentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="lbl_monday_closetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item  "
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Tuesday">Monday Afternoon
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="lbl_mondaya_aftrnoon_open" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="lbl_mondaya_aftrnoon_close" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item  "
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Tuesday">Tuesday Morning
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="Tuesday_opentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="Tuesday_closetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item"
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Tuesday">Tuesday Afternoon
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="TuesdayAfternoonopentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="TuesdayAfternoonclosetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item  "
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Wednesday">Wednesday Morning
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="Wednesday_opentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="Wednesday_closetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item  "
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Wednesday">Wednesday Afternoon
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="WednesdayAfternoonopentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="WednesdayAfternoonclosetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item  "
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Thursday">Thursday Morning
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="Thursday_opentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="Thursday_closetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item  "
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Thursday">Thursday Afternoon
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="Thursday_Afternoonopentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="Thursday_Afternoonclosetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item  "
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Friday">Friday Morning
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="friday_opentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="friday_closetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item  "
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Friday">Friday Afternoon
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="FridayAfternoonopentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="FridayAfternoonclosetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item  "
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Saturday">Saturday Morning
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="Saturday_opentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="Saturday_closetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item  "
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Saturday">Saturday Afternoon
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="SaturdayAfternoonopentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="SaturdayAfternoonclosetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item  "
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Sunday">Sunday Morning
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="Sunday_opentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="Sunday_closetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                        <li
                                            class="schedules__item  "
                                            itemscope
                                            itemtype="http://schema.org/OpeningHoursSpecification">
                                            <span
                                                class="schedules__item__day"
                                                itemprop="dayOfWeek"
                                                content="Sunday">Sunday Afternoon
                                            </span>
                                            <span class="schedules__item__times">
                                                <span class="schedules__item__time">
                                                    <asp:Label ID="SundayAfternoonopentime" runat="server" Text=""></asp:Label>
                                                    -
                                                    <asp:Label ID="SundayAfternoonclosetime" runat="server" Text=""></asp:Label>

                                                    <meta itemprop="opens" content="11:00:00" />
                                                    <meta itemprop="closes" content="23:00:00" />
                                                </span>
                                            </span>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="vendor-info__overview">
                                <hr />
                                <dl class="vendor-info__overview__list">
                                    <dt class="vendor-delivery-fee">Delivery Min</dt>
                                    <dd>From Rs.<asp:Label ID="lbl_deliveryfee" runat="server" Text=""></asp:Label>.00
                                    </dd>
                                    <dt class="vendor-delivery-time">Delivery time</dt>
                                    <dd>
                                        <asp:Label ID="lbl_delivery_time" runat="server" Text=""></asp:Label>
                                        min 
                                    </dd>
                                </dl>
                            </div>
                            <div class="vendor-info__address">
                                <hr />
                                <div class="vendor-info__address__title">
                                    Address
                                </div>
                                <address
                                    class="vendor-info__address__content"
                                    itemprop="address"
                                    itemscope
                                    itemtype="http://schema.org/PostalAddress">
                                    <span itemprop="streetAddress">
                                        <asp:Label ID="lbl_adress" runat="server" Text=""></asp:Label></span>
                                </address>
                                <div
                                    class="vendor-info__address__map"
                                    itemprop="geo"
                                    itemscope
                                    itemtype="http://schema.org/GeoCoordinates">
                                    <meta itemprop="latitude" content="28.446053" />
                                    <meta itemprop="longitude" content="77.099991" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane active" id="menu">
                        <div class="container post-wrap" style="margin-top: -2%;">
                            <div class="row-fluid foodcusnes2">
                                <div id="Div2" class="span2">
                                    <h2>Food Cuisines</h2>
                                    <asp:Repeater ID="Repeater8" runat="server">
                                        <ItemTemplate>
                                            <a href='#<%#Eval("name") %>' style="font-size: 14px; font-weight: bold; color: #333333;"><%#Eval("name") %></a><br />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div id="Div1" class="span6 hidden-scrollbar" style="margin-left: -4%;">
                                    <asp:Panel ID="pnl_menu" runat="server" CssClass="inner">
                                        <div id="Div3">
                                            <div class="font_style span12" style="font-size: 25px;">
                                                <span style="color: #333333; font-size: 141%; text-align: center;">Menu</span>
                                            </div>
                                            <br />
                                            <%--   <div class="border-content-box bottom-space"></div>--%>
                                            <br />
                                            <div class="page-container clearfix span12">
                                                <div class="menu span12">
                                                    <asp:Repeater ID="Repeater2" runat="server">
                                                        <ItemTemplate>
                                                            <h3 id='<%#Eval("Title") %>' class="subheading"><%#Eval("Title") %></h3>
                                                            <asp:Repeater ID="Repeater3" runat="server">
                                                                <ItemTemplate>
                                                                    <div>
                                                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("code") %>' />
                                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("foodtype") %>' Visible="false"></asp:Label>
                                                                        <h3 class="menu_item item2" style="border-bottom: 1px solid #e8e9e3;">
                                                                            <%-- <hr style="background-color: #e8e9e3; color: #ffffff; border-color:#e8e9e3;  margin: -1% 1% 1%;" />--%>
                                                                            <a style="margin-left: 10px; margin-top: 10px;">
                                                                                <asp:Image ID="veg" ImageUrl="wp-content/themes/foodeez/images/veg.jpg" runat="server" Visible="false" title="Veg" Style="margin-left: -4%; margin-top: 1px; width: 2.5%;"></asp:Image>
                                                                                <asp:Image ID="nonveg" ImageUrl="wp-content/themes/foodeez/images/cup-rate-active.jpg" runat="server" title="Non Veg" Style="margin-left: -4%; margin-top: 1px; width: 2.5%;"
                                                                                    Visible="false"></asp:Image></a>
                                                                            <asp:LinkButton ID="link_itemname" runat="server" title='<%#Eval("discription") %>' OnClick="link_itemname_Click" OnClientClick="OngoogleDataClick()" CommandArgument='<%#Eval("code") %>' CssClass="itemname2"><%#Eval("List") %></asp:LinkButton>
                                                                            <%--   <a title='<%#Eval("discription") %>' style="color: #333333; font-size: 14px; font-weight: bold;"><%#Eval("List") %></a>--%>
                                                                            <asp:Image ID="new_image" runat="server" src="Images/new1.gif" Width="5%" Style="border: 0; margin-bottom: -1%;"></asp:Image>
                                                                            <a id="datatime" style="margin-left: 10px; margin-top: 10px;">
                                                                                <span style="float: right;"><a class="menulist2">Rs.<%#Eval("RS") %>&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" CssClass="plus2" ImageUrl="Images/plus.png" OnClick="ImageButton1_Click" OnClientClick="OngoogleDataClick()" CommandArgument='<%#Eval("code") %>'></asp:ImageButton></a></span></h3>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <br>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                                <br />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <!-- container -->
                                </div>
                                <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
                                <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="hiddenTargetControlForModalPopup"
                                    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup scrollcss chooce_product2" Style="left: 287.5px; display: none; padding: 73px 198px 27px 182px; position: fixed; top: 75px; z-index: 100001;">
                                    <div class="header chooceproduct chooceproduct2">
                                        Choose Product Choices
                                    </div>
                                    <div id="Div5"></div>
                                    <div id="Div6" class="span7" runat="server" style="width: 499px;">
                                        <div class="post clearfix" id="Div7">
                                            <div class="skepost shiping2">
                                                <div class="wpcf7" id="Div10" lang="en-US" dir="ltr">
                                                    <div class="screen-reader-response"></div>
                                                    <div name="" method="post" class="wpcf7-form" novalidate="novalidate">
                                                        <div id="Div11" class="choocewidth choocewidth2">
                                                            <asp:Repeater ID="Repeater5" runat="server">
                                                                <ItemTemplate>
                                                                    <p class="one_half" style="width: 50%;">
                                                                        <span>

                                                                            <asp:Label ID="Label7" runat="server" CssClass="category2 category"
                                                                                Text='<%#Eval("Category") %>'></asp:Label>

                                                                            <asp:Label ID="Label10" runat="server" CssClass="" Style="font-size: 12px;"
                                                                                Text=""></asp:Label></span>

                                                                        <a class="minimum2">Minimum
                                                                            <asp:Label ID="Label8" runat="server"
                                                                                Text='<%#Eval("Minimum") %>'></asp:Label></a>

                                                                        <a class="minimum2">Maximum
                                                                            <asp:Label ID="Label9" runat="server" CssClass=""
                                                                                Text='<%#Eval("Maximum") %>'></asp:Label></a>

                                                                        </span>
                                                                    </p>
                                                                    <p class="two_third last">
                                                                        <asp:Repeater ID="Repeater6" runat="server">
                                                                            <ItemTemplate>
                                                                                <asp:HiddenField ID="HiddenField4" Visible="false" runat="server" Value='<%#Eval("code") %>' />
                                                                                <asp:CheckBox ID="chek_item" runat="server" class="minimum3" Style="padding: 0;" Text='<%#Eval("item_name") %>'></asp:CheckBox>
                                                                                <asp:Label ID="lbl_price" runat="server" class="minimum2 price2"
                                                                                    Text='<%#Eval("item_price") %>'></asp:Label>
                                                                                <br />
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                    </p>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <p class="one_half" style="width: 50%;">
                                                                <asp:Button ID="btn_send" runat="server" Text="Submit" class="res-button" Style="float: none;"
                                                                    OnClick="btn_send_Click" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:Button ID="btnClose" runat="server" Text="Close" class="res-button" Style="float: none;" />
                                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="msg1" />
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="Div4"></div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Button runat="server" ID="Button1" Style="display: none;" />
                                <cc1:ModalPopupExtender ID="mp_google_area" runat="server" PopupControlID="Panel2" TargetControlID="hiddenTargetControlForModalPopup"
                                    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                                <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup scrollcss" Style="left: 381.5px; display: none; padding: 73px 62px 27px 141px; position: fixed; top: 61.5px; z-index: 100001;">
                                    <div class="header" style="color: #333333; font-size: 24px; font-weight: bold; margin: -34px -1px 41px -3px;">
                                        Choose your location
                                    </div>
                                    <div id="Div12"></div>
                                    <div id="Div13" class="span7" runat="server" style="width: 100%;">
                                        <div class="post clearfix choocelocation2" id="Div14">
                                            <div class="skepost shiping2">
                                                <div class="wpcf7" id="Div15" lang="en-US" dir="ltr">
                                                    <div class="screen-reader-response"></div>
                                                    <div name="" method="post" class="wpcf7-form" novalidate="novalidate">
                                                        <div id="Div16">
                                                            <p class="one_half">
                                                                <span class="wpcf7-form-control-wrap your-email">
                                                                    <asp:Label ID="Label8" runat="server" class="location2" Style="color: #333333; font-size: 17px;" Text="Select your location :"></asp:Label>
                                                                    <asp:DropDownList ID="ddl_googel_area" runat="server" DataTextField="nickname" DataValueField="intglcode" Style="border-color: #ed1b24; margin: 0; padding: 0;"
                                                                        class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required droplocation">
                                                                    </asp:DropDownList>
                                                                    <%--<asp:TextBox ID="txt_google_location" runat="server" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required droplocation" Style="padding: 4px 4px 4px 4px;"></asp:TextBox>--%>
                                                                    <%-- <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" OnClientShown="calendarShown" runat="server" DelimiterCharacters=""
                                                                        Enabled="true" ServicePath="WebService.asmx" MinimumPrefixLength="1" ServiceMethod="Get_google_location"
                                                                        TargetControlID="txt_google_location">
                                                                    </cc1:AutoCompleteExtender>--%>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="None" runat="server" ErrorMessage="Select your location"
                                                                        ControlToValidate="ddl_googel_area" ValidationGroup="btnsubmit2" InitialValue="Select your location">*</asp:RequiredFieldValidator>
                                                                </span>
                                                            </p>
                                                            <p>
                                                                <asp:Button ID="btn_submit_google" runat="server" Text="Submit" class="res-button locationsubmit2" ValidationGroup="btnsubmit2" Style="float: none; margin: 24% 1% 1% -49%;"
                                                                    OnClick="btn_submit_google_Click" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button3" runat="server" Text="Close" class="res-button" Style="float: none; visibility: hidden; margin: 0 1% 1%;" />
                                                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="btnsubmit2" />
                                                            </p>
                                                            <%--</ItemTemplate>
                                        </asp:Repeater>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="Div17"></div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <!-- End Google Area -->
                            </div>
                            <!-- container -->
                        </div>
                    </div>
                    <div class="tab-pane" id="reviews">
                        <asp:Panel ID="pnl_review" runat="server">
                            <div class="post clearfix hidden-scrollbar3" id="post-26">
                                <div class="skepost inner3">
                                    <div class="contact_form_title">
                                        <span style="color: #333333; font-family: fontawesome; font-size: 35px; margin-left: 37%; text-align: center;">Write a Review</span>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="Images/back.png" OnClick="ImageButton2_Click" Style="margin-left: 12%;" Width="30" Height="30"></asp:ImageButton>
                                    </div>
                                    <div class="wpcf7 " id="wpcf7-f19-p26-o1" lang="en-US" dir="ltr">
                                        <div class="screen-reader-response" style="margin-bottom: -2px; margin-top: 19px;">
                                        </div>
                                        <div name="" method="post" class="wpcf7-form " novalidate="novalidate">
                                            <div id="foodeez_contform">
                                                <p>
                                                    <span class="wpcf7-form-control-wrap text-379">
                                                        <asp:TextBox runat="server" ID="txt_name" name="text-379" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" aria-required="true" aria-invalid="false" placeholder="Your Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Name"
                                                            ControlToValidate="txt_Reviews" Display="None" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>
                                                <p>
                                                    <span class="wpcf7-form-control-wrap text-379">
                                                        <asp:TextBox runat="server" ID="txt_Reviews" name="text-379" value="" size="40" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" aria-required="true" aria-invalid="false" placeholder="Your Review"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Reviews"
                                                            ControlToValidate="txt_Reviews" Display="None" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                    </span>
                                                </p>
                                                <p>
                                                    <span class="wpcf7-form-control-wrap text-379">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <b style="color: #333333; font-size: 17px;">Rating   :</b>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rb_rating" runat="server" DataTextField="star" class="wpcf7-form-control wpcf7-text wpcf7-validates-as-required" aria-required="true" aria-invalid="false" RepeatDirection="Horizontal" DataValueField="intglcode">
                                                                        <asp:ListItem></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Rating"
                                                                        ControlToValidate="txt_Reviews" Display="None" ValidationGroup="btnsubmit">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </span>
                                                </p>
                                                <div class="clearfix">
                                                    <p style="margin-left: 43%;">
                                                        <asp:Button ID="btn_submit" runat="server" Text="Submit" ValidationGroup="btnsubmit" OnClick="btn_submit_Click" class="wpcf7-form-control wpcf7-submit"></asp:Button>
                                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="btnsubmit" />
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="menu-item-reviews" style="margin: -6% 4% 1% 1%;">
                                                <div class="small-divider"></div>
                                                <h1>Reviews for this Restaurant</h1>
                                                <!-- the loop -->
                                                <div id="reviewer_review_box">
                                                    <div class="clearfix">
                                                        <!-- REVIEW CONTENT STARTS HERE -->
                                                        <asp:Repeater ID="Repeater7" runat="server">
                                                            <ItemTemplate>
                                                                <div class="review_content">
                                                                    <div class="review_topsec clarfix">
                                                                        <ul class="review_social clearfix" style="padding: 12px 0 0;">
                                                                            <li><i class="fa fa-user"></i><span style="color: #000;"><%# Eval("name") %></span></li>
                                                                            <li><i class="fa fa-clock-o"></i><span style="color: #000;"><span class="head"><span class="date"><%# Convert.ToDateTime(Eval("date")).ToString("dd")%></span> <span class="month"><%# Convert.ToDateTime(Eval("date")).ToString("MMM")%></span> <span class="year"><%# Convert.ToDateTime(Eval("date")).ToString("yyyy")%></span></span></li>
                                                                            <li><i class="fa fa-star-o"></i><span style="color: #000;">
                                                                                <table style="margin-left: 19px; margin-top: -25px;">
                                                                                    <tr>
                                                                                        <td>Ratings </td>
                                                                                        <td style="width: 0%;">
                                                                                            <cc1:Rating ID="Rating1" OnChanged="Rating1_Changed" runat="server" AutoPostBack="true" ReadOnly="true"
                                                                                                StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="Star"
                                                                                                FilledStarCssClass="ratingFilled" CurrentRating='<%# Eval("Rating") %>'>
                                                                                            </cc1:Rating>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </span>
                                                                            </li>
                                                                            <!-- rating -->
                                                                        </ul>
                                                                    </div>
                                                                    <div class="review_bottomsec clarfix">
                                                                        <div class="cust-review-title" style="color: #000;"><%#Eval("review") %> </div>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>

                                                    </div>
                                                </div>

                                                <div class="cust-review-border"></div>

                                            </div>

                                            <div class="wpcf7-response-output wpcf7-display-none"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </section>
            </div>
            <asp:Panel ID="pnl_menu1" runat="server">
                <div style="float: right;">
                    <section class="row">
                        <div class="cart-container vendor-cart" style="width: 62%;">
                            <div class="js-sticky-element" id="js-sticky-element-cart">
                                <div id="sticky-anchor"></div>
                                <div id="sidebar" class="cart">
                                    <div class="cart__minimal">
                                        <div class="container">
                                            <img src="Images/Shoppingbag_2.png" style="margin: 1% 0 0 -90%;" />
                                            <span class="cart__minimal__amount">Total :
                                                <asp:Label ID="lbl_total_amount" runat="server" Text=""></asp:Label></span>
                                            <a href="#" class="cart__minimal__toggle"></a>
                                        </div>
                                    </div>
                                    <div class="cart__inner">
                                        <div class="cart__content">
                                            <div class="cart__header vendor3">
                                                <div class="cart__header__title">
                                                    <img src="Images/Shoppingbag.png" style="margin: -12% 1% -8% 87%;" />
                                                    <span class="cart__header__title__text">Your order </span>
                                                </div>
                                            </div>
                                            <div id="mf70" class="cart__details scrollcss orderresponsiv2">
                                                <div id="mf72" class="cart__details__products">
                                                    <asp:GridView ID="grd_shoping" runat="server" Width="100%" DataKeyNames="productcode" AutoGenerateColumns="false" AllowPaging="true" OnRowDataBound="grd_shoping_RowDataBound" ShowHeader="false" ForeColor="Black" OnRowDeleting="grd_shoping_RowDeleting">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <table style="max-width: 100%;">
                                                                        <tr>
                                                                            <td colspan="4" style="padding: 0 5px;">
                                                                                <asp:Label ID="Label4" runat="server" Font-Bold="true" Text='<%#Eval("restro_id") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: -10%; max-width: 5%; padding: 1px 4px;">
                                                                            <td>
                                                                                <asp:DropDownList ID="drpquantity" runat="server" Style="margin: 0 28px 0 5px; padding: 0;"
                                                                                    AutoPostBack="true" OnSelectedIndexChanged="drpquantity_SelectedIndexChanged">
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
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td style="max-width: 259px;">
                                                                                <asp:Label ID="Label3" runat="server" Style="max-width: 259px;" Text='<%#Eval("productname").ToString() %>'></asp:Label></td>

                                                                            <td style="max-width: 0; padding: 0 0 0 12%;">
                                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("totalprice") %>'></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ControlStyle-CssClass="delete" ButtonType="Image" DeleteImageUrl="~/Images/remove.png" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                            <div class="cart__details">
                                                <div class="cart__details_empty-cart">
                                                    <ul class="cart__details__empty-cart__elements">
                                                        <div class="continue" style="margin-left: 3%; color: #333333;">
                                                            <asp:Panel ID="pnl_menu_cart" runat="server" CssClass="menuresponsiv2">
                                                                <asp:Panel ID="Panel3" runat="server" Style="visibility: hidden;">
                                                                    Add Rs.100 to reach Rs.300, the minimum amount for delivery in Royal Bengal Foods
                                                                </asp:Panel>
                                                                <asp:Panel ID="pnl_add_total" runat="server">
                                                                    Add Rs.<asp:Label ID="lbl_add_to_total" runat="server" Text=""></asp:Label>
                                                                    to reach Rs.<asp:Label ID="lbl_delivery_in1" runat="server" Text=""></asp:Label>, the minimum amount for delivery in
                                                               <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
                                                                    <asp:Label ID="lbl_restro_name" runat="server" Text=""></asp:Label>
                                                                </asp:Panel>
                                                                <h2 style="margin-bottom: 2%;">Subtotal : 
                                                                <asp:Label ID="lbl_sub_totle" runat="server" Text=""></asp:Label></h2>
                                                                <asp:Panel ID="pnl_multirestorant" runat="server">
                                                                <asp:Label ID="lbl_multirestorant" runat="server" Visible="false" ForeColor="#222" Text="Multi Restaurant Selection Fee Rs 10.00"></asp:Label>
                                                                </asp:Panel>
                                                                <%-- <h2 style="font-size: 15px; margin-bottom: 1%">Delivery min : Rs
                                        <asp:Label ID="lbl_delivery_in" runat="server" Text=""></asp:Label>
                                        </h2>--%>
                                                                <%--<asp:Label ID="Label6" runat="server" Text="" Visible="false"></asp:Label>--%>
                                                                <h2 style="margin-bottom: 1%;">Total :
                                    <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></h2>
                                                            </asp:Panel>
                                                            <asp:Panel ID="pnl_delicuios" runat="server">
                                                                <h2 style="margin-bottom: 15%; margin-right: 1%; margin-top: 13%;">Order delicious food from the menu!
                                    <asp:Label ID="Label5" runat="server" Text=""></asp:Label></h2>
                                                            </asp:Panel>
                                                        </div>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="cart__checkout totalmenu">
                                                <span class="checkout__button__text">
                                                    <asp:LinkButton ID="lnl_chekout1" class="btn btn-default btn-block btn-lg btn-arrow disabled" runat="server">Proceed to checkout</asp:LinkButton>
                                                    <asp:LinkButton ID="lnk_process_to_checkout" CssClass="btn btn-default btn-block btn-lg btn-arrow btn-primary" OnClick="lnk_process_to_checkout_Click" runat="server"> Proceed to checkout</asp:LinkButton>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <script>
                                        FD
                                            .setControllerConfig('Cart', 'enable', true)
                                            .setControllerConfig('Cart', 'cartRefreshUrl', "\/cart\/show-cart\/t3lp")
                                            .setControllerConfig('Cart', 'showPopupIfMinimumOrderAmountIsNotReached', false)
                                        ;
                                    </script>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnl_menu2" runat="server" Visible="false">
                <div style="float: right;">
                    <section class="row">
                        <div class="cart-container vendor-cart" style="margin: 4px 1% 0 0; width: 80%;">
                            <div class="js-sticky-element" id="Div8">
                                <div id="Div9"></div>
                                <div id="Div18" class="cart">
                                    <div class="cart__minimal">
                                        <div class="container">
                                            <img src="Images/Shoppingbag_2.png" style="margin: 1% 0 0 -83%;" />
                                            <span class="cart__minimal__amount">Total : 0
                                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label></span>
                                            <a href="#" class="cart__minimal__toggle"></a>
                                        </div>
                                    </div>
                                    <div class="cart__inner">
                                        <div class="cart__content">
                                            <div class="cart__header">
                                                <div class="cart__header__title">
                                                    <img src="Images/Shoppingbag.png" style="margin: -12% 1% -8% 87%;" />
                                                    <span class="cart__header__title__text">Your order</span>
                                                </div>
                                            </div>
                                            <div id="Div19" class="cart__details scrollcss" style="width: 86%;">
                                                <div id="Div20" class="cart__details__products">
                                                </div>
                                            </div>
                                            <div class="cart__details">
                                                <div class="cart__details_empty-cart">
                                                    <ul class="cart__details__empty-cart__elements">
                                                        <div class="continue" style="margin-left: 3%; color: #333333;">
                                                            <asp:Panel ID="Panel5" runat="server">
                                                                <h2 style="margin-bottom: 15%; margin-right: 1%; margin-top: 13%;">Order delicious food from the menu!
                                    <asp:Label ID="Label11" runat="server" Text=""></asp:Label></h2>
                                                            </asp:Panel>

                                                            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/restaurants_list.aspx" Visible="false" Style="background-color: #ED1B24; color: #FFFFFF;">Go to resturant list</asp:LinkButton>


                                                        </div>

                                                    </ul>

                                                </div>
                                            </div>

                                            <div class="cart__checkout">

                                                <span class="checkout__button__text">
                                                    <asp:LinkButton ID="LinkButton3" class="btn btn-default btn-block btn-lg btn-arrow disabled" runat="server">Proceed to checkout</asp:LinkButton>

                                                </span>

                                            </div>


                                        </div>
                                    </div>

                                    <script>

                                        FD
                                            .setControllerConfig('Cart', 'enable', true)
                                            .setControllerConfig('Cart', 'cartRefreshUrl', "\/cart\/show-cart\/t3lp")
                                            .setControllerConfig('Cart', 'showPopupIfMinimumOrderAmountIsNotReached', false)
                                        ;
                                    </script>
                                </div>

                            </div>
                        </div>
                    </section>
                </div>
            </asp:Panel>
        </section>

        <script>
            FD
                .setControllerConfig('VendorDetailTabs', 'enable', true)
                .setControllerConfig('VendorDetailProductVariation', 'enable', true)
                .setControllerConfig('VendorDetailMenuScrollSpy', 'enable', true)
                .setControllerConfig('ToggleElements', 'enable', true)
            ;
        </script>

    </div>


    <div class="clearfix"></div>

    </span>
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

