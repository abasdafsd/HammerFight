using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    public enum ControlType
    {
        TypeA,
        TypeB,
    }
    [SerializeField]
    private ControlType controlType;
    [SerializeField]
    private Rigidbody rb;
    private Vector3 leftForce;
    private Vector3 rightForce;
    // Use this for initialization
    void Awake()
    {
        leftForce = Launcher.instance.gameParameters.leftForce;
        rightForce = Launcher.instance.gameParameters.rightForce;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput(controlType);
    }

    private void CheckForInput(ControlType ct)
    {
        if (ct == ControlType.TypeA)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) Swing(leftForce);
            if (Input.GetKeyDown(KeyCode.RightArrow)) Swing(rightForce);
        }
        if (ct == ControlType.TypeB)
        {
            if (Input.GetKeyDown(KeyCode.A)) Swing(leftForce);
            if (Input.GetKeyDown(KeyCode.D)) Swing(rightForce);
        }
    }

    private void Swing(Vector3 force)
    {
        rb.AddForce(force);
    }

    public void SwingLeft()
    {
        rb.AddForce(leftForce);
    }

    public void SwingRight()
    {
        rb.AddForce(rightForce);
    }
}
