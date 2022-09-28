using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace VelozientCodingTest.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public List<CardModel> Get()
        {
            //get all cards
            List<CardModel> cards = ReadFile();

            return cards;
        }

        public bool Insert(CardModel newCard)
        {
            //get all cards
            List<CardModel> cards = ReadFile();

            //assign new ID
            if (cards.Any())
            {
                int newID = cards.Max(x => x.Id) + 1;
                newCard.Id = newID;
            }
            else
                newCard.Id = 1;

            //add the new item to the list
            cards.Add(newCard);

            //write file
            WriteFile(cards);

            return true;
        }

        public bool Update(CardModel newCard)
        {
            //get all cards
            List<CardModel> cards = ReadFile();
            //assign new values
            CardModel oldCard = cards.FirstOrDefault(x => x.Id == newCard.Id);

            oldCard.Name = newCard.Name;
            oldCard.URL = newCard.URL;
            oldCard.Username = newCard.Username;
            oldCard.Password = newCard.Password;

            //write file
            WriteFile(cards);

            return true;
        }

        public bool Delete(int id)
        {
            //get all cards
            List<CardModel> cards = ReadFile();

            //remove item from the list
            int index = cards.FindIndex(x => x.Id == id);
            cards.RemoveAt(index);

            //write the data
            WriteFile(cards);

            return true;
        }

        private List<CardModel> ReadFile()
        {
            //read file
            List<CardModel> cards = new List<CardModel>();
            string data = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/App_Data/CardsData.js");

            if (!string.IsNullOrWhiteSpace(data))
                cards = JsonConvert.DeserializeObject<List<CardModel>>(data);

            return cards;
        }
        private void WriteFile(List<CardModel> data)
        {
            //write file
            string cardsData = JsonConvert.SerializeObject(data);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/App_Data/CardsData.js", cardsData);
        }
    }
}