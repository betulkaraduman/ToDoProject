using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.TagHelpers
{
    [HtmlTargetElement("NewTag")]
    //bu tag i gördüğünde kendi başına aşağıdaki işlemi yapar
    public class CreateParagraph : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            //WAY 1

            //var tagBuilder = new TagBuilder("p");
            //tagBuilder.InnerHtml.AppendHtml("<b>Hello I created new p tag</b>");
            //output.Content.SetHtmlContent(tagBuilder);


            //WAY 2

            //var stringBuilder = new StringBuilder();
            //stringBuilder.AppendFormat("<p>{0}</p>", "Hello This is a p tag");
            //output.Content.SetHtmlContent(stringBuilder.ToString());


            //WAY 3
            string data = string.Empty;
            data = "<p>Hello This is a p tag</p>";
            output.Content.SetHtmlContent(data);

            base.Process(context, output);
        }
    }

}
