using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    // UIController class will manage the UI for the blackjack game. This class will have methods to update the UI based on the game state.

    // Properties for the UI elements

    [SerializeField] private TextMeshProUGUI playerHandText;
    [SerializeField] private TextMeshProUGUI dealerHandText;
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

    }
    
    void InitializeUI()
    {
        // Initialize the UI elements
        playerHandText.text = "";
        dealerHandText.text = "";
        playerScoreText.text = "";
        dealerScoreText.text = "";
        gameResultText.text = "";
        hitButton.interactable = false;
        standButton.interactable = false;
        dealButton.interactable = true;
        playAgainButton.interactable = false;
    }

    public void DealButtonClicked()
    {
        // Deal button clicked
        // Update the UI
        hitButton.interactable = true;
        standButton.interactable = true;
        dealButton.interactable = false;
        playAgainButton.interactable = false;
        gameResultText.text = "";
    }

    public void HitButtonClicked()
    {
        // Hit button clicked
        // Update the UI
    }

    public void StandButtonClicked()
    {
        // Stand button clicked
        // Update the UI
    }
    

}
