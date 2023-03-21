using PublishMessages;
using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILogWriter, LogWriter>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStatusHistoryRepository, StatusHistoryRepository>();
builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<IBoardBusiness, BoardBusiness>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<ITaskBusiness, TaskBusiness>();
builder.Services.AddScoped<IStatusHistoryBusiness, StatusHistoryBusiness>();
builder.Services.AddScoped<ICommentBusiness, CommentBusiness>();
builder.Services.AddScoped<ISectionBusiness, SectionBusiness>();
builder.Services.AddScoped<ISectionBusiness, SectionBusiness>();
builder.Services.AddScoped<ISendService, SendService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
