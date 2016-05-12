using UnityEngine;
using System.Collections;
using System;

public class MotherWolfMotorAttack : MotherWolfAttack {

    [SerializeField]
    GameObject m_motor;
    bool m_launchMotor;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (m_launchMotor)
            attack();
	}

    public override void launchAttackSequence(MotherWolfMovement movement, Animator anim)
    {
        m_animator = anim;
        m_hasEnded = false;
        m_animator.SetTrigger("objectRain");
    }

    protected override void selectTarget()
    {
    }

    protected override void aim()
    {
    }

    protected override void attack()
    {
        GameObject motorhead = Instantiate(m_motor);
        motorhead.GetComponent<Motor>().setDamage(m_damage);
        m_launchMotor = false;
        m_hasEnded = true;
    }

    public void launchMotor()
    {
        m_launchMotor = true;
    }
    
}
