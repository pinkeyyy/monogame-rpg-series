using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGame
{
    class LaunchOptions
    {
        [Option("map", Required = false, HelpText = "Provide a map to load up initially.")]
        public string Map { get; set; }
    }
}
