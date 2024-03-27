using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SquareButton : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI squareText;
    private Button button;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(playTurn);
    }

    void playTurn ()
    {
        squareText.text = "" + GameManager.currentTurn;
        GameManager.currentGrid[int.Parse(gameObject.name)-1] = GameManager.currentTurn;

        if (GameManager.currentTurn == "X")
        {
            GameManager.currentTurn = "O";
            squareText.color = new Color(0, 0, 255, 255);
        }
        else if (GameManager.currentTurn == "O")
        {
            GameManager.currentTurn = "X";
            squareText.color = new Color(255, 0, 0, 255);
        }

        button.enabled = false;
        gameManager.updateCurrentTurn();
        gameManager.checkForWin();
    }

    public void eraseContents ()
    {
        squareText.text = "";
    }
}
