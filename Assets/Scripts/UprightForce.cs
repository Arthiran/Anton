using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UprightForce : MonoBehaviour
{
    [SerializeField]
    private Rigidbody[] rb;
    [SerializeField]
    private float uprightForce;

    // Update is called once per frame
    private void LateUpdate()
    {
        for (int i = 0; i < rb.Length; i++)
        {
            rb[i].AddForce(transform.up * uprightForce * Time.fixedDeltaTime);
        }
    }
}
