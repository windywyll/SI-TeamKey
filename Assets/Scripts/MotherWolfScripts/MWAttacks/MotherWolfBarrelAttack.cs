using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherWolfBarrelAttack : MotherWolfAttack {

    List<GameObject> m_aimedPlayers;

	// Use this for initialization
	void Start () {
        m_aimedPlayers = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_players == null)
            m_players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
    }

    public override void launchAttackSequence(MotherWolfMovement movement)
    {
        m_hasEnded = false;
        m_movement = movement;

        if (m_aimedPlayers.Count != m_players.Count - 1)
            selectTarget();
        else
            lastTarget();

        aim();
    }

    protected override void selectTarget()
    {
        bool selected = false;

        while(!selected)
        {
            int playerToShoot = Random.Range(0, m_players.Count);

            if(!m_aimedPlayers.Contains(m_players[playerToShoot]))
            {
                m_target = m_players[playerToShoot];
                m_aimedPlayers.Add(m_players[playerToShoot]);
                selected = true;
            }
        }
    }

    protected void lastTarget()
    {
        for(int i=0; i<m_players.Count; i++)
        {
            if(!m_aimedPlayers.Contains(m_players[i]))
            {
                m_target = m_players[i];
                m_aimedPlayers = new List<GameObject>();
                break;
            }
        }
    }

    protected override void aim()
    {
        attack();
    }

    protected override void attack()
    {
        m_hasEnded = true;
        //instantiate barrel
        Debug.Log("KA-BOOM");
    }
}
