using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class GameNetworkManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void JoinHost()
    {
        NetworkManager.Singleton.StartHost();
        statusText.text = "Joined as Host - Waiting for opponent...";

        gameManager.localPlayerSymbol = "X";
    }

    public void JoinClient()
    {
        NetworkManager.Singleton.StartClient();
        statusText.text = "Joined as Client";

        gameManager.localPlayerSymbol = "O";
    }
}