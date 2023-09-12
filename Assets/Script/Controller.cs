using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Controller : NetworkBehaviour
{
    private void Start()
    {
        if (IsLocalPlayer)
        {
            Debug.Log("Local");
        }
    }
}
