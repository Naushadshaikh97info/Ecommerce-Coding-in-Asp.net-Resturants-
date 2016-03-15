<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="item_order.aspx.cs" Inherits="item_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <title>Redjinni - Food Delivery Surat, Food Delivery Surat, Food at Home, Online Food Order in Surat, Online Food Order</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="clearfix">
        <div class="main-wrapper-item">
            <div class="bread-title-holder">
                <div class="bread-title-bg-image full-bg-breadimage-fixed"></div>
                <div class="container">
                    <div class="row-fluid">
                        <div class="container_inner clearfix">
                            <h1 class="title">Item  Description</h1>
                            <section class="cont_nav">
                                <div class="cont_nav_inner">
                                    <p><a href="Default.aspx">Home</a>&nbsp;<span class="skt-breadcrumbs-separator"> &gt;&gt; </span>&nbsp;<span>Item Description</span></p>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
            <div class="page-content default-pagetemp">
                <div class="container post-wrap">
                    <div class="row-fluid">
                        <div id="content" class="span8">
                            <%-- <h1 style="text-align: center; font-size: 35px;">Item Discription</h1>--%>
                            <div class="post clearfix" id="post-24">
                                <div class="skepost">
                                    <div id="foodeez_reservation" class="foodeez_reservation">
                                        <div>
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                                    <div class="input_wrap">
                                                        <asp:Label ID="lbl_name" runat="server" Text='<%#Eval("name") %>' Style="text-align: center; color: #ED1B24; font-size: 25px; margin: 0 14% 1% 38%;"></asp:Label>
                                                        <asp:Image ID="Image1" ImageUrl='<%#Eval("image") %>' runat="server" Width="350" Height="350" Style="margin-left: 27%;"></asp:Image>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <div class="reservation_status" id="reservation_status"></div>
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
                        <div id="sidebar" class="span4">
                            <div id="sidebar_2" class="ske_widget">
                                <ul class="skeside">
                                    <li id="search-3" class="ske-container widget_search">
                                        
                                    </li>
                                    <li id="sktopening_hours-2" class="ske-container skt-opening-hours-widget">
                                        <h3 class="ske-title">Restaurant :</h3>
                                        <ul class="opening-hours-list">
                                            <div style="float: left;">
                                                <asp:RadioButtonList ID="rb_resturants"  DataValueField="intglcode"  DataTextField="resturant_name"  runat="server" Style="margin-left: 16px; color: #333333; font-size: 15px;">
                                                </asp:RadioButtonList>
                                            </div>
                                        </ul>
                                    </li>
                                    <asp:DropDownList ID="ddl_quantity" runat="server" style="width: 22%;">
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
                                    <asp:Button ID="btn_orderthisitem" runat="server" OnClick="btn_orderthisitem_Click" Style="margin-left: 33px;" Text="Order This Item" CssClass="btn1"></asp:Button>
                                </ul>
                            </div>
                            <!-- #sidebar_2 .ske_widget -->
                        </div>
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

