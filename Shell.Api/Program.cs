using Shell.DomainLayer;
using System.Reflection;
using Shell.Api.Filters;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddSingleton<DomainFacade>();
var _logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext().CreateLogger();

builder.Logging.AddSerilog(_logger);
builder.Host.UseSerilog(_logger);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalAsyncExceptionfilter());
});

builder.Services.AddControllers().AddNewtonsoftJson();

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

    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
