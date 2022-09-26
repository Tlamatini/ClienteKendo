using Microsoft.OpenApi.Models;

#region Swagger
void AddSwagger(IServiceCollection services)
{
    //Con este metodo agregamos swagger
    services.AddSwaggerGen(options =>
    {
        var groupName = "v1";

        options.SwaggerDoc(groupName, new OpenApiInfo
        {
            Title = $"Tutorial01 {groupName}",
            Version = groupName,
            Description = "Tutorial01 API",
            Contact = new OpenApiContact
            {
                Name = "Tutoriales",
                Email = string.Empty,
                Url = new Uri("http://localhost:5008/"),
            }
        });
    });
}
#endregion

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

#region Swagger
AddSwagger(builder.Services);
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute( name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

#region Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tutorial01 API V1");
});
#endregion

app.Run();
