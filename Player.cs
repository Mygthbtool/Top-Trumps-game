//Player.cs
using System.Collections.Generic;
using System.Dynamic;

// Represent a player in the game who holds a collection of cards
public class Player
{
    public string Name { get; set; }
    public List<Card> Cards { get; set; }

    public Player(string name)
    {
        Name = name;
        Cards = new List<Card>();
    }

    // Add card to the player's collection
    public void AddCard(Card card)
    {
        Cards.Add(card);
    }

    // Play the top card from the player's collection
    public Card PlayCard()
    {
        if (Cards.Count > 0)
        {
            Card card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }
        return null;
    }

    // Check if the player has any card left
    public bool HasCards()
    {
        return Cards.Count > 0;
    }

}