using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    private List<CardObject> playerHand;
    private List<CardObject> dealerHand;
    [SerializeField] private GameObject[] playerHandObjects;
    [SerializeField] private GameObject[] dealerHandObjects;
    private List<CardObject> deck;
    [SerializeField] private CardObject cardObjectPrefab;
    [SerializeField] private GameObject deckParent;
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the game
        deck = new List<CardObject>();
        playerHand = new List<CardObject>();
        dealerHand = new List<CardObject>();
        CreateDeck();
        ShuffleDeck();
    }

    public void CreateDeck()
    {
        string[] suits = new string[] { "Heart", "Diamond", "Club", "Spade"};
        string[] ranks = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        foreach (string suit in suits)
        {
            for (int j = 0; j < ranks.Length; j++)
            {
                string rank = ranks[j];
                bool isAce = ranks[j] == "Ace"; // check if the card is an Ace
                int value = j < 10 ? j+1 : 10; // Ace to 10 have their face values, face cards have value 10

                GameObject cardObject = new GameObject("Card");
                cardObject.transform.parent = deckParent.transform; // Set the parent of the cardObject
                CardObject card = cardObject.AddComponent<CardObject>();
                card.Initialize(value, suit, rank, isAce);
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

    public void DealHand()
    {
        // Deal the player and dealer hands
        playerHand.Add(deck[0]);
        Destroy(deck[0].gameObject);
        deck.RemoveAt(0);

        dealerHand.Add(deck[0]);
        Destroy(deck[0].gameObject);
        deck.RemoveAt(0);

        playerHand.Add(deck[0]);
        Destroy(deck[0].gameObject);
        deck.RemoveAt(0);

        dealerHand.Add(deck[0]);
        Destroy(deck[0].gameObject);
        deck.RemoveAt(0);

        DisplayHands();
        UpdateHandValues();
    }

    public void PlayerHit()
    {
        // Player hits
        playerHand.Add(deck[0]);
        Destroy(deck[0].gameObject); 
        deck.RemoveAt(0);
        CheckPlayerBust();
        DisplayHands();
        UpdateHandValues();
    }

    public void PlayerStand()
    {
        // Player stands
        // Dealer's turn
        while (GetHandValue(dealerHand) < 17)
        {
            dealerHand.Add(deck[0]);
            Destroy(deck[0].gameObject);
            deck.RemoveAt(0);
            DisplayHands();
            UpdateHandValues();
        }
        DetermineWinner();
    }

    // update player and dealer hand values
    public void UpdateHandValues()
    {
        int playerHandValue = GetHandValue(playerHand);
        int dealerHandValue = GetHandValue(dealerHand);
        uiController.UpdateHandValuesText(playerHandValue, dealerHandValue);
    }

    public int GetHandValue(List<CardObject> hand)
    {
        // Get the value of the hand
        int handValue = 0;
        int aceCount = 0;
        foreach (CardObject card in hand)
        {
            handValue += card.GetValue();
            if (card.GetValue() == 11)
            {
                aceCount++;
            }
        }
        while (handValue > 21 && aceCount > 0)
        {
            handValue -= 10;
            aceCount--;
        }
        return handValue;
    }

    public void DisplayHands()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            Card card = playerHand[i];
            GameObject location = playerHandObjects[i];
            CardObject cardObject = Instantiate(cardObjectPrefab, location.transform.position, Quaternion.identity);
            cardObject.SetCardObject(card.GetRank(), card.GetSuit());
        }

        for (int i = 0; i < dealerHand.Count; i++)
        {
            Card card = dealerHand[i];
            GameObject location = dealerHandObjects[i];
            CardObject cardObject = Instantiate(cardObjectPrefab, location.transform.position, Quaternion.identity);
            cardObject.SetCardObject(card.GetRank(), card.GetSuit());
        }
    }

    void CheckPlayerBust()
    {
        // Check if the player busts
        if (GetHandValue(playerHand) > 21)
        {
            DetermineWinner();
        }
    }

    void DetermineWinner()
    {
        // Determine the winner
        int playerHandValue = GetHandValue(playerHand);
        int dealerHandValue = GetHandValue(dealerHand);
        uiController.ShowGameResult(playerHandValue, dealerHandValue);
    }
    
}
