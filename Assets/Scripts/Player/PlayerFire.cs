using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : TankShoot
{
    public int CurrentCount=0;
    public override void Fire(){
        base.Fire();
        CurrentCount++;
        m_Fired = true;                                                                                     // Set the fired flag so Fire is only called once.
        Rigidbody shellInstance = (objectPool.spawner("Shell",m_FireTransform)).GetComponent<Rigidbody>();  //get Rigidbody Component from Object Instance
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;                            // Set the shell's velocity 
    }
}
