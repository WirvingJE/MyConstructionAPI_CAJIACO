
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MyConstructionAPI_CAJIACO.Attributes
{

    [AttributeUsage(validOn: AttributeTargets.All)]
    public sealed class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        //Especificamos cuál es el clave:valor dentro de appsettings que queremos usar como ApiKey
        private readonly string _apiKey = "ProyectoProgra6ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {


            if (!context.HttpContext.Request.Headers.TryGetValue(_apiKey, out var ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Llamada no contiene información de seguridad..."
                };
                return;


            }


            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var ApiKeyValue = appSettings.GetValue<string>(_apiKey);

            //queda comparar que las apikey sean iguales
            if (!ApiKeyValue.Equals(ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApiKey Inválida..."
                };

                return;
            }

            await next();

        }


    }


}
