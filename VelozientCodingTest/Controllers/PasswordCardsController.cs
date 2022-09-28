using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelozientCodingTest.Models;

namespace VelozientCodingTest.Controllers
{
    public class PasswordCardsController : ApiController
    {
        CardModel cardModel = new CardModel();

        // GET
        [Route("password-cards")]
        [HttpGet]
        public IEnumerable<CardModel> Get()
        {
            return new CardModel().Get();
        }

        // POST
        [Route("password-cards")]
        [HttpPost]
        public bool Post([FromBody] CardModel newCard)
        {
            return cardModel.Insert(newCard);
        }

        // PUT
        [Route("password-cards/{id}")]
        [HttpPut]
        public bool Put(int id, [FromBody] CardModel card)
        {
            return cardModel.Update(card);
        }

        // DELETE
        [Route("password-cards/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return cardModel.Delete(id);
        }
    }
}
