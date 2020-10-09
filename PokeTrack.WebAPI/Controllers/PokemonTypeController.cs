using PokeTrack.Models.Type;
using PokeTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PokeTrack.WebAPI.Controllers
{
    public class PokemonTypeController : ApiController
    {
        private PokemonTypeService CreatePokemonTypeService()
        {
            return new PokemonTypeService();
        }

        [HttpGet]
        public IHttpActionResult GetPokemonTypeListItems()
        {
            PokemonTypeService service = CreatePokemonTypeService();
            var pokeTypeList = service.GetPokemonTypeList();
            return Ok(pokeTypeList);
        }

        [HttpGet]
        public IHttpActionResult GetPokemonTypeSingle(int id)
        {
            PokemonTypeService service = CreatePokemonTypeService();
            var pokemonType = service.GetPokemonTypeByID(id);
            return Ok(pokemonType);
        }

        [HttpPost]
        public IHttpActionResult PostPokemonType(PokemonTypeCreate pokemonType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePokemonTypeService();

            if (!service.CreatePokemonType(pokemonType))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EditPokemonType(PokemonTypeEdit pokemonType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePokemonTypeService();

            if (!service.UpdatePokemonType(pokemonType))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeletePokemonType(int id)
        {
            var service = CreatePokemonTypeService();

            if (!service.DeletePokemonType(id))
                return InternalServerError();

            return Ok();
        }
    }
}
