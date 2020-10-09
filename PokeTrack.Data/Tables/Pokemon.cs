using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Data.Tables
{
    public class Pokemon
    {
        [Key]
        [Display(Name = "ID")]
        public int PokemonID { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string PokemonName { get; set; }
        
        [Required]
        [Display(Name = "Base XP")]
        public int BaseExperience { get; set; }

        public int PokemonTypeID { get; set; }
        public int MoveOneID { get; set; }
        public int MoveTwoID { get; set; }
        public int MoveThreeID { get; set; }
        public int MoveFourID { get; set; }
        
        [ForeignKey("PokemonTypeID")]
        public virtual PokemonType PokemonType { get; set; }

        //Move 1
        
        [ForeignKey("MoveOneID")]
        public virtual Move MoveOne { get; set; }
        //Move 2
        
        [ForeignKey("MoveTwoID")]
        public virtual Move MoveTwo { get; set; }

        //Move 3
        
        [ForeignKey("MoveThreeID")]
        public virtual Move MoveThree { get; set; }

        //Move 4
        
        [ForeignKey("MoveFourID")]
        public virtual Move MoveFour { get; set; }
    }
}
