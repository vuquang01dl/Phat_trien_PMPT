#pragma checksum "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "36897807becd8dccc14d535b51a54527e528d9890c6e2a15b16c9682d156b809"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_CategoriesManagement_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/CategoriesManagement/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"36897807becd8dccc14d535b51a54527e528d9890c6e2a15b16c9682d156b809", @"/Areas/Admin/Views/CategoriesManagement/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_CategoriesManagement_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DTO.Category.CategoryDTO>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\Index.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_LayoutPage.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"account-management\">\r\n    ");
#nullable restore
#line 6 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\Index.cshtml"
Write(await Html.PartialAsync("_breadcrumb", new Dictionary<string, string> { { "A", "Homepage" }, { "B", "Categories management" } }, new ViewDataDictionary(ViewData) { { "mHref", Url.Action("New", "CategoriesManagement", new { area = "Admin" }) }, { "mShowButton", "true" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""table-responsive m-t-40"">
                        <table id=""config-table"" class=""table display table-bordered table-striped no-wrap"">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Image</th>
                                    <th>Status</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 23 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\Index.cshtml"
                                 if (Model != null && Model.Any())
                                {
                                    foreach (var item in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 28 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\Index.cshtml"
                                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td><img");
            BeginWriteAttribute("src", " src=\"", 1487, "\"", 1507, 1);
#nullable restore
#line 29 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\Index.cshtml"
WriteAttributeValue("", 1493, item.ImageURL, 1493, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 75px\"/> </td>\r\n                                            <td>\r\n");
#nullable restore
#line 31 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\Index.cshtml"
                                                 if (item.IsActive)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <label class=\"btn btn-default btn-sm\"><i class=\"fa fa-lg fa-toggle-on text-success\"></i></label>\r\n");
#nullable restore
#line 34 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\Index.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <label class=\"btn btn-default btn-sm\"><i class=\"fa fa-lg fa-toggle-off text-danger\"></i></label>\r\n");
#nullable restore
#line 38 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\r\n                                            <td>\r\n                                                <div class=\"btn-group btn-group-3 pull-right\">\r\n                                                    <a");
            BeginWriteAttribute("href", " href=\"", 2466, "\"", 2537, 1);
#nullable restore
#line 42 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\Index.cshtml"
WriteAttributeValue("", 2473, Url.Action("Edit","CategoriesManagement", new { Id = item.Id }), 2473, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-default btn-sm"" data-toggle=""tooltip"" data-placement=""bottom"" title=""Update"">
                                                        <i class=""fas fa-fw fa-pencil-alt text-success""></i>
                                                    </a>
                                                    <a");
            BeginWriteAttribute("href", " href=\"", 2855, "\"", 2930, 1);
#nullable restore
#line 45 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\Index.cshtml"
WriteAttributeValue("", 2862, Url.Action("Destroy", "CategoriesManagement", new { Id = item.Id }), 2862, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-default btn-sm"" data-confirm=""Do you want ?"" data-toggle=""tooltip"" data-placement=""bottom"" title=""Xoá thông tin tài khoản"">
                                                        <i class=""fa fa-fw fa-trash text-danger""></i>
                                                    </a>
                                                </div>
                                            </td>
                                        </tr>
");
#nullable restore
#line 51 "C:\Users\vuqua\OneDrive\Máy tính\FoodWebApplication (2)\FoodWebApplication\FoodWebApplication\Areas\Admin\Views\CategoriesManagement\Index.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<script>
    $('#config-table').DataTable({
        responsive: true
    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DTO.Category.CategoryDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
