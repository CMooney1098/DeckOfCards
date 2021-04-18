using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class Program
    {

        static void Main(string[] args)
        {
            bool valid = false;
            bool valid2 = false;
            Deck deck = new Deck();
            deck.CreateDeck();
            while (valid2 == false)
            {
                Console.WriteLine("Would you like to shuffle the deck?");
                string shuffle = Console.ReadLine();
                if (shuffle.ToLower() == "yes")
                {
                    deck.Shuffle();
                    while (valid == false)
                    {
                        Console.WriteLine("Would you like to be dealt a card?");
                        string response = Console.ReadLine();
                        if (response.ToLower() == "yes")
                        {
                            deck.Deal();
                            Console.ReadLine();
                            valid = true;
                        }
                        else if (response.ToLower() == "no")
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Response, Please enter either 'yes' or 'no'");
                        }
                    }
                    valid2 = true;
                }
                else if (shuffle.ToLower() == "no")
                {
                    while (valid == false)
                    {
                        Console.WriteLine("Would you like to be dealt a card?");
                        string response = Console.ReadLine();
                        if (response.ToLower() == "yes")
                        {
                            deck.Deal();
                            Console.ReadLine();
                            valid = true;
                        }
                        else if (response.ToLower() == "no")
                        {
                            Console.Write("Exiting...");
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Response, Please enter either 'yes' or 'no'");
                        }
                    }
                    valid2 = true;
                }
                else
                {
                    Console.WriteLine("Invalid Response, Please enter either 'yes' or 'no'");
                }

            }
        }
        //Gives the users control giving them access to shuffle and ask to get dealt cards with appropriate validation

        public class Card
        {
            public enum Suits
            {
                Hearts = 0,
                Diamonds,
                Clubs,
                Spades,
            }

            public int Value
            {
                get;
                set;
            }

            public Suits Suit
            {
                get;
                set;
            }

            public string SuitValue
            {
                get
                {
                    string CardType = string.Empty;
                    switch (Value)
                    {
                        case (14):
                            CardType = "Ace";
                            break;
                        case (13):
                            CardType = "King";
                            break;
                        case (12):
                            CardType = "Queen";
                            break;
                        case (11):
                            CardType = "Jack";
                            break;
                        default:
                            CardType = Value.ToString();
                            break;

                    }
                    return CardType;
                //Creates the Suits
                }
            }
            public string CardType
            {
                 get
                 {
                    return SuitValue + " of " + Suit.ToString();
                 }
            }
            public Card(int Value, Suits Suit)
            {
                this.Value = Value;
                this.Suit = Suit;
            }
        
        }

        public class Deck
        {
            public List<Card> Cards = new List<Card>();
            public void CreateDeck()
            {
                 for (int i = 0; i < 52; i++)
                 {
                     Card.Suits suit = (Card.Suits)(Math.Floor((decimal)i / 13));
                     int val = i % 13 + 2;
                     Cards.Add(new Card(val, suit));
                 }
            //Creates the cards assinging them a value and a suit for all 52 cards
            }
            public void Deal()
            {
                foreach(Card card in this.Cards)
                {
                    Console.WriteLine(card.CardType);
                }
            //Outputs all the cards shuffled or not
            }

            public void Shuffle()
            {
                Random rand = new Random();
                Card temp;
                for (int TimesShuffled = 0; TimesShuffled < 1000; TimesShuffled++)
                //Shuffles the deck 1000 times
                {
                    for (int i = 0; i < 52; i++)
                    {
                        int ShuffledCard = rand.Next(13);
                        temp = Cards[i];
                        Cards[i] = Cards[ShuffledCard];
                        Cards[ShuffledCard] = temp;
                    }
                //Shuffles the deck and swaps the cards 
                }


            }

        }












    }

    
}
