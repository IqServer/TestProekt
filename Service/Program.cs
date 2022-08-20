//класс строитель, добавляем сервисы в веб приложение
using Rt.DbLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//добавление 
builder.Services.AddControllers();

// метод описывается как метод для поддержки минимальных API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<StudentService>();

///проверка
//мердж
//создание вебприложения
WebApplication app = builder.Build();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseNpgsql(configuration.GetConnectionString("Db"));
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}
);

//подключаем сваггер, Если среда разработки Developer
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//http -> https перенаправление
app.UseHttpsRedirection();

//добавление middleware авторизации 
app.UseAuthorization();

// маршрут к конечной точке
app.MapGet("/", () => "Hello World!");
app.MapControllers();
//запуск приложения 
app.Run();
