#pragma checksum "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c592c5e98f5206d382936142115304cefac12db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductModalPartial), @"mvc.1.0.view", @"/Views/Shared/_ProductModalPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c592c5e98f5206d382936142115304cefac12db", @"/Views/Shared/_ProductModalPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b1abeaedc4571c9ddb21620078bacabe0e5fba8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductModalPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-6 shop-detail-left\">\r\n        <div id=\"carouselExampleControls\" class=\"carousel slide\" data-bs-ride=\"carousel\">\r\n            <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 7 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
                 for (int i = 0; i < Model.ProductImages.Count(); i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div");
            BeginWriteAttribute("class", " class=\"", 327, "\"", 370, 2);
            WriteAttributeValue("", 335, "carousel-item", 335, 13, true);
#nullable restore
#line 9 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
WriteAttributeValue(" ", 348, i==0 ? "active":"", 349, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1c592c5e98f5206d382936142115304cefac12db5520", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 408, "~/uploads/product/", 408, 18, true);
#nullable restore
#line 10 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
AddHtmlAttributeValue("", 426, Model.ProductImages[i].Image, 426, 29, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 12 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                
            </div>
            <button class=""carousel-control-prev"" type=""button"" data-bs-target=""#carouselExampleControls""
                    data-bs-slide=""prev"">
                <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                <span class=""visually-hidden"">Previous</span>
            </button>
            <button class=""carousel-control-next"" type=""button"" data-bs-target=""#carouselExampleControls""
                    data-bs-slide=""next"">
                <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                <span class=""visually-hidden"">Next</span>
            </button>
        </div>
        

    </div>
    <div class=""col-6 shop-detail-right"">
        <h2>");
#nullable restore
#line 30 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        <p class=\"price\">$");
#nullable restore
#line 31 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
                     Write(Model.SalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(".00</p>\r\n        <div class=\"product-desc\">\r\n            ");
#nullable restore
#line 33 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
       Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"product-quantity-box\">\r\n            <button class=\"add-button add-cart add-basket-btn\" data-id=\"");
#nullable restore
#line 36 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
                                                                   Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">ADD TO CART</button>\r\n            <button class=\"add-button\">WISHLIST</button>\r\n        </div>\r\n        <hr>\r\n        <div class=\"shop-details-box\">\r\n            <p>Variaty:</p>\r\n            <span>");
#nullable restore
#line 42 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
             Write(Model.Variaty.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n        <div class=\"shop-details-box\">\r\n            <p>Type:</p>\r\n            <span>");
#nullable restore
#line 46 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
             Write(Model.Type.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n        <div class=\"shop-details-box\">\r\n            <p>Vintage:</p>\r\n            <span>");
#nullable restore
#line 50 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
             Write(Model.Vintage.ToString("yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n        <div class=\"shop-details-box\">\r\n            <p>Region:</p>\r\n            <span>");
#nullable restore
#line 54 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
             Write(Model.Region.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n        <div class=\"product-rating-box\">\r\n            <div class=\"product-rate\">\r\n");
#nullable restore
#line 58 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"
                 for (int i = 1; i <= 5; i++)
                {
                    if (i <= Model.Rate)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i class=\"fas fa-star\"></i>\r\n");
#nullable restore
#line 63 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"

                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i class=\"far fa-star\"></i>\r\n");
#nullable restore
#line 68 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Shared\_ProductModalPartial.cshtml"

                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 2693, "\"", 2700, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"product-review-count\">\r\n                ( 5 Reviews )\r\n            </a>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
