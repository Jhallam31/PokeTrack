using PokeTrack.Data.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.Pokemon
{
    public class PokemonListItem
    {
        [Display(Name ="ID")]
        public int PokemonID { get; set; }
        
        [Display(Name ="Name")]
        public string PokemonName { get; set; }

        
        [Display(Name = "Type 1")]
        public string TypeName1 { get; set; }
        
        [Display(Name = "Type 2")]
        public string TypeName2 { get; set; }





    }
}
