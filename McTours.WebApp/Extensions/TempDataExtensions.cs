using McTours.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace McTours.WebApp.Extensions
{
    public static class TempDataExtensions
    {
        public static string GetString(this ITempDataDictionary tempdata, string key)
        {
            return tempdata[key] as string;
        }

        public static string GetSuccessMessage(this ITempDataDictionary tempdata)
        {
            return tempdata.GetString(Keys.SuccessMessage);
        }

        public static string GetErrorMessage(this ITempDataDictionary tempdata)
        {
            return tempdata.GetString(Keys.ErrorMessage);
        }
    }
}
