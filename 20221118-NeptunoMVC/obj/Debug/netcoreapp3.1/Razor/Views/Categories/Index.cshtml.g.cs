#pragma checksum "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221118-NeptunoMVC\Views\Categories\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ddfaffb740d6eceb5b542f2c4f504cc997888482"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_Index), @"mvc.1.0.view", @"/Views/Categories/Index.cshtml")]
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
#line 1 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221118-NeptunoMVC\Views\_ViewImports.cshtml"
using _20221118_NeptunoMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221118-NeptunoMVC\Views\_ViewImports.cshtml"
using _20221118_NeptunoMVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221118-NeptunoMVC\Views\Categories\Index.cshtml"
using _20221118_NeptunoMVC.Dal;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddfaffb740d6eceb5b542f2c4f504cc997888482", @"/Views/Categories/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e7f2d23314c7e102817fc4bdf80b7106fc94f54", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Categories_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221118-NeptunoMVC\Views\Categories\Index.cshtml"
  
	ViewData["Title"] = "Categories";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n\t<div class=\"col\" style=\"text-align:center;margin-bottom:25px;\">\r\n\t\t<h1>Categories</h1>\r\n\t</div>\r\n</div>\r\n<div class=\"row\">\r\n\r\n");
#nullable restore
#line 12 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221118-NeptunoMVC\Views\Categories\Index.cshtml"
      
		var lista=(List<Category>)ViewData["categories"];
		foreach(var item in lista){

			string nombreImagen = "category" + item.CategoryId + "-small.jpeg";

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<div class=\"col-lg-3 col-md-3 col-sm-6\">\r\n\t\t\t\t\t\t<p>\r\n\t\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 453, "\"", 505, 2);
            WriteAttributeValue("", 460, "/Products/Index?idCategoryId=", 460, 29, true);
#nullable restore
#line 19 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221118-NeptunoMVC\Views\Categories\Index.cshtml"
WriteAttributeValue("", 489, item.CategoryId, 489, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ddfaffb740d6eceb5b542f2c4f504cc9978884825175", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 527, "~/images/categories/", 527, 20, true);
#nullable restore
#line 20 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221118-NeptunoMVC\Views\Categories\Index.cshtml"
AddHtmlAttributeValue("", 547, nombreImagen, 547, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 20 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221118-NeptunoMVC\Views\Categories\Index.cshtml"
AddHtmlAttributeValue("", 581, item.CategoryName, 581, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t</p>\r\n\t\t\t\t\t\t<h2>");
#nullable restore
#line 23 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221118-NeptunoMVC\Views\Categories\Index.cshtml"
                       Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\t\t\t\t\t\t<p>");
#nullable restore
#line 24 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221118-NeptunoMVC\Views\Categories\Index.cshtml"
                      Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t</div>\r\n");
#nullable restore
#line 26 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221118-NeptunoMVC\Views\Categories\Index.cshtml"
		}
		
	

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591