using Dicom.Server;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<DicomServerWindowsService>();

builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "DicomServerWindowsService";
});

var host = builder.Build();

host.Run();
