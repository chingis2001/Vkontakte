#pragma checksum "D:\w\4\Vkontakte\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf976dc74dc1319b06f8f7bf423811e65c8397e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\w\4\Vkontakte\Views\_ViewImports.cshtml"
using Vkontakte;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\w\4\Vkontakte\Views\_ViewImports.cshtml"
using Vkontakte.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf976dc74dc1319b06f8f7bf423811e65c8397e8", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9ef84d7aefa6be7667800f16790f5696be5b8db", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Vkontakte.Models.PostBlogCommentActionViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("changeType(this)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("GetTrends"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetTrends", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Guid IdUser = Guid.Parse(Context.User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("<div id=\"maindiv\" class=\"row\">\r\n");
#nullable restore
#line 8 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-12\" style=\"background-color: #ffffff; border-radius: 4px; margin-bottom: 1rem\">\r\n        <div class=\"row\">\r\n            <div class=\"col-12\">\r\n                <h6 style=\"margin:0.4rem 1rem 0.4rem 1rem; font-size:12px; color:#4d5885\">");
#nullable restore
#line 13 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                                                                                     Write(item.Блог.Название);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                <p style=\" margin:0.4rem 1rem 0.4rem 1rem; font-size: 10px\">");
#nullable restore
#line 14 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                                                                       Write(item.Запись.Дата_публикации);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-12\">\r\n                <p style=\"margin:0.4rem 1rem 0.4rem 1rem; font-size:12px\">");
#nullable restore
#line 19 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                                                                     Write(item.Запись.Текст);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div style=\"padding-left:30px\" class=\"col-12\">\r\n");
#nullable restore
#line 24 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                 if (item.Данные.Count() > 3)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                     foreach (var data in item.Данные)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img style=\"max-height:200px; max-width:200px; float:left; margin-right:10px\"");
            BeginWriteAttribute("src", " src=\"", 1226, "\"", 1291, 2);
            WriteAttributeValue("", 1232, "data:image/jpeg;base64,", 1232, 23, true);
#nullable restore
#line 28 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
WriteAttributeValue("", 1255, Convert.ToBase64String(data.Data), 1255, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 29 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                 if (item.Данные.Count() == 3)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                     for (int i = 0; i < item.Данные.Count(); i++)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                         if (i == 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img style=\"max-height:350px; max-width:280px; float:left; margin-right:10px\"");
            BeginWriteAttribute("src", " src=\"", 1667, "\"", 1752, 2);
            WriteAttributeValue("", 1673, "data:image/jpeg;base64,", 1673, 23, true);
#nullable restore
#line 37 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
WriteAttributeValue("", 1696, Convert.ToBase64String(item.Данные.ElementAt(i).Data), 1696, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 38 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img style=\"max-height:175px; max-width:280px; float:left; margin-right:10px\"");
            BeginWriteAttribute("src", " src=\"", 1947, "\"", 2032, 2);
            WriteAttributeValue("", 1953, "data:image/jpeg;base64,", 1953, 23, true);
#nullable restore
#line 41 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
WriteAttributeValue("", 1976, Convert.ToBase64String(item.Данные.ElementAt(i).Data), 1976, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 42 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                 if (item.Данные.Count() == 2)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                     foreach (var data in item.Данные)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img style=\"max-height:350px; max-width:280px; float:left; margin-right:10px\"");
            BeginWriteAttribute("src", " src=\"", 2354, "\"", 2419, 2);
            WriteAttributeValue("", 2360, "data:image/jpeg;base64,", 2360, 23, true);
#nullable restore
#line 49 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
WriteAttributeValue("", 2383, Convert.ToBase64String(data.Data), 2383, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 50 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                 if (item.Данные.Count() == 1)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                     foreach (var data in item.Данные)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img style=\"max-height:350px; max-width:600px; float:left;\"");
            BeginWriteAttribute("src", " src=\"", 2696, "\"", 2761, 2);
            WriteAttributeValue("", 2702, "data:image/jpeg;base64,", 2702, 23, true);
#nullable restore
#line 56 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
WriteAttributeValue("", 2725, Convert.ToBase64String(data.Data), 2725, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 57 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>
        <div class=""row"">
            <div class=""col-1""></div>
            <div class=""col-10"" style=""margin-top:1rem;margin-bottom:1rem; border-bottom: 1px solid #adb2bc"">
                <div class=""col-1""></div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-1"" style=""margin-left:1rem; padding: 0"">
                <p style=""font-size:12px; margin-left: 1rem"">
");
#nullable restore
#line 70 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                     if (item.Дествия.Contains(item.Дествия.FirstOrDefault(t => t.Пользователь.ID == IdUser && t.Код == 1)))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <svg onclick=\"addLike(this)\" style=\"cursor:pointer\"");
            BeginWriteAttribute("id", " id=\"", 3485, "\"", 3512, 1);
#nullable restore
#line 72 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
WriteAttributeValue("", 3490, item.Запись.ID_Записи, 3490, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""bi bi-heart likesbtn"" fill=""#ff0000"" xmlns=""http://www.w3.org/2000/svg"">
                            <path fill-rule=""evenodd"" d=""M8 1.314C12.438-3.248 23.534 4.735 8 15-7.534 4.736 3.562-3.248 8 1.314z"" />
                        </svg>
");
#nullable restore
#line 75 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                   Write(item.Дествия.Where(t => t.Код == 1).ToList().Count());

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                                                                             
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <svg onclick=\"addLike(this)\" style=\"cursor:pointer\"");
            BeginWriteAttribute("id", " id=\"", 4033, "\"", 4060, 1);
#nullable restore
#line 79 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
WriteAttributeValue("", 4038, item.Запись.ID_Записи, 4038, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""bi bi-heart likesbtn"" fill=""#000000"" xmlns=""http://www.w3.org/2000/svg"">
                            <path fill-rule=""evenodd"" d=""M8 2.748l-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z"" />
                        </svg>
");
#nullable restore
#line 82 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                   Write(item.Дествия.Where(t => t.Код == 1).ToList().Count());

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
                                                                             
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </p>\r\n            </div>\r\n            <div class=\"col-1\" style=\"padding: 0\">\r\n                <p");
            BeginWriteAttribute("id", " id=\"", 4834, "\"", 4861, 1);
#nullable restore
#line 87 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
WriteAttributeValue("", 4839, item.Запись.ID_Записи, 4839, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""font-size:12px; margin-left: 1rem"">
                    <svg onclick=""getPostComents(this)"" style=""cursor: pointer"" width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""comentbtn bi bi-chat-square"" fill=""currentColor"" xmlns=""http://www.w3.org/2000/svg"">
                        <path fill-rule=""evenodd"" d=""M14 1H2a1 1 0 0 0-1 1v8a1 1 0 0 0 1 1h2.5a2 2 0 0 1 1.6.8L8 14.333 9.9 11.8a2 2 0 0 1 1.6-.8H14a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1zM2 0a2 2 0 0 0-2 2v8a2 2 0 0 0 2 2h2.5a1 1 0 0 1 .8.4l1.9 2.533a1 1 0 0 0 1.6 0l1.9-2.533a1 1 0 0 1 .8-.4H14a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z"" />
                    </svg>
                    ");
#nullable restore
#line 91 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
               Write(item.Коментарии.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </p>
            </div>
            <div class=""col-8""></div>
            <div class=""col-1"" style=""padding: 0"">
                <p style=""font-size:12px; margin-left: 1rem"">
                    <svg width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""bi bi-eye-fill"" fill=""currentColor"" xmlns=""http://www.w3.org/2000/svg"">
                        <path d=""M10.5 8a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0z"" />
                        <path fill-rule=""evenodd"" d=""M0 8s3-5.5 8-5.5S16 8 16 8s-3 5.5-8 5.5S0 8 0 8zm8 3.5a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7z"" />
                    </svg>
                    ");
#nullable restore
#line 101 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
               Write(item.Дествия.Where(t => t.Код == 2).ToList().Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 106 "D:\w\4\Vkontakte\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
            DefineSection("Additional", async() => {
                WriteLiteral(@"
    <div class=""row"" style=""margin-left:0.4rem"">
        <div class=""col-12"" style=""background-color: #ffffff; border-radius: 4px;"">
            <div class=""row"" style=""margin-top:0.4rem"">
                <div class=""col-12"">
                    <p>
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf976dc74dc1319b06f8f7bf423811e65c8397e819716", async() => {
                    WriteLiteral("Все записи");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </p>\r\n                </div>\r\n                <div class=\"col-12\">\r\n                    <p>\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf976dc74dc1319b06f8f7bf423811e65c8397e821475", async() => {
                    WriteLiteral("Тренды");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            WriteLiteral(@"<script>
    let page = 1;
    let Controller = ""Index"";
    function changeType(element)
    {
        Controller = element.id;
    }
    onscroll = function () {
        if (window.scrollY + 1 >= document.documentElement.scrollHeight - document.documentElement.clientHeight) {
            let data = { page: page };
            let request = new XMLHttpRequest();
            function reqReadyStateChange() {
                if (request.readyState == 4 && request.status == 200) {
                    page = page + 1;
                    response = request.responseText;
                    let div = document.getElementById('maindiv');
                    div.innerHTML = div.innerHTML + response;
                }
            }
            body = ""page="" + data.page;
            let url = ""/Home/"" + Controller;
            request.open(""POST"", url);
            request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            request.onreadystatechange = reqReadyStat");
            WriteLiteral(@"eChange;
            request.send(body);
        }
    };
    function getPostComents(element) {
        let data = { id: element.parentNode.id };
        let request = new XMLHttpRequest();
        function reqReadyStateChanche() {
            if (request.readyState == 4 && request.status == 200) {
                let response = request.responseText;
                let div = document.getElementById('maindiv');
                div.innerHTML = div.innerHTML + response;
            }
        }
        let body = ""id="" + data.id;
        request.open(""POST"", ""Home/GetPostComents"");
        request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        request.onreadystatechange = reqReadyStateChanche;
        request.send(body);
    }
    function addLike(element) {
        var data = { id: element.id };
        var request = new XMLHttpRequest();
        function reqReadyStateChanche() {
            if (request.readyState == 4 && request.status == 200) {
       ");
            WriteLiteral(@"         let reqstrings = request.responseText.split("";"");
                let pelem = element.parentNode;
                while (pelem.firstChild)
                    pelem.removeChild(pelem.firstChild);
                if (reqstrings[0] == ""add"") {
                    pelem.innerHTML = '<svg onclick=""addLike(this)"" style=""cursor:pointer"" id=""' + data.id + '"" width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""bi bi-heart likesbtn"" fill=""#ff0000"" xmlns=""http://www.w3.org/2000/svg"">' +
                        '<path fill-rule=""evenodd"" d=""M8 1.314C12.438-3.248 23.534 4.735 8 15-7.534 4.736 3.562-3.248 8 1.314z""/>' +
                        '</svg> ' + reqstrings[1];
                }
                else {
                    pelem.innerHTML = '<svg onclick=""addLike(this)"" style=""cursor:pointer"" id=""' + data.id + '"" width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""bi bi-heart likesbtn"" fill=""#000000"" xmlns=""http://www.w3.org/2000/svg"">' +
                        '<path fill-rule=""evenodd"" d=""M8 ");
            WriteLiteral(@"2.748l-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z"" />' +
                        '</svg> ' + reqstrings[1];
                }
            }
        }
        var body = ""id="" + data.id;
        request.open(""POST"", ""Home/LikeAdd"");
        request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        request.onreadystatechange = reqReadyStateChanche;
        request.send(body);
    }
    function closeDetail(element) {
        let postBanner = document.getElementById('PostBanner');
        let postContent = document.getElementById('PostContent');
        postBanner.parentElement.removeChild(postBanner);
        postContent.parentElement.removeChild(postContent);
    }
    const hubConnect");
            WriteLiteral(@"ion = new signalR.HubConnectionBuilder().withUrl(""/chat"").build();
    hubConnection.on(""Publicated"", function (response) {
        let render = function (response) {
            let postcol = document.createElement('div');
            postcol.setAttribute('class', 'col-12');
            postcol.setAttribute('style', 'background-color: #ffffff; border-radius: 4px; margin-bottom: 1rem');
            let firstrow = document.createElement('div');
            firstrow.setAttribute('class', 'row');
            let secondrow = document.createElement('div');
            secondrow.setAttribute('class', 'row');
            let thirdrow = document.createElement('div');
            thirdrow.setAttribute('class', 'row');
            let fourthrow = document.createElement('div');
            fourthrow.setAttribute('class', 'row');
            let blogcol = document.createElement('div');
            blogcol.setAttribute('class', 'col-12');
            blogcol.setAttribute('style', 'background-color: #ffffff");
            WriteLiteral(@"; border-radius: 4px; margin-bottom: 1rem');
            let blogname = document.createElement('h6');
            blogname.setAttribute('style', 'margin:0.4rem 1rem 0.4rem 1rem; font-size:12px; color:#4d5885');
            blogname.innerHTML = response.блог;
            let datetime = document.createElement('p');
            datetime.setAttribute('style', 'margin:0.4rem 1rem 0.4rem 1rem; font-size: 10px');
            datetime.innerHTML = response.дата_публикации;
            blogcol.appendChild(blogname);
            blogcol.appendChild(datetime);
            let textcol = document.createElement('div');
            textcol.setAttribute('class', 'col-12');
            let text = document.createElement('p');
            text.setAttribute('style', 'margin:0.4rem 1rem 0.4rem 1rem; font-size:12px');
            text.innerHTML = response.текст;
            textcol.appendChild(text);
            thirdrow.innerHTML = '<div class=""col-1""></div><div class=""col-10"" style=""margin-top:1rem;margin-bottom:1r");
            WriteLiteral(@"em; border-bottom: 1px solid #adb2bc""><div class=""col-1""></div></div>';
            firstrow.appendChild(blogcol);
            secondrow.appendChild(textcol);
            let likecol = document.createElement('div');
            likecol.setAttribute('class', 'col-2');
            likecol.setAttribute('style', 'margin-left:1rem; padding: 0');
            let likes = document.createElement('p');
            likes.setAttribute('style', 'font-size:12px; margin-left: 1rem');
            likes.innerHTML = '<svg onclick=""addLike(this)"" style=""cursor:pointer"" id=""' + response.id_записи + '"" width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""bi bi-heart likesbtn"" fill=""#000000"" xmlns=""http://www.w3.org/2000/svg"">' +
                '<path fill-rule=""evenodd"" d=""M8 2.748l-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 ");
            WriteLiteral(@"1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z"" />' +
                '</svg>' + ' ' + response.лайки;
            let comments = document.createElement('p');
            let comentcol = document.createElement('div');
            likecol.appendChild(likes);
            comentcol.setAttribute('class', 'col-2');
            comentcol.setAttribute('style', 'padding: 0');
            comments.setAttribute('id', response.id_записи);
            comments.setAttribute('style', 'font-size:12px; margin-left: 1rem');
            comments.innerHTML = ' <svg onclick=""getPostComents(this)"" style=""cursor: pointer"" width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""comentbtn bi bi-chat-square"" fill=""currentColor"" xmlns=""http://www.w3.org/2000/svg"">' +
                '<path fill-rule=""evenodd"" d=""M14 1H2a1 1 0 0 0-1 1v8a1 1 0 0 0 1 1h2.5a2 2 0 0 1 1.6.8L8 14.333 9.9 11.8a2 2 0 0 1 1.6-.8H14a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1zM2 0a2 2 0 0 0-2 2v8a2 2 0 0 0 2 2h2.5a1 1 0 0 1 .8.4l1");
            WriteLiteral(@".9 2.533a1 1 0 0 0 1.6 0l1.9-2.533a1 1 0 0 1 .8-.4H14a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z"" />' +
                '</svg>' + ' ' + response.коментарии;
            comentcol.appendChild(comments);
            let buffcol = document.createElement('div');
            buffcol.setAttribute('class', 'col-5');
            let viewcol = document.createElement('div');
            viewcol.setAttribute('class', 'col-2');
            let views = document.createElement('p');
            views.setAttribute('style', 'font-size:12px; margin-left: 1rem');
            views.innerHTML = '<svg width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""bi bi-eye-fill"" fill=""currentColor"" xmlns=""http://www.w3.org/2000/svg""><path d = ""M10.5 8a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0z"" /><path fill-rule=""evenodd"" d=""M0 8s3-5.5 8-5.5S16 8 16 8s-3 5.5-8 5.5S0 8 0 8zm8 3.5a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7z"" /></svg >' +
                ' ' + 1;
            viewcol.appendChild(views);
            fourthrow.appendChild(likecol);
       ");
            WriteLiteral(@"     fourthrow.appendChild(comentcol);
            fourthrow.appendChild(buffcol);
            fourthrow.appendChild(viewcol);
            postcol.appendChild(firstrow);
            postcol.appendChild(secondrow);
            postcol.appendChild(thirdrow);
            postcol.appendChild(fourthrow);
            let firstElem = document.getElementById(""maindiv"").firstChild;
            document.getElementById(""maindiv"").insertBefore(postcol, firstElem);
            if (firstElem.id == ""empty"") {
                document.getElementById(""maindiv"").removeChild(firstElem);
            }
        }
        if (document.getElementById(""BlogId"")) {
            if (document.getElementById(""BlogId"").value == response.id_блога)
                render(response);
        }
        else {
            if (document.location.pathname == '/') {
                render(response);
            }
        }
    });
    hubConnection.start();
    document.addEventListener(""DOMContentLoaded"", function () {
    ");
            WriteLiteral(@"    let contentRow = document.getElementById(""contentRow"");
        let post = document.getElementById(""postwithcomments"");
        let bannerwidth = document.documentElement.clientWidth - 665;
        if (post)
        {
            post.style.marginLeft = bannerwidth + ""px"";
            contentRow.style.height = document.documentElement.clientHeight + ""px"";
            alert(post.style.marginLeft);
            window.onresize = function () {
                alert(""Hello blyat"");
                newheight = document.documentElement.clientHeight;
                contentRow.style.height = newheight + ""px"";
                post.style.marginLeft = bannerwidth + ""px"";
            }
        }
    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Vkontakte.Models.PostBlogCommentActionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
