using PokeTrack.Models.Pokemon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.Move
{
    public class MoveDetail
    {
        public int MoveID { get; set; }
        public string MoveName { get; set; }
        public int Accuracy { get; set; }
        public int Power { get; set; }

        public ICollection<PokemonDetail> PokemonWithThisMove { get; set; }
    }
}
