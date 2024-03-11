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
    private bool flipDealerCard;
    public bool blackjack;
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the game
        deck = new List<CardObject>();
        playerHand = new List<CardObject>();
        dealerHand = new List<CardObject>();
        CreateDeck();
        ShuffleDeck();
        flipDealerCard = true;
        blackjack = false;
    }

    public void CreateDeck()
    {
        string[] suits = new string[] { "Heart", "Diamond", "Club", "Spade"};
        string[] ranks = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        foreach (string suit in suits)
        {
            for (int j = 0; j < ranks.Length; j++)
            {
                string rank = ranks[j];
                bool isAce = ranks[j] == "A"; // check if the card is an Ace

                GameObject cardObject = new GameObject("Card");
                cardObject.transform.parent = deckParent.transform;
                CardObject card = cardObject.AddComponent<CardObject>();
                card.Initialize(suit, rank, isAce);
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

        while (GetHandValue(dealerHand) < 17)
        {
            dealerHand.Add(deck[0]);
            Destroy(deck[0].gameObject);
            deck.RemoveAt(0);
            UpdateHandValues();
        }

        DetermineWinner();
        DisplayHands();
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
        int value = 0;
        int aceCount = 0;

        foreach (CardObject card in hand)
        {
            if (card.GetRank() == "A")
            {
                aceCount++;
                value += 11; // Initially count Aces as 11
            }
            else if (card.GetRank() == "K" || card.GetRank() == "Q" || card.GetRank() == "J")
            {
                value += 10; // For face cards
            }
            else
            {
                value += int.Parse(card.GetRank()); // For numbered cards
            }
        }

        // If value is over 21 and there's an Ace counted as 11, subtract 10
        while (value > 21 && aceCount > 0)
        {
            value -= 10;
            aceCount--;
        }

        return value;
    }

    public void DisplayHands()
    {
        for (int i = 0; i < playerHand.Count; i++) // Display the player's hand
        {
            if (playerHandObjects[i].transform.childCount > 0)
            {
                Destroy(playerHandObjects[i].transform.GetChild(0).gameObject);
            }

            Card card = playerHand[i];
            GameObject location = playerHandObjects[i];
            CardObject cardObject = Instantiate(cardObjectPrefab, location.transform.position, Quaternion.Euler(90, 0, 0));
            cardObject.transform.parent = location.transform;
            cardObject.SetCardObject(card.GetRank(), card.GetSuit());
        }

        for (int i = 0; i < dealerHand.Count; i++) // Display the dealer's hand
        {
            if (dealerHandObjects[i].transform.childCount > 0)
            {
                Destroy(dealerHandObjects[i].transform.GetChild(0).gameObject);
            }

            Card card = dealerHand[i];
            GameObject location = dealerHandObjects[i];
            CardObject cardObject;
            
            if (i == 1 && flipDealerCard) // Hide the dealer's second card
            {
                cardObject = Instantiate(cardObjectPrefab, location.transform.position, Quaternion.Euler(-90, 0, 0));
                cardObject.transform.parent = location.transform;
                
            } else
            {
                cardObject = Instantiate(cardObjectPrefab, location.transform.position, Quaternion.Euler(90, 0, 0));
                cardObject.transform.parent = location.transform;
            }

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

    public void CheckPlayerBlackjack()
    {
        // Check if the player has blackjack
        if (GetHandValue(playerHand) == 21)
        {
            blackjack = true;
            DetermineWinner();
        }
    }

    void DetermineWinner()
    {
        flipDealerCard = false;
        int playerHandValue = GetHandValue(playerHand);
        int dealerHandValue = GetHandValue(dealerHand);
        uiController.ShowGameResult(playerHandValue, dealerHandValue);
        uiController.DisablePlayerButtons();
    }
    
    public void ResetGame()
    {
        playerHand.Clear();
        dealerHand.Clear();
        deck.Clear();
        CreateDeck();
        ShuffleDeck();
        flipDealerCard = true;
        blackjack = false;
        foreach (GameObject playerHandObject in playerHandObjects)
        {
            if (playerHandObject.transform.childCount > 0)
            {
                Destroy(playerHandObject.transform.GetChild(0).gameObject);
            }
        }
        foreach (GameObject dealerHandObject in dealerHandObjects)
        {
            if (dealerHandObject.transform.childCount > 0)
            {
                Destroy(dealerHandObject.transform.GetChild(0).gameObject);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
