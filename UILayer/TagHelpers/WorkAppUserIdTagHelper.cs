using BusinessLayer.Interfaces;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.TagHelpers
{
    [HtmlTargetElement("GetWork")]
    public class WorkAppUserIdTagHelper : TagHelper
    {
        IWorkService _workService;
        public WorkAppUserIdTagHelper(IWorkService workService)
        {
            _workService = workService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            List<Work> works = _workService.GetByUserId(AppUserId);
            var finished = works.Where(i => i.State).Count();
            var Notfinished = works.Where(i => !i.State).Count();
            string htmlSting = $"<strong>Finished Works : </strong>{finished}<br/> <strong>Not Finished Works : </strong>{Notfinished}";
            output.Content.SetHtmlContent(htmlSting);
        }
    }
}
