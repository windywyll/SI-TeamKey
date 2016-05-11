using UnityEngine;
using System.Collections;

public class MotherWolfRocketAttack : MotherWolfAttack {

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

    protected override void selectTarget()
    {
    }

    protected override void aim()
    {
    }

    protected override void attack()
    {
        Debug.Log("Pew Pew Pew");
    }
}
