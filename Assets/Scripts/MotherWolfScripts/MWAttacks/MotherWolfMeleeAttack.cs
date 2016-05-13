using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherWolfMeleeAttack : MotherWolfAttack {

    [SerializeField]
    private float m_delayAim;
    [SerializeField]
    Transform m_elbow;
    private float m_startDelayAim;
    private bool m_aiming, m_attacking, m_endRotElbow, m_returnElbow;
    Vector3 m_posToAttack;
    Vector3 smoothVel2;
    Vector3 m_initElbowPos;
    Quaternion m_initElbowRot;
    Quaternion m_prevRot;

    // Use this for initialization
    void Start () {
        m_aiming = false;
        m_initElbowPos = m_elbow.position;
        m_initElbowRot = m_elbow.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_players == null)
            m_players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

        if (m_aiming)
            aim();

        if (m_attacking)
            attack();

        if (m_returnElbow)
            returnElbowToInitpos();
	}

    public override void launchAttackSequence(MotherWolfMovement movement, Animator anim, MotherWolf mom)
    {
        m_animator = anim;
        m_movement = movement;
        selectTarget();
        m_startDelayAim = Time.time;
        m_aiming = true;
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
        //anim bras levé
        m_movement.setTarget(m_target);

        if (m_startDelayAim + m_delayAim < Time.time)
        {
            m_movement.setTarget(null);
            m_posToAttack = m_target.transform.position;
            m_target = null;
            m_aiming = false;
            m_attacking = true;
            m_endRotElbow = false;
        }
    }

    protected override void attack()
    {
        //bougé bras vers cible.
        if (!m_endRotElbow)
        {
            float smoothTime = 0.3f;
            Quaternion targetRotation;
            Vector3 lookPoint = Vector3.SmoothDamp(m_elbow.position, m_elbow.position + m_elbow.right, ref smoothVel2, smoothTime);
            targetRotation = Quaternion.FromToRotation(m_elbow.right, m_posToAttack);
            targetRotation *= Quaternion.FromToRotation(m_elbow.right, lookPoint);
            m_elbow.rotation = Quaternion.Slerp(m_elbow.rotation, targetRotation * m_elbow.rotation, smoothTime);
        }
        else
        {
            Vector3 direction = (m_posToAttack - m_elbow.position) * 0.3f;
            Vector3 moveToVec = new Vector3(direction.z, direction.x, direction.y);
            m_elbow.Translate(moveToVec);
        }

        if (m_prevRot == m_elbow.rotation && !m_endRotElbow)
        {
            m_endRotElbow = true;
        }
        else
        {
            m_prevRot = m_elbow.rotation;
        }

        if(m_elbow.position.x > m_posToAttack.z - 0.1f && m_elbow.position.x < m_posToAttack.z + 0.1f)
        {
            if (m_elbow.position.y > m_posToAttack.x - 0.1f && m_elbow.position.y < m_posToAttack.x + 0.1f)
            {
                if (m_elbow.position.z > m_posToAttack.y - 0.1f && m_elbow.position.z < m_posToAttack.y + 0.1f)
                {
                    m_attacking = false;
                    applyDamage();
                }
            }
        }
    }

    private void applyDamage()
    {
        Debug.Log("Spluuuush");
        m_returnElbow = true;
    }

    private void returnElbowToInitpos()
    {
        m_elbow.position = m_initElbowPos;
        m_elbow.rotation = m_initElbowRot;
    }

    public override void stopAttack()
    {
        m_hasEnded = true;
    }
}
