using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    // UIController class will manage the UI for the blackjack game. This class will have methods to update the UI based on the game state.

    // Properties for the UI elements
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI dealerScoreText;
    [SerializeField] private TextMeshProUGUI gameResultText;
    [SerializeField] private Button hitButton;
    [SerializeField] private Button standButton;
    [SerializeField] private Button dealButton;
    [SerializeField] private Button playAgainButton;


    void Start()
    {
        // Initialize the UI
        InitializeUI();
        dealButton.onClick.AddListener(DealButtonClicked);
        hitButton.onClick.AddListener(HitButtonClicked);
        standButton.onClick.AddListener(StandButtonClicked);

    }
    
    void InitializeUI()
    {
        // Initialize the UI elements
        hitButton.interactable = false;
        standButton.interactable = false;
        dealButton.interactable = true;
    }

    public void DealButtonClicked()
    {
        // Deal button clicked
        // Update the UI
        gameManager.DealHand();
        hitButton.interactable = true;
        standButton.interactable = true;
        dealButton.interactable = false;
    }

    public void HitButtonClicked()
    {
        // Hit button clicked
        // Update the UI
        gameManager.PlayerHit();
    }

    public void StandButtonClicked()
    {
        // Stand button clicked
        // Update the UI
        gameManager.PlayerStand();
        hitButton.interactable = false;
        standButton.interactable = false;
        dealButton.interactable = false;
    }

    public void UpdateHandValuesText(int playerScore, int dealerScore)
    {
        // Update the player score
        // Update the UI
        playerScoreText.text = "Player Score: " + playerScore;
        dealerScoreText.text = "Dealer Score: " + dealerScore;
    }

    public void ShowGameResult(int playerScore, int dealerScore)
    {
        // Show the game result
        // Update the UI
        if (playerScore > 21)
        {
            gameResultText.text = "Player Busts! Dealer Wins!";
        }
        else if (dealerScore > 21)
        {
            gameResultText.text = "Dealer Busts! Player Wins!";
        }
        else if (playerScore == dealerScore)
        {
            gameResultText.text = "It's a Tie!";
        }
        else if (playerScore == 21)
        {
            gameResultText.text = "Blackjack! Player Wins!";
        }
        else if (dealerScore == 21)
        {
            gameResultText.text = "Blackjack! Dealer Wins!";
        }
        else if (playerScore > dealerScore)
        {
            gameResultText.text = "Player Wins!";
        }
        else
        {
            gameResultText.text = "Dealer Wins!";
        }

    }
    

}
