#pragma checksum "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Home\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b061239d1e324718c9e10ddd5c27d8bd59dbd5eba341442250e77b9087659d1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"b061239d1e324718c9e10ddd5c27d8bd59dbd5eba341442250e77b9087659d1f", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"02d274d87010061b4781aa0148e5584a0577516c2a2915a1692456b41253b911", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FoodWebApplication.Models.HomeViewModels>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Home\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div ng-controller=\"CartCtrl\">\r\n    <!-- Slider Area Start -->\r\n    <div class=\"slider-area slider-style-three\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n");
#nullable restore
#line 13 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Home\Index.cshtml"
                 if (Model != null && Model.Categories.Any())
                {
                    var No = 0;
                    foreach (var item in Model.Categories)
                    {
                        No = No + 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-lg-3\" style=\"text-align: center\">\r\n                            <div><img");
            BeginWriteAttribute("src", " src=\"", 707, "\"", 741, 1);
#nullable restore
#line 20 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Home\Index.cshtml"
WriteAttributeValue("", 713, Url.Content(@item.ImageURL), 713, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 100% !important; height: 150px !important; \" /></div>\r\n                            <div style=\"margin: 9px\"><a");
            BeginWriteAttribute("href", " href=\"", 867, "\"", 929, 1);
#nullable restore
#line 21 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Home\Index.cshtml"
WriteAttributeValue("", 874, Url.Action("Index","Restaurant", new { id = item.Id }), 874, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><h4 style=\"color: #f1ac06 \">");
#nullable restore
#line 21 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Home\Index.cshtml"
                                                                                                                                              Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4></a></div>\r\n                        </div>\r\n");
#nullable restore
#line 23 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Home\Index.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FoodWebApplication.Models.HomeViewModels> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
