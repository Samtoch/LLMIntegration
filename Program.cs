
using LLMIntegrations.Services.External;
using LLMIntegrations.Services.Http;
using LLMIntegrations.Utilities;
using LLMIntegrations.Services;

namespace LLMIntegrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<LLMConfigs>(builder.Configuration.GetSection("OpenAI"));
            builder.Services.AddScoped<IOpenAIService, OpenAIService>();
            builder.Services.AddTransient<IExternalServices, ExternalServices>();
            builder.Services.AddTransient<IHttpService, HttpService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
