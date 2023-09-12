using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Director : MonoBehaviour
{ // You can adjust this padding as needed.

    private Camera mainCamera;
    public Transform flag, player;
    private float objectWidth;
    private float objectHeight;
    private SpriteRenderer spriteRenderer;

    [SerializeField]private bool placeRight;
    [SerializeField] bool placeLeft;
    [SerializeField]private bool placeUp;
    [SerializeField]private bool placeDown;

    [SerializeField] private Transform arrowDirection;
    
    public bool startDirector;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        arrowDirection.gameObject.SetActive(false);
    }

    public void StartDirector()
    {
        startDirector = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        arrowDirection.gameObject.SetActive(true);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        mainCamera = Camera.main;
        flag = GameObject.FindWithTag("Finish").GetComponent<Transform>();
        
        objectWidth = GetComponent<Renderer>().bounds.size.x;
        objectHeight = GetComponent<Renderer>().bounds.size.y;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!startDirector)
        {
            return;
        }
        CheckFlagVisibility();
        // Get the camera's position in world space
        Vector3 cameraPosition = mainCamera.transform.position;

        // Calculate the camera's boundaries in world space
        float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float cameraHalfHeight = mainCamera.orthographicSize;

        arrowDirection.position = player.position;

        float targetY = flag.transform.position.y;
        float referenceY = arrowDirection.position.y;

        if (targetY > referenceY)
        {
            // The target GameObject is above the reference GameObject
            placeUp = true;
            placeDown = false;
        }
        else if (targetY < referenceY)
        {
            // The target GameObject is below the reference GameObject
            placeUp = false;
            placeDown = true;
        }
        
        float targetX = flag.transform.position.x;
        float referenceX = arrowDirection.position.x;

        if (targetX > referenceX)
        {
            placeLeft = false;
            placeRight = true;
        }
        else if (targetX < referenceX)
        {
            placeLeft = true;
            placeRight = false;
        }

        // Calculate the edge position for the object based on the closest edge
        float edgeX = 0f;
        float edgeY = 0f;

        if (placeRight)
        {
            edgeX = cameraPosition.x + cameraHalfWidth - objectWidth / 2;
        }else
        if (placeLeft)
        {
            edgeX = cameraPosition.x - cameraHalfWidth + objectWidth / 2;
        }
        if (placeUp)
        {
            edgeY = cameraPosition.y + cameraHalfHeight - objectHeight / 2;
        }else
        if (placeDown)
        {
            edgeY = cameraPosition.y - cameraHalfHeight + objectHeight / 2;
        }
        
        transform.position = new Vector3(edgeX, edgeY, transform.position.z);


        // Set the object's position to the chosen edge
        
        Vector3 targ = flag.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void CheckFlagVisibility()
    {
        // Check if the flag is visible within the camera's view
        Vector3 flagViewportPosition = mainCamera.WorldToViewportPoint(flag.position);

        if (flagViewportPosition.x >= 0f && flagViewportPosition.x <= 1f &&
            flagViewportPosition.y >= 0f && flagViewportPosition.y <= 1f)
        {
            // Flag is within the camera's view, disable the sprite
            spriteRenderer.enabled = false;
        }
        else
        {
            // Flag is not within the camera's view, enable the sprite
            spriteRenderer.enabled = true;
        }
    }
}
