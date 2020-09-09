#pragma checksum "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8e3aea0894a2fefa2d5e673751d53cfa39383b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Jobs), @"mvc.1.0.view", @"/Views/Admin/Jobs.cshtml")]
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
#line 1 "D:\job\Jobs\JobCardCSIR\JobCard\Views\_ViewImports.cshtml"
using JobCard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\job\Jobs\JobCardCSIR\JobCard\Views\_ViewImports.cshtml"
using JobCard.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8e3aea0894a2fefa2d5e673751d53cfa39383b3", @"/Views/Admin/Jobs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13ff3c6fa0fd7b550e864c3308030453193bef9b", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Jobs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<JobCard.Models.JobCardViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
  
    ViewData["Title"] = "Jobs";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Job-Card List</h1>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n");
#nullable restore
#line 12 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
         using (Html.BeginForm("Export", "Admin", FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col-md-12 text-right\" style=\"margin:10px 0;\">\r\n                    <input class=\"btn btn-primary mx-2\" type=\"submit\" value=\"Export\" />\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 19 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-striped table-responsive"">
            <thead>
                <tr>
                    <th>Ticket No.</th>
                    <th>Date</th>
                    <th>Name</th>
                    <th>Designation</th>
                    <th>Division</th>
                    <th>Email</th>
                    <th>Mobile Number</th>
                    <th>Date Of Completion</th>
                    <th>Nature of service</th>
                    <th>Action</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 38 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                 foreach (var x in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 41 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                       Write(x.JobId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>");
#nullable restore
#line 42 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                       Write(x.CreatedDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>");
#nullable restore
#line 43 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                       Write(x.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>");
#nullable restore
#line 44 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                       Write(x.Designation);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>");
#nullable restore
#line 45 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                       Write(x.Division);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>");
#nullable restore
#line 46 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                       Write(x.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>");
#nullable restore
#line 47 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                       Write(x.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>");
#nullable restore
#line 48 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                       Write(x.DateOfCompletion?.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>");
#nullable restore
#line 49 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                       Write(x.NatureOfService);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>\r\n");
#nullable restore
#line 51 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                             if (!x.isReject)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                                 if (x.isAccept)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <button class=\"btn btn-success\">Accepted</button>\r\n");
#nullable restore
#line 56 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <button");
            BeginWriteAttribute("onclick", " onclick=\"", 2173, "\"", 2248, 3);
            WriteAttributeValue("", 2183, "location.href=\'", 2183, 15, true);
#nullable restore
#line 59 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
WriteAttributeValue("", 2198, Url.Action("Accept", "Admin", new { id = x.Id }), 2198, 49, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2247, "\'", 2247, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success my-1\">Accept</button>\r\n");
#nullable restore
#line 60 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                             if (!x.isAccept)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                                 if (x.isReject)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <button class=\"btn btn-danger\">Rejected</button>\r\n");
#nullable restore
#line 67 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <button");
            BeginWriteAttribute("onclick", " onclick=\"", 2762, "\"", 2837, 3);
            WriteAttributeValue("", 2772, "location.href=\'", 2772, 15, true);
#nullable restore
#line 70 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
WriteAttributeValue("", 2787, Url.Action("Reject", "Admin", new { id = x.Id }), 2787, 49, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2836, "\'", 2836, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger my-1\">Reject</button>\r\n");
#nullable restore
#line 71 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 76 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                             if (!x.isReject)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                                 if (x.isComplete)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <button class=\"btn btn-warning\">Completed</button>\r\n");
#nullable restore
#line 81 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <button");
            BeginWriteAttribute("onclick", " onclick=\"", 3417, "\"", 3494, 3);
            WriteAttributeValue("", 3427, "location.href=\'", 3427, 15, true);
#nullable restore
#line 84 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
WriteAttributeValue("", 3442, Url.Action("Complete", "Admin", new { id = x.Id }), 3442, 51, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3493, "\'", 3493, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Complete</button>\r\n");
#nullable restore
#line 85 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 89 "D:\job\Jobs\JobCardCSIR\JobCard\Views\Admin\Jobs.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<JobCard.Models.JobCardViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
