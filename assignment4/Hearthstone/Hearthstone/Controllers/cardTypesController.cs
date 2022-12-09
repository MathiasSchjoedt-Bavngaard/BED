﻿using Hearthstone.Models;
using Hearthstone.Services;
using Microsoft.AspNetCore.Mvc;
using Hearthstone.Services;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hearthstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class cardTypesController : ControllerBase
    {
        private readonly HearthstoneService _hearthstoneService;
        private readonly ControllerLogger _logger = new ControllerLogger();
        public cardTypesController(HearthstoneService hearthstoneService) =>
            _hearthstoneService = hearthstoneService;

        #region F5 types
        //F5 An endpoint @ GET /types that returns all available card types
        [HttpGet("/types")]
        public async Task<ActionResult<List<CardType>>> GetTypes()
        {
            //throw new NotImplementedException();
            _logger.OutputLine("GetTypes ran with Query: " + Request.QueryString);
            return await _hearthstoneService.CardTypes.Find(_ => true).ToListAsync();
        }
        #endregion

        //#region autogeneratedEndpoints
        //// GET: api/<cardTypesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<cardTypesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<cardTypesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<cardTypesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<cardTypesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        //#endregion
    }
}
