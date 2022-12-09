using Hearthstone.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Hearthstone.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hearthstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class cardsController : ControllerBase
    {
        private readonly HearthstoneService _hearthstoneService;
        public cardsController(HearthstoneService hearthstoneService) =>
            _hearthstoneService = hearthstoneService;
        
            
        #region F1 Cards
        //F1 An endpoint @ GET /cards that returns all available cards
        // F1.1 Shall have a query parameter page that is used for pagination
        // F1.2 Each page shall consist of at most 100 entries
        // F1.3 Shall have a query parameter setid that is used for filtering cards based on sets
        // F1.4 Shall have a query parameter artist that filters on artist name (exact)
        // F1.5 Shall have a query parameter classid that filters on class
        // F1.6 Shall have a query paramenter rarityid that filters on rarity'
        //

        [HttpGet]
        public async Task<ActionResult<List<DTOCardsNSC>>> GetCards(int setid=0, string? artist=null, int classid=0, int rarityid=0)
        {
            var filter = _hearthstoneService.CreateCardFilter(setid, artist, classid, rarityid);
            var collection = await _hearthstoneService.Cards.Find(filter)
                .Project(NSC => new DTOCardsNSC()
                {
                    Name = NSC.Name,
                    Set = NSC.cardSetId.ToString(),
                    Class = NSC.ClassId.ToString()

                })
                .ToListAsync();
                     
            return collection;


            throw new NotImplementedException();
        }

        [HttpGet("/AllInfo")]
        public async Task<ActionResult<List<Card>>> GetCardsWithAllInfo(int setid = 0, string? artist = null, int classid = 0, int rarityid = 0)
        {
            var filter = _hearthstoneService.CreateCardFilter(setid, artist, classid, rarityid);
            var collection = await _hearthstoneService.Cards.Find(filter).ToListAsync();

            return collection;


            throw new NotImplementedException();
        }


        #endregion


        //#region Not implemented
        //// GET api/<cardsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<cardsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<cardsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<cardsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        //#endregion

    }
}
