using PokeTrack.Models.Pokemon;
using PokeTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace PokeTrack.WebAPI.Controllers
{
    public class PokemonController : ApiController
    {

        private PokemonService CreatePokemonService()
        {
            return new PokemonService();
        }

        [HttpGet]
        public IHttpActionResult GetPokemonList()
        {
            PokemonService service = CreatePokemonService();
            var pokeList = service.GetPokemonList();
            return Ok(pokeList);
        }

        [HttpGet]
        public IHttpActionResult GetPokemonSingle(int id)
        {
            PokemonService service = CreatePokemonService();
            var pokemon = service.GetPokemonByID(id);
            return Ok(pokemon);
        }

        [HttpPost]
        public IHttpActionResult PostPokemon(PokemonCreate pokemon)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePokemonService();

            if (!service.CreatePokemon(pokemon))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EditPokemon(PokemonEdit pokemon, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePokemonService();

            if (!service.UpdatePokemon(pokemon, id))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeletePokemon(int id)
        {
            var service = CreatePokemonService();

            if (!service.DeletePokemon(id))
                return InternalServerError();

            return Ok();
        }


    }
}
