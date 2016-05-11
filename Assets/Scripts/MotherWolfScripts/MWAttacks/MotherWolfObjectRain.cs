using UnityEngine;
using System.Collections;
using System;

public class MotherWolfObjectRain : MotherWolfAttack {
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void launchAttackSequence(MotherWolfMovement movement)
    {
        attack();
    }

    protected override void aim()
    {
    }

    protected override void attack()
    {
        Debug.Log("Huhuhu");
    }

    protected override void selectTarget()
    {
        
    }
}
