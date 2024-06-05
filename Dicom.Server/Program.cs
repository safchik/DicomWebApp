using Dicom.Server;
using DicomWebApp.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<DicomServerWindowsService>();
builder.Services.AddDbContext<MyDicomContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "DicomServerWindowsService";
});

var host = builder.Build();

host.Run();
