using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaManager
{
    public class Game : Media
    {
        public string Studio;
        public List<string> Platform;
        public string Publisher;
        public uint Players
        {
            get { return _players; }
            set { if (value > 0) _players = value; else _players = 1; }
        }
        private uint _players;

        public Game()
        {
            Studio = string.Empty;
            Platform = new List<string>();
            Publisher = string.Empty;
            Players = 1;
        }
    }
}
