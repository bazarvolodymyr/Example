using DAL.EF;
using DAL.Repository;
using DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000/"); 
        });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<AppDbContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database")
               //, sqlOptions => sqlOptions.EnableRetryOnFailure()
                ));
builder.Services.AddScoped<IUserRepo, UserRepo>(
            sr => new UserRepo(sr.GetRequiredService<AppDbContext>()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();
