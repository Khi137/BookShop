#pragma checksum "D:\ASP\02_Layout\02_Layout\Views\Ads\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "128bc64fddd84e9ca010028268520066b3a8cfc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ads_Index), @"mvc.1.0.view", @"/Views/Ads/Index.cshtml")]
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
#line 1 "D:\ASP\02_Layout\02_Layout\Views\_ViewImports.cshtml"
using _02_Layout;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASP\02_Layout\02_Layout\Views\_ViewImports.cshtml"
using _02_Layout.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"128bc64fddd84e9ca010028268520066b3a8cfc6", @"/Views/Ads/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9455e0b4cf6fb43b1ce70a2d982a292a760216eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Ads_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<_02_Layout.Areas.Admin.Models.Ads>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/ads/1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\ASP\02_Layout\02_Layout\Views\Ads\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""hero_area"">
        <!-- header section strats -->
        
        <!-- end header section -->
        <!-- slider section -->
        <section class=""slider_section "">
            <div id=""customCarousel1"" class=""carousel slide"" data-ride=""carousel"">
                <div class=""carousel-inner"">             
                    <div class=""carousel-item active"">
                        <div class=""container "">
                            <div class=""row"">
                                <div class=""col-md-6"">
                                    <div class=""detail-box"">
                                        <h1>
                                            Welcome to our shop
                                        </h1>
                                        <p>
                                            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Iste quam velit saepe dolorem deserunt quo quidem ad optio.
                                        </p>
    ");
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 1207, "\"", 1214, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                            Read More
                                        </a>
                                    </div>
                                </div>
                                <div class=""col-md-6"">
                                    <div class=""img-box"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "128bc64fddd84e9ca010028268520066b3a8cfc65581", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                  \r\n");
#nullable restore
#line 43 "D:\ASP\02_Layout\02_Layout\Views\Ads\Index.cshtml"
                     foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"         <div class=""carousel-item"">
                        <div class=""container "">
                            <div class=""row"">
                                <div class=""col-md-6"">
                                    <div class=""detail-box"">
                                        <h1>
                                            Welcome to our shop
                                        </h1>
                                        <p>
                                            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Iste quam velit saepe dolorem deserunt quo quidem ad optio.
                                        </p>
                                        <a");
            BeginWriteAttribute("href", " href=\"", 2553, "\"", 2560, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                            Read More
                                        </a>
                                    </div>
                                </div>
                                <div class=""col-md-6"">
                                    <div class=""img-box"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "128bc64fddd84e9ca010028268520066b3a8cfc68327", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2914, "~/img/ads/", 2914, 10, true);
#nullable restore
#line 62 "D:\ASP\02_Layout\02_Layout\Views\Ads\Index.cshtml"
AddHtmlAttributeValue("", 2924, Html.DisplayFor(modelItem => item.Image), 2924, 41, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>          \r\n");
#nullable restore
#line 68 "D:\ASP\02_Layout\02_Layout\Views\Ads\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""carousel_btn_box"">
                    <a class=""carousel-control-prev"" href=""#customCarousel1"" role=""button"" data-slide=""prev"">
                        <i class=""fa fa-angle-left"" aria-hidden=""true""></i>
                        <span class=""sr-only"">Previous</span>
                    </a>
                    <a class=""carousel-control-next"" href=""#customCarousel1"" role=""button"" data-slide=""next"">
                        <i class=""fa fa-angle-right"" aria-hidden=""true""></i>
                        <span class=""sr-only"">Next</span>
                    </a>
                </div>
            </div>
        </section>
        <!-- end slider section -->
    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<_02_Layout.Areas.Admin.Models.Ads>> Html { get; private set; }
    }
}
#pragma warning restore 1591