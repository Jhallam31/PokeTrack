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
    public class PokemonDetail
    {
        [Display(Name = "Name")]
        public string PokemonName { get; set; }
        
        [Display(Name = "Base XP")]
        public int BaseExperience { get; set; }

        
        
        [Display(Name = "Type 1")]
        public string Type1Name { get; set; }

        [Display(Name = "Type 2")]
        public string Type2Name { get; set; }

       
        [Display(Name = "Move 1")]
        public string MoveOneName { get; set; }
        
        [Display(Name = "Move 2")]
        public string MoveTwoName { get; set; }
        
        [Display(Name = "Move 3")]
        public string MoveThreeName { get; set; }
        
        [Display(Name = "Move 4")]
        public string MoveFourName { get; set; }


    }
}
