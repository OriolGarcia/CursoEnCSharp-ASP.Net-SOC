#pragma checksum "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "001db38869a2465fcb3413833e125c1161223f16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Details), @"mvc.1.0.view", @"/Views/Products/Details.cshtml")]
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
#line 1 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\_ViewImports.cshtml"
using _20221213_CRUDS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\_ViewImports.cshtml"
using _20221213_CRUDS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"001db38869a2465fcb3413833e125c1161223f16", @"/Views/Products/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6925c0b9c1fba838cd5b2fdd6f340f68980807c0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<_20221213_CRUDS.Dal.Product>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Product</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.QuantityPerUnit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.QuantityPerUnit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UnitsInStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.UnitsInStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UnitsOnOrder));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.UnitsOnOrder));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ReorderLevel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.ReorderLevel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Discontinued));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.Discontinued));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.Category.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Supplier));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
       Write(Html.DisplayFor(model => model.Supplier.CompanyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "001db38869a2465fcb3413833e125c1161223f1610475", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "C:\Users\Alumne_mati1\Documents\Oriol Garcia\Projectes\20221213-CRUDS\Views\Products\Details.cshtml"
                           WriteLiteral(Model.ProductId);

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
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "001db38869a2465fcb3413833e125c1161223f1612645", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<_20221213_CRUDS.Dal.Product> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591