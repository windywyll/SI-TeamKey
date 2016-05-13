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
	}

    public override void launchAttackSequence(MotherWolfMovement movement, Animator anim)
    {
        m_animator = anim;
        m_hasEnded = false;
        m_animator.SetTrigger("motor");
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
        motorhead.transform.position = new Vector3(0.0f, 12.0f, 12.0f);
        motorhead.GetComponent<Motor>().setDamage(m_damage);
        motorhead.GetComponent<Motor>().selectLandingPoint();
        m_hasEnded = true;
    }

    public void launchMotor()
    {
        attack();
    }

    public override void stopAttack()
    {
        m_hasEnded = true;
    }

}
