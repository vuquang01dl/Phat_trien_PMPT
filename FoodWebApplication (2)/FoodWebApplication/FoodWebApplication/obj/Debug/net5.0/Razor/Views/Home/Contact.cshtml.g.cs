#pragma checksum "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Home\Contact.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7e1a355913611d06a7bbb8b9d77d8443d0bf0b9d4bcd5d4ae72b00496e9a20d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contact), @"mvc.1.0.view", @"/Views/Home/Contact.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"7e1a355913611d06a7bbb8b9d77d8443d0bf0b9d4bcd5d4ae72b00496e9a20d5", @"/Views/Home/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"02d274d87010061b4781aa0148e5584a0577516c2a2915a1692456b41253b911", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<!--==================== page content ====================-->
<div class=""page-section"">
    <!--=============================================
       =            google map container         =
       =============================================-->
    <div class=""container google-map-container mb-45"">
        <div id=""google-map"">
            <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3724.691539793691!2d105.84129487446495!3d21.00499838063841!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3135add3c46cb161%3A0x463734da30e16629!2zxJDhuqFpIGjhu41jIELDoWNoIGtob2EgSMOgIE7hu5lpIC0gSGFub2kgVW5pdmVyc2l0eSBvZiBTY2llbmNlIGFuZCBUZWNobm9sb2d5!5e0!3m2!1svi!2s!4v1703753647526!5m2!1svi!2s"" width=""100%"" height=""450"" style=""border:0;""");
            BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 767, "\"", 785, 0);
            EndWriteAttribute();
            WriteLiteral(@" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade""></iframe>
        </div>
    </div>
    <!--=====  End of google map container  ======-->
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-2 col-md-12"">
            </div>
            <div class=""col-lg-8 col-md-12"" style=""margin-top: 30px; "">
                <!--=======  contact form content  =======-->
                <div class=""contact-form-content"">
                    <fieldset>
                        <legend>Đặt bàn tới chúng tôi</legend>
                        <div class=""contact-form"">
");
#nullable restore
#line 23 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Home\Contact.cshtml"
                             using (Html.BeginForm("Contact", "Home", FormMethod.Post, new { @id = "contact-form", @class = "form-horizontal", @enctype = "multipart/form-data", @style = "Width: 100%" }))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""form-group"">
                                    <label>Họ tên <span class=""required"">*</span></label>
                                    <input type=""text"" name=""Name"" id=""customername"" class=""form-control"" required>
                                </div>
                                <div class=""form-group"">
                                    <label>Email <span class=""required"">*</span></label>
                                    <input type=""email"" name=""Email"" id=""customerEmail"" class=""form-control"" required>
                                </div>
                                <div class=""form-group"">
                                    <label>Số điện thoại <span class=""required"">*</span></label>
                                    <input type=""text"" name=""Phone"" id=""customerPhone"" class=""form-control"" required>
                                </div>
                                <div class=""form-group"">
                                    <");
            WriteLiteral(@"label>Tiêu đề</label>
                                    <input type=""text"" name=""Title"" id=""contactSubject"" class=""form-control"">
                                </div>
                                <div class=""form-group"">
                                    <label>Ghi chú</label>
                                    <textarea name=""Content"" id=""contactMessage"" class=""form-control""></textarea>
                                </div>
                                <div class=""form-group mb-0"">
                                    <button type=""submit"" value=""submit"" id=""submit"" class=""theme-button contact-button form-control btn btn-success"" name=""submit"">Send</button>
                                </div>
");
#nullable restore
#line 48 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Views\Home\Contact.cshtml"
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
            <div class=""col-lg-2 col-md-12"">
            </div>
        </div>
    </div>
</div>
<!--=========");
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
