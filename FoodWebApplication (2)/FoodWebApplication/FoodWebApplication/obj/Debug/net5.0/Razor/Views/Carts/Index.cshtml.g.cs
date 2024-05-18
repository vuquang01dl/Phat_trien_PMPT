#pragma checksum "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Carts\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "bd537c6f71d70d29bf188a2453b12cd9cb1458638edf19b43033fc2e67ad255d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Carts_Index), @"mvc.1.0.view", @"/Views/Carts/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\_ViewImports.cshtml"
using FoodWebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\_ViewImports.cshtml"
using FoodWebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"bd537c6f71d70d29bf188a2453b12cd9cb1458638edf19b43033fc2e67ad255d", @"/Views/Carts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"02d274d87010061b4781aa0148e5584a0577516c2a2915a1692456b41253b911", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Carts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""container"" ng-controller=""CartCtrl"">
    <div>
        <table class=""table table-striped"">
            <tbody>
                <tr>
                    <th style=""text-align: left"">Name</th>
                    <th style=""text-align: center"">Food-Code</th>
                    <th style=""text-align: center"">Modifie-Code</th>
                    <th style=""text-align: center"">Price</th>
                    <th style=""text-align: center"">Quantity</th>
                    <th></th>
                </tr>
                <tr ng-repeat=""item in Products"">
                    <td style=""text-align: left"" class=""text-center"" ng-bind=""item.Name""> </td>
                    <td style=""text-align: center"" class=""text-left"" ng-bind=""item.ItemId""></td>
                    <td style=""text-align: center"" class=""text-right"" ng-bind=""item.ModifieCode""></td>
                    <td style=""text-align: center"" class=""text-right"" ng-bind=""item.Price""></td>
                    <td style=""text-align: cent");
            WriteLiteral("er\" class=\"text-right\">\r\n\r\n                        <input type=\"number\" ng-model=\"item.Quantity\" ng-blur=\"ngBlurModal($index);\" ng-change=\"UpdateQtyOrder($index);\" class=\"input-text qty text\" step=\"1\" min=\"0\"");
            BeginWriteAttribute("max", " max=\"", 1232, "\"", 1238, 0);
            EndWriteAttribute();
            WriteLiteral(@" value=""1"" title=""SL"" size=""4"" inputmode=""numeric"">
                    </td>
                    <td style=""text-align: right"" class=""text-center"">
                        <a style=""cursor:pointer"" class=""cart__remove"" ng-click=""RemoveItemOrder($index)"">
                            <small>Remove</small>
                        </a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div>
        <div>
            <table class=""table table-bordered"">
                <tbody>
                    <tr>
                        <td class=""text-right""><strong>Total</strong></td>
                        <td class=""text-right"">{{getTotal()}}</td>
                    </tr>
                </tbody>
            </table>
            <p class='text-right'>
                <a");
            BeginWriteAttribute("href", " href=\"", 2082, "\"", 2117, 1);
#nullable restore
#line 42 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Carts\Index.cshtml"
WriteAttributeValue("", 2089, Url.Action("Index", "Cart"), 2089, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\'btn btn-danger\'><i class=\'fa fa-shopping-cart\'></i> Cart</a>&nbsp;&nbsp;&nbsp;\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 2224, "\"", 2263, 1);
#nullable restore
#line 43 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Carts\Index.cshtml"
WriteAttributeValue("", 2231, Url.Action("CheckOut", "Carts"), 2231, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\'btn btn-success\'><i class=\'fa fa-shopping-cart\'></i> Confirm</a>\r\n            </p>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591