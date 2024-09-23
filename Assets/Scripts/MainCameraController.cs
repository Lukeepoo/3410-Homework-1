//Lucas Lovellette
//09/21/2024
// MainCameraController.cs
// Controls the camera to follow the player's movement with a fixed offset.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; //offset vector from initial config  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
