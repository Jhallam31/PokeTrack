using PokeTrack.Data;
using PokeTrack.Data.Tables;
using PokeTrack.Models.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Services
{
    public class PokemonTypeService
    {
        public PokemonTypeService() { }
        public bool CreatePokemonType(PokemonTypeCreate model)
        {
            var entity =
                new PokemonType()
                {
                    
                    TypeName = model.TypeName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TypeDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PokemonTypeListItem> GetPokemonTypeList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .TypeDb
                    .Where(e => e.TypeName == e.TypeName)
                    .Select(
                        e =>
                        new PokemonTypeListItem
                        {
                            PokemonTypeID = e.PokemonTypeID,
                            TypeName = e.TypeName,
                            PokemonCount = e.PokemonWithThisType.Count()

                        }
                        );
                return query.ToArray();
            }
        }

        public PokemonTypeDetail GetPokemonTypeByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TypeDb
                    .Single(e => e.PokemonTypeID == id);
                return
                new PokemonTypeDetail
                {
                    TypeName = entity.TypeName,
                    PokemonCount = entity.PokemonWithThisType.Count()

                };

            }
        }

        public bool UpdatePokemonType(PokemonTypeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.TypeDb
                    .Single(e => e.PokemonTypeID == e.PokemonTypeID);
                entity.TypeName = model.TypeName;
                

                return ctx.SaveChanges() == 1;


            }
        }
        public bool DeletePokemonType(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TypeDb
                        .Single(e => e.PokemonTypeID == id);

                ctx.TypeDb.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
