#pragma checksum "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_WishlistPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a0023a4cf269ca20013b7bf68509780b5f73348"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__WishlistPartial), @"mvc.1.0.view", @"/Views/Shared/_WishlistPartial.cshtml")]
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
#line 1 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\_ViewImports.cshtml"
using Ulvino;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\_ViewImports.cshtml"
using Ulvino.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\_ViewImports.cshtml"
using Ulvino.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\_ViewImports.cshtml"
using Ulvino.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a0023a4cf269ca20013b7bf68509780b5f73348", @"/Views/Shared/_WishlistPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b1abeaedc4571c9ddb21620078bacabe0e5fba8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__WishlistPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WishlistItemViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_WishlistPartial.cshtml"
  
    Layout = null;


#line default
#line hidden
#nullable disable
            WriteLiteral("<input hidden value=\"salam\" class=\"ferid\" />\r\n<ul>\r\n");
#nullable restore
#line 9 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_WishlistPartial.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            ");
#nullable restore
#line 12 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_WishlistPartial.cshtml"
       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </li>\r\n");
#nullable restore
#line 14 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_WishlistPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WishlistItemViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
