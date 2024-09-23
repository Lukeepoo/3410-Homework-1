//Lucas Lovellette
//09/21/2024
// Rotator.cs
// Rotates objects (e.g., pickups) continuously on the Z-axis to create a rotating effect.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
}
