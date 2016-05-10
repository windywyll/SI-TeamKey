using UnityEngine;
using System.Collections;

public class MotherWolfMeleeAttack : MotherWolfAttack {

	// Use this for initialization
	void Start () {
        m_damage = 10.0f;
        m_percentageAttack = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setTarget(GameObject target)
    {
        m_target = target;
    }

    public override void launchAttack()
    {
        Debug.Log("Attack!");
    }
}
