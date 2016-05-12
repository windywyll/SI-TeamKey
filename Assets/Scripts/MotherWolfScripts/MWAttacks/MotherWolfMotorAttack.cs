using UnityEngine;
using System.Collections;
using System;

public class MotherWolfMotorAttack : MotherWolfAttack {
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void launchAttackSequence(MotherWolfMovement movement, Animator anim)
    {
        m_animator = anim;
        m_hasEnded = false;
        attack();
    }

    protected override void selectTarget()
    {
    }

    protected override void aim()
    {
    }

    protected override void attack()
    {
        m_hasEnded = true;
        Debug.Log("Moot Moot");
    }
    
}
