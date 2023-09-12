using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    public void StartPlacement()
    {
        float randomY = 0;
        float randomX = 0;
        
        if (Random.Range(1, 10)/2 == 0)
        {
            randomY = Random.Range(7, 14);
        }
        else
        {
            randomY = Random.Range(-14, -7);
        }
        
        randomX = Random.Range(-7, 7);


        transform.position = new Vector3(randomX, randomY);
    }
}
