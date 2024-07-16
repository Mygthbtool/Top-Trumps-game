//Game.cs



public class Game
{
    public List<Card> Deck { get; set; }
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    private Random rand = new Random();

    public Game(Player player1, Player player2)
    {
        Deck = new List<Card>();
        Player1 = player1;
        Player2 = player2;
    }

    // Initialize the deck with Super cars characters and their attributes.
    public void InitializeDeck()
    {
        Deck.Add(new Card("Bugatti Chiron", 261, 1479, 2500000, 10));
        Deck.Add(new Card("Lamborghini Aventador ", 217, 759, 518000, 9));
        Deck.Add(new Card("Ferrari LaFerrari", 218, 950, 1200000, 8.5));
        Deck.Add(new Card("Porche 911 GTE", 211, 700, 290000, 8.3));
        Deck.Add(new Card("McLaren P1", 220, 903, 1100000, 9.5));
        Deck.Add(new Card("Koenigsegg Jesko", 300, 1600, 2700000, 10));
        Deck.Add(new Card("Aston Martin Valkyrie", 250, 1160, 2800000, 9));
        Deck.Add(new Card("Pagani Huayra", 238, 730, 2400000, 8.8));
        Deck.Add(new Card("Tesla Roadster (2022)", 250, 1000, 200000, 8));
        Deck.Add(new Card("Ford GT", 216, 647, 500000, 7));

    }

    // Shuffle the deck of cards using a random algorithm.
    public void ShuffleDeck()
    {
        for (int i = Deck.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            Card temp = Deck[i];
            Deck[i] = Deck[j];
            Deck[j] = temp;
        }
    }

    // Distribute the shuffled deck evenly between the two players.
    public void DistributeCards()
    {
        for (int i = 0; i < Deck.Count; i++)
        {
            if (i % 2 == 0)
            {
                Player1.AddCard(Deck[i]);
            }
            else
            {
                Player2.AddCard(Deck[i]);
            }
        }
    }

    //Main game logic that hundels turns, comparisons and winning.

    public void PlayGame()
    {
        while (Player1.HasCards() && Player2.HasCards())
        {
            // Players play their top card.
            Card card1 = Player1.PlayCard();
            Card card2 = Player2.PlayCard();
            Console.WriteLine($"{Player1.Name} plays {card1}");
            Console.WriteLine($"{Player2.Name} plays {card2}");
            int choice;
            // Prompt user to select an attribute.

            while (true)
            {
                Console.WriteLine("Choose an attribute to compare: (1) Top Speed (2) Horsepower (3) Price (4) Design");
                string input = Console.ReadLine();
                // validate it the input is a valid number.

                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 4)
                {
                    break; // Input is valid. exit the loop.
                }
                else
                {
                    Console.WriteLine("input is invalid. Please enter a number between 1 and 5");
                }

            }


            int result = CompareCards(card1, card2, choice);
            // Determine the winner Of the round.
            if (result > 0)
            {
                Console.WriteLine($"{Player1.Name} wins this round!");
                Player1.AddCard(card1);
                Player1.AddCard(card2);
            }
            else if (result < 0)
            {
                Console.WriteLine($"{Player2.Name} wins this round!");
                Player2.AddCard(card1);
                Player2.AddCard(card2);
            }
            else
            {
                Console.WriteLine("It's a draw!");
                Player1.AddCard(card1);
                Player2.AddCard(card2);
            }
            // Show the number of each cards player has left
            Console.WriteLine($"{Player1.Name} has {Player1.Cards.Count} cards left");
            Console.WriteLine($"{Player2.Name} has {Player2.Cards.Count} cards left");
        }

        //Determine the overall winner
        if (Player1.HasCards())
        {
            Console.WriteLine($"{Player1.Name} wins the game!");
        }
        else
        {
            Console.WriteLine($"{Player2.Name} wins the game!");
        }
    }
    // Compare two cards based on the chosen attribute
    public int CompareCards(Card card1, Card card2, int attribute)
    {
        switch (attribute)
        {
            case 1:
                return card1.TopSpeed.CompareTo(card2.TopSpeed);
            case 2:
                return card1.HorsePower.CompareTo(card2.HorsePower);
            case 3:
                return card2.Price.CompareTo(card1.Price);
            case 4:
                return card2.Design.CompareTo(card1.Design);
            default:
                throw new ArgumentException("Invalid Attribute selected.");
        }
    }

}
