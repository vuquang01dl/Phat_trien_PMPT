#pragma checksum "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\_Form.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "108ad2eee049eb634ee15208af34438a85777b23bab528ae7f64566e8d9ed1fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_CategoriesManagement__Form), @"mvc.1.0.view", @"/Areas/Admin/Views/CategoriesManagement/_Form.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"108ad2eee049eb634ee15208af34438a85777b23bab528ae7f64566e8d9ed1fa", @"/Areas/Admin/Views/CategoriesManagement/_Form.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_CategoriesManagement__Form : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DTO.Category.CategoryDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\_Form.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row form-horizontal form-label-left"" style=""margin-bottom:15px;"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-body"">
                <fieldset style=""width: 100%"">
                    <legend>Information </legend>
                    <div class=""first-step-group-criteria"" style=""padding-top:10px; margin-bottom: 10px;"">
                        <div class=""form-row"">
                            <div class=""col-md-6 mb-3"">
                                <label for=""FullName"">Name</label>
                                ");
#nullable restore
#line 15 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\_Form.cshtml"
                           Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 16 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\_Form.cshtml"
                           Write(Html.TextBoxFor(model => model.Name, new { @class = "form-control", @id = "Code", placeholder = "Name", @autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 17 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\_Form.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Name, null, new { @class = "label label-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                        </div>

                        <div class=""form-row"">
                            <div class=""col-md-6 mb-3"">
                                <label for=""email"">Image</label>
                                ");
#nullable restore
#line 24 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\_Form.cshtml"
                           Write(Html.HiddenFor(model =>model.ImageURL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 25 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\_Form.cshtml"
                           Write(Html.TextBoxFor(model => model.PictureUpload, new { @class = "dropify", @type = "file" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                        </div>

                        <div class=""form-row"">
                            <div class=""col-md-6 mb-3"">
                                <label></label>
                                <div class=""custom-control custom-checkbox"">
                                    ");
#nullable restore
#line 33 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\_Form.cshtml"
                               Write(Html.CheckBoxFor(model => model.IsActive, new { @class = "icheck custom-control-input", @id = "active" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    <label class=""custom-control-label"" for=""active"">status</label>
                                </div>
                            </div>
                        </div>

                    </div>
                </fieldset>
                <div class=""text-right"">
                    <a");
            BeginWriteAttribute("href", " href=\"", 2183, "\"", 2233, 1);
#nullable restore
#line 42 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\_Form.cshtml"
WriteAttributeValue("", 2190, Url.Action("Index","CategoriesManagement"), 2190, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-default"" type=""submit"">Cancel</a>
                    <button class=""btn btn-primary"" type=""submit"">Save</button>
                </div>
            </div>
        </div>
    </div>
</div>
<script type=""text/javascript"">
    $(document).ready(function () {
    })
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DTO.Category.CategoryDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
