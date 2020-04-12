using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform Hips;
    [SerializeField]
    private Vector3 offset;

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Hips.position + offset;
    }
}
