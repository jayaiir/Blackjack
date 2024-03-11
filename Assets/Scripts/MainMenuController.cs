using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    public GameObject startButton;
    public GameObject instructionsButton;
    public GameObject quitButton;
    public GameObject instructionsPanel;
    public GameObject backButton;
    public GameObject nextButton;
    public GameObject previousButton;
    public GameObject instructionsTextPanel;
    public int currentInstruction;
    public int totalInstructions;

    // Start is called before the first frame update
    void Start()
    {
        instructionsPanel.SetActive(false);
        startButton.GetComponent<Button>().onClick.AddListener(StartGame);
        instructionsButton.GetComponent<Button>().onClick.AddListener(Instructions);
        backButton.GetComponent<Button>().onClick.AddListener(Back);
        nextButton.GetComponent<Button>().onClick.AddListener(NextInstruction);
        previousButton.GetComponent<Button>().onClick.AddListener(PreviousInstruction);
        quitButton.GetComponent<Button>().onClick.AddListener(Application.Quit);
        currentInstruction = 0;
        totalInstructions = instructionsTextPanel.transform.childCount;
        
    }

    public void StartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void Instructions() {

        instructionsPanel.SetActive(true);
        instructionsTextPanel.transform.GetChild(currentInstruction).gameObject.SetActive(true);
        previousButton.SetActive(false);
        

        // set other instructions to false
        for(int i = 1; i < totalInstructions; i++) {
            instructionsTextPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
        

    }

    public void NextInstruction() {
        instructionsTextPanel.transform.GetChild(currentInstruction).gameObject.SetActive(false);
        currentInstruction++;
        instructionsTextPanel.transform.GetChild(currentInstruction).gameObject.SetActive(true);

        if(currentInstruction == 0) {
            previousButton.SetActive(false);
        } else {
            previousButton.SetActive(true);
        }

        if(currentInstruction == (totalInstructions - 1)) {
            nextButton.SetActive(false);
        } else {
            nextButton.SetActive(true);
        }
    }

    public void PreviousInstruction() {
        instructionsTextPanel.transform.GetChild(currentInstruction).gameObject.SetActive(false);
        currentInstruction--;
        instructionsTextPanel.transform.GetChild(currentInstruction).gameObject.SetActive(true);

        if(currentInstruction == 0) {
            previousButton.SetActive(false);
        } else {
            previousButton.SetActive(true);
        }

        if(currentInstruction == totalInstructions) {
            nextButton.SetActive(false);
        } else {
            nextButton.SetActive(true);
        }
    }

    public void Back() {
        instructionsPanel.SetActive(false);
        instructionsTextPanel.transform.GetChild(currentInstruction).gameObject.SetActive(false);
        currentInstruction = 0;
        previousButton.SetActive(false);
        nextButton.SetActive(true);
    }
}
