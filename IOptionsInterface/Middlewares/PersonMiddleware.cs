using IOptionsInterface.Models;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace IOptionsInterface.Middlewares
{
    public class PersonMiddleware
    {
        private readonly RequestDelegate _next;
        public Person Person { get; }

        public PersonMiddleware(RequestDelegate next, IOptions<Person> options)
        {
            _next = next;
            Person = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 404)
            {
                string str = string.Empty;
                str += $"<h1>{Person.Name}</h1>";
                str += $"<h2>{Person.Age}</h2>";
                str += $"<h2>Languages</h2><ul>";

                foreach (var lang in Person.Languages)
                {
                    str += $"<li>{lang}</li>";
                }

                str += $"</ul>";
                await context.Response.WriteAsync(str);
            }
        }
    }
}
