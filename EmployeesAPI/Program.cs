namespace EmployeesAPI
{
    using MongoCRUD.Data;
    using MongoCRUD.Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthorization();

            MongoDB db = new MongoDB("test");


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();


            //Read all
            app.MapGet("/users", async() =>
            {
                var users = await db.GetAllUsers("Robin");
                return Results.Ok(users);
            });


            //Reead by id
            app.MapGet("/user/{id}", (int id) =>
            {
              
            });

            //Create a user
            app.MapPost("/user", async (UserModel user) =>
            {
                var userTocreate = await db.AddUser("Robin", user);
                return Results.Ok(userTocreate);
            });


            //Updates a user
            app.MapPut("/user/{id}", (int id) =>
            {

            });

            //Deletes a user
            app.MapDelete("/user/{id}", (int id) =>
            {

            });



            app.Run();
        }
    }
}