using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Data.Tables
{
    public class PokemonType
    {
        [Key]
        [Display(Name = "ID")]
        public int PokemonTypeID { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string TypeName { get; set; }

        [Display(Name = "Pokemon Count")]
        public int PokemonCount { get; set; }

        [Display(Name = "Pokemon")]
        public ICollection<Pokemon> PokemonWithThisType { get; set; }
    }
}
