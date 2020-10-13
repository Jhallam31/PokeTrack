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
        //Absolute lowest available experience for this pokemon
        public int BaseExperience { get; set; }

        //References the ID of the chosen pokemon type. 
        //**Each pokemon can have up to TWO types
        public int? TypeID1 { get; set; }
        public int? TypeID2 { get; set; }

        //Default moves for this pokemon
        public int MoveOneID { get; set; }
        public int? MoveTwoID { get; set; }
        public int? MoveThreeID { get; set; }
        public int? MoveFourID { get; set; }


        //Type Foreign Key
        [ForeignKey("TypeID1")]
        public virtual Type Type1 { get; set; }

        //Type 2 Foreign Key (nullable)
        [ForeignKey("TypeID2")]
        public virtual Type Type2 { get; set; }
        
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
