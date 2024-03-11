using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardObject : Card  // This class inherits from the Card class
{
 
    [SerializeField] private TMP_Text[] cardText;
    [SerializeField] private GameObject[] cardSprites;
    [SerializeField] private Sprite[] cardSpriteArray;
    [SerializeField] private int cardValue;
    [SerializeField] private string cardSuit;
    [SerializeField] private string cardRank;
    [SerializeField] private bool cardIsAce;

    public CardObject(int value, string suit, string rank, bool isAce) : base(value, suit, rank, isAce)
    {
        
    }

    public void Initialize(string suit, string rank, bool isAce)
    {
        this.Suit = suit;
        this.Rank = rank;
        this.IsAce = isAce;
        cardSuit = suit;
        cardRank = rank;
    }

    // this method will set the card object to the card name and suit visually
    public void SetCardObject(string rank, string suit)
    {

        for (int i = 0; i < cardText.Length; i++)
        {
            // set the card's rank
            cardText[i].text = rank; 

            if(suit == "Heart")
            {
                cardText[i].color = Color.red;
                cardSprites[i].GetComponent<SpriteRenderer>().sprite = cardSpriteArray[0];
            }
            else if(suit == "Diamond")
            {
                cardText[i].color = Color.red;
                cardSprites[i].GetComponent<SpriteRenderer>().sprite = cardSpriteArray[1];
            }
            else if(suit == "Club")
            {
                cardText[i].color = Color.black;
                cardSprites[i].GetComponent<SpriteRenderer>().sprite = cardSpriteArray[2];
            }
            else if(suit == "Spade")
            {
                cardText[i].color = Color.black;
                cardSprites[i].GetComponent<SpriteRenderer>().sprite = cardSpriteArray[3];
            }
        }
    }

}