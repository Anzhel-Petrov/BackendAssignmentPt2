#pragma checksum "C:\Users\Anzhel Petrov\Source\Repos\Anzhel-Petrov\BackendAssignmentPt2\Views\Shared\_ProductSummaryMovie.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6c2ee889e17c8434bb3fea7b2436995080007a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductSummaryMovie), @"mvc.1.0.view", @"/Views/Shared/_ProductSummaryMovie.cshtml")]
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
#line 1 "C:\Users\Anzhel Petrov\Source\Repos\Anzhel-Petrov\BackendAssignmentPt2\Views\_ViewImports.cshtml"
using BackendAssignmentPt2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Anzhel Petrov\Source\Repos\Anzhel-Petrov\BackendAssignmentPt2\Views\_ViewImports.cshtml"
using BackendAssignmentPt2.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6c2ee889e17c8434bb3fea7b2436995080007a5", @"/Views/Shared/_ProductSummaryMovie.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6bb35af8dc6adefce01f99767cc7a00a1835b75", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductSummaryMovie : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BackendAssignmentPt2.Models.Movie>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-md-2\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 101, "\"", 135, 2);
            WriteAttributeValue("", 107, "/Images/", 107, 8, true);
#nullable restore
#line 4 "C:\Users\Anzhel Petrov\Source\Repos\Anzhel-Petrov\BackendAssignmentPt2\Views\Shared\_ProductSummaryMovie.cshtml"
WriteAttributeValue("", 115, Model.ImageFileName, 115, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 136, "\"", 154, 1);
#nullable restore
#line 4 "C:\Users\Anzhel Petrov\Source\Repos\Anzhel-Petrov\BackendAssignmentPt2\Views\Shared\_ProductSummaryMovie.cshtml"
WriteAttributeValue("", 142, Model.Title, 142, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100px\" />\r\n    </div>\r\n    <div class=\"col-md-4\">\r\n        <strong>Title:</strong> ");
#nullable restore
#line 7 "C:\Users\Anzhel Petrov\Source\Repos\Anzhel-Petrov\BackendAssignmentPt2\Views\Shared\_ProductSummaryMovie.cshtml"
                           Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n        <strong>Director:</strong> ");
#nullable restore
#line 8 "C:\Users\Anzhel Petrov\Source\Repos\Anzhel-Petrov\BackendAssignmentPt2\Views\Shared\_ProductSummaryMovie.cshtml"
                              Write(Model.Director);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n        <strong>Price:</strong> ");
#nullable restore
#line 9 "C:\Users\Anzhel Petrov\Source\Repos\Anzhel-Petrov\BackendAssignmentPt2\Views\Shared\_ProductSummaryMovie.cshtml"
                           Write(String.Format("{0:0.00}", Model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n    </div>\r\n    ");
#nullable restore
#line 11 "C:\Users\Anzhel Petrov\Source\Repos\Anzhel-Petrov\BackendAssignmentPt2\Views\Shared\_ProductSummaryMovie.cshtml"
Write(await Html.PartialAsync("_AddToCartButton", (Product)Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BackendAssignmentPt2.Models.Movie> Html { get; private set; }
    }
}
#pragma warning restore 1591
