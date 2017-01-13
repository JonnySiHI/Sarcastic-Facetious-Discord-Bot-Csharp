using Discord;
using Discord.Commands;
using System;

namespace Lucillebot
{
    class Lucillebot
    {
        DiscordClient discord;

        public Lucillebot()
        {
            discord = new DiscordClient(x =>
            {

                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;

            });

            discord.UsingCommands(x =>
            {

                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;

            });

            var commands = discord.GetService<CommandService>();

            commands.CreateCommand("Hello").Do(async (e) =>

            {
                await e.Channel.SendMessage("Hey? what do you want?");

            });

            commands.CreateCommand("How are you?").Do(async (e) =>

            {
                await e.Channel.SendMessage("Good thanks, how are you? (not that i care at all)");


            });


            discord.ExecuteAndWait(async () =>

           {

               await discord.Connect("", TokenType.Bot);


            });
        }
            

    private void Log(object sender, LogMessageEventArgs e)
    {

        Console.WriteLine(e.Message);
        }
    }
}
