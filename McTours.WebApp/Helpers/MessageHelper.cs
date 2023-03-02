using Microsoft.AspNetCore.Html;
using System.Text;

namespace McTours.WebApp.Helpers
{
    public static class MessageHelper
    {
        public static HtmlString DisplaySuccess(string message)
        {
            var splittedMessages = message.Split(Environment.NewLine);
            var stringBuilder = new StringBuilder();
            stringBuilder
                .Append("<div class=\"alert alert-success\">")
                .Append("<ul class=\"my-0\">");

            foreach (var successMessage in splittedMessages)
            {
                stringBuilder.AppendFormat("<li>{0}</li>", successMessage);
            }
            stringBuilder
            .Append("</ul>")
            .Append("</div>");

            return new HtmlString(stringBuilder.ToString());
        }

        public static HtmlString DisplayError(string message)
        {
            var splittedMessages = message.Split(Environment.NewLine);
            var stringBuilder = new StringBuilder();
            stringBuilder
                .Append("<div class=\"alert alert-danger\">")
                .Append("<ul class=\"my-0\">");

            foreach (var errorMessage in splittedMessages)
            {
                stringBuilder.AppendFormat("<li>{0}</li>", errorMessage);
            }
            stringBuilder
            .Append("</ul>")
            .Append("</div>");

            return new HtmlString(stringBuilder.ToString());
        }

    }
}
