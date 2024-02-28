using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // This is a blackjack card class 
    protected int Value { get; set; }
    protected string Suit { get; set; }
    protected string Rank { get; set; }
    protected bool IsAceHigh { get; set; }
    
    public Card(int value, string suit, string rank, bool isAceHigh)
    {
        Value = value;
        Suit = suit;
        Rank = rank;
        IsAceHigh = isAceHigh;
    }

    public int GetValue()
    {
        return Value;
    }

    public void SetValue(int value)
    {
        if(Rank == "Ace" &&  IsAceHigh)
        {
            if(value == 1)
            {
                Value = 11;
            }
            else
            {
                Value = value;
            }
        }
        else
        {
            Value = value;
        }
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