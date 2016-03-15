<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="new_resturants.aspx.cs" Inherits="new_resturants1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Redjinni - Food Delivery Surat, Food Delivery Surat, Food at Home, Online Food Order in Surat, Online Food Order</title>
    <style type='text/css'>
        .deals1 {
            height: auto;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="clearfix">
        <div class="bread-title-holder">
            <div class="bread-title-bg-image full-bg-breadimage-fixed"></div>
            <div class="container">
                <div class="row-fluid">
                    <div class="container_inner clearfix">
                        <h1 class="title">New Resturants</h1>
                        <section class="cont_nav">
                            <div class="cont_nav_inner">
                                <p><a href="Default.aspx">Home</a>&nbsp;<span class="skt-breadcrumbs-separator"> &gt;&gt; </span>&nbsp;<span>New Resturants</span></p>
                            </div>
                        </section>
                    </div>
                </div>
            </div>
        </div>
        <div class="page-content fullwidth-temp">
            <div class="container post-wrap">
                <div class="row-fluid">
                    <div id="content" class="span12">
                        <div class="post" id="post-154">
                            <div class="skepost">
                                <div class="page-container clearfix">
                                    <asp:DataList ID="Repeater1" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnl_resturant" runat="server">
                                                <div runat="server" id="new_item" style="margin-left: 2px; padding-right: 9px;">
                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("code") %>' />
                                                    <asp:ImageButton ID="ImageButton1" CssClass="deals1 deals2" runat="server" ImageUrl='<%#Eval("image") %>' OnClick="ImageButton1_Click" CommandArgument='<%#Eval("code") %>'></asp:ImageButton>
                                                    <asp:Label ID="Label1" runat="server" Style="color: #000; font-size: 21px; font-weight: bolder;"
                                                        Text='<%#Eval("item_name") %>'></asp:Label>
                                                </div>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                                <br />
                            </div>
                            <!-- skepost -->
                        </div>
                        <!-- post -->
                    </div>
                    <!-- content -->
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


