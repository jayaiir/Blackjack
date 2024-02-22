using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<CardObject> deck;

    public Deck()
    {
        deck = new List<CardObject>();
        CreateDeck();
    }

    public void CreateDeck()
    {
        string[] suits = new string[] { "hearts", "diamonds", "clubs", "spades" };
        string[] ranks = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        foreach (string suit in suits)
        {
            for (int j = 0; j < ranks.Length; j++)
            {
                string rank = ranks[j];
                bool isAce = ranks[j] == "Ace"; // check if the card is an Ace
                int value = j < 10 ? j+1 : 10; // Ace to 10 have their face values, face cards have value 10

                CardObject card = new CardObject(value, suit, rank, isAce);
                deck.Add(card);
            }
        }
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            CardObject temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public CardObject DrawCard()
    {
        CardObject card = deck[0];
        deck.RemoveAt(0);
        return card;
    }

    // draw initial hand for player or dealer
    public List<CardObject> DrawHand(int numCards)
    {
        List<CardObject> hand = new List<CardObject>();
        for (int i = 0; i < numCards; i++)
        {
            hand.Add(DrawCard());
        }
        return hand;
    }

}