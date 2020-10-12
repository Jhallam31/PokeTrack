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
                    PokemonTypeID = model.PokemonTypeID,
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
                            TypeName = e.PokemonType.TypeName

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
                    TypeName = entity.PokemonType.TypeName,
                    MoveOneName = entity.MoveOne.MoveName,
                    MoveTwoName = entity.MoveTwo.MoveName,
                    MoveThreeName = entity.MoveThree.MoveName,
                    MoveFourName = entity.MoveFour.MoveName,

                };

            }
        }

        public bool UpdatePokemon(PokemonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.PokemonDb
                    .Single(e => e.PokemonID == e.PokemonID);
                entity.PokemonName = model.PokemonName;
                entity.BaseExperience = model.BaseExperience;
                entity.PokemonType.PokemonTypeID = model.PokemonTypeID;
                entity.MoveOneID = model.MoveOneID;
                entity.MoveTwoID = model.MoveTwoID;
                entity.MoveThreeID = model.MoveThreeID;
                entity.MoveFourID = model.MoveFourID;

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
