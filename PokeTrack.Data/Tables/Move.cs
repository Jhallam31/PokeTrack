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
        [Display(Name ="ID")]
        public int MoveID { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string MoveName { get; set; }

        public int Accuracy { get; set; }
        public int Power { get; set; }

        //Pokemon Count = count of PokemonWithThisMove
        [Display(Name = "Pokemon Count")]
        public int PokemonCount { get; set; }

        //Collection of instances of Pokemon that contain this move
        [Display(Name = "Pokemon")]
        public ICollection<Pokemon> PokemonWithThisMove { get; set; }

    }
}
