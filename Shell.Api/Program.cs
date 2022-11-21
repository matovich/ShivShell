using Shell.DomainLayer;
using System.Reflection;
using Microsoft.AspNetCore.HttpLogging;
using Shell.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpLogging(opts => opts.LoggingFields = HttpLoggingFields.RequestProperties);
builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<DomainFacade>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalAsyncExceptionfilter());
});

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers().AddXmlSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlfilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlfilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpLogging();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
