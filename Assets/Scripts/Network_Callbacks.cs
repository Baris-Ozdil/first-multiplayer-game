using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;
using UnityEngine.SceneManagement;

public class Network_Callbacks : GlobalEventListener
{
    public GameObject player;



    public override void SceneLoadLocalDone(string scene, IProtocolToken token)
    {

        var spawnPos = new Vector3(Random.Range(-7, 7), 1, Random.Range(-10, 10));
        BoltNetwork.Instantiate(player, spawnPos, Quaternion.identity);
    }

}
