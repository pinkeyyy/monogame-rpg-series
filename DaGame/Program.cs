namespace DaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MainGame ourGame = new MainGame())
            {
                ourGame.Run();
            }
        }
    }
}
