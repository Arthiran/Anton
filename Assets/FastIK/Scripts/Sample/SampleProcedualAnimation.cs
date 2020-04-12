using UnityEngine;

namespace DitzelGames.FastIK
{
    class SampleProcedualAnimation :  MonoBehaviour
    {
        public Transform[] FootTarget;

        public LayerMask myLayerMask;

        private bool Foot1Grounded = false;
        private bool Foot2Grounded = false;
        public void LateUpdate()
        {
            //footsteps
            for(int i = 0; i < FootTarget.Length; i++)
            {
                var foot = FootTarget[i];
                var ray = new Ray(foot.transform.position + Vector3.up * 0.5f, Vector3.down);
                var hitInfo = new RaycastHit();
                if (Physics.SphereCast(ray, 0.05f, out hitInfo, 0.5f, myLayerMask))
                {
                    if (i == 0)
                    {
                        Foot1Grounded = true;
                    }
                    else
                    {
                        Foot2Grounded = true;
                    }
                }
                else
                {
                    Foot1Grounded = false;
                    Foot2Grounded = false;
                }
                Debug.DrawRay(transform.position, -transform.up);
                if (Physics.Raycast(foot.position, -transform.up, out hitInfo, 0.05f, myLayerMask))
                {
                    foot.position = hitInfo.point + Vector3.up * 0.05f;
                    //foot.localRotation = Quaternion.FromToRotation(transform.up, hitInfo.normal);
                }
            }
            if (!Foot1Grounded && !Foot2Grounded)
            {
                Debug.Log("Fall mofo");
            }
        }

    }
}
