using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
