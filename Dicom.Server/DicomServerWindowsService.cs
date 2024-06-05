using System.Text;
using Dicom;
using Dicom.Network;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Dicom.Server
{
    public class DicomServerWindowsService : BackgroundService
    {
        private readonly ILogger<DicomServerWindowsService> _logger;
        private IDicomServer _dicomServer;

        public DicomServerWindowsService(ILogger<DicomServerWindowsService> logger)
        {
            _logger = logger;
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
            _logger.LogInformation("Starting DICOM server...");
            _dicomServer = Dicom.Network.DicomServer.Create<SimpleDicomService>(104);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping DICOM server...");
            _dicomServer?.Dispose();
            return base.StopAsync(cancellationToken);
        }
    }

    public class SimpleDicomService : DicomService, IDicomServiceProvider
    {
        private readonly ILogger<SimpleDicomService> _logger;

        public SimpleDicomService(INetworkStream stream, Encoding fallbackEncoding, Dicom.Log.Logger dicomLogger)
            : base(stream, fallbackEncoding, dicomLogger)
        {
            _logger = new Microsoft.Extensions.Logging.LoggerFactory().CreateLogger<SimpleDicomService>();
        }

        public Task OnReceiveAssociationRequestAsync(DicomAssociation association)
        {
            return SendAssociationAcceptAsync(association);
        }

        public Task OnReceiveAssociationReleaseRequestAsync()
        {
            return SendAssociationReleaseResponseAsync();
        }

        public void OnReceiveAbort(DicomAbortSource source, DicomAbortReason reason)
        {
            _logger.LogWarning("Received abort from source {source} with reason {reason}", source, reason);
        }

        public void OnConnectionClosed(Exception exception)
        {
            _logger.LogInformation("Connection closed");
            if (exception != null)
            {
                _logger.LogError(exception, "Connection closed with error");
            }
        }



        public void OnCStoreRequestException(string tempFileName, Exception e)
        {
            _logger.LogError(e, "Error processing C-STORE request: {TempFileName}", tempFileName);
        }
    }
}