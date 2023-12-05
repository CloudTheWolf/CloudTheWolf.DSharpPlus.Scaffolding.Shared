namespace CloudTheWolf.DSharpPlus.Scaffolding.Shared.Tests
{
    using global::DSharpPlus;
    using Microsoft.Extensions.Logging;

    public class ShardBot : IShardBot
    {
        public DiscordShardedClient Client { get; set; }

        public DiscordRestClient Rest { get; set; }

        public IReadOnlyDictionary<int, CommandsNextExtension> Commands { get; set; }

        public IReadOnlyDictionary<int, InteractivityExtension> Interactivity { get; set; }

        public IReadOnlyDictionary<int, VoiceNextExtension> Voice { get; set; }

        public IReadOnlyDictionary<int, LavalinkConfiguration> LavalinkConfig { get; set; }

        public IReadOnlyDictionary<int, SlashCommandsExtension> SlashCommandsExt { get; set; }

        public static DiscordConfiguration DiscordConfig = new ()
                                                               {
                                                                   Token = "super-secret-token-owo",
                                                                   TokenType = TokenType.Bot,
                                                                   AutoReconnect = true,
                                                                   MinimumLogLevel = LogLevel.Debug,
                                                               };
    }

    [TestFixture]
    public class ShardBotTests
    {
        [Test]
        public void Test_ValidateSharedBot()
        {
            // Arrange
            var client = new DiscordShardedClient(ShardBot.DiscordConfig);
            var rest = new DiscordRestClient(ShardBot.DiscordConfig);
            var commands = new Dictionary<int, CommandsNextExtension>();
            var interactivity = new Dictionary<int, InteractivityExtension>();
            var voice = new Dictionary<int, VoiceNextExtension>();
            var lavalink = new Dictionary<int, LavalinkConfiguration>();
            var slashCommands = new Dictionary<int, SlashCommandsExtension>();

            var bot = new ShardBot
                          {
                              Client = client,
                              Rest = rest,
                              Commands = commands,
                              Interactivity = interactivity,
                              Voice = voice,
                              LavalinkConfig = lavalink,
                              SlashCommandsExt = slashCommands
                          };

            // Act
            var actualClient = bot.Client;
            var actualRest = bot.Rest;
            var actualCommands = bot.Commands;
            var actualInteractivity = bot.Interactivity;
            var actualVoice = bot.Voice;
            var actualLavalink = bot.LavalinkConfig;
            var actualSlashCommands = bot.SlashCommandsExt;

            // Assert
            Assert.Equals(client, actualClient);
            Assert.Equals(rest, actualRest);
            Assert.Equals(commands, actualCommands);
            Assert.Equals(interactivity, actualInteractivity);
            Assert.Equals(voice, actualVoice);
            Assert.Equals(lavalink, actualLavalink);
            Assert.Equals(slashCommands, actualSlashCommands);
        }
    }
}