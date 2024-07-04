using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace FlightInfo.Server.Code.Swagger
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (!context.Type.IsEnum)
                return;

            model.Enum.Clear();
            Enum.GetNames(context.Type).ToList()
                .ForEach(name => model.Enum.Add(new OpenApiString(name)));
            model.Format = null;
            model.Type = nameof(String).ToLower();
        }
    }
}
