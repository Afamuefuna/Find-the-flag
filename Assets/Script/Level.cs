using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class Level : NetworkBehaviour
{
    public int level = 1;
    public TMP_Text currentLevel_txt;
    public Play play;
    
    public void StartLevel()
    {
        currentLevel_txt.text = "Level: " + level.ToString();
    }
    
    public void UpdateLevel()
    {
        if (IsHost)
        {
            level = level + 1;
            ReceiveLevelClientRpc(level);
            
            currentLevel_txt.text = "Level: " + level.ToString();
        }
    }
    
    [ClientRpc]
    void ReceiveLevelClientRpc(int level)
    {
        Debug.Log("Received");
        currentLevel_txt.text = "Level: " + level.ToString();
        if (IsClient)
        {
            play.ResetGameClient();
        }
    }
    
    public void Win()
    {
        if (IsLocalPlayer)
        {
            win_txt.text = "Winner";
            Invoke(nameof(ClearWin), 2f);
        }
    }

    public void ClearWin()
    {
        win_txt.text = " ";
    }
    
    public TMP_Text win_txt;
}
