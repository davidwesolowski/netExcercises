using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace demo.Models
{
    public class CultureSelectRouteConstraint : IRouteConstraint
    {
        public const string CultureKey = "language";

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if((!values.ContainsKey(CultureKey)) || (values[CultureKey] == null)) {
                return false;
            }

            var lang = values[CultureKey].ToString();
            var requestLocalizationOptions = httpContext.RequestServices.GetRequiredService<IOptions<RequestLocalizationOptions>>();

            if((requestLocalizationOptions.Value.SupportedCultures == null) || (requestLocalizationOptions.Value.SupportedCultures.Count == 0)) {
                try {
                    new System.Globalization.CultureInfo(lang);
                    return true;
                } catch {
                    return false;
                }
            }

            return requestLocalizationOptions.Value.SupportedCultures.Any(culture => culture.Name.Equals(lang, System.StringComparison.CurrentCultureIgnoreCase));
        }
    }
}