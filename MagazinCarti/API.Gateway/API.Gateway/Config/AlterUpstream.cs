using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Gateway.Config
{
    public class AlterUpstream
    {
        public static string AlterUpstreamSwaggerJson(HttpContext context, string swaggetJson)
        {
            var swagger = JObject.Parse(swaggetJson);

            return swagger.ToString(Formatting.Indented);
        }
    }
}
