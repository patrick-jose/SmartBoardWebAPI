using SmartBoardWebAPI.Business;
using SmartBoardWebAPI.Data.Repository;
using SmartBoardWebAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ILogWriter, LogWriter>();
builder.Services.AddSingleton<ICommentRepository, CommentRepository>();
builder.Services.AddSingleton<ISectionRepository, SectionRepository>();
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IStatusHistoryRepository, StatusHistoryRepository>();
builder.Services.AddSingleton<IBoardRepository, BoardRepository>();
builder.Services.AddSingleton<IBoardBusiness, BoardBusiness>();
builder.Services.AddSingleton<IUserBusiness, UserBusiness>();
builder.Services.AddSingleton<ITaskBusiness, TaskBusiness>();
builder.Services.AddSingleton<IStatusHistoryBusiness, StatusHistoryBusiness>();
builder.Services.AddSingleton<ICommentBusiness, CommentBusiness>();
builder.Services.AddSingleton<ISectionBusiness, SectionBusiness>();

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
