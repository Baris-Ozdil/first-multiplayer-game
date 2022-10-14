using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class Shooting : Photon.Bolt.EntityBehaviour<IRoboPlayerState>
{

    public Rigidbody Bullet;
    public GameObject muzzel;
    public float bulletSpeed = 100;

    public override void Attached()
    {
        state.Onshooting = Shoot;
    }

    private void Shoot()
    {
        Rigidbody Bulletclone = Instantiate(Bullet, muzzel.transform.position, this.transform.rotation);
        Bulletclone.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && entity.IsOwner)
            state.shooting();
    }
}
