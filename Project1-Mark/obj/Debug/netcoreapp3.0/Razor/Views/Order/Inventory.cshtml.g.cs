#pragma checksum "C:\revature\mark-project1\Project1-Mark\Views\Order\Inventory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e3cb3194d09a9480e22b48b4fa92b3bb2688188"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Inventory), @"mvc.1.0.view", @"/Views/Order/Inventory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e3cb3194d09a9480e22b48b4fa92b3bb2688188", @"/Views/Order/Inventory.cshtml")]
    public class Views_Order_Inventory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DbLibrary.ViewInventoryViewModels>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\revature\mark-project1\Project1-Mark\Views\Order\Inventory.cshtml"
  
    ViewData["Title"] = "Inventory";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Please choose your desired quantity from the available products below.</h2>\r\n\r\n<form method=\"POST\" asp-action=\"AddProducts\" asp-controller=\"Order\" class=\"nav-link text-dark\">\r\n");
#nullable restore
#line 10 "C:\revature\mark-project1\Project1-Mark\Views\Order\Inventory.cshtml"
     foreach (var item in Model.InventoriesAll)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br>\r\n        <div>\r\n");
            WriteLiteral("\r\n            <div>\r\n                ");
#nullable restore
#line 17 "C:\revature\mark-project1\Project1-Mark\Views\Order\Inventory.cshtml"
           Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <select");
            BeginWriteAttribute("name", " name=\"", 483, "\"", 507, 1);
#nullable restore
#line 18 "C:\revature\mark-project1\Project1-Mark\Views\Order\Inventory.cshtml"
WriteAttributeValue("", 490, item.ProductName, 490, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 19 "C:\revature\mark-project1\Project1-Mark\Views\Order\Inventory.cshtml"
                     for (int i = 0; i <= item.ProductQuantity; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <option");
            BeginWriteAttribute("value", " value=", 635, "", 644, 1);
#nullable restore
#line 21 "C:\revature\mark-project1\Project1-Mark\Views\Order\Inventory.cshtml"
WriteAttributeValue("", 642, i, 642, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 21 "C:\revature\mark-project1\Project1-Mark\Views\Order\Inventory.cshtml"
                                    Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 22 "C:\revature\mark-project1\Project1-Mark\Views\Order\Inventory.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </select>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 26 "C:\revature\mark-project1\Project1-Mark\Views\Order\Inventory.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br>\r\n    <input type=\"submit\" value=\"Submit\">\r\n</form>\r\n<br><br>\r\n<a asp-action=\"LogOut\" asp-controller=\"Login\">Log Out and Start Over?</a>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DbLibrary.ViewInventoryViewModels> Html { get; private set; }
    }
}
#pragma warning restore 1591
