#pragma checksum "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Account\SignIn.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "cec2b5c0d30a2386c7c100e5a95bf96a1dd3427a8b7e54a24f02c59663ea17fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_SignIn), @"mvc.1.0.view", @"/Views/Account/SignIn.cshtml")]
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
#nullable restore
#line 1 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Account\SignIn.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"cec2b5c0d30a2386c7c100e5a95bf96a1dd3427a8b7e54a24f02c59663ea17fe", @"/Views/Account/SignIn.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"02d274d87010061b4781aa0148e5584a0577516c2a2915a1692456b41253b911", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_SignIn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.User.LoginDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Account\SignIn.cshtml"
  
    var userInfo = HttpContextAccessor.HttpContext.Session.GetString("UserAdmin");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!--==================== page content ====================-->
<div class=""page-section"">
    <!--=====  End of google map container  ======-->
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-4 col-md-12"">
            </div>
            <div class=""col-lg-4 col-md-12"" style=""margin-top: 30px; "">
                <!--=======  contact form content  =======-->
                <div class=""contact-form-content"">
                    <fieldset>
                        <legend>Đăng nhập hệ thống</legend>
                        <div class=""contact-form"">
");
#nullable restore
#line 20 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Account\SignIn.cshtml"
                             using (Html.BeginForm("SignIn", "Account", FormMethod.Post, new { @id = "contact-form", @class = "form-horizontal", @enctype = "multipart/form-data", @style = "Width: 100%" }))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""form-group"">
                                    <label>Tên đăng nhập<span class=""required"">*</span></label>
                                    <input type=""email"" name=""Email"" id=""customername"" class=""form-control"" required>
                                </div>
                                <div class=""form-group"">
                                    <label>Mật khẩu <span class=""required"">*</span></label>
                                    <input type=""text"" name=""Password"" id=""Password"" class=""form-control"" required>
                                </div>
                                <div class=""form-group mb-0"">
                                    <button type=""submit"" value=""Đăng nhập"" id=""submit"" class=""theme-button contact-button form-control btn btn-success"" name=""submit"">Đăng nhập</button>
                                </div>
");
#nullable restore
#line 33 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Account\SignIn.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </fieldset>
                    <p class=""form-messege pt-10 pb-10 mt-10 mb-10""></p>
                </div>
                <!--=======  End of contact form content =======-->
            </div>
            <div class=""col-lg-4 col-md-12"">
            </div>
        </div>
    </div>
</div>
<!--=========");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.User.LoginDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
