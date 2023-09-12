using System;
using Unity.Mathematics;
using UnityEngine;

public class EndlessBackground : MonoBehaviour
{
    public GameObject backgroundPrefab;
    public bool hasCreated;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (hasCreated == false)
            {
                Debug.Log("here");
                FillNeighbour();
                hasCreated = true;
            }
        }
    }

    public void FillNeighbour()
    {
        Instantiate(backgroundPrefab, new Vector3(0, 17, 0) + transform.position, quaternion.identity);
        Instantiate(backgroundPrefab, new Vector3(0, -17, 0) + transform.position, quaternion.identity);
        Instantiate(backgroundPrefab, new Vector3(17, 0, 0) + transform.position, quaternion.identity);
        Instantiate(backgroundPrefab, new Vector3(-17, 0, 0) + transform.position, quaternion.identity);
        Instantiate(backgroundPrefab, new Vector3(-17, 17, 0) + transform.position, quaternion.identity);
        Instantiate(backgroundPrefab, new Vector3(17, -17, 0) + transform.position, quaternion.identity);
        Instantiate(backgroundPrefab, new Vector3(-17, -17, 0) + transform.position, quaternion.identity);
        Instantiate(backgroundPrefab, new Vector3(17, 17, 0) + transform.position, quaternion.identity);
    }
}