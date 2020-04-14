using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform Hips;
    [SerializeField]
    private Vector3 offset;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            offset = new Vector3(3, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.rotation = Quaternion.Euler(90, 0, 0);
            offset = new Vector3(0, 3, 0);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            offset = new Vector3(0, 0, 3);
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Hips.position + offset;
    }
}
