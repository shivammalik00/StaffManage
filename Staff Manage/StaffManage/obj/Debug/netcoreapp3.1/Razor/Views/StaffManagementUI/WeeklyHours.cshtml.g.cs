#pragma checksum "C:\Users\L_428643\OneDrive - Alstom\Desktop\Staff Manage\StaffManage\Views\StaffManagementUI\WeeklyHours.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d626ec431fd5ac472dca8500896bfcdfd26c2935"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StaffManagementUI_WeeklyHours), @"mvc.1.0.view", @"/Views/StaffManagementUI/WeeklyHours.cshtml")]
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
#line 1 "C:\Users\L_428643\OneDrive - Alstom\Desktop\Staff Manage\StaffManage\Views\_ViewImports.cshtml"
using StaffManage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\L_428643\OneDrive - Alstom\Desktop\Staff Manage\StaffManage\Views\_ViewImports.cshtml"
using StaffManage.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d626ec431fd5ac472dca8500896bfcdfd26c2935", @"/Views/StaffManagementUI/WeeklyHours.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76bf3a95d54776b132080e05025c0004ba8c2f41", @"/Views/_ViewImports.cshtml")]
    public class Views_StaffManagementUI_WeeklyHours : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\L_428643\OneDrive - Alstom\Desktop\Staff Manage\StaffManage\Views\StaffManagementUI\WeeklyHours.cshtml"
  
    ViewData["Title"] = "WeeklyHours";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Total hours worked in A Week</h1>\r\n\r\n<h4 id=\"TotalHours\">\r\n</h4>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $.ajax({
                type: ""GET"",
                url: ""/StaffManagement/GetWeeklyHours"",
                contentType: ""application/json; char"",
                dataType: ""json"",
                success: bindData,
                failure: function (response) {
                    alert(response);
                }
            });
        });

        function bindData(data) {
            var jsonData = JSON.parse(data);
            let value = data;
            
            $('#TotalHours').html(value);
        }
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n");
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
