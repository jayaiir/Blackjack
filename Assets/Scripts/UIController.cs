using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

   
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI dealerScoreText;
    [SerializeField] private TextMeshProUGUI gameResultText;
    [SerializeField] private Button hitButton;
    [SerializeField] private Button standButton;
    [SerializeField] private Button dealButton;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button restartButton;


    void Start()
    {

        EnableDealButton();
        dealButton.interactable = true;
        dealerScoreText.gameObject.SetActive(false);
        playerScoreText.gameObject.SetActive(false);
        dealButton.onClick.AddListener(DealButtonClicked);
        hitButton.onClick.AddListener(HitButtonClicked);
        standButton.onClick.AddListener(StandButtonClicked);
        restartButton.onClick.AddListener(RestartButtonClicked);
        quitButton.onClick.AddListener(QuitButtonClicked);

    }
    
    public void DealButtonClicked()
    {
     
        gameManager.DealHand();
        playerScoreText.gameObject.SetActive(true);
        EnablePlayerButtons();
        gameManager.CheckPlayerBlackjack();
    }

    public void HitButtonClicked()
    {
        gameManager.PlayerHit();
    }

    public void StandButtonClicked()
    {
        gameManager.PlayerStand();
    }

    public void UpdateHandValuesText(int playerScore, int dealerScore)
    {
        
        playerScoreText.text = "Player Score: " + playerScore;
        dealerScoreText.text = "Dealer Score: " + dealerScore;
    }

    public void DisablePlayerButtons()
    {
        hitButton.interactable = false;
        standButton.interactable = false;
    }

    public void EnablePlayerButtons()
    {
        dealButton.gameObject.SetActive(false);
        hitButton.interactable = true;
        standButton.interactable = true;
    }

    public void EnableDealButton()
    {
        dealButton.gameObject.SetActive(true);
        DisablePlayerButtons();
    }

    public void RestartButtonClicked()
    {
        
        gameManager.ResetGame();
        playerScoreText.gameObject.SetActive(false);
        dealerScoreText.gameObject.SetActive(false);
        gameResultText.text = "";
        EnableDealButton();
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }

    public void ShowGameResult(int playerScore, int dealerScore)
    {
        dealerScoreText.gameObject.SetActive(true);

        if(gameManager.blackjack) 
        {
            gameResultText.text = "Blackjack! Player Wins!";
            return;
        }

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
