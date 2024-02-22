using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardObject : Card  // This class inherits from the Card class
{
 
    [SerializeField] private TextMesh[] cardText;
    [SerializeField] private GameObject[] cardSprites;
    [SerializeField] private Sprite[] cardSpriteArray;

    public CardObject(int value, string suit, string rank, bool isAceHigh) : base(value, suit, rank, isAceHigh)
    {
        // Constructor body (if needed)
    }

    // this method will set the card object to the card name and suit visually
    public void SetCardObject(string rank, string suit)
    {

        for (int i = 0; i < cardText.Length; i++)
        {
            // set the card's rank
            cardText[i].text = rank; 

            if(suit == "Hearts")
            {
                cardText[i].color = Color.red;
                cardSprites[i].GetComponent<Image>().sprite = cardSpriteArray[0];
            }
            else if(suit == "Diamonds")
            {
                // set the card's suit
                cardText[i].color = Color.red;
                cardSprites[i].GetComponent<Image>().sprite = cardSpriteArray[1];
            }
            else if(suit == "Clubs")
            {
                cardText[i].color = Color.black;
                cardSprites[i].GetComponent<Image>().sprite = cardSpriteArray[2];
            }
            else if(suit == "Spades")
            {
                cardText[i].color = Color.black;
                cardSprites[i].GetComponent<Image>().sprite = cardSpriteArray[3];
            }
        }

        
        



      
    }




}