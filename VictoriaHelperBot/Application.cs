using System.Collections;

namespace VictoriaHelperBot;

public class Application
{
    private readonly BotClient _bot;

    public Application()
    {
        string? token = Environment.GetEnvironmentVariable("victoria_token");

        if (token == null)
        {
            throw new Exception("Token not found in environment variables");
        }

        _bot = new BotClient(token);
    }

    public async void Start()
    {
        await _bot.StartReceiver();
    }
}