using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Blog.Helpers
{
    public static class ListHelper
    {
        public static IHtmlString List<T>(this HtmlHelper htmlHelper, IEnumerable<T> items)
        {
            var stringBuilder = new StringBuilder();
            foreach(var item in items)
            {
                var listItem = new TagBuilder("ol");
                listItem.SetInnerText(item.ToString());
                stringBuilder.Append(listItem.ToString());
            }
            var list = new TagBuilder("ul");
            list.InnerHtml = stringBuilder.ToString();
            var html = list.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(html);
        }
    }
}