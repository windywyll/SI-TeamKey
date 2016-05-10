using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherWolf : MonoBehaviour {

    bool m_vulnerable;
    MotherWolfMovement m_movement;
    [SerializeField]
    List<MotherWolfAttack> m_attacks;
    List<GameObject> m_players;

    private float m_startAttack;
    private float m_attackCooldown = 5.0f;

	// Use this for initialization
	void Start () {
        m_movement = gameObject.GetComponent<MotherWolfMovement>();
        m_startAttack = Time.time;
        m_players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
	}
	
	// Update is called once per frame
	void Update () {
	    if(m_startAttack + m_attackCooldown < Time.time)
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
        float randomAttack = Random.Range(0.0f,100.0f);
        float countPercentage = 0;

        for(int i = 0; i < m_attacks.Count; i++)
        {
            countPercentage += m_attacks[i].getPercentageAttack();
            if(randomAttack <= countPercentage)
            {
                m_attacks[i].launchAttack();
                break;
            }
        }
    }
}
