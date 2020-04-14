using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipsScript : MonoBehaviour
{
    [SerializeField]
    private Transform[] FootTargets;
    private Vector3 furthestDist = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float hipsY;
        if (FootTargets[0].position.y < FootTargets[1].position.y)
        {
            hipsY = FootTargets[0].position.y + 0.85f;
        }
        else
        {
            hipsY = FootTargets[1].position.y + 0.85f;
        }
        Vector3 newPosition;
        newPosition = new Vector3(((FootTargets[0].position + FootTargets[1].position) / 2).x, hipsY, ((FootTargets[0].position + FootTargets[1].position) / 2).z);
        transform.position = newPosition;

        //Debug.Log(transform.position.y - FootTargets[0].position.y);
    }
}
