using PokeTrack.Data.Tables;
using PokeTrack.Models.Move;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.Pokemon
{
    public class PokemonEdit
    {
        [Display(Name = "Name")]
        public string PokemonName { get; set; }
        
        [Display(Name = "Base XP")]
        public int BaseExperience { get; set; }

        
        [Display(Name ="Type 1 ID")]
        public int TypeID1 { get; set; }
        
        [Display(Name = "Type 2 ID")]
        public int TypeID2 { get; set; }

        
        
        [Display(Name = "Move 1")]
        public int MoveOneID { get; set; }
        
        [Display(Name = "Move 2")]
        public int MoveTwoID { get; set; }
        
        [Display(Name = "Move 3")]
        public int MoveThreeID { get; set; }
        
        [Display(Name = "Move 4")]
        public int MoveFourID { get; set; }
    }
}
