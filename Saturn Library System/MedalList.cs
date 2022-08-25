using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn_Library_System
{
    class MedalList
    {
        private string[] medals = {
            "images/medal1.png",
            "images/medal2.png",
            "images/medal3.png",
            "images/medal4.png",
        };
        public string[] Medals { get => medals; set => medals = value; }
    }
}
