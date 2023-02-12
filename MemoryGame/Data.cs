using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Data
    {
        public levelType levelDiffculty { get;set;}
        public ThemeType Theme { get;set;}
        public Data(levelType levelDiffculty , ThemeType Theme)
        {
            this.levelDiffculty = levelDiffculty;
            this.Theme = Theme;
        }
        public Data()
        {

        }
    }
}
