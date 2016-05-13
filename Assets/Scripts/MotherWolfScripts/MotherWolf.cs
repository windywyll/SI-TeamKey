using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherWolf : MonoBehaviour {

    bool m_vulnerable;
    bool m_isRocket;
    bool m_isMotorInZone;
    bool m_attackEnded;
    bool m_isDead;
    bool m_isWeak;
    MotherWolfMovement m_movement;
    [SerializeField]
    List<MotherWolfAttack> m_attacks;
    [SerializeField]
    MotherWolfAttack m_rocket;
    [SerializeField]
    Animator m_animator;
    [SerializeField]
    int m_lifeMax, m_weakMultiplicator;
    int m_life;
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
        m_attackEnded = true;
        m_countRepeat = 0;
        m_attackRepeated = -1;
        m_life = m_lifeMax;
	}
	
	// Update is called once per frame
	void Update () {
        if (!m_isDead)
        {
            if (m_players == null)
                m_players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

            if (m_startAttack + m_attackCooldown < Time.time && m_attackEnded && ! m_isWeak)
            {
                selectAttack();
            }

            if (!m_attackEnded)
                checkIfAttackEnded();
        }
	}

    public void becomeWeak()
    {
        m_isWeak = true;
        m_animator.SetTrigger("hurt");
    }

    public void stopBeingWeak()
    {
        m_isWeak = false;
        m_animator.ResetTrigger("hurt");
    }

    public bool isDead()
    {
        return m_isDead;
    }

    public bool isVulnerable()
    {
        return m_vulnerable;
    }

    public void getHit(int damage)
    {
        if (m_isWeak)
            m_life -= damage * m_weakMultiplicator;
        else
            m_life -= damage;

        if (m_life <= 0)
            death();
    }

    void selectAttack()
    {
        Debug.Log(m_isRocket);
        m_animator.ResetTrigger("objectRain");
        m_animator.ResetTrigger("melee");
        m_animator.ResetTrigger("launchBarrel");
        m_animator.ResetTrigger("missile");
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
        m_rocket.launchAttackSequence(m_movement, m_animator);
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
                    m_attacks[i].launchAttackSequence(m_movement, m_animator);
                    m_attackSelected = i;

                    if(m_attacks[i].isRepeatable())
                    {
                        m_countRepeat++;
                        m_attackRepeated = i;
                    }
                    else
                    {
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
            m_attacks[m_attackRepeated].launchAttackSequence(m_movement, m_animator);
            m_countRepeat++;
        }
        else
        {
            if (m_countRepeat < m_attacks[m_attackRepeated].getMaxRepeat() && Random.Range(0, 100) < m_attacks[m_attackRepeated].getPercentRepeat())
            {
                m_attacks[m_attackRepeated].launchAttackSequence(m_movement, m_animator);
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
        {
            m_attackEnded = m_rocket.attackEnded();
        }
        else
        {
            m_attackEnded = m_attacks[m_attackSelected].attackEnded();
        }

        if (m_attackEnded)
        {
            m_startAttack = Time.time;
            m_isRocket = !m_isRocket;
        }
    }

    void death()
    {
        m_isDead = true;
    }
}
