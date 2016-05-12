﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherWolf : MonoBehaviour {

    bool m_vulnerable;
    bool m_isRocket;
    bool m_isMotorInZone;
    bool m_attackEnded;
    MotherWolfMovement m_movement;
    [SerializeField]
    List<MotherWolfAttack> m_attacks;
    [SerializeField]
    MotherWolfAttack m_rocket;
    int m_countRepeat, m_attackRepeated, m_attackSelected;
    List<GameObject> m_players;

    private float m_startAttack;
    [SerializeField]
    private float m_attackCooldown;

	// Use this for initialization
	void Start () {
        m_movement = gameObject.GetComponent<MotherWolfMovement>();
        m_startAttack = Time.time;
        m_isRocket = true;
        m_isMotorInZone = false;
        m_countRepeat = 0;
        m_attackRepeated = -1;
	}
	
	// Update is called once per frame
	void Update () {
        if(m_players == null)
            m_players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

        if (m_startAttack + m_attackCooldown < Time.time)
        {
            selectAttack();
        }

        if (!m_attackEnded)
            checkIfAttackEnded();
	}

    public bool isVulnerable()
    {
        return m_vulnerable;
    }

    void selectAttack()
    {
        m_attackEnded = false;

        if (m_isRocket)
        {
            rocketAttack();
        }
        else
        {
            otherAttack();
        }
    }

    void rocketAttack()
    {
        m_rocket.launchAttackSequence(m_movement);
        m_isRocket = false;
        m_countRepeat = 0;
    }

    /*void meleeAttack()
    {
        if (m_countRepeat < m_rocket.getMinRepeat())
        {
            m_rocket.launchAttackSequence(m_movement);
            m_countRepeat++;
        }
        else
        {
            if (m_countRepeat < m_rocket.getMaxRepeat() && Random.Range(0,100) < m_rocket.getPercentRepeat())
            {
                m_rocket.launchAttackSequence(m_movement);
                m_countRepeat++;
            }
            else
            {
                m_countRepeat = 0;
                m_isRocket = false;
            }
        }
    }*/

    void otherAttack()
    {
        if (m_attackRepeated < 0)
        {
            float randomAttack = Random.Range(0, 100);
            float countPercentage = 0;

            for (int i = 0; i < m_attacks.Count; i++)
            {
                countPercentage += m_attacks[i].getPercentageAttack();
                if (randomAttack <= countPercentage)
                {
                    m_attacks[i].launchAttackSequence(m_movement);
                    m_attackSelected = i;

                    if(m_attacks[i].isRepeatable())
                    {
                        m_countRepeat++;
                        m_attackRepeated = i;
                    }
                    else
                    {
                        m_isRocket = true;
                        m_countRepeat = 0;
                        m_attackRepeated = -1;
                    }
                    break;
                }
            }
        }
        else
        {
            repeatOtherAttack();
        }
    }

    void repeatOtherAttack()
    {
        if (m_countRepeat < m_attacks[m_attackRepeated].getMinRepeat())
        {
            m_attacks[m_attackRepeated].launchAttackSequence(m_movement);
            m_countRepeat++;
        }
        else
        {
            if (m_countRepeat < m_attacks[m_attackRepeated].getMaxRepeat() && Random.Range(0, 100) < m_attacks[m_attackRepeated].getPercentRepeat())
            {
                m_attacks[m_attackRepeated].launchAttackSequence(m_movement);
                m_countRepeat++;
            }
            else
            {
                m_countRepeat = 0;
                m_attackRepeated = -1;
                m_isRocket = true;
            }
        }
    }

    void checkIfAttackEnded()
    {
        if (m_isRocket)
            m_attackEnded = m_rocket.attackEnded();
        else
            m_attackEnded = m_attacks[m_attackSelected].attackEnded();

        if (m_attackEnded)
            m_startAttack = Time.time;
    }
}
