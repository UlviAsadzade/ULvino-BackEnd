#pragma checksum "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e55b6a18d4792682c3b38a94d9222e8e23a5a38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Detail), @"mvc.1.0.view", @"/Views/Product/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e55b6a18d4792682c3b38a94d9222e8e23a5a38", @"/Views/Product/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b1abeaedc4571c9ddb21620078bacabe0e5fba8", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("add-your-review"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    List<Product> sameProducts = ViewBag.SameProducts;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<section class=\"page-title\" style=\"background-image: url(\'/assets/images/page-title.jpg\');\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <h1>");
#nullable restore
#line 12 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            <div class=\"page-tab\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e55b6a18d4792682c3b38a94d9222e8e23a5a387518", async() => {
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
            WriteLiteral("\r\n                <i class=\"fas fa-angle-right\"></i>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e55b6a18d4792682c3b38a94d9222e8e23a5a388949", async() => {
                WriteLiteral("SHOP");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <i class=\"fas fa-angle-right\"></i>\r\n                <span>");
#nullable restore
#line 18 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                 Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
            </div>
        </div>
    </div>
</section>

<section class=""shop-detail-main"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-6 shop-detail-left"">
                <div id=""carouselExampleControls"" class=""carousel slide"" data-bs-ride=""carousel"">
                    <div class=""carousel-inner"">
");
#nullable restore
#line 30 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                         for (int i = 0; i < Model.ProductImages.Count(); i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div");
            BeginWriteAttribute("class", " class=\"", 1121, "\"", 1164, 2);
            WriteAttributeValue("", 1129, "carousel-item", 1129, 13, true);
#nullable restore
#line 32 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
WriteAttributeValue(" ", 1142, i==0 ? "active":"", 1143, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9e55b6a18d4792682c3b38a94d9222e8e23a5a3811845", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1210, "~/uploads/product/", 1210, 18, true);
#nullable restore
#line 33 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
AddHtmlAttributeValue("", 1228, Model.ProductImages[i].Image, 1228, 29, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n");
#nullable restore
#line 35 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
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
#line 52 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <p class=\"price\">$");
#nullable restore
#line 53 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                             Write(Model.SalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(".00</p>\r\n                <div class=\"product-desc\">\r\n                    ");
#nullable restore
#line 55 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
               Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"product-quantity-box\">\r\n                    <button class=\"add-button add-cart add-basket-btn\" data-id=\"");
#nullable restore
#line 58 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                                                                           Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">ADD TO CART</button>\r\n                    <button class=\"add-button add-wishlist-btn\" data-id=\"");
#nullable restore
#line 59 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                                                                    Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">WISHLIST</button>\r\n                </div>\r\n                <hr>\r\n                <div class=\"shop-details-box\">\r\n                    <p>Variaty:</p>\r\n                    <span>");
#nullable restore
#line 64 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                     Write(Model.Variaty.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                <div class=\"shop-details-box\">\r\n                    <p>Type:</p>\r\n                    <span>");
#nullable restore
#line 68 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                     Write(Model.Type.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                <div class=\"shop-details-box\">\r\n                    <p>Vintage:</p>\r\n                    <span>");
#nullable restore
#line 72 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                     Write(Model.Vintage.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                <div class=\"shop-details-box\">\r\n                    <p>Region:</p>\r\n                    <span>");
#nullable restore
#line 76 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                     Write(Model.Region.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                <div class=\"product-rating-box\">\r\n                    <div class=\"product-rate\">\r\n");
#nullable restore
#line 80 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                         for (int i = 1; i <= 5; i++)
                        {
                            if (i <= Model.Rate)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <i class=\"fas fa-star\"></i>\r\n");
#nullable restore
#line 85 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <i class=\"far fa-star\"></i>\r\n");
#nullable restore
#line 90 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"

                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 3950, "\"", 3957, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""product-review-count"">
                        ( 5 Reviews )
                    </a>
                </div>
            </div>
        </div>
    </div>
</section>

<section class=""product-reviews"">
    <div class=""container"">
        <div class=""row"">
            <h2>Customer Reviews</h2>

            <div class=""all-users-reviews"">
                <div class=""user-review-box"">
                    <div class=""user-review"">
                        <div class=""product-rate"">
                            <i class=""fas fa-star""></i>
                            <i class=""fas fa-star""></i>
                            <i class=""fas fa-star""></i>
                            <i class=""fas fa-star""></i>
                            <i class=""far fa-star""></i>
                        </div>
                        <p class=""user-comment"">
                            This wine is the best
                        </p>
                    </div>
                    <div class=""review-det");
            WriteLiteral(@"ail"">
                        <p>Ulvi Asadzade</p>
                        <p>|</p>
                        <p>27.11.2021</p>
                    </div>
                </div>

                <div class=""user-review-box"">
                    <div class=""user-review"">
                        <div class=""product-rate"">
                            <i class=""fas fa-star""></i>
                            <i class=""fas fa-star""></i>
                            <i class=""fas fa-star""></i>
                            <i class=""far fa-star""></i>
                            <i class=""far fa-star""></i>
                        </div>
                        <p class=""user-comment"">
                            Not bad
                        </p>
                    </div>
                    <div class=""review-detail"">
                        <p>Ismail Abdullazade</p>
                        <p>|</p>
                        <p>28.11.2021</p>
                    </div>
                </div>

 ");
            WriteLiteral("           </div>\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e55b6a18d4792682c3b38a94d9222e8e23a5a3821660", async() => {
                WriteLiteral("\r\n                <h3>Add a review</h3>\r\n                <h5>Your rating</h5>\r\n                <div class=\"your-rate-box\">\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 6215, "\"", 6222, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <i class=\"fas fa-star\"></i>\r\n                    </a>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 6327, "\"", 6334, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <i class=\"fas fa-star\"></i>\r\n                        <i class=\"fas fa-star\"></i>\r\n                    </a>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 6492, "\"", 6499, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <i class=\"fas fa-star\"></i>\r\n                        <i class=\"fas fa-star\"></i>\r\n                        <i class=\"fas fa-star\"></i>\r\n                    </a>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 6710, "\"", 6717, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        <i class=""fas fa-star""></i>
                        <i class=""fas fa-star""></i>
                        <i class=""fas fa-star""></i>
                        <i class=""fas fa-star""></i>
                    </a>
                    <a");
                BeginWriteAttribute("href", " href=\"", 6981, "\"", 6988, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        <i class=""fas fa-star""></i>
                        <i class=""fas fa-star""></i>
                        <i class=""fas fa-star""></i>
                        <i class=""fas fa-star""></i>
                        <i class=""fas fa-star""></i>
                    </a>
                </div>
                <textarea");
                BeginWriteAttribute("name", " name=\"", 7332, "\"", 7339, 0);
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 7340, "\"", 7345, 0);
                EndWriteAttribute();
                WriteLiteral(" cols=\"45\" rows=\"8\" placeholder=\"Add your comment...\"></textarea>\r\n                <button type=\"submit\">SEND</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n<section class=\"same-category-product\">\r\n    <div class=\"container products-box\">\r\n        <h2>YOU MAY ALSO LIKE…</h2>\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 193 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
             foreach (var item in sameProducts)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-3\">\r\n                    <div class=\"product-card\">\r\n                        <div class=\"card-img\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e55b6a18d4792682c3b38a94d9222e8e23a5a3826081", async() => {
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9e55b6a18d4792682c3b38a94d9222e8e23a5a3826369", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 8017, "~/uploads/product/", 8017, 18, true);
#nullable restore
#line 199 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
AddHtmlAttributeValue("", 8035, item.ProductImages.FirstOrDefault(x=>x.IsPoster==true)?.Image, 8035, 62, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 198 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                                                                              WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"card-body\">\r\n                            <h5>");
#nullable restore
#line 203 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <div class=\"product-rate\">\r\n");
#nullable restore
#line 205 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                                 for (int i = 1; i <= 5; i++)
                                {
                                    if (i <= item.Rate)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <i class=\"fas fa-star\"></i>\r\n");
#nullable restore
#line 210 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"

                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <i class=\"far fa-star\"></i>\r\n");
#nullable restore
#line 215 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"

                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                            <div class=\"product-price\">\r\n                                <span>$");
#nullable restore
#line 220 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                                  Write(item.SalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(".00</span>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"product-icons\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 9168, "\"", 9175, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"wishlist-button add-wishlist-btn\" data-id=\"");
#nullable restore
#line 224 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                                                                                    Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                <i class=\"far fa-heart\"></i>\r\n                            </a>\r\n\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 9367, "\"", 9374, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"add-basket-btn\" data-id=\"");
#nullable restore
#line 228 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                                                                  Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                <i class=\"fas fa-shopping-cart\"></i>\r\n                            </a>\r\n\r\n                            <a data-bs-toggle=\"modal\" data-bs-target=\"#productModal\" class=\"show-product-modal\" data-id=\"");
#nullable restore
#line 232 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"
                                                                                                                    Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                <i class=\"fas fa-expand-alt\"></i>\r\n                            </a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 238 "C:\Users\lenovo\OneDrive\Masaüstü\ULvino-BackEnd\Ulvino\Ulvino\Views\Product\Detail.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n\r\n\r\n");
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
