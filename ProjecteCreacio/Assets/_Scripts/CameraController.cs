using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offSet = 10.0f;
    private Transform player;
    private Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        camera = GetComponent<Transform>();
        camera.position = player.position - new Vector3 (0,0,offSet);
    }

    // Update is called once per frame
    void Update()
    {
        camera.position = player.position - new Vector3(0, 0, offSet);
    }
}
