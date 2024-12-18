using ClassLibrary1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LaboratoryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<LaboratoryContext>();
}

app.Run();
public static class DbInitializer
{
    public static void Initialize(LaboratoryContext context)
    {
        context.Database.EnsureCreated();
        if (context.Researches.Any() && context.Equipments.Any() && context.Scientists.Any())
        {
            return;
        }
        var researches = new[]
        {
            new Research { Title = "Изучение клеток", Description = "Исследование клеточной структуры." },
            new Research { Title = "Генетические исследования", Description = "Изучение генетического материала." }
        };
        var equipments = new[]
        {
            new Equipment { Name = "Микроскоп", Type = "Измерительный прибор"},
            new Equipment { Name = "Пробирки", Type = "Расходник" }
        };
        var scientists = new[]
        {
            new Scientist { Name = "Виктор Юрьевич Иванов", FieldOfStudy = "РНИМУ" },
            new Scientist { Name = "Леонид Ильич Юрков", FieldOfStudy = "РУМ" }
        };
        context.SaveChanges();
    }
}