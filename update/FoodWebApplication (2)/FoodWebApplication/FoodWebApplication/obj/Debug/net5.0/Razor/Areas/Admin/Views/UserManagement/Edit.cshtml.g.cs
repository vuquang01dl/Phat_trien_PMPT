#pragma checksum "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\UserManagement\Edit.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4a4d65045206ad405a765d743d7a90189907f13c026011105c7270e728d692d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_UserManagement_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/UserManagement/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"4a4d65045206ad405a765d743d7a90189907f13c026011105c7270e728d692d5", @"/Areas/Admin/Views/UserManagement/Edit.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_UserManagement_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.User.UserDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\UserManagement\Edit.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_LayoutPage.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"menu-management\">\r\n    ");
#nullable restore
#line 6 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\UserManagement\Edit.cshtml"
Write(await Html.PartialAsync("_breadcrumb", new Dictionary<string, string> { { "A", "Homepage" }, { "B", "User magement" }, { "C", "Cập Nhật Tài Khoản" } }, new ViewDataDictionary(ViewData) { { "mHref", Url.Action("Index", "UserManagement", new { area = "Admin" }) }, { "mShowButton", "true" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\UserManagement\Edit.cshtml"
     using (Html.BeginForm("Edit", "UserManagement", FormMethod.Post, new { @id = "form-create", @class = "form-horizontal needs-validation", @enctype = "multipart/form-data" }))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\UserManagement\Edit.cshtml"
   Write(await Html.PartialAsync("_Form", Model));

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\UserManagement\Edit.cshtml"
                                                
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.User.UserDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
