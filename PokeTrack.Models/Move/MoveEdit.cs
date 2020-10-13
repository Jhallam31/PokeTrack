using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.Move
{
    public class MoveEdit
    {
        public int MoveID { get; set; }
        public string MoveName { get; set; }
        public int Accuracy { get; set; }
        public int Power { get; set; }
        public string Description { get; set; }

        //User can edit the type of this move
        public int TypeID { get; set; }
    }
}
