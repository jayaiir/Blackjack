using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // This is a blackjack card class 
    protected int Value { get; set; }
    protected string Suit { get; set; }
    protected string Rank { get; set; }
    protected bool IsAce { get; set; }
    
    public Card(int value, string suit, string rank, bool isAce)
    {
        Value = value;
        Suit = suit;
        Rank = rank;
        IsAce = isAce;
    }

    public int GetValue()
    {
        return Value;
    }

    public string GetSuit()
    {
        return Suit;
    }

    public string GetRank()
    {
        return Rank;
    }
}