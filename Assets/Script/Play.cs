using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    [FormerlySerializedAs("win")] [SerializeField] private Button playAgain;
    [FormerlySerializedAs("loss")] [SerializeField] private Button quit;
    [FormerlySerializedAs("winEvent")] [SerializeField] private UnityEvent finishEvent;
    [SerializeField] private UnityEvent resetEvent;
    [SerializeField] private UnityEvent resetEventClient;
    [SerializeField] public static bool hasPlayed;
    public NetworkManager _networkManager;
    public GameObject host, client;
    public Level _level;

    private void Start()
    {
        _level = gameObject.GetComponent<Level>();
        playAgain.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }

    public void SetButtonActive()
    {
        playAgain.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
    }

    public void SetButtonInactive()
    {
        playAgain.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }

    public void PlayerFinish()
    {
        hasPlayed = true;
        finishEvent.Invoke();
    }

    public void ResetGame()
    {
        hasPlayed = false;
        resetEvent.Invoke();
    }
    
    public void ResetGameClient()
    {
        hasPlayed = false;
        resetEventClient.Invoke();
    }

    public void HostGame()
    {
        _networkManager.StartHost();
        
        host.SetActive(false);
        client.SetActive(false);
    }
    
    public void ClientGame()
    {
        _networkManager.StartClient();
        
        host.SetActive(false);
        client.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
    

}
