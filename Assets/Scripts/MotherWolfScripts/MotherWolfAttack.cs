using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class MotherWolfAttack : MonoBehaviour {

    protected List<GameObject> m_players;
    protected GameObject m_target;
    [SerializeField]
    protected int m_damage;
    [SerializeField]
    protected int m_percentageAttack;
    protected MotherWolfMovement m_movement;
    [SerializeField]
    protected bool m_isRepeatable;
    [SerializeField]
    protected int m_minRepeat, m_maxRepeat, m_percentRepeat;

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

    public abstract void launchAttackSequence(MotherWolfMovement movement);
    protected abstract void selectTarget();
    protected abstract void aim();
    protected abstract void attack();
}
