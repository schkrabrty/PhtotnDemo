using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class networkPlayerSpawner : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private GameObject spawnedPlayerPrefab;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player3", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
