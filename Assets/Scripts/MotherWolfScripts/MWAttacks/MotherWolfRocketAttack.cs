using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherWolfRocketAttack : MotherWolfAttack {

    [SerializeField]
    int m_numRocket2Fire;
    int m_numRocketLaunched;
    bool m_startLaunchRockets;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (m_players == null)
            m_players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

        if (m_startLaunchRockets)
            selectTarget();
	}

    public override void launchAttackSequence(MotherWolfMovement movement)
    {
        m_hasEnded = false;
        m_startLaunchRockets = true;
    }

    protected override void selectTarget()
    {
        m_target = m_players[Random.Range(0, m_players.Count)];
        aim();
    }

    protected override void aim()
    {
        //instantiate rocket
        //rotate it

        m_numRocketLaunched++;

        attack();
    }

    protected override void attack()
    {
        if (m_numRocketLaunched >= m_numRocket2Fire)
        {
            m_startLaunchRockets = false;
            m_hasEnded = true;
        }

        Debug.Log("Pew Pew Pew");
    }
}
