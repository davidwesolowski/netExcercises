using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace demo.Tools
{
    public static class CustomHtmlHelper
    {
        public static IHtmlContent SubmitButton(this IHtmlHelper html, string text, object htmlAttributes = null)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("<input type='submit' value='{0}'", text);
            builder.Append("/>");
            return new HtmlString(builder.ToString());
        } 
    }
}