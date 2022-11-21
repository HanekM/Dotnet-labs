using Lab3.Models;
using Lab3.Database;
using Lab3.Services;
using Microsoft.Extensions.Primitives;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("Database"));
builder.Services.AddTransient<EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapGet(pattern: "/", async (ctx) =>
{
    ctx.Response.Headers["Content-Type"] = new StringValues("text/html; charset=UTF-8");

    var builder = new StringBuilder();

    EmployeeService service = app.Services.GetRequiredService<EmployeeService>();

    builder.Append(@"<html>
<head>
    <style>
        .employee { 
            border-radius: 4px; 
            background-color: #ddd; 
            padding: 8px; 
            margin-top: 16px; 
        }
        .icon { 
            width: 256px; 
            height: 128px; 
        }
    </style>
</head>");

    builder.Append(@"<body>");
    builder.Append(@"<img class=""icon"" src=""/img/this-is-fine.jpg""></img>");

    foreach (var employee in await service.GetAllEmployees())
    {
        builder.Append(@"<div class=""employee"">");

        builder.Append("<div>");
        builder.Append($"First name: {employee.FirstName}");
        builder.Append("</div>");

        builder.Append("<div>");
        builder.Append($"Last name:    {employee.LastName}");
        builder.Append("</div>");

        builder.Append("<div>");
        builder.Append($"Phone number: {employee.PhoneNumber}");
        builder.Append("</div>");

        builder.Append("<div>");
        builder.Append($"Position: {employee.Position.Name}");
        builder.Append("</div>");

        builder.Append("<div>");
        builder.Append($"Subject: {employee.Subject.Name}");
        builder.Append("</div>");

        builder.Append("<div>");
        builder.Append($"Total hours: {employee.TotalHours}");
        builder.Append("</div>");

        builder.Append("<div>");
        builder.Append($"Hourly rate: {employee.HourlyRate}");
        builder.Append("</div>");

        builder.Append("<div>");
        builder.Append($"Home Address: {employee.HomeAddress.City}, {employee.HomeAddress.Street} Str, {employee.HomeAddress.Number}, {(employee.HomeAddress.Floor != null ? "Floor " + employee.HomeAddress.Floor : "")} {(employee.HomeAddress.ApartmentNumber != null ? ", Apartments " + employee.HomeAddress.ApartmentNumber : "")}");
        builder.Append("</div>");

        builder.Append("<div>");
        builder.Append($"Work Address: {employee.WorkplaceAddress.City}, {employee.WorkplaceAddress.Street} Str, {employee.WorkplaceAddress.Number}, {(employee.WorkplaceAddress.Floor != null ? "Floor " + employee.WorkplaceAddress.Floor : "")} {(employee.WorkplaceAddress.ApartmentNumber != null ? ", Apartments " + employee.WorkplaceAddress.ApartmentNumber : "")}");
        builder.Append("</div>");

        builder.Append("</div>");
    }

    builder.Append(@"</body></html>");

    await ctx.Response.WriteAsync(builder.ToString());
});

app.Run();
