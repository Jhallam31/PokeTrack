﻿using PokeTrack.Data.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.Type
{
    public class PokemonTypeDetail
    {
        [Display(Name = "Name")]
        public string TypeName { get; set; }

        [Display(Name = "Pokemon Count")]
        public int? PokemonCount { get; set; }

        public List<PokeTrack.Data.Tables.Pokemon> PokemonWithThisType { get; set; }


    }
}
