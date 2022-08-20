AllTask allTask = new AllTask();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(allTask.MainTask);

app.Run();
