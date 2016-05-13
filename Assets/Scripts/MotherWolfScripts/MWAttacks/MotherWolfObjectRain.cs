using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherWolfObjectRain : MotherWolfAttack {

    [SerializeField]
    List<GameObject> m_propsToRain;
    [SerializeField]
    float m_minTimeToSpawn, m_maxTimeToSpawn, m_rainTimeMin, m_rainTimeMax;
    float m_startDelay, m_delay, m_rainTime;
    float m_startLooping;
    bool m_chocolateRain;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (m_chocolateRain && m_startDelay + m_delay < Time.time)
            attack();

        if (m_startLooping + m_rainTime < Time.time && m_chocolateRain)
        {
            stopAttack();
        }
	}

    public override void launchAttackSequence(MotherWolfMovement movement, Animator anim, MotherWolf mom)
    {
        m_animator = anim;
        m_animator.SetTrigger("objectRain");
        m_hasEnded = false;
        m_chocolateRain = false;
    }

    protected override void selectTarget()
    {

    }

    protected override void aim()
    {
    }

    protected override void attack()
    {
        m_startDelay = Time.time;
        m_delay = Random.Range(m_minTimeToSpawn, m_maxTimeToSpawn);
        int propsToCreate = Random.Range(0, m_propsToRain.Count);
        GameObject rainingProp = Instantiate(m_propsToRain[propsToCreate]);
        rainingProp.transform.position = new Vector3(0.0f, 12.0f, 12.0f);
        ObjectRain prop = rainingProp.GetComponent<ObjectRain>();
        prop.setDamage(m_damage);
        prop.selectLandingPoint();
    }

    public void releaseTheRain()
    {
        m_chocolateRain = true;
        m_rainTime = Random.Range(m_rainTimeMin, m_rainTimeMax);
        m_startLooping = Time.time;
        m_animator.SetTrigger("startLoop");
    }

    public override void stopAttack()
    {
        m_animator.SetTrigger("endLoop");
        m_chocolateRain = false;
        m_hasEnded = true;
    }
}
