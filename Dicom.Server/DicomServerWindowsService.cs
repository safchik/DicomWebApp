using DicomObjects;
using DicomObjects.EventArguments;


namespace Dicom.Server;

public class DicomServerWindowsService : BackgroundService
{
    private readonly ILogger<DicomServerWindowsService> _logger;
    private readonly DicomServer _dicomServer;

    public DicomServerWindowsService(ILogger<DicomServerWindowsService> logger)
    {
        _logger = logger;
        _dicomServer = new DicomServer()
        {
            AllowExtendedNegotiation = true,
            DefaultStatus = 0xC000
        };
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            await Task.Delay(1000, stoppingToken);
        }
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        DicomLicence.ActivateOnLine("TR-2506-8503-3367", string.Empty, string.Empty, out var result);

        _dicomServer.Listen(104);
        _dicomServer.ReceivingPixelData += OnPixelDataReceived;
        return base.StartAsync(cancellationToken);
    }

    private void OnPixelDataReceived(object sender, ReceivingPixelDataArgs args)
    {
        throw new NotImplementedException();
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _dicomServer.UnlistenAll();
        return base.StopAsync(cancellationToken);
    }
}
