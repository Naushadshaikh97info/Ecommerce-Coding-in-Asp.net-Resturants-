<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="order_details.aspx.cs" Inherits="order_details" %>

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
                            <h1 class="title"><span style="font-family: fontawesome;">Restaurants Order Status</span></h1>
                            <section class="cont_nav">
                                <div class="cont_nav_inner">
                                    <p><a href="Default.aspx">Home</a>&nbsp;<span class="skt-breadcrumbs-separator"> &gt;&gt; </span>&nbsp;<span>Restaurants Order Status</span></p>
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
                            <div class="post" id="post-169">
                                <div class="skepost">
                                    <div class="contact_form_title">
                                       <span class="order_title">Restaurants Order Status</span>
                                    </div>
                                      <asp:Panel ID="Panel2" runat="server" >
                                    <table style="border: 1px solid #ED1B24; margin: 0 -2px -1px; text-align: left; width: 100%;">
                                        <tbody style="border: 1px solid #ED1B24; margin: 0 -2px -1px; text-align: left; width: 100%; background-color: #ED1B24;">
                                            <tr>
                                                <th style="width: 10%; color: white; font-size: 15px;">Order#</th>
                                                <th style="width: 10%; color: white; font-size: 15px;">Customer Name</th>
                                                <th style="width: 11%; color: white; font-size: 15px;">Mobile No.</th>
                                                <th style="width: 13%; color: white; font-size: 15px;">Email</th>
                                                <th style="padding-right: 3%; width: 10%; color: white; font-size: 15px;">Total Amount(र)</th>
                                                <th style="width: 6%; color: white; font-size: 15px;">Status</th>
                                                <th style="width: 7%; color: white; font-size: 15px;">Cancel Order</th>
                                            </tr>
                                        </tbody>
                                        <asp:GridView ID="grd_order" AllowPaging="true" AutoGenerateColumns="false" CssClass="orderno2 orderno" DataKeyNames="code" ShowHeader="false"
                                            PageSize="20" runat="server" Width="99.8%" GridLines="None" OnPageIndexChanging="grd_order_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Order#" ControlStyle-CssClass="shoping3 orderno2" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton12" runat="server" Style="color:#ED1B24;" CommandArgument='<%#Eval("code") %>'
                                                            ForeColor="Blue" Text='<%#Eval("order_no") %>' OnClick="onclick_order"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Customer Name" DataField="name"  ControlStyle-CssClass="shoping3 orderno2" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Font-Bold="false" />
                                                <asp:BoundField HeaderText="Mobile No." DataField="mobile"  ControlStyle-CssClass="shoping3 orderno2" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Font-Bold="false" />
                                                <asp:BoundField HeaderText="Email" DataField="date"  ControlStyle-CssClass="shoping3 orderno2" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Font-Bold="false" />
                                                <asp:BoundField HeaderText="Total Amount(र)" DataField="amount"  ControlStyle-CssClass="shoping3 orderno2" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Font-Bold="false" />
                                                <asp:BoundField HeaderText="Status" DataField="status"  ControlStyle-CssClass="shoping3 orderno2" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Font-Bold="false" />
                                                <asp:TemplateField HeaderText="Cancel Order"  ControlStyle-CssClass="shoping3 orderno2" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton13" runat="server" CommandArgument='<%#Eval("code") %>'
                                                            ForeColor="Blue" Text="Cancel" OnClick="LinkButton12_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </table>
                                      </asp:Panel>
                                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                                    <table class="table table-bordered table-striped" id="Table6">
                                        <tr>
                                            <td>
                                                <h3>View Order Detail</h3>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="grd_shopingcart" AllowPaging="true" AutoGenerateColumns="false"
                                                    DataKeyNames="code" runat="server" Width="100%" GridLines="None">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Product Name" DataField="productcode" ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-Font-Bold="false" />
                                                        <asp:BoundField HeaderText="Resturant Name" DataField="ResturantName" ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-Font-Bold="false" />
                                                        <asp:BoundField HeaderText="Quantity" DataField="qty" ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-Font-Bold="false" />
                                                        <asp:BoundField HeaderText="Price" DataField="price" ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-Font-Bold="false" />
                                                        <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("img")%>' Height="70px" Width="70px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                        </asp:Panel>
                                </div>

                                <!-- skepost -->
                            </div>
                            <!-- post -->
                        </div>




                        <!-- content -->
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

