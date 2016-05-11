using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherWolfMeleeAttack : MotherWolfAttack {

    [SerializeField]
    private float m_delayAim;
    private float m_startDelayAim;
    private bool aiming;

	// Use this for initialization
	void Start () {
        aiming = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_players == null)
            m_players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

        if (aiming)
            aim();
	}

    public override void launchAttackSequence(MotherWolfMovement movement)
    {
        m_movement = movement;
        selectTarget();
        m_startDelayAim = Time.time;
        aiming = true;
    }

    protected override void selectTarget()
    {
        bool noWeakest = true;

        m_target = null;

        for(int i = 0; i < m_players.Count; i++)
        {
            if (m_target == null)
                m_target = m_players[i];
            else
            {
                if ((m_players[i].GetComponent<Player>().getCurrentLife() < m_target.GetComponent<Player>().getCurrentLife()) && !m_players[i].GetComponent<Player>().isDead())
                {
                    noWeakest = false;
                    m_target = m_players[i];
                }
            }
        }

        if(noWeakest)
        {
            m_target = m_players[Random.Range(0, m_players.Count)];
        }
    }

    protected override void aim()
    {
        m_movement.setTarget(m_target);

        if (m_startDelayAim + m_delayAim < Time.time)
        {
            m_movement.setTarget(null);
            m_target = null;
            aiming = false;
            attack();
        }
    }

    protected override void attack()
    {
        Debug.Log("Spluuuush");
    }
}
