var builder = WebApplication.CreateBuilder();
builder.Services.AddTransient<CalcService>();
builder.Services.AddTransient<TimeOfDayService>();

var app = builder.Build();

app.MapGet("/", () =>
{
    var timeOfDayService = app.Services.GetRequiredService<TimeOfDayService>();
    var calcService = app.Services.GetRequiredService<CalcService>();

    return Results.Text($"Time: {timeOfDayService.GetTimeOfDay()}\n" +
                        $"Sum: {calcService.Add(12, 2)}\n" +
                        $"Subtraction: {calcService.Subtract(15, 3)}\n" +
                        $"Dividing: {calcService.Division(21, 3)}\n" +
                        $"Multiplication: {calcService.Multiplication(9, 2)}", "text/plain");
});

app.Run();
