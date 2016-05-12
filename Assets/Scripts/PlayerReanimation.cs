using UnityEngine;
using System.Collections;

public class PlayerReanimation : MonoBehaviour
{

    Player m_PlayerReanimation;

    private Player m_Player;
    private int m_PlayerId;
    private bool m_IsReanimated = false;
    public Player m_PlayerNear;

    public float m_TimeRez = 2;

    // Use this for initialization
    void Start()
    {
        m_Player = GetComponent<Player>();
        m_PlayerId = m_Player.m_PlayerId;
    }

    public bool GetReanimate()
    {
        return m_IsReanimated;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("A_" + m_PlayerId.ToString()))
        {
            
            if (m_Player.isDead() == false && m_IsReanimated == false)
            {
                if (m_PlayerNear != null)
                {
                    Debug.Log("A");
                    LaunchRez();
                }
            }
        }

        if (Input.GetButtonUp("A_" + m_PlayerId.ToString()))
        {
            StopRez();
        }
    }

    void LaunchRez()
    {
        RezPlayer();
        /*
        m_IsReanimated = true;
        StartCoroutine(ReanimationCoroutine());
        */
        
    }

    public void StopRez()
    {
        StopAllCoroutines();
        m_IsReanimated = false;
    }

    IEnumerator ReanimationCoroutine()
    {
        float _time = m_TimeRez;
        while (_time > 0)
        {
            _time -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

    }

    void RezPlayer()
    {
        if(m_PlayerNear!=null)
        {
            m_PlayerNear.GetComponent<Player>().Rez();
            m_PlayerNear = null;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject);
        if(col.gameObject.tag=="Player")
        {
           if(col.gameObject.GetComponent<Player>().isDead())
            {
                m_PlayerNear = col.gameObject.GetComponent<Player>();
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == m_PlayerNear)
        {
            m_PlayerNear = null;
        }
    }
}
