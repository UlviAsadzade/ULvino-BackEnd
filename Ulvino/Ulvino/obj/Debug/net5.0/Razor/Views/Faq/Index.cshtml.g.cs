#pragma checksum "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Faq\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "591560be08e98519ff63fb414e6949fc5a0fbf47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Faq_Index), @"mvc.1.0.view", @"/Views/Faq/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"591560be08e98519ff63fb414e6949fc5a0fbf47", @"/Views/Faq/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d41d4d07bd35d13f0891971e9257085c90a2e7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Faq_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Faq>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Faq\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<section class=\"page-title\" style=\"background-image: url(\'./assets/images/page-title.jpg\');\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <h1>FREQUENTLY QUESTIONS</h1>\r\n            <div class=\"page-tab\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "591560be08e98519ff63fb414e6949fc5a0fbf474390", async() => {
                WriteLiteral("HOME");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <i class=""fas fa-angle-right""></i>
                <span>FAQ</span>
            </div>
        </div>
    </div>
</section>

<section class=""faq-main"">
    <div class=""container"">
        <div class=""row"">
            <div>
                <img class=""deal-left-icon"" src=""./assets/images/glass.png""");
            BeginWriteAttribute("alt", " alt=\"", 693, "\"", 699, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n            <h2>Frequently Asked Questions</h2>\r\n\r\n\r\n            <div class=\"container\">\r\n                <div class=\"accordion\" id=\"accordionExample\">\r\n");
#nullable restore
#line 33 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Faq\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"item\">\r\n                            <div class=\"item-header\"");
            BeginWriteAttribute("id", " id=\"", 1045, "\"", 1066, 2);
            WriteAttributeValue("", 1050, "heading-", 1050, 8, true);
#nullable restore
#line 36 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Faq\Index.cshtml"
WriteAttributeValue("", 1058, item.Id, 1058, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <h2 class=\"mb-0\">\r\n                                    <button class=\"btn btn-link collapsed\" type=\"button\" data-toggle=\"collapse\"\r\n                                            data-target=\"#collapse-");
#nullable restore
#line 39 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Faq\Index.cshtml"
                                                              Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"false\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 1332, "\"", 1365, 2);
            WriteAttributeValue("", 1348, "collapse-", 1348, 9, true);
#nullable restore
#line 39 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Faq\Index.cshtml"
WriteAttributeValue("", 1357, item.Id, 1357, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
#nullable restore
#line 40 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Faq\Index.cshtml"
                                   Write(item.Question);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        <i class=\"fa fa-angle-down\"></i>\r\n                                    </button>\r\n                                </h2>\r\n                            </div>\r\n                            <div");
            BeginWriteAttribute("id", " id=\"", 1655, "\"", 1677, 2);
            WriteAttributeValue("", 1660, "collapse-", 1660, 9, true);
#nullable restore
#line 46 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Faq\Index.cshtml"
WriteAttributeValue("", 1669, item.Id, 1669, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 1695, "\"", 1729, 2);
            WriteAttributeValue("", 1713, "heading-", 1713, 8, true);
#nullable restore
#line 46 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Faq\Index.cshtml"
WriteAttributeValue("", 1721, item.Id, 1721, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                 data-parent=\"#accordionExample\">\r\n                                <div class=\"t-p\">\r\n                                    ");
#nullable restore
#line 49 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Faq\Index.cshtml"
                               Write(item.Answer);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 53 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Faq\Index.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n");
            DefineSection("faqjs", async() => {
                WriteLiteral("\r\n    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js\"></script>\r\n    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.3.1/js/bootstrap.min.js\"></script>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Faq>> Html { get; private set; }
    }
}
#pragma warning restore 1591
