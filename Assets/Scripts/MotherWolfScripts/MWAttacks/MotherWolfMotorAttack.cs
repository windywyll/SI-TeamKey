using UnityEngine;
using System.Collections;
using System;

public class MotherWolfMotorAttack : MotherWolfAttack {

    [SerializeField]
    GameObject m_motor;
    bool m_launchMotor, m_motorInZone;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public bool isMotorInZone()
    {
        return m_motorInZone;
    }

    public override void launchAttackSequence(MotherWolfMovement movement, Animator anim, MotherWolf mom)
    {
        m_mom = mom;
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
        m_motorInZone = true;
        m_mom.setMotorInZone(true);
        GameObject motorhead = Instantiate(m_motor);
        motorhead.transform.position = new Vector3(0.0f, 12.0f, 12.0f);
        Motor motor = motorhead.GetComponent<Motor>();
        motor.setDamage(m_damage);
        motor.setCreator(this);
        motor.selectLandingPoint();

        m_hasEnded = true;
    }

    public void launchMotor()
    {
        attack();
    }

    public void motorExplode()
    {
        m_mom.setMotorInZone(false);
    }

    public override void stopAttack()
    {
        m_hasEnded = true;
    }

}
