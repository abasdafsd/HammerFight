using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using System.Collections.Generic;

public class Launcher : MonoBehaviourPunCallbacks
{
    public GameManager1 gameManager1;
    [SerializeField]
    private byte maxPlayersPerRoom = 4;
    bool isConnecting;
    string gameVersion = "1";
    [SerializeField]
    GameObject gameOverObject;
    bool isGameOverObjectSet = false;

    [SerializeField]
    private List<GameObject> enableOnJoinRoom;
    [SerializeField]
    private List<GameObject> disableOnJoinRoom;

    private bool isSinglePlyer = false;


    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Connect();
    }

    public void Connect()
    {
        isConnecting = true;
        PhotonNetwork.GameVersion = this.gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        JoinRandomRoom();
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void JoinRoom(string name)
    {
        PhotonNetwork.JoinRoom(name);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom(true);
    }

    public void CreateRoom(bool visible)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayersPerRoom, IsVisible = visible});
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        isConnecting = false;
        if (isSinglePlyer) SinglePlayer();
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate(gameManager1.name, gameManager1.transform.position, gameManager1.transform.rotation, 0);
        }
        foreach (GameObject go in enableOnJoinRoom)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in disableOnJoinRoom)
        {
            go.SetActive(false);
        }
    }

    public void SinglePlayer()
    {
        if (PhotonNetwork.IsConnected)
        {
            isSinglePlyer = true;
            PhotonNetwork.Disconnect();
        }
        else
        {
            PhotonNetwork.OfflineMode = true;
            CreateRoom(false);
        }
    }
}