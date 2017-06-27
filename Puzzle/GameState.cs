using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    public static class GameState
    {
        public static bool ActiveGame { get; set; }
        public static bool EditMode { get; set; }
        public static int ClickedCorrectButtons { get; set; }
        public static int LeftLifesCount { get; set; }
        public static int Score { get; set; }
        public static int GameTime { get; set; }
        public static int LifesCount { get; set; }
    }
}
