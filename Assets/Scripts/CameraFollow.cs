using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target; // target della telecamera (taxi)
    public Vector3 offset = new Vector3(0, 2, -5);
    public float damper = 0.1f;


    void LateUpdate()
    {
        if (Target == null)
        {
            return;
        }

        // posizione dietro il target usando offset e rotazione
        Vector3 desiredPosition = Target.position + Target.rotation * offset;

        // Applica Lerp
        transform.position = Vector3.Lerp(transform.position, desiredPosition, damper);

        // telecamera guarda sempre nella stessa direzione del target
        transform.rotation = Quaternion.Lerp(transform.rotation, Target.rotation, damper);
    }
}
