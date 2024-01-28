using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyInertiaTensorFix : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            ResetInertiaTensor();
        }
    }

    void ResetInertiaTensor()
    {
        // Reset the inertia tensor rotation
        rb.inertiaTensorRotation = Quaternion.identity;

        // Optionally, set the inertia tensor to a specific value if needed
        rb.inertiaTensor = new Vector3(1, 1, 0); // Example value
    }

    private void LateUpdate()
    {
        ResetInertiaTensor();
    }
}
