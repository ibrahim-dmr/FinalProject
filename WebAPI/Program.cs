using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



 void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddSingleton<IProductService, ProductManager>();
    services.AddSingleton<IProductDal, EfProductDal>();



}


//builder.Services.AddControllers();

//builder.Services.AddTransient<IProductService, ProductManager>();
//builder.Services.AddTransient<IProductDal, EfProductDal>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
