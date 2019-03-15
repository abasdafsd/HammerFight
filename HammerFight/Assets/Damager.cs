using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField]
    private HingeJoint hinge;

    void OnCollisionEnter(Collision collision)
    {
        var motor = hinge.motor;
        motor.targetVelocity *= (-1f);
        hinge.motor = motor;
    }
}