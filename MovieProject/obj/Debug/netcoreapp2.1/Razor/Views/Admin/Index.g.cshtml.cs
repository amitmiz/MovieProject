#pragma checksum "D:\MovieProject\MovieProject\MovieProject\Views\Admin\Admin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6dc2bfac7b1ec20743454eec93c402f2104d6081"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/Index.cshtml", typeof(AspNetCore.Views_Admin_Index))]
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
#line 1 "D:\MovieProject\MovieProject\MovieProject\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "D:\MovieProject\MovieProject\MovieProject\Views\_ViewImports.cshtml"
using MovieProject;

#line default
#line hidden
#line 3 "D:\MovieProject\MovieProject\MovieProject\Views\_ViewImports.cshtml"
using MovieProject.Models;

#line default
#line hidden
#line 4 "D:\MovieProject\MovieProject\MovieProject\Views\_ViewImports.cshtml"
using MovieProject.Models.AccountViewModels;

#line default
#line hidden
#line 5 "D:\MovieProject\MovieProject\MovieProject\Views\_ViewImports.cshtml"
using MovieProject.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30c3e26b75409861a28e7a92a11d14e4452a8537", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b7e3b31d4c48f8f1fe680b18c99472e87317128", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\MovieProject\MovieProject\MovieProject\Views\Admin\Admin.cshtml"
  
    ViewData["Title"] = "Admin Dashbaord";

#line default
#line hidden
            BeginContext(53, 55, true);
            WriteLiteral("\r\n<h2>Admin Dashbaord</h2>\r\n\r\n<div class=\"jumbotron\">\r\n");
            EndContext();
            BeginContext(164, 291, true);
            WriteLiteral(@"    <p>...</p>
    <p><a class=""btn btn-primary btn-lg"" href=""#"" role=""button"">Learn more</a></p>
</div>

<div class=""row"">
    <div class=""col-md-4"">Create New Movie</div>
    <div class=""col-md-4"">Create New Customer</div>
    <div class=""col-md-4"">Create New Customer</div>
</div>");
            EndContext();
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
