#pragma checksum "C:\Code\RankCreditCard\RankCreditCard\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b85f2432804611f7c77f535968f94821ce9d7e3b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Code\RankCreditCard\RankCreditCard\Views\_ViewImports.cshtml"
using RankCreditCard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Code\RankCreditCard\RankCreditCard\Views\_ViewImports.cshtml"
using RankCreditCard.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b85f2432804611f7c77f535968f94821ce9d7e3b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b508d9d29a0abd6ccb7be40d2ed1af0b68913823", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Code\RankCreditCard\RankCreditCard\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome, to Rank Interactive Credit Card Management System</h1>\r\n    <input type=\"button\" value=\"Manage Credit Cards\"");
            BeginWriteAttribute("onclick", " onclick=\"", 217, "\"", 276, 3);
            WriteAttributeValue("", 227, "location.href=\'", 227, 15, true);
#nullable restore
#line 7 "C:\Code\RankCreditCard\RankCreditCard\Views\Home\Index.cshtml"
WriteAttributeValue("", 242, Url.Action("List", "CreditCard"), 242, 33, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 275, "\'", 275, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
