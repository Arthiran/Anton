using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootGrounded : MonoBehaviour
{
    public Rigidbody[] FeetRB;

    public LayerMask myLayerMask;

    private bool Foot1Grounded = false;
    private bool Foot2Grounded = false;

    private bool Foot1Moving = false;
    private bool Foot2Moving = false;

    private bool Foot1CanMove = true;
    private bool Foot2CanMove = true;

    public float speed;
    private float distance = 0f;
    [SerializeField]
    private Rigidbody[] rb;
    [SerializeField]
    private Rigidbody HipRB;
    [SerializeField]
    private float uprightForce;
    private Vector3 forwardForce = Vector3.forward * 100f;
    private Vector3 backwardForce = -Vector3.forward * 100f;

    private Vector3 moveVector = (Vector3.up * 30f) + (Vector3.forward * 12.5f);
    private Vector3 moveVectorDoubled = (Vector3.up * 35f) + (Vector3.forward * 25f);

    private Vector3 moveBackVector = (Vector3.up * 30f) + (-Vector3.forward * 12.5f);
    private Vector3 moveBackVectorDoubled = (Vector3.up * 35f) + (-Vector3.forward * 25f);

    private void Start()
    {
        distance = Vector3.Distance(FeetRB[0].position, FeetRB[1].position);
    }
    private void Update()
    {
        //footsteps
        for (int i = 0; i < FeetRB.Length; i++)
        {
            Transform foot = FeetRB[i].transform;
            Ray ray = new Ray(foot.transform.position + Vector3.up * 1f, Vector3.down);
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(foot.position, -transform.up, out hitInfo, 0.1f, myLayerMask))
            {
                foot.position = hitInfo.point + Vector3.up * 0.1f;
                foot.localRotation = Quaternion.FromToRotation(transform.up, hitInfo.normal);
            }
            if (Physics.SphereCast(ray, 0.1f, out hitInfo, 1f, myLayerMask))
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

        for (int i = 0; i < rb.Length; i++)
        {
            rb[i].AddForce(transform.up * uprightForce * Time.deltaTime);
        }

        if (Foot1Grounded && !Foot1Moving)
        {
            FeetRB[0].isKinematic = true;
        }

        if (Foot2Grounded && !Foot2Moving)
        {
            FeetRB[1].isKinematic = true;
        }

        if (Input.GetKeyDown(KeyCode.Q) && Foot1Grounded && Foot2Grounded && Foot1CanMove)
        {
            Foot1Moving = true;
            FeetRB[0].isKinematic = false;
            if (Vector3.Distance(FeetRB[0].position, FeetRB[1].position) > distance)
            {
                FeetRB[0].AddRelativeForce(moveVectorDoubled);
            }
            else
            {
                FeetRB[0].AddRelativeForce(moveVector);
            }
            Foot1CanMove = false;
            Foot2CanMove = true;
        }
        else if (Input.GetKeyDown(KeyCode.W) && Foot2Grounded && Foot1Grounded && Foot2CanMove)
        {
            Foot2Moving = true;
            FeetRB[1].isKinematic = false;
            if (Vector3.Distance(FeetRB[0].position, FeetRB[1].position) > distance)
            {
                FeetRB[1].AddRelativeForce(moveVectorDoubled);
            }
            else
            {
                FeetRB[1].AddRelativeForce(moveVector);
            }
            Foot2CanMove = false;
            Foot1CanMove = true;
        }
        else if (Input.GetKeyDown(KeyCode.O) && Foot1Grounded && Foot2Grounded && Foot2CanMove)
        {
            Foot1Moving = true;
            FeetRB[0].isKinematic = false;
            if (Vector3.Distance(FeetRB[0].position, FeetRB[1].position) > distance)
            {
                FeetRB[0].AddRelativeForce(moveBackVectorDoubled);
            }
            else
            {
                FeetRB[0].AddRelativeForce(moveBackVector);
            }
            Foot2CanMove = false;
            Foot1CanMove = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && Foot2Grounded && Foot1Grounded && Foot1CanMove)
        {
            Foot2Moving = true;
            FeetRB[1].isKinematic = false;
            if (Vector3.Distance(FeetRB[0].position, FeetRB[1].position) > distance)
            {
                FeetRB[1].AddRelativeForce(moveBackVectorDoubled);
            }
            else
            {
                FeetRB[1].AddRelativeForce(moveBackVector);
            }
            Foot1CanMove = false;
            Foot2CanMove = true;
        }

        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.O))
        {
            Foot1Moving = false;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.P))
        {
            Foot2Moving = false;
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < FeetRB.Length; i++)
        {
            FeetRB[i].AddForce(-Vector3.up * 2);
        }
    }
    private void LateUpdate()
    {
        
    }
}
