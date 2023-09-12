using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

public class Found : MonoBehaviour
{
    [FormerlySerializedAs("_Win")] public Play play;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            play.PlayerFinish();
        }
    }
}
