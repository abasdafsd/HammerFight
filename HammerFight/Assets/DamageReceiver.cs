using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField]
    private ReferenceContainer playerInstance;
    [SerializeField]
    private float oneHitDamage;
    [SerializeField]
    private float minDamageSpeed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Damager>())
        {
            Damager dam = collision.gameObject.GetComponent<Damager>();
            float velocity = dam.GetComponent<Rigidbody>().velocity.magnitude;
            if (velocity > minDamageSpeed)
            {
                Damage(velocity);
            }
        }
    }

    private void Damage(float velocity)
    {
        float damage = oneHitDamage * (velocity / minDamageSpeed);
        playerInstance.ChangeHealth(-damage);

        if (playerInstance.GetHealth() < 0f)
        {
            PhotonNetwork.Destroy(playerInstance.gameObject);
        }
    }
}