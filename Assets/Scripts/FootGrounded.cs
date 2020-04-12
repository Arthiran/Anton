using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootGrounded : MonoBehaviour
{
    public GameObject[] Feet;
    public Transform[] FootTarget;

    public LayerMask myLayerMask;

    private bool Foot1Grounded = true;
    private bool Foot2Grounded = true;
    private int groundedCounter = 0;

    [SerializeField]
    private Rigidbody[] rb;
    [SerializeField]
    private float uprightForce;

    public void LateUpdate()
    {
        //footsteps
        for (int i = 0; i < FootTarget.Length; i++)
        {
            var foot = FootTarget[i];
            var ray = new Ray(foot.transform.position + Vector3.up * 0.5f, Vector3.down);
            var hitInfo = new RaycastHit();
            if (Physics.Raycast(foot.position, -transform.up, out hitInfo, 0.05f, myLayerMask))
            {
                foot.position = hitInfo.point + Vector3.up * 0.05f;
                //foot.localRotation = Quaternion.FromToRotation(transform.up, hitInfo.normal);
            }
            if (Physics.SphereCast(ray, 0.05f, out hitInfo, 0.5f, myLayerMask))
            {
                if (i == 0)
                {
                    Foot1Grounded = true;
                }
                else if (i == 1)
                {
                    Foot2Grounded = true;
                }
            }
            else
            {
                if (i == 0)
                {
                    Foot1Grounded = false;
                }
                else if (i == 1)
                {
                    Foot2Grounded = false;
                }
            }
        }
        if (!Foot1Grounded || !Foot2Grounded)
        {
            for (int i = 0; i < rb.Length; i++)
            {
                rb[i].AddForce(transform.up * uprightForce / 1.1f * Time.deltaTime);
            }
        }
        else
        {
            for (int i = 0; i < rb.Length; i++)
            {
                rb[i].AddForce(transform.up * uprightForce * Time.deltaTime);
            }
        }


        if (!Foot1Grounded && !Foot2Grounded)
        {
            for (int i = 0; i < FootTarget.Length; i++)
            {
                FootTarget[i].GetComponent<Rigidbody>().isKinematic = false;
            }

        }
        else
        {
            for (int i = 0; i < FootTarget.Length; i++)
            {
                FootTarget[i].GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
