//Card.cs
using System;

// Represent a card with attributes for the game
public class Card
{
    // Card properties
    public string Name { get; set; }
    public int TopSpeed { get; set; }
    public int HorsePower { get; set; }
    public int Price { get; set; }
    public double Design { get; set; }

    // Card constructor
    public Card(string name, int topSpeed, int horsePower, int price, double design)
    {
        string Name = name;
        int TopSpeed = topSpeed;
        int HorsePower = horsePower;
        int Price = price;
        double Design = design;
    }

    // Method output the car attributres
    public override string ToString()
    {
        return $"{Name}, Top Speed: {TopSpeed} mph, Horse Power: {HorsePower} hp, Price: £{Price}, Design: {Design} out of 10";
    }

}