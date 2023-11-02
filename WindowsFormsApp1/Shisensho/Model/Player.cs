using Formtest.common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Formtest.Model
{
    public class Player
    {
        public int playerNumber;
        Stopwatch stopwatch = new Stopwatch();
        DispatcherTimer timer = new DispatcherTimer();
        public List<Tile> getTileList = new List<Tile>();
    }
}
