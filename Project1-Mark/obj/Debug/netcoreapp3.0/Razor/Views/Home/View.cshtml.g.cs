#pragma checksum "C:\revature\mark-project1\Project1-Mark\Views\Home\View.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fff4ca5131f4cb02e981065418ae249ce7896b4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_View), @"mvc.1.0.view", @"/Views/Home/View.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fff4ca5131f4cb02e981065418ae249ce7896b4d", @"/Views/Home/View.cshtml")]
    public class Views_Home_View : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DbLibrary.InventoryViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\revature\mark-project1\Project1-Mark\Views\Home\View.cshtml"
  
    ViewData["Title"] = "View";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>View</h1>

<h4>InventoryViewModel</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""View"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""ProductId"" class=""control-label""></label>
                <input asp-for=""ProductId"" class=""form-control"" />
                <span asp-validation-for=""ProductId"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""ProductName"" class=""control-label""></label>
                <input asp-for=""ProductName"" class=""form-control"" />
                <span asp-validation-for=""ProductName"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""LocationName"" class=""control-label""></label>
                <input asp-for=""LocationName"" class=""form-control"" />
                <span asp-validation-for=""Locati");
            WriteLiteral(@"onName"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""ProductPrice"" class=""control-label""></label>
                <input asp-for=""ProductPrice"" class=""form-control"" />
                <span asp-validation-for=""ProductPrice"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""ProductQuantity"" class=""control-label""></label>
                <input asp-for=""ProductQuantity"" class=""form-control"" />
                <span asp-validation-for=""ProductQuantity"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DbLibrary.InventoryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
