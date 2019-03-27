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
    string gameVersion = "1";
    public static Launcher instance;
    public GameParameters gameParameters;


    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Connect();
        instance = this;
    }

    public void Connect()
    {
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

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom(true);
    }

    public void CreateRoom(bool visible)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayersPerRoom, IsVisible = visible});
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate(gameManager1.name, gameManager1.transform.position, gameManager1.transform.rotation, 0);
        }
    }
}