using Hearthstone.Models;
using Hearthstone.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Hearthstone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HearthstoneController : ControllerBase
    {
        private readonly HearthstoneService _hearthstoneService;

        public HearthstoneController(HearthstoneService hearthstoneService) =>
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

        [HttpGet("/cards")]
        public async Task<ActionResult<List<Card>>> GetCards(int setid, string artist, int classid, int rarityid)
        {

            throw new NotImplementedException();
        }

        #endregion

        #region F2 sets
        //F2 An endpoint @ GET /sets that returns all available sets
        [HttpGet("/sets")]
        public async Task<ActionResult<List<Set>>> GetSets()
        {
            return await _hearthstoneService.Sets.Find(_ => true).ToListAsync();
        }

        #endregion

        #region F3 rarities
        //F3 An endpoint @ GET /rarities that returns all available rarities
        [HttpGet("/rarities")]
        public async Task<ActionResult<List<Rarity>>> GetRarities()
        {
            //throw new NotImplementedException();
            return await _hearthstoneService.Rarities.Find(_ => true).ToListAsync();
        }
        #endregion

        #region F4 classses
        //F4 An endpoint @ GET /classes that returns all available classes
        [HttpGet("/classes")]
        public async Task<ActionResult<List<Class>>> GetClasses()
        {
            //throw new NotImplementedException();
            return await _hearthstoneService.Classes.Find(_ => true).ToListAsync();
        }
        #endregion

        #region F5 types
        //F5 An endpoint @ GET /types that returns all available card types
        [HttpGet("/types")]
        public async Task<ActionResult<List<CardType>>> GetTypes()
        {
            //throw new NotImplementedException();
            return await _hearthstoneService.CardTypes.Find(_ => true).ToListAsync();
        }
        #endregion
    }
}
