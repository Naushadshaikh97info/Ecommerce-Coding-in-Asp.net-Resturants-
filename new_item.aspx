<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="new_item.aspx.cs" Inherits="new_item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Redjinni - Food Delivery Surat, Food Delivery Surat, Food at Home, Online Food Order in Surat, Online Food Order</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="clearfix">
        <div id="contact_page_temp" class="main-wrapper-item">
            <div class="bread-title-holder">
                <div class="bread-title-bg-image full-bg-breadimage-fixed"></div>
                <div class="container">
                    <div class="row-fluid">
                        <div class="container_inner clearfix">
                            <h1 class="title">Most Popular Item</h1>
                            <section class="cont_nav">
                                <div class="cont_nav_inner">
                                    <p><a href="Default.aspx">Home</a>&nbsp;<span class="skt-breadcrumbs-separator"> &gt;&gt; </span>&nbsp;<span>Most Popular Item</span></p>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
            <div class="page-content default-pagetemp">
                <div class="container post-wrap" style="margin-left: 9%;">
                    <!-- .CONTACT TOP BLOCK CONTENT STARTS -->
                    <a>
                        <h1 style="text-align: center; font-size: 35px;">Most Popular Item</h1>
                        <%--   <div class="border-content-box bottom-space"></div>--%>
                    </a>
                    <div class="border-content-box bottom-space"></div>
                    <div class="contact_top_block clearfix">
                        <div class="page-container clearfix">
                           <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <div runat="server" id="new_item" class="one_fourth last" style="width: 25%;">
                                        <asp:Image ID="Image1" ImageUrl='<%#Eval("image")%>' Width="250" Height="200" runat="server"></asp:Image>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("code") %>' />
                                        <label class="subtitle" style="color: #000; display: block; float: left; font-size: 11px; font-weight: bolder; margin: -2% -2% 1% 0; width: 100%;">
                                            <%#Eval("item_name") %></label><br>
                                        <asp:Button ID="btn_orderthisitem" runat="server" CommandArgument='<%#Eval("code") %>' Text="Order This Item" CssClass="btn1" OnClick="btn_orderthisitem_Click" Style="margin-left: 12%;"></asp:Button>
                                        <br>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <!-- .CONTACT TOP BLOCK CONTENT ENDS -->
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



