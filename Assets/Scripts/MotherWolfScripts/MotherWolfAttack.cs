﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class MotherWolfAttack : MonoBehaviour {

    protected MotherWolf m_mom;
    protected List<GameObject> m_players;
    protected GameObject m_target;
    protected Animator m_animator;
    [SerializeField]
    protected int m_damage;
    [SerializeField]
    protected int m_percentageAttack, m_percentageAttackMotorInZone;
    protected MotherWolfMovement m_movement;
    [SerializeField]
    protected bool m_isRepeatable;
    [SerializeField]
    protected int m_minRepeat, m_maxRepeat, m_percentRepeat;
    protected bool m_hasEnded;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    public float getPercentageAttack()
    {
        return m_percentageAttack;
    }

    public float getPercentageAttackWithMotorInZone()
    {
        return m_percentageAttackMotorInZone;
    }

    public float getDamage()
    {
        return m_damage;
    }

    public int getMinRepeat()
    {
        return m_minRepeat;
    }

    public int getMaxRepeat()
    {
        return m_maxRepeat;
    }

    public int getPercentRepeat()
    {
        return m_percentRepeat;
    }

    public bool isRepeatable()
    {
        return m_isRepeatable;
    }

    public bool attackEnded()
    {
        return m_hasEnded;
    }

    public abstract void launchAttackSequence(MotherWolfMovement movement, Animator anim, MotherWolf mom);
    protected abstract void selectTarget();
    protected abstract void aim();
    protected abstract void attack();
    public abstract void stopAttack();
}
