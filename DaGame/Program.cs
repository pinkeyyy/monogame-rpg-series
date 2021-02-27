using CommandLine;

namespace DaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            LaunchOptions options = new LaunchOptions();

            Parser.Default.ParseArguments<LaunchOptions>(args)
                .WithParsed(o => options = o);

            using (MainGame ourGame = new MainGame(options))
            {
                ourGame.Run();
            }
        }
    }
}
