using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashAnalogue
{
    internal class PwdCommand : Command
    {
        public override string Run()
        {
            string path = Directory.GetCurrentDirectory();
            return path;
        }
    }
}
