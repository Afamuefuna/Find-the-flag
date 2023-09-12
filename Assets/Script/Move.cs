using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Move the object forward based on its current rotation
        transform.Translate(Vector3.up * 5.0f * Time.deltaTime); 
    }
}
