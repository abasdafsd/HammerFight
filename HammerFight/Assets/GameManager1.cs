using UnityEngine;
using Photon.Pun;

public class GameManager1 : MonoBehaviourPunCallbacks
{
    [Tooltip("The prefab to use for representing the player")]
    [SerializeField]
    private GameObject playerPrefab;
    public Transform spawnPoint;

    public void Awake()
    {
        if (ReferenceContainer.instance == null)
        {
            PhotonNetwork.Instantiate(this.playerPrefab.name, spawnPoint.position, spawnPoint.rotation, 0);
        }
    }
}