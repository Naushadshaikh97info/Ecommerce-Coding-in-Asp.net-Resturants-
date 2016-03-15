<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Redjinni - Food Delivery Surat, Food Delivery Surat, Food at Home, Online Food Order in Surat, Online Food Order</title>
    <link href="Images/favicon.png" rel="icon" />
    <meta name="google-site-verification" content="K8CK_ojwHI8zZuNsqNZ-JU8BIUDD_qDF6387z6_hF-w" />
    <meta name="description" content="Redjinni - Food Delivery in Surat, Food Delivery in Surat, Online Food Ordering Surat, Online Food Ordering Surat, Home Delivery Surat, Home Delivery Surat, Office Delivery Surat. Office Delivery Surat.  redjinni is one of the first online food ordering and delivery platforms in Gujarat to bring food from your favourite restaurant to your doorstep." />
    <meta name="author" content="Redjinni" />
    <meta name="keywords" content="Food Delivery in Surat, Food Delivery in Surat, Online Food Ordering Surat, Online Food Ordering Surat, Home Delivery Surat, Home Delivery Surat, Office Delivery Surat. Office Delivery Surat." />
    <link rel='stylesheet' href='wp-content/plugins/contact-form-7/includes/css/styles657a.css?ver=3.9.3' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/plugins/revslider/rs-plugin/css/settingsdded.css?rev=4.6.0&amp;ver=4.0.1' type='text/css' media='all' />
    <style type='text/css'>
        .tp-caption a {
            color: #ff7302;
            text-shadow: none;
            -webkit-transition: all 0.2s ease-out;
            -moz-transition: all 0.2s ease-out;
            -o-transition: all 0.2s ease-out;
            -ms-transition: all 0.2s ease-out;
        }

            .tp-caption a:hover {
                color: #ffa902;
            }

        .black_button a.large-button {
            margin: 25px 6px 0 0 !important;
            padding: 13px 18px !important;
            line-height: normal !important;
        }

            .black_button a.large-button span {
                font-size: 16px !important;
                line-height: normal !important;
            }

        .tp-caption a {
            color: #ff7302;
            text-shadow: none;
            -webkit-transition: all 0.2s ease-out;
            -moz-transition: all 0.2s ease-out;
            -o-transition: all 0.2s ease-out;
            -ms-transition: all 0.2s ease-out;
        }

            .tp-caption a:hover {
                color: #ffa902;
            }

        .tp-caption a {
            color: #ff7302;
            text-shadow: none;
            -webkit-transition: all 0.2s ease-out;
            -moz-transition: all 0.2s ease-out;
            -o-transition: all 0.2s ease-out;
            -ms-transition: all 0.2s ease-out;
        }

            .tp-caption a:hover {
                color: #ffa902;
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
    <link rel='stylesheet' href='wp-content/plugins/sketchthemes-buy-button/css/sktbuybtnf39e.css?ver=4.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/stylef39e.css?ver=4.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/skt-animationf269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/flexsliderf269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/font-awesomef269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/foodeez-fontf269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/ihoverf269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/prettyPhotof269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/jquery.timepickerf269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/bootstrap-datepickerf269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/owl.carouself269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/owl.themef269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/owl.transitionsf269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/superfishf269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/css/bootstrap-responsivef269.css?ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Open+Sans%3A400%2C600&amp;ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Dancing+Script&amp;ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Muli&amp;ver=1.0.1' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/SketchBoard/functions/modules/shortcodes/css/sketch-shortcodes5152.css?ver=1.0' type='text/css' media='all' />
    <link rel='stylesheet' href='wp-content/themes/foodeez/SketchBoard/functions/modules/shortcodes/css/sketch-tipTip5152.css?ver=1.0' type='text/css' media='all' />
    <script type='text/javascript' src='wp-includes/js/jquery/jquery90f9.js?ver=1.11.1'></script>
    <script type='text/javascript' src='wp-includes/js/jquery/jquery-migrate.min1576.js?ver=1.2.1'></script>
    <script type='text/javascript' src='wp-content/themes/foodeez/js/custom5152.js?ver=1.0'></script>
    <script type='text/javascript' src='wp-content/plugins/revslider/rs-plugin/js/jquery.themepunch.tools.mindded.js?rev=4.6.0&amp;ver=4.0.1'></script>
    <script type='text/javascript' src='wp-content/plugins/revslider/rs-plugin/js/jquery.themepunch.revolution.mindded.js?rev=4.6.0&amp;ver=4.0.1'></script>

    <link rel="EditURI" type="application/rsd+xml" title="RSD" href="xmlrpc0db0.php?rsd" />
    <link rel="wlwmanifest" type="application/wlwmanifest+xml" href="wp-includes/wlwmanifest.xml" />
    <meta name="generator" content="WordPress 4.0.1" />

    <!-- Start analytics code 16/10/2014 3:51:02 PM -->

    <!-- End analytics code 16/10/2014 3:51:09 PM -->
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;">

    <style type="text/css">
        /***************** THEME *****************/
        .res-button {
            color: #ffffff;
            background: #ed1b24;
        }

            .res-button:hover {
                background: #000;
                color: #fff;
            }

        #logo img {
            width: 222px;
            height: 100px;
        }

        .bread-title-holder, .teamsocial li a {
            background: #ED1B24;
        }

        .skt-opening-hours-widget .opening-hours-list li:hover {
            border-top-color: #ED1B24;
        }

        .service-icon:before {
            border-bottom-color: #ED1B24;
        }

        h1, h2, h3, h4, h5, h6, .food_map_window .food_right_sec h3, .contact_form_title, #contact_page_temp .contact_top_block h3, blockquote.sketch-quote a, .quoteauthor a, blockquote {
            color: #ED1B24;
        }

        .error404 #searchform input[type="text"]:focus, .search #searchform input[type="text"]:focus, #sidebar #searchform input[type="text"]:focus, #footer #searchform input[type="text"]:focus, #wp-calendar {
            border-color: #ED1B24;
        }

            li.ui-timepicker-selected, .ui-timepicker-list li:hover, .ui-timepicker-list .ui-timepicker-selected:hover, #wp-calendar thead {
                background: #ED1B24;
            }

        .sticky-post {
            color: #ED1B24;
            border-color: rgba(127,191,0,.6);
        }

        #footer, .skt-opening-hours-widget .opening-hours-list li.active {
            border-color: #ED1B24;
        }

        .social li a:hover, .skt-opening-hours-widget .opening-hours-list li:hover, .skt-opening-hours-widget .opening-hours-list li.active, #about_author_box .author_social li a, .sketch_price_table .price_table_inner ul li.table_title {
            background: #ED1B24;
        }

            .social li a:hover:before {
                color: #fff;
            }

        a#backtop, #respond input[type="submit"], .skt-ctabox div.skt-ctabox-button a:hover, .widget_tag_cloud a:hover, .continue a, #foodeez-paginate .foodeez-current, #foodeez-paginate a:hover, .comments-template .reply a, #commentsbox .reply a, #content .contact-left form input[type="submit"]:hover, .skt-parallax-button:hover, .sktmenu-toggle, #footer .tagcloud a:hover, ._404_artbg img, .full-map-box .hsearch-close, form input[type="submit"] {
            background-color: #ED1B24;
        }

        form.wpcf7-form input[type="submit"], #foodeez_reservation input[type="submit"], .postformat-gallerycontrol-nav a.postformat-galleryactive, .skt-rate-price {
            background-color: #ED1B24;
        }

        .skt-ctabox div.skt-ctabox-button a, #portfolio-division-box .readmore, .teammember, .slider-link a, .ske_tab_v ul.ske_tabs li.active, .ske_tab_h ul.ske_tabs li.active, #content .contact-left form input[type="submit"], .filter a, .skt-parallax-button, #foodeez-paginate a:hover, #foodeez-paginate .foodeez-current, form.wpcf7-form input[type="text"]:focus, .search1:focus, form.wpcf7-form input[type="email"]:focus,
        form.wpcf7-form input[type="url"]:focus, form.wpcf7-form input[type="tel"]:focus,
        form.wpcf7-form input[type="number"]:focus, form.wpcf7-form input[type="range"]:focus,
        form.wpcf7-form input[type="date"]:focus, form.wpcf7-form input[type="file"]:focus, form.wpcf7-form textarea:focus,
        #foodeez_reservation input[type="text"]:focus,
        #foodeez_reservation input[type="email"]:focus, #sidebar select:focus, #footer select:focus,
        #foodeez_reservation input[type="number"]:focus, #foodeez_reservation textarea:focus, #respond input:focus, #respond textarea:focus,
        form input[type="text"]:focus, form input[type="email"]:focus,
        form input[type="url"]:focus, form input[type="tel"]:focus,
        form input[type="number"]:focus, form input[type="range"]:focus,
        form input[type="date"]:focus, form input[type="file"]:focus, form textarea:focus,
        .skt-opening-hours-widget .opening-hours-list {
            border-color: #ED1B24;
        }

        .clients-items li a:hover {
            border-bottom-color: #ED1B24;
        }

        a, .ske-footer-container ul li:hover:before, .ske-footer-container ul li:hover > a, .ske_widget ul ul li:hover:before, .ske_widget ul ul li:hover, .ske_widget ul ul li:hover a, .title a, .skepost-meta a:hover, .post-tags a:hover, .entry-title a:hover, .readmore a:hover, #Site-map .sitemap-rows ul li a:hover, .childpages li a, #Site-map .sitemap-rows .title, .ske_widget a, .ske_widget a:hover, #Site-map .sitemap-rows ul li:hover, #footer .third_wrapper a, .ske-title, #content .contact-left form input[type="submit"], .filter a, span.team_name, .reply a, a.comment-edit-link, .skt_price_table .price_in_table .value, .teammember strong .team_name, #content .skt-service-page .one_third:hover .service-box-text h3, .ad-service:hover .service-box-text h3, .mid-box-mid .mid-box:hover .iconbox-content h4, .error-txt, .skt-ctabox .skt-ctabox-content h2, .reply a:hover, a.comment-edit-link:hover, .skepost-meta i, .topbar_info i, .topbar_info .head-phone-txt {
            color: #ED1B24;
            text-decoration: none;
        }

            .single #content .title, #content .post-heading, .childpages li, .fullwidth-heading, .comment-meta a:hover, #respond .required, #wp-calendar tbody a, .skt-opening-hours-widget .opening-hours-list li:before, .ske-title.ske-footer-title, h3#comments-title, h3#reply-title, .nav-previous, .nav-next, #comments, .full-map-box .hsearch-close:hover, #foodeez_review .foodeez_review_form_title, .cust-review-title, #reviewer_review_box i, .single-meta-content span, .iconbox-icon i, .customer-reviews .review-menuitem, .post.skt_menu_items .menu-item-price span, .sketch_price_table .price_in_table .value {
                color: #ED1B24;
            }

        .specialities-icon .sketch-font-foodeez-hot-plate-icons, .review-icon .sketch-font-foodeez-hot-dish-icon, .about-icon.sketch-font-foodeez-hot-dish-icon, .about_page_content .about_icon1 .sketch-font-foodeez-house-icon, .about_page_content .about_icon2 .sketch-font-foodeez-martini-wine-glass-icon, .icon_image_cap .sketch-font-foodeez-chief-cap-icon, #about_logos_block .icon_image_fog .sketch-font-foodeez-fork-knife-icon, .iconbox-icon a.skt-featured-icons i {
            color: #FFB73D;
        }

        .sketch_price_table .active_best_price {
            background-color: #FFB73D;
        }

        .skepost-meta {
            border-bottom: 1px solid rgba(127,191,0,.2);
            border-top: 1px solid rgba(127,191,0,.2);
        }

        .single-menu-rating, .single-menu-item-price, .single-menu-item-vnveg, .single-menu-itemtype, #ske-like-dislike {
            border-bottom: 1px solid rgba(127,191,0,.2);
        }

        .fdz-map-overlay {
            background-image: url('wp-content/themes/foodeez/images/map-cover.png');
        }

        *::-moz-selection {
            background: #ED1B24;
            color: #fff;
        }

        ::selection {
            background: #ED1B24;
            color: #fff;
        }

        #skenav ul li.current_page_item > a,
        #skenav ul li.current-menu-ancestor > a,
        #skenav ul li.current-menu-item > a,
        #skenav ul li.current-menu-parent > a, #skenav ul li.current_page_ancestor > a {
            background-color: #ED1B24;
            color: #fff;
        }

        #skenav ul ul li a:hover {
            background-color: #ED1B24;
            color: #fff;
        }

        .sticky-post {
            border-color: #ED1B24;
        }

        #searchform input[type="submit"] {
            background: none repeat scroll 0 0 #ED1B24;
        }

        .col-one .box .title, .col-two .box .title, .col-three .box .title, .col-four .box .title {
            color: #ED1B24 !important;
        }

        .full-bg-breadimage-fixed {
        }

        #full-division-box {
            background-image: url("wp-content/themes/foodeez/images/Background2.jpg");
        }

        .footer-top-border {
            border: 2px solid #ED1B24;
        }

        .front-page #wrapper {
            background: none repeat scroll 0 0 rgba(0, 0, 0, 0);
        }


        /******************* HEADER & FOOTER BACKGROUND IMAGE ******************/
        .header-top-wrap {
            background: url("wp-content/themes/foodeez/images/Background2.jpg") no-repeat fixed top center transparent;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        #footer_strip {
            background: url("wp-content/themes/foodeez/images/footer-strip-bg.jpg") no-repeat scroll top center transparent;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
            display: block;
        }

        /************** CONTACT PAGE HEADER & FOOTER BACKGROUND IMAGE **********/
        .page-template-template-contact-page-php .header-top-wrap {
            background: none;
        }

        .page-template-template-contact-page-php #footer_strip {
            background: url("wp-content/themes/foodeez/images/footer-strip-bg.jpg") no-repeat scroll top center transparent;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
            display: block;
        }

        /******************** ABOUT PAGE & CNTACT PAGE HEIGHT ******************/


        /************** ABOUT PAGE HEADER & FOOTER BACKGROUND IMAGE ************/
        .page-template-template-about-page-php .header-top-wrap {
            background: url("wp-content/themes/foodeez/images/page-title-img.jpg") no-repeat scroll top center transparent;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        .page-template-template-about-page-php #footer_strip {
            background: url("wp-content/themes/foodeez/images/footer-strip-bg.jpg") no-repeat scroll top center transparent;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
            display: block;
        }

        blockquote.sketch-quote, blockquote {
            margin-bottom: 27px;
            border-left: 8px solid #ED1B24;
            border-radius: 10px;
            border-right: 8px solid;
            border-style: solid;
            border-width: 1px 8px;
        }

        /************** DISH OF DAY ************/
        .ih-item.square.effect6 .info {
            background-color: rgba(127,191,0,.6);
        }

        /************** NAVIGATION *************/
        #skenav li a:hover, #skenav .sfHover {
            background-color: #333333;
            color: #FFFFFF;
        }

            #skenav .sfHover a {
                color: #FFFFFF;
            }

        #skenav ul ul li {
            background: none repeat scroll 0 0 #333333;
            color: #FFFFFF;
        }

        #skenav ul ul li {
            background: none repeat scroll 0 0 #333333;
            color: #FFFFFF;
        }

        #skenav .ske-menu #menu-secondary-menu li a:hover, #skenav .ske-menu #menu-secondary-menu .current-menu-item a {
            color: #71C1F2;
        }

        .footer-seperator {
            background-color: rgba(0,0,0,.2);
        }

        #skenav .ske-menu #menu-secondary-menu li .sub-menu li {
            margin: 0;
        }


        .skehead-headernav .logo {
            height: 40px;
            width: 156px;
        }

        completionList {
            border: solid 1px #444444;
            height: 17px;
            overflow: auto;
            background-color: #FFFFFF;
            list-style-type: none;
            z-index: 10000;
        }

        .listItem {
            color: #FD000A;
            font-size: 17px;
            list-style-type: none;
            cursor: pointer;
            height: 30px;
            padding-top: 5px;
            z-index: 10000;
        }

        .itemHighlighted {
            background-color: #73A908;
            font-size: 17px;
            color: white;
            cursor: pointer;
            list-style-type: none;
            padding-top: 5px;
            height: 30px;
            z-index: 10000;
        }

        #header .links {
            background: url("../image/bullet-d.png") no-repeat scroll right center rgba(0, 0, 0, 0);
            cursor: pointer;
            float: left;
            margin: 0 7px;
            padding-right: 10px;
            position: relative;
            z-index: 1011;
        }
    </style>

    <script src="script.js"></script>
    <link href="styles.css" rel="stylesheet" />

    <script type="text/javascript">
        jQuery('document').ready(function () {
            jQuery('ul#menu-main').sktmobilemenu({ 'fwidth': '1140' });
        });
    </script>
    <!-- Foodeez Custom CSS Section Starts Here -->

    <!-- Foodeez Custom CSS Section Ends Here -->
    <style type="text/css">
        .ex1 img {
            height: 135px;
            width: 135px;
            float: left;
            margin: 15px;
            -webkit-transition: margin 0.5s ease-out;
            -moz-transition: margin 0.5s ease-out;
            -o-transition: margin 0.5s ease-out;
        }

            .ex1 img:hover {
                margin-top: 4px;
            }
    </style>
  
