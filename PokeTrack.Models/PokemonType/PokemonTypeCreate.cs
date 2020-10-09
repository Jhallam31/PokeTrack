﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.Type
{
    public class PokemonTypeCreate
    {
        public int PokemonTypeID { get; set; }
        [Display(Name ="Name")]
        public string TypeName { get; set; }

    }
}
