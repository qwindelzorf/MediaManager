using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaManager
{
    public class Game : Media
    {
        public string Studio;
        [Flags]
        public enum Platforms
        {
            None,
            NES,
            SNES,
            Gameboy,
            GameboyAdvance,
            DS,
            Wii,
            PSOne,
            PSTwo,
            PSThree,
            PSP,
            XBox,
            XBox360,
            Windows,
            Linux,
            Mac,
        }
        public Platforms Platform;
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
            Platform = Platforms.None;
            Publisher = string.Empty;
            Players = 1;
        }
    }
}
