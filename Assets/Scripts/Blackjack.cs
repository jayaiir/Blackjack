using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackjack : MonoBehaviour
{

    // This is a blackjack game class. This class needs to manage the game state, the player's hand, and the dealer's hand.
    private List<Card> playerHand;
    private List<Card> dealerHand;
    private Deck deck;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the game
        playerHand = new List<Card>();
        dealerHand = new List<Card>();
        deck = new Deck();
        deck.CreateDeck();
        deck.ShuffleDeck();
    }
}

