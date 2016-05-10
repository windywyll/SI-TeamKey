using UnityEngine;
using System.Collections;

public abstract class MotherWolfAttack : MonoBehaviour {

    protected GameObject m_target;
    protected float m_damage;
    protected float m_percentageAttack;

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

    public float getDamage()
    {
        return m_damage;
    }

    public abstract void launchAttack();
}
