using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Data.Tables
{
    public class Move
    {
        [Key]
        public int MoveID { get; set; }
        
        [Required]
        public string MoveName { get; set; }
        
        
        //Describes the function/effects of the move (is nullable)
        public string Description { get; set; }

        //Accuracy percentage
        public int Accuracy { get; set; }

        public int Power { get; set; }

        //type of move
        public int TypeID { get; set; }
        
        [ForeignKey("TypeID")]
        public virtual Type MoveType { get; set; }

    }
}
