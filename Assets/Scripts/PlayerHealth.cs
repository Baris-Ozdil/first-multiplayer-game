using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class PlayerHealth : Photon.Bolt.EntityBehaviour<IRoboPlayerState>
{
    public int LocalHealth = 100;

    public override void Attached()
    {
        state.Health = LocalHealth;
    }

    public void Update()
    {
        if(state.Health <= 0)
        {
            
            BoltNetwork.Destroy(gameObject);
        }
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag!= "wall")
        {
            state.Health -= 25;
            if (other.tag != "player")
            {
                BoltNetwork.Destroy(other.gameObject);
            }
        }
    }

}
