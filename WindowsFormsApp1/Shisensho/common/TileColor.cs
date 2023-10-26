using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shisensho
{
    public class TileColor
    {
        public TileColor()
        {
            TilePairs.Add("一", Color.Red);
            TilePairs.Add("二", Color.Red);
            TilePairs.Add("三", Color.Red);
            TilePairs.Add("四", Color.Red);
            TilePairs.Add("五", Color.Red);
            TilePairs.Add("六", Color.Red);
            TilePairs.Add("七", Color.Red);
            TilePairs.Add("八", Color.Red);
            TilePairs.Add("九", Color.Red);

            TilePairs.Add("①", Color.Blue);
            TilePairs.Add("②", Color.Blue);
            TilePairs.Add("③", Color.Blue);
            TilePairs.Add("④", Color.Blue);
            TilePairs.Add("⑤", Color.Blue);
            TilePairs.Add("⑥", Color.Blue);
            TilePairs.Add("⑦", Color.Blue);
            TilePairs.Add("⑧", Color.Blue);
            TilePairs.Add("⑨", Color.Blue);

            TilePairs.Add("Ⅰ", Color.Green);
            TilePairs.Add("Ⅱ", Color.Green);
            TilePairs.Add("Ⅲ", Color.Green);
            TilePairs.Add("Ⅳ", Color.Green);
            TilePairs.Add("Ⅴ", Color.Green);
            TilePairs.Add("Ⅵ", Color.Green);
            TilePairs.Add("Ⅶ", Color.Green);
            TilePairs.Add("Ⅷ", Color.Green);
            TilePairs.Add("Ⅸ", Color.Green);

            TilePairs.Add("東", Color.Black);
            TilePairs.Add("南", Color.Black);
            TilePairs.Add("西", Color.Black);
            TilePairs.Add("北", Color.Black);
            TilePairs.Add("白", Color.Black);
            TilePairs.Add("發", Color.Black);
            TilePairs.Add("中", Color.Black);
        }

        public Dictionary<string, Color> TilePairs { get; set; } = new Dictionary<string, Color>();

    }
}
