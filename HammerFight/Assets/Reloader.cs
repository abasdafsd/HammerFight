using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class Reloader : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject reloadButton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        reloadButton.SetActive(true);
    }

    public void Reload()
    {
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().name);
    }
}