</head>
<body class="page page-id-169 page-template page-template-template-fullwidth-php">
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="wrapper" class="skepage">
            <div class="header-top-wrap">
                <!-- IF IS CONTACT PAGE TEMPLATE -->
                <!-- IF IS CONTACT PAGE TEMPLATE END -->
                <div id="header" class="skehead-headernav clearfix" style="top: 0px; display: block;">
                    <div id="skehead">
                        <div class="container">
                            <div class="row-fluid">
                                <div class="header-topbar clearfix">
                                    <div class="container">
                                        <div class="row-fluid">
                                            <!-- #logo -->
                                            <div id="logo" class="span3">
                                                <a href="Default.aspx">
                                                    <img src="Images/redjinnilogo.png" class="logo" />
                                                </a>
                                            </div>
                                            <!-- #logo -->
                                            <div class="span5">
                                                <!-- Top Contact Info -->
                                                <div class="topbar_info">
                                                    <div class="span12">
                                                        <img src="Images/Untitled_2.png" class="callusnow2 callusnow" />
                                                    </div>
                                                </div>
                                                <!-- Top Contact Info -->
                                            </div>
                                            <a href="registraion_form.aspx">
                                                <asp:Label ID="lbl_login" class="res-button signup2 signup1" runat="server" Text="Login"></asp:Label></a>
                                            <a href="registraion_form.aspx">
                                                <asp:Label ID="lbl_signup" class="res-button signup2 signup1" runat="server" Text="Sign up"></asp:Label></a>
                                            <asp:Panel ID="pnl_profile" runat="server" Visible="false">
                                                <div id='cssmenu'>
                                                    <ul>
                                                        <li class='has-sub' style="margin-left: 14%;"><a href='#'><span>
                                                            <asp:Label ID="lbl_name" runat="server" Text="Label" Style="font-size: 15px; font-weight: bold;"></asp:Label></a></span></a>
                                                        <ul>
                                                            <li id="menu-item-210" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-210"><a href="order_details.aspx">My restaurants order status</a></li>
                                                            <li id="menu-item-209" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-209 "><a href="history.aspx">My restaurants order history</a></li>
                                                            <li id="Li5" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-210"><a href="bakery_order_details.aspx">My bakery order status</a></li>
                                                            <li id="Li2" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-209"><a href="cake_order_report.aspx">My bakery order history</a></li>
                                                            <li id="Li6" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-210"><a href="flower_shop_order_details.aspx">My flower shop order status</a></li>
                                                            <li id="Li3" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-209"><a href="flower_order_report.aspx">My flower shop order history</a></li>
                                                            <li id="menu-item-286" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-286"><a href="profile.aspx">My profile</a></li>
                                                            <li id="Li1" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-286">
                                                                <asp:LinkButton ID="lbl_logout" OnClick="LinkButton1_Click" runat="server">Logout</asp:LinkButton></li>
                                                        </ul>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- header-topbar -->
                <!-- search-strip -->
                <div id="featured-box" class="skt-section">
                    <div class="container">
                        <div class="mid-box-mid row-fluid">
                            <div class="ex1 icon2">

                                <a href="restaurants_list.aspx">
                                    <img src="wp-content/uploads/Restaurant.png"></a>
                                <a href="deals.aspx">
                                    <img src="wp-content/uploads/Deals.png"></a>
                                <a href="new_resturants.aspx">
                                    <img src="wp-content/uploads/New.png"></a>
                                <a href="new_item.aspx">
                                    <img src="wp-content/uploads/Most-popular.png"></a>
                                <a href="bakery_list.aspx">
                                    <img src="wp-content/uploads/Cakes.png"></a>
                                <a href="Flower.aspx">
                                    <img src="wp-content/uploads/Flower-shop.png"></a>
                                <a href="Organise_a_party.aspx">
                                    <img src="wp-content/uploads/Organize-a-party1.png"></a>
                            </div>
                            <!-- Featured Box 1 -->







                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <div class="searchbar span12" style="margin-top: 10px;">
                    <div class="row-fluid search2 search3">
                        <div class="span3">
                            <asp:TextBox ID="txt_searcharea" runat="server" Style="padding: 9px; color: #ED1B24;" name="your-email" size="40" class="search1" placeholder="Search Area"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                Enabled="true" ServicePath="area_service.asmx" MinimumPrefixLength="1" ServiceMethod="Get_service_name"
                                TargetControlID="txt_searcharea">
                            </cc1:AutoCompleteExtender>
                        </div>
                        <div class="span3">
                            <asp:TextBox ID="txt_search_restaurants" runat="server" Style="padding: 9px; color: #ED1B24;" name="your-email" size="40" class="search1" placeholder="Search Restaurants"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                                Enabled="true" ServicePath="restaurants_service.asmx" MinimumPrefixLength="1" ServiceMethod="Get_resturants_name"
                                TargetControlID="txt_search_restaurants">
                            </cc1:AutoCompleteExtender>
                        </div>
                        <div class="span3">
                            <asp:TextBox ID="txt_search_dish" runat="server" size="40" Style="padding: 9px; color: #ED1B24;" class="search1" placeholder="Search Dish"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                                Enabled="true" ServicePath="dish_service.asmx" MinimumPrefixLength="1" ServiceMethod="Get_item_name"
                                TargetControlID="txt_search_dish">
                            </cc1:AutoCompleteExtender>
                        </div>
                        <div class="span2">
                            <a>
                                <asp:Button ID="btn_search" class="res-button" runat="server" Style="margin-top: 2%;" OnClick="btn_search_Click" Text="Search"></asp:Button></a>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #header -->
        </div>

        <!-- header image section -->

        <div id="main" class="clearfix">
            <!-- AWESOME PARALLAX SECTION -->
            <div id="full-division-box" class="skt-section">
                <div class="container full-content-box" style="padding: 5px 0 5px;">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="dod-icon"></div>
                            <div class="dod-bottom-icon"></div>
                            <!-- pagination here -->
                            <div id="skt-menu-items" class="owl-carousel skt_animate_when_almost_visible skt_bottom-to-top" style="background-color: #ffffff;">
                                <!-- the loop -->
                                <div class="item">
                                    <h2><a href="#">Hot Offers</a></h2>
                                    <div class="feature_image">
                                        <img src="Images/Foodeez-SGF-Strawberry-Rhubarb-Nest-350x325_1.jpg" style="height: 0; width: 0;" alt="Menu Thumbnail" />
                                    </div>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Image1" runat="server" class="deafultimage defaultimage2" ImageUrl='<%#Eval("image") %>' CommandArgument='<%#Eval("code") %>' OnClick="ImageButton1_Click" />
                                            <br />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="item">
                                    <h2><a href="#">Featured Restaurants</a></h2>
                                    <div class="feature_image">
                                        <asp:Label ID="Label2" runat="server" Text="Label" Style="visibility: hidden;"></asp:Label>
                                        <img src="Images/Foodeez-SGF-Strawberry-Rhubarb-Nest-350x325_1.jpg" style="height: 0; width: 0;" alt="Menu Thumbnail" />
                                    </div>
                                    <asp:Repeater ID="Repeater2" runat="server">
                                        <ItemTemplate>
                                            <div class="skt-rate-price clearfix">
                                                <a href="restaurant_menu.aspx?id=<%#Eval("code") %>">
                                                    <div class="menu-item-price" style="text-align: left; margin-top: 0px; width: 77%;">
                                                        <span style="font-size: 18px;"><%#Eval("tital") %></span>
                                                    </div>
                                                </a>
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("foodtype") %>' Visible="false"></asp:Label>
                                                <span class="menu-post-rating-stars" title="" style="float: right; padding-right: 10px; margin-top: 4px;">
                                                    <asp:Image ID="veg" ImageUrl="wp-content/themes/foodeez/images/veg.jpg" Visible="false" title="Veg" runat="server"></asp:Image>
                                                    <asp:Image ID="nonveg" ImageUrl="wp-content/themes/foodeez/images/cup-rate-active.jpg" title="Non Veg" Visible="false" runat="server" Style="margin-top: 8px;"></asp:Image>
                                                </span>
                                            </div>
                                            <asp:ImageButton ID="Image1" runat="server" ImageUrl='<%#Eval("image") %>' class="deafultimag3 defaultimage4" CommandArgument='<%#Eval("code") %>' OnClick="ImageButton1_Click" />
                                            <br />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="item">
                                    <h2><a href="#">User Reviews</a></h2>
                                    <div class="feature_image">
                                        <img src="Images/Foodeez-SGF-Strawberry-Rhubarb-Nest-350x325_1.jpg" style="height: 0; width: 0;" alt="Menu Thumbnail" />
                                    </div>
                                    <asp:Repeater ID="Repeater3" runat="server">
                                        <ItemTemplate>
                                            <div class="skt-rate-price clearfix">
                                                <a href="restaurant_menu.aspx?id=<%#Eval("code") %>">
                                                    <div class="menu-item-price" style="text-align: left; margin-top: 0px; width: 77%;">
                                                        <span style="font-size: 18px;"><%#Eval("tital") %></span>
                                                    </div>
                                                </a>
                                                <span class="menu-post-rating-stars" title="" style="float: left; margin: 15px 1px 1px -40px;">
                                                    <cc1:Rating ID="Rating1" runat="server" OnChanged="Rating1_Changed" AutoPostBack="true" ReadOnly="true"
                                                        StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="Star"
                                                        FilledStarCssClass="ratingFilled" CurrentRating='<%# Eval("Rating") %>'>
                                                    </cc1:Rating>
                                                </span>
                                            </div>
                                            <div class="menu-item-content" style="margin-bottom: -2%; margin-top: 0; text-align: left;">
                                                <span style="color: #ED1B24;"><%#Eval("name") %></span>
                                                <br />
                                                <%#Eval("location") %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!-- end of the loop -->
                            </div>
                            <!-- pagination here -->
                        </div>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                jQuery(document).ready(function () {



                    jQuery("#skt-menu-items").owlCarousel({
                        items: 3,
                        lazyLoad: true,
                        navigation: true,
                        autoPlay: true,
                        pagination: false
                    });

                });
            </script>




            <div class="clearfix"></div>
        </div>
        <!-- #main -->
        <!-- #footer -->
        <div id="footer">
            <div class="container">
                <div class="row-fluid">
                    <div class="second_wrapper">
                        <div id="text-2" class="ske-footer-container span3 ske-container widget_text">
                            <div class="textwidget">
                                <a class="foot-logo">
                                    <img src="Images/redjinnilogo.png" />
                                </a>
                                <div style="height: 10px;"></div>
                                <span id="docs-internal-guid-1559beca-7549-cb19-d74c-42cb28707503" style="color: #333;"><span>Redjinni.com</span><span> is run by </span><span>Redpill Online Services Pvt Ltd</span><span>. We are a team of young professionals who have come together to develop exciting solutions to everyday problems.</span></span>
                                <asp:LinkButton ID="link_read_more" runat="server" CommandArgument='<%#Eval("code") %>' OnClick="link_read_more_Click">Read More...</asp:LinkButton>
                            </div>
                        </div>
                        <div id="nav_menu-2" class="ske-footer-container span3 ske-container widget_nav_menu">
                            <h3 class="ske-title ske-footer-title">Menu</h3>
                            <div class="menu-foot-menu-container">
                                <ul class="menu">
                                    <li class="menu-item menu-item-type-post_type menu-item-object-skt_menu_items menu-item-106"><a href="about_us.aspx">About Us</a></li>
                                    <li class="menu-item menu-item-type-post_type menu-item-object-skt_menu_items menu-item-108"><a href="Contact.aspx">FAQ'S</a></li>
                                    <li class="menu-item menu-item-type-post_type menu-item-object-skt_menu_items menu-item-110"><a href="term_condition.aspx">Terms & Condition</a></li>
                                    <li class="menu-item menu-item-type-post_type menu-item-object-skt_menu_items menu-item-107"><a href="Privacy_Policy.aspx">Privacy Policy</a></li>
                                    <li class="menu-item menu-item-type-post_type menu-item-object-skt_menu_items menu-item-126"><a href="Contact.aspx">Contact Us</a></li>
                                </ul>
                            </div>
                        </div>
                        <div id="sktfollowwidget-2" class="ske-footer-container span3 ske-container SktFollowContact">
                            <h3 class="ske-title ske-footer-title">Follow Us</h3>
                            <div class="follow-icons">
                                <ul class="social clearfix">

                                    <li class="facebook-icon"><a target="_blank" href="https://www.facebook.com/people/Red-Jinni/100009271336555" title="Facebook"></a></li>
                                    <li class="twitter-icon"><a target="_blank" href="https://twitter.com/red_jinni" title="Twitter"></a></li>

                                    <li class="pinterest-icon"><a target="_blank" href="https://in.pinterest.com/red_jinni/" title="Pinterest"></a></li>

                                </ul>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div id="Div1" class="ske-footer-container span3 ske-container widget_nav_menu">
                            <h3 class="ske-title ske-footer-title">Links</h3>
                            <div class="menu-foot-menu-container">
                                <ul id="menu-foot-menu" class="menu">
                                    <li id="menu-item-109" class="menu-item menu-item-type-post_type menu-item-object-skt_menu_items menu-item-109"><a href="restaurants_list.aspx">Restaurant</a></li>
                                    <li id="menu-item-106" class="menu-item menu-item-type-post_type menu-item-object-skt_menu_items menu-item-106"><a href="deals.aspx">Deals</a></li>
                                    <li id="menu-item-108" class="menu-item menu-item-type-post_type menu-item-object-skt_menu_items menu-item-108"><a href="new_resturants.aspx">New Restaurant</a></li>
                                    <li id="menu-item-110" class="menu-item menu-item-type-post_type menu-item-object-skt_menu_items menu-item-110"><a href="new_item.aspx">Most Popular Item</a></li>
                                    <li id="menu-item-107" class="menu-item menu-item-type-post_type menu-item-object-skt_menu_items menu-item-107"><a href="bakery_list.aspx">Cakes And Bakery</a></li>
                                    <li id="menu-item-126" class="menu-item menu-item-type-post_type menu-item-object-skt_menu_items menu-item-126"><a href="Flower.aspx">Flower</a></li>
                                    <li id="Li4" class="menu-item menu-item-type-post_type menu-item-object-skt_menu_items menu-item-126"><a href="Organise_a_party.aspx">Organise A Party</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <!-- second_wrapper -->
                </div>
            </div>
            <div class="third_wrapper">
                <div class="container">
                    <div class="row-fluid">
                        <div class="copyright span6 alpha omega">Copyright &copy; 2015 Redjinni. All rights reserved.</div>
                        <div class="owner span6 alpha omega">Powered by: <a href="http://webcodetechnologies.com/" style="color: #ffffff;" target="_blank">Webcode Technologies</a></div>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- third_wrapper -->
        </div>
        <!-- #footer -->
        </div>
        <!-- #wrapper -->
        <a href="JavaScript:void(0);" title="Back To Top" id="backtop"></a>
        <!-- Start analytics code 16/10/2014 3:51:02 PM -->


        <script type="text/javascript">

            //FULL WIDTH SLIDER HEIGHT	

            jQuery(document).ready(function () {

                'use strict';

                jQuery(".flexslider ul.slides,.flexslider ol.flex-control-nav").css({ 'visibility': 'hidden' });

                jQuery(window).resize(function () {

                    var fullwidth = jQuery(window).width();

                    jQuery('.flexslider').width(fullwidth).height('auto');

                });

            });


            jQuery(window).load(function () {

                'use strict';

                jQuery(".flexslider .slides .flex-caption").each(function () {

                    var flxSldrHt = jQuery(".flexslider .slides > li img").height() - 8;

                    var flxSlideHt = jQuery(this).outerHeight(true);

                    var flxSlideTop = (flxSldrHt / 2) - (flxSlideHt / 2);

                    jQuery(this).css({ 'top': flxSlideTop });
                });

            });

            jQuery(window).resize(function () {

                'use strict';

                jQuery(".flexslider .slides .flex-caption").each(function () {

                    var flxSldrHt = jQuery(".flexslider .slides > li img").height() - 8;

                    var flxSlideHt = jQuery(this).outerHeight(true);

                    var flxSlideTop = (flxSldrHt / 2) - (flxSlideHt / 2);

                    jQuery(this).css({ 'top': flxSlideTop });
                });

            });



            jQuery(window).load(function () {

                'use strict';

                jQuery(".flexslider ul.slides,.flexslider ol.flex-control-nav,.flexslider ul.flex-direction-nav").css({ 'visibility': 'visible' });

                var fullwidth = jQuery(window).width();

                jQuery('.flexslider').width(fullwidth).height('auto');

            });



            jQuery(document).ready(function () {

                'use strict';



                jQuery('.flexslider').flexslider({

                    namespace: "flex-",             //{NEW} String: Prefix string attached to the class of every element generated by the plugin

                    selector: ".slides > li",       //{NEW} Selector: Must match a simple pattern. '{container} > {slide}' -- Ignore pattern at your own peril

                    animation: 'fade',              //String: Select your animation type, "fade" or "slide"

                    easing: "swing",                //{NEW} String: Determines the easing method used in jQuery transitions. jQuery easing plugin is supported!

                    direction: "horizontal",        //String: Select the sliding direction, "horizontal" or "vertical"

                    reverse: false,                 //{NEW} Boolean: Reverse the animation direction

                    animationLoop: true,            //Boolean: Should the animation loop? If false, directionNav will received "disable" classes at either end

                    smoothHeight: false,            //{NEW} Boolean: Allow height of the slider to animate smoothly in horizontal mode

                    startAt: 0,                     //Integer: The slide that the slider should start on. Array notation (0 = first slide)

                    slideshow: true,                //Boolean: Animate slider automatically

                    slideshowSpeed: 7000,          //Integer: Set the speed of the slideshow cycling, in milliseconds

                    animationSpeed: 600,            //Integer: Set the speed of animations, in milliseconds

                    initDelay: 0,                   //{NEW} Integer: Set an initialization delay, in milliseconds

                    randomize: false,               //Boolean: Randomize slide order

                    thumbCaptions: false,           //Boolean: Whether or not to put captions on thumbnails when using the "thumbnails" controlNav.



                    // Usability features

                    pauseOnAction: true,            //Boolean: Pause the slideshow when interacting with control elements, highly recommended.

                    pauseOnHover: true,          //Boolean: Pause the slideshow when hovering over slider, then resume when no longer hovering

                    pauseInvisible: true,   		//{NEW} Boolean: Pause the slideshow when tab is invisible, resume when visible. Provides better UX, lower CPU usage.

                    useCSS: true,                   //{NEW} Boolean: Slider will use CSS3 transitions if available

                    touch: true,                    //{NEW} Boolean: Allow touch swipe navigation of the slider on touch-enabled devices

                    video: false,                   //{NEW} Boolean: If using video in the slider, will prevent CSS3 3D Transforms to avoid graphical glitches



                    // Primary Controls

                    controlNav: true,              //Boolean: Create navigation for paging control of each slide? Note: Leave true for manualControls usage

                    directionNav: true,            //Boolean: Create navigation for previous/next navigation? (true/false)

                    prevText: "Previous",           //String: Set the text for the "previous" directionNav item

                    nextText: "Next",               //String: Set the text for the "next" directionNav item



                    // Secondary Navigation

                    keyboard: true,                 //Boolean: Allow slider navigating via keyboard left/right keys

                    multipleKeyboard: false,        //{NEW} Boolean: Allow keyboard navigation to affect multiple sliders. Default behavior cuts out keyboard navigation with more than one slider present.

                    mousewheel: false,              //{UPDATED} Boolean: Requires jquery.mousewheel.js (https://github.com/brandonaaron/jquery-mousewheel) - Allows slider navigating via mousewheel

                    pausePlay: false,               //Boolean: Create pause/play dynamic element

                    pauseText: "Pause",             //String: Set the text for the "pause" pausePlay item

                    playText: "Play",               //String: Set the text for the "play" pausePlay item



                    // Special properties

                    controlsContainer: "",          //{UPDATED} jQuery Object/Selector: Declare which container the navigation elements should be appended too. Default container is the FlexSlider element. Example use would be $(".flexslider-container"). Property is ignored if given element is not found.

                    manualControls: "",             //{UPDATED} jQuery Object/Selector: Declare custom control navigation. Examples would be $(".flex-control-nav li") or "#tabs-nav li img", etc. The number of elements in your controlNav should match the number of slides/tabs.

                    sync: "",                       //{NEW} Selector: Mirror the actions performed on this slider with another slider. Use with care.

                    asNavFor: "",                   //{NEW} Selector: Internal property exposed for turning the slider into a thumbnail navigation for another slider



                    // Carousel Options

                    itemWidth: 0,                   //{NEW} Integer: Box-model width of individual carousel items, including horizontal borders and padding.

                    itemMargin: 0,                  //{NEW} Integer: Margin between carousel items.

                    minItems: 1,                    //{NEW} Integer: Minimum number of carousel items that should be visible. Items will resize fluidly when below this.

                    maxItems: 0,                    //{NEW} Integer: Maxmimum number of carousel items that should be visible. Items will resize fluidly when above this limit.

                    move: 0,                        //{NEW} Integer: Number of carousel items that should move on animation. If 0, slider will move all visible items.

                    allowOneSlide: true,           //{NEW} Boolean: Whether or not to allow a slider comprised of a single slide



                    // Callback API

                    start: function (slider) {
                        slider.removeClass('loading');

                        jQuery('.flex-caption').stop().animate({ left: 0 }, 700);
                    }, //Callback: function(slider) - Fires when the slider loads the first slide

                    before: function () { jQuery('.flex-caption').stop().animate({ left: 100, opacity: 0 }, 700); },

                    // animate caption

                    after: function () { jQuery('.flex-caption').stop().animate({ left: 0, opacity: 1 }, 700); },

                    end: function () { },    //Callback: function(slider) - Fires when the slider reaches the last slide (asynchronous)

                    added: function () { },  //{NEW} Callback: function(slider) - Fires after a slide is added

                    removed: function () { } //{NEW} Callback: function(slider) - Fires after a slide is removed

                });

            });

        </script>
        <script type="text/javascript">
            // <![CDATA[ 
            var isProcessing = false;
            function alter_ul_post_values(obj, post_id, ul_type) {
                if (isProcessing)
                    return;

                isProcessing = true;
                var strt = jQuery(obj).find("span.ldc_counts").html();
                var count = strt.replace(/^\s+|\s+$/g, '');

                jQuery(obj).find("span.ldc_counts").html("..");
                jQuery.ajax({
                    type: "POST",
                    url: 'http://sketchthemes.com/samples/foodeez-multi-cuisine-restaurant-demo/wp-content/themes/foodeez/SketchBoard/functions/modules/sketch-ldc/ajax_counter.php',
                    data: "post_id=" + post_id + "&up_type=" + ul_type,
                    success: function (msg) {
                        if (count == msg.replace(/^\s+|\s+$/g, '')) {
                            jQuery(obj).find(".alert-msg").empty().html("Already voted!").stop(true, true).fadeIn(400).delay(1000).fadeOut(400);
                        }
                        else {
                            jQuery(obj).find(".alert-msg").empty().html("Thanks for your vote!").stop(true, true).fadeIn(400).delay(1000).fadeOut(400);
                        }
                        jQuery(obj).find("span.ldc_counts").html(msg);
                        isProcessing = false;
                    }
                });
            }
            // ]]> 
        </script>
        <div class="revsliderstyles">
            <style type="text/css">
                .tp-caption.black {
                    color: #000;
                    text-shadow: none;
                }

                .black {
                    color: #000;
                    text-shadow: none;
                }
            </style>
        </div>
        <script type='text/javascript' src='wp-content/themes/foodeez/js/jquery.flexslider-min5152.js?ver=1.0'></script>
        <script type='text/javascript' src='wp-includes/js/comment-reply.minf39e.js?ver=4.0.1'></script>
        <script type='text/javascript' src='wp-content/plugins/contact-form-7/includes/js/jquery.form.mind03d.js?ver=3.51.0-2014.06.20'></script>
        <script type='text/javascript'>
            /* <![CDATA[ */
            var _wpcf7 = { "loaderUrl": "http:\/\/sketchthemes.com\/samples\/foodeez-multi-cuisine-restaurant-demo\/wp-content\/plugins\/contact-form-7\/images\/ajax-loader.gif", "sending": "Sending ..." };
            /* ]]> */
        </script>
        <script type='text/javascript' src='wp-content/plugins/contact-form-7/includes/js/scripts657a.js?ver=3.9.3'></script>
        <script type='text/javascript' src='wp-includes/js/hoverIntent.min5618.js?ver=r7'></script>
        <script type='text/javascript' src='wp-content/themes/foodeez/js/superfish68b3.js?ver=1'></script>
        <script type='text/javascript' src='wp-content/themes/foodeez/js/cbpAnimatedHeader68b3.js?ver=1'></script>
        <script type='text/javascript' src='wp-content/themes/foodeez/js/jquery.easing.1.35152.js?ver=1.0'></script>
        <script type='text/javascript' src='wp-content/themes/foodeez/js/waypoints.min5152.js?ver=1.0'></script>
        <script type='text/javascript' src='wp-content/themes/foodeez/js/owl.carousel5152.js?ver=1.0'></script>
        <script type='text/javascript' src='wp-content/themes/foodeez/js/jquery.timepicker.min5152.js?ver=1.0'></script>
        <script type='text/javascript' src='wp-content/themes/foodeez/js/bootstrap-datepicker5152.js?ver=1.0'></script>
        <script type='text/javascript' src='wp-content/themes/foodeez/js/jquery.validate.min5152.js?ver=1.0'></script>
        <script type='text/javascript' src='wp-content/themes/foodeez/js/jquery.prettyPhoto68b3.js?ver=1'></script>
        <script type='text/javascript' src='wp-content/themes/foodeez/SketchBoard/functions/modules/shortcodes/js/sketch-shortcodes5152.js?ver=1.0'></script>
        <script type='text/javascript' src='wp-content/themes/foodeez/SketchBoard/functions/modules/shortcodes/js/jquery.tipTip5152.js?ver=1.0'></script>
    </form>
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
    <!--Start of Zopim Live Chat Script-->
    <script type="text/javascript">
        window.$zopim || (function (d, s) {
            var z = $zopim = function (c) { z._.push(c) }, $ = z.s =
            d.createElement(s), e = d.getElementsByTagName(s)[0]; z.set = function (o) {
                z.set.
                _.push(o)
            }; z._ = []; z.set._ = []; $.async = !0; $.setAttribute("charset", "utf-8");
            $.src = "//v2.zopim.com/?36Cb4iJejzuNsoniLJrbksloOKPQsop8"; z.t = +new Date; $.
            type = "text/javascript"; e.parentNode.insertBefore($, e)
        })(document, "script");
    </script>
    <!--End of Zopim Live Chat Script-->
</body>
</html>
