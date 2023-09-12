using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

public class Timer : NetworkBehaviour
{
    [FormerlySerializedAs("_Win")] public Play play;
    public TMP_Text countdownText;

    private float timer = 20;

    public void StartCount()
    {
        InvokeRepeating(nameof(StartCountdown), 1, 1);
    }

    public void ResetTimer()
    {
        CancelInvoke();
        timer = 20;
        InvokeRepeating(nameof(StartCountdown), 1, 1);
    }
    
    public void StartCountdown()
    {
        if (Play.hasPlayed)
        {
            return;
        }
        
        if (IsHost)
        {
            Debug.Log(timer);
            
            timer--;
            //SendTimerToServerRpc(timer);
            ReceiveTimerClientRpc(timer);
            
            if (timer > 0)
            {
                countdownText.text = "Time: " + timer.ToString();
            }
            else
            {
                // Countdown has finished, you can add any additional logic here.
                countdownText.text = "Countdown Complete!";
                CancelInvoke(nameof(StartCountdown));
                play.PlayerFinish();
            }
        }
        else
        {
            Debug.Log("not host");
        }
    }
    
    [ClientRpc]
    void ReceiveTimerClientRpc(float timer)
    {
        
        if (timer > 0)
        {
            countdownText.text = "Time: " + timer.ToString();
        }
        else
        {
            // Countdown has finished, you can add any additional logic here.
            countdownText.text = "Countdown Complete!";
            CancelInvoke(nameof(StartCountdown));
            play.PlayerFinish();
        }
    }

    [ServerRpc]
    public void SendTimerToServerRpc(float timer)
    {
        Debug.Log("Received");
    }
}
