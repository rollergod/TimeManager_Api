using TimeManager_Api.Services;
using TimeManager_Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITimeManager,TimeManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/getTime", (ITimeManager manager) =>
{
    return manager.GetDate();
})
    .WithDisplayName("GetTime");

app.MapGet("/convertDate", (string date,ITimeManager manager) =>
{
    return manager.ConvertDate(date);
})
    .WithDisplayName("ConvertDate");

app.MapPost("/setTimeZone", (string timeZone, ITimeManager manager) =>
{
    return manager.SetTimeZone(timeZone);
})
    .WithDisplayName("SetTimeZone");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}