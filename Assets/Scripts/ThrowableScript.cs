using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableScript : MonoBehaviour
{
    [SerializeField]
    private GameObject throwable;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject throwableTemp;
            throwableTemp = Instantiate(throwable, transform.position, Quaternion.Euler(0, 0, 0));
            throwableTemp.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
        }
    }
}
