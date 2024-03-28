using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static string currentTurn;
    public static string[] currentGrid = new string[9];

    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private GameObject[] squareButtons;
    [SerializeField] private GameObject[] strikeOuts;
    [SerializeField] private GameObject gamePanel;
    private string gameWinner;

    public string localPlayerSymbol;

    bool gameStarted;

    public void StartGame()
    {
        gameStarted = true;
        gamePanel.SetActive(true);

        currentTurn = "X";
        updateCurrentTurn();
    }

    public void checkForWin ()
    {
        if (currentGrid[0] == currentGrid[3] && currentGrid[3] == currentGrid[6] && (currentGrid[0] == "X" || currentGrid[0] == "O"))
        {
            strikeOuts[0].SetActive(true);
            gameWinner = currentGrid[0];
            gameOver();
        }
        else if (currentGrid[1] == currentGrid[4] && currentGrid[4] == currentGrid[7] && (currentGrid[1] == "X" || currentGrid[1] == "O"))
        {
            strikeOuts[1].SetActive(true);
            gameWinner = currentGrid[1];
            gameOver();
        }
        else if (currentGrid[2] == currentGrid[5] && currentGrid[5] == currentGrid[8] && (currentGrid[2] == "X" || currentGrid[2] == "O"))
        {
            strikeOuts[2].SetActive(true);
            gameWinner = currentGrid[2];
            gameOver();
        }
        else if (currentGrid[0] == currentGrid[1] && currentGrid[1] == currentGrid[2] && (currentGrid[0] == "X" || currentGrid[0] == "O"))
        {
            strikeOuts[3].SetActive(true);
            gameWinner = currentGrid[0];
            gameOver();
        }
        else if (currentGrid[3] == currentGrid[4] && currentGrid[4] == currentGrid[5] && (currentGrid[3] == "X" || currentGrid[3] == "O"))
        {
            strikeOuts[4].SetActive(true);
            gameWinner = currentGrid[3];
            gameOver();
        }
        else if (currentGrid[6] == currentGrid[7] && currentGrid[7] == currentGrid[8] && (currentGrid[6] == "X" || currentGrid[6] == "O"))
        {
            strikeOuts[5].SetActive(true);
            gameWinner = currentGrid[6];
            gameOver();
        }
        else if (currentGrid[2] == currentGrid[4] && currentGrid[4] == currentGrid[6] && (currentGrid[2] == "X" || currentGrid[2] == "O"))
        {
            strikeOuts[6].SetActive(true);
            gameWinner = currentGrid[2];
            gameOver();
        }
        else if (currentGrid[0] == currentGrid[4] && currentGrid[4] == currentGrid[8] && (currentGrid[0] == "X" || currentGrid[0] == "O"))
        {
            strikeOuts[7].SetActive(true);
            gameWinner = currentGrid[0];
            gameOver();
        }
    }

    private void gameOver ()
    {
        for (int i = 0; i < squareButtons.Length; i++)
        {
            Button squareBtn = squareButtons[i].GetComponent<Button>();
            SquareButton btnScript = squareButtons[i].GetComponent<SquareButton>();

            squareBtn.enabled = false;

            currentGrid[i] = "";
            
        }
        displayText.text = "WINNER: " + gameWinner;
    }

    public void resetGame ()
    {
        for (int i=0; i < squareButtons.Length; i++)
        {
            Button squareBtn = squareButtons[i].GetComponent<Button>();
            SquareButton btnScript = squareButtons[i].GetComponent<SquareButton>();
            
            squareBtn.enabled = true;
            btnScript.eraseContents();

            currentGrid[i] = "";
        }

        for (int i=0; i<strikeOuts.Length; i++)
        {
            strikeOuts[i].SetActive(false);
        }

        currentTurn = "X";
        updateCurrentTurn();
    }

    public void updateCurrentTurn()
    {
        displayText.text = "Current Turn: " + currentTurn;
    }
}
