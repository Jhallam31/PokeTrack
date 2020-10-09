using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.Type
{
    public class PokemonTypeEdit
    {
        [Display(Name = "Name")]
        public string TypeName { get; set; }
        
    }
}
