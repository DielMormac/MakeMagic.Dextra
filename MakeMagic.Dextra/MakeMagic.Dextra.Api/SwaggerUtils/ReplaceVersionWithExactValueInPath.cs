using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace MakeMagic.Dextra.Api.SwaggerUtils
{
    /// <summary>
    /// Modifica a url do endpoint para aparecer a versão no swagger.
    /// </summary>
    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            //swaggerDoc.Paths = (OpenApiPaths)swaggerDoc.Paths.ToDictionary(path => path.Key.Replace("v{version}", swaggerDoc.Info.Version), path => path.Value);

            var oap = new OpenApiPaths();

            foreach (var p in swaggerDoc.Paths)
                oap.Add(p.Key.Replace("v{version}", swaggerDoc.Info.Version),
                    p.Value);

            swaggerDoc.Paths = oap;
        }
    }
}
