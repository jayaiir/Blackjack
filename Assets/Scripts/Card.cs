using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // This is a blackjack card class 
    private int value { get; set; }
    private string suit { get; set; }
    private string rank { get; set; }
    private bool isAceHigh { get; set; }
    
    public Card(int value, string suit, string rank, bool isAceHigh)
    {
        this.value = value;
        this.suit = suit;
        this.rank = rank;
        this.isAceHigh = isAceHigh;
    }

    public int GetValue()
    {
        return value;
    }

    public void SetValue(int value)
    {
        if(name == "Ace" &&  isAceHigh)
        {
            if(value == 1)
            {
                this.value = 11;
            }
            else
            {
                this.value = value;
            }
        }
        else
        {
            this.value = value;
        }

    }

}
