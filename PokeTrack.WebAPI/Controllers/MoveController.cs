using PokeTrack.Models.Move;
using PokeTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PokeTrack.WebAPI.Controllers
{
    public class MoveController : ApiController
    {
        private MoveService CreateMoveService()
        {
            return new MoveService();
        }

        [HttpGet]
        public IHttpActionResult GetMoveListItems()
        {
            MoveService service = CreateMoveService();
            var moveList = service.GetMoveList();
            return Ok(moveList);
        }

        [HttpGet]
        public IHttpActionResult GetMoveSingle(int id)
        {
            MoveService service = CreateMoveService();
            var move = service.GetMoveByID(id);
            return Ok(move);
        }

        [HttpPost]
        public IHttpActionResult PostMove(MoveCreate move)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMoveService();

            if (!service.CreateMove(move))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EditMove(MoveEdit move)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMoveService();

            if (!service.UpdateMove(move))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMove(int id)
        {
            var service = CreateMoveService();

            if (!service.DeleteMove(id))
                return InternalServerError();

            return Ok();
        }
    }
}
