using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ReferenceContainer : MonoBehaviour
{
    public static ReferenceContainer instance;
    public PhotonView photonView;
    [SerializeField]
    private FlightController flight;
    [SerializeField]
    private DamageReceiver damageReceiver;
    [SerializeField]
    private Damager damager;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private UIController ui;

    [SerializeField]
    private float healthMax = 100f;
    private float health;
    public void ChangeHealth(float value)
    {
        ChangeHealthRPC(value);
        photonView.RPC("ChangeHealthRPC", RpcTarget.Others, value);
    }
    public float GetHealth()
    {
        return health;
    }

    [PunRPC]
    private void ChangeHealthRPC(float value)
    {
        health += value;
        ui.SetHealth(health/healthMax);
    }

    // Use this for initialization
    void Awake()
    {
        if (photonView.IsMine)
        {
            instance = this;
            damager.enabled = false;
        }
        else DisableLogic();

        health = healthMax;
    }

    // Update is called once per frame
    void DisableLogic()
    {
        flight.enabled = false;
        damageReceiver.enabled = false;
        damager.enabled = true;
        canvas.SetActive(false);
    }
}
