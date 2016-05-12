using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherWolfRocketAttack : MotherWolfAttack {

    [SerializeField]
    int m_numRocket2Fire;
    [SerializeField]
    GameObject m_rocket;
    [SerializeField]
    Transform m_launcher;
    int m_numRocketLaunched;
    [SerializeField]
    float m_delayBetweenFire;
    float m_startDelay;
    bool m_startLaunchRockets;

    // Use this for initialization
    void Start () {
	}
 	
	// Update is called once per frame
	void Update () {
        if (m_players == null)
            m_players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

        if (m_startLaunchRockets && m_startDelay + m_delayBetweenFire < Time.time)
            selectTarget();
	}

    public override void launchAttackSequence(MotherWolfMovement movement, Animator anim)
    {
        m_animator = anim;
        m_animator.SetTrigger("missile");
    }

    public void launchMissiles()
    {
        m_hasEnded = false;
        m_startLaunchRockets = true;
        m_numRocketLaunched = 0;
    }

    protected override void selectTarget()
    {
        m_startDelay = Time.time;
        m_target = m_players[Random.Range(0, m_players.Count)];
        aim();
    }

    protected override void aim()
    {
        //instantiate rocket
        //rotate it
        Vector3 down = m_launcher.position;
        down += m_launcher.forward * 4;
        down.y = m_target.transform.position.y;
        GameObject rock = (GameObject) Instantiate(m_rocket);
        rock.transform.position = m_launcher.position;
        rock.transform.LookAt(down);
        rock.GetComponent<Rocket>().setTarget(m_target.transform);
        rock.GetComponent<Rocket>().setDamage(m_damage);

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
    }
}
