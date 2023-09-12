using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayManager : MonoBehaviour
{
    private Director _director;
    private Level _level;
    private Timer _timer;
    private ObjectPlacement _objectPlacement;
    public Camera _camera;
    
    private void Start()
    {
        if (GetComponent<Controller>().IsLocalPlayer)
        {
            _director = GameObject.FindObjectOfType<Director>();
            _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            _camera.GetComponent<CameraFollow>().target = this.transform;
            _level = GameObject.FindObjectOfType<Level>();
            _timer = FindObjectOfType<Timer>();
            _objectPlacement = FindObjectOfType<ObjectPlacement>();
        
            _objectPlacement.StartPlacement();
            _timer.StartCount();
            _level.StartLevel();
            _director.StartDirector();
        }
    }
    
    public float minX = -15f;
    public float maxX = 15f;
    public float minY = -15f;
    public float maxY = 15f;

    void Update()
    {
        float x = Mathf.Clamp(transform.position.x, minX, maxX);
        float y = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
