using PokeTrack.Data;
using PokeTrack.Data.Tables;
using PokeTrack.Models.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Services
{
    public class MoveService
    {
        public MoveService() { }
        public bool CreateMove(MoveCreate model)
        {
            var entity =
                new Move()
                {
                    MoveName = model.MoveName,
                    Accuracy = model.Accuracy,
                    Power =model.Power,
                    Description=model.Description,
                    TypeID = model.MoveTypeID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MoveDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MoveListItem> GetMoveList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .MoveDb
                    .Where(e => e.MoveName == e.MoveName)
                    .Select(
                        e =>
                        new MoveListItem
                        {
                            MoveID = e.MoveID,
                            MoveName = e.MoveName,
                            TypeName = e.MoveType.TypeName

                        }
                        );
                return query.ToArray();
            }
        }

        public MoveDetail GetMoveByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MoveDb
                    .Single(e => e.MoveID == id);
                return
                new MoveDetail
                {
                    
                    MoveID = entity.MoveID,
                    MoveName = entity.MoveName,
                    Accuracy = entity.Accuracy,
                    Power = entity.Power,
                    Description = entity.Description,
                    TypeName =entity.MoveType.TypeName

                };

            }
        }

        public bool UpdateMove(MoveEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.MoveDb
                    .Single(e => e.MoveID == id);
                entity.MoveName = model.MoveName;
                entity.Accuracy = model.Accuracy;
                entity.Power = model.Power;
                entity.Description = model.Description;
                

                return ctx.SaveChanges() == 1;


            }
        }
        public bool DeleteMove(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MoveDb
                        .Single(e => e.MoveID == id);

                ctx.MoveDb.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
    
