using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UprightForce : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float uprightForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        /*if (Input.GetKeyDown(KeyCode.Y))
        {
            rb.AddForce(transform.up * uprightForce);
        }*/
    }
}
