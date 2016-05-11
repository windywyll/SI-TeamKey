using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherWolf : MonoBehaviour {

    bool m_vulnerable;
    bool m_isMelee;
    bool m_isMotorInZone;
    MotherWolfMovement m_movement;
    [SerializeField]
    List<MotherWolfAttack> m_attacks;
    [SerializeField]
    MotherWolfAttack m_melee;
    int m_countRepeat, m_attackRepeated;
    List<GameObject> m_players;

    private float m_startAttack;
    [SerializeField]
    private float m_attackCooldown;

	// Use this for initialization
	void Start () {
        m_movement = gameObject.GetComponent<MotherWolfMovement>();
        m_startAttack = Time.time;
        m_isMelee = true;
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
	}

    public bool isVulnerable()
    {
        return m_vulnerable;
    }

    void selectAttack()
    {
        m_startAttack = Time.time;
        if (m_isMelee)
        {
            meleeAttack();
        }
        else
        {
            otherAttack();
        }
    }

    void meleeAttack()
    {
        if (m_countRepeat < m_melee.getMinRepeat())
        {
            m_melee.launchAttackSequence(m_movement);
            m_countRepeat++;
        }
        else
        {
            if (m_countRepeat < m_melee.getMaxRepeat() && Random.Range(0,100) < m_melee.getPercentRepeat())
            {
                m_melee.launchAttackSequence(m_movement);
                m_countRepeat++;
            }
            else
            {
                m_countRepeat = 0;
                m_isMelee = false;
            }
        }
    }

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

                    if(m_attacks[i].isRepeatable())
                    {
                        m_countRepeat++;
                        m_attackRepeated = i;
                    }
                    else
                    {
                        m_isMelee = true;
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
                m_isMelee = true;
            }
        }
    }
}
