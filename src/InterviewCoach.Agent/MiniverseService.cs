namespace InterviewCoach.Agent;

/// <summary>
/// Background service that keeps the Interview Coach agent visible in the
/// Miniverse pixel world by sending periodic heartbeats to the Miniverse server.
/// </summary>
internal sealed class MiniverseService : BackgroundService
{
    private const string AgentName = "interview-coach";
    private const int HeartbeatIntervalSeconds = 30;

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<MiniverseService> _logger;

    public MiniverseService(IHttpClientFactory httpClientFactory, ILogger<MiniverseService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Miniverse service started. Agent '{AgentName}' will send heartbeats every {Interval}s.",
            AgentName, HeartbeatIntervalSeconds);

        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(HeartbeatIntervalSeconds));

        await SendHeartbeatAsync("idle", null, stoppingToken);

        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            await SendHeartbeatAsync("idle", null, stoppingToken);
        }
    }

    public async Task ReportStateAsync(string state, string? task, CancellationToken cancellationToken = default)
    {
        await SendHeartbeatAsync(state, task, cancellationToken);
    }

    private async Task SendHeartbeatAsync(string state, string? task, CancellationToken cancellationToken)
    {
        try
        {
            var client = _httpClientFactory.CreateClient(Constants.MiniverseHttpClient);

            var payload = task is null
                ? (object)new { agent = AgentName, state }
                : new { agent = AgentName, state, task };

            using var response = await client.PostAsJsonAsync("/api/heartbeat", payload, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Miniverse heartbeat returned {StatusCode}.", response.StatusCode);
            }
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _logger.LogDebug(ex, "Miniverse heartbeat failed — server may not be available yet.");
        }
    }
}
