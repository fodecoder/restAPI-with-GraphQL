using Common.DB.Extension;
using Common.GraphQL.Extensions;
using Common.GraphQL.Schemas;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Inventory.BL.Interfaces.Repository;
using Inventory.BL.Interfaces.Service;
using Inventory.BL.Services.AutoMapper;
using Inventory.BL.Services.Context;
using Inventory.BL.Services.Queries;
using Inventory.BL.Services.Repository;
using Inventory.BL.Services.Services;

var builder = WebApplication.CreateBuilder ( args );

// Add services to the container.

builder.Services.AddControllers ();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer ();
builder.Services.AddSwaggerGen ();

// Add Repositories
builder.Services.AddScoped<IItemRepository , ItemRepository> ();

// Add Services
builder.Services.AddScoped<IItemService , ItemService> ();

// Add AutoMapper
builder.Services.AddAutoMapper ( typeof ( InventoryProfile ) );

// Add Db Context
builder.Services.AddDatabase<InventoryDBContext> ();

// Add GraphQL 
builder.Services.AddSingleton<IDocumentExecuter , DocumentExecuter> ();
builder.Services.AddSingleton<IGraphQLSerializer , GraphQLSerializer> ();
builder.Services.AddTransient<InventoryQuery> ();
builder.Services.AddScoped<ISchema , GraphQLSchema<InventoryQuery>> ( services => new GraphQLSchema<InventoryQuery> ( new SelfActivatingServiceProvider ( services ) ) );
builder.Services.AddGraphQLExtension<InventoryQuery> ( options =>
{
    options.EndPoint = "/graphql";
} );

var app = builder.Build ();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment ())
{
    app.UseSwagger ();
    app.UseSwaggerUI ();
}

app.UseHttpsRedirection ();

app.UseAuthorization ();

app.MapControllers ();

app.UseRouting ();

// GraphQL
app.UseGraphQLGraphiQL ();
app.UseGraphQL<ISchema> ();

app.UseHttpsRedirection ();

app.Run ();
