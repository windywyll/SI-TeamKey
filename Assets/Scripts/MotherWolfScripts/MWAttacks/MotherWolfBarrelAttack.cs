using UnityEngine;
using System.Collections;

public class MotherWolfBarrelAttack : MotherWolfAttack {

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
        Debug.Log("KA-BOOM");
    }

    protected override void selectTarget()
    {
        
    }
}
