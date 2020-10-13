using PokeTrack.Data;
using PokeTrack.Data.Tables;
using PokeTrack.Models.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Services
{
    public class PokemonService
    {
        public PokemonService() { }
        public bool CreatePokemon(PokemonCreate model)
        {
            var entity =
                new Pokemon()
                {
                    PokemonName = model.PokemonName,
                    BaseExperience = model.BaseExperience,
                    
                    //Type 2 is nullable
                    TypeID1 = model.PokemonTypeID1,
                    TypeID2= model.PokemonTypeID2,

                    //Moves 2-4 are nullable
                    MoveOneID = model.MoveOneID,
                    MoveTwoID = model.MoveTwoID,
                    MoveThreeID = model.MoveThreeID,
                    MoveFourID = model.MoveFourID
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PokemonDb.Add(entity);
                
                 
                return ctx.SaveChanges() == 1;
            }
            
        }

        public IEnumerable<PokemonListItem> GetPokemonList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .PokemonDb
                    .Where(e => e.PokemonName == e.PokemonName)
                    .Select(
                        e =>
                        new PokemonListItem
                        {
                            PokemonID = e.PokemonID,
                            PokemonName = e.PokemonName,
                            TypeName1 = e.Type1.TypeName,
                            TypeName2 = e.Type2.TypeName

                        }
                        );
                return query.ToArray();
            }
        }

        public PokemonDetail GetPokemonByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PokemonDb
                    .Single(e => e.PokemonID == id);
                return
                new PokemonDetail
                {
                    PokemonName = entity.PokemonName,
                    BaseExperience = entity.BaseExperience,
                    Type1Name = entity.Type1.TypeName,
                    Type2Name = entity.Type2.TypeName,
                    MoveOneName = entity.MoveOne.MoveName,
                    MoveTwoName = entity.MoveTwo.MoveName,
                    MoveThreeName = entity.MoveThree.MoveName,
                    MoveFourName = entity.MoveFour.MoveName,

                };

            }
        }

        public bool UpdatePokemon(PokemonEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.PokemonDb
                    .Single(e => e.PokemonID == id);
                entity.PokemonName = model.PokemonName;
                entity.BaseExperience = model.BaseExperience;

                return ctx.SaveChanges() == 1;


            }
        }
        public bool DeletePokemon(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PokemonDb
                        .Single(e => e.PokemonID == id);

                ctx.PokemonDb.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
