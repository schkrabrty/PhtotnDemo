using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CanvasController : MonoBehaviourPun
{
    public GameObject Camera;

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(Camera.transform); // Turn the canvas to face the camera
        this.transform.Rotate(0, 180, 0); // Rotate the canvas by 180 degree on Y-axis to read the words properly
    }
}
