using UnityEngine;
using System.Collections;

public class PlayerReanimation : MonoBehaviour
{

    Player m_PlayerReanimation;

    public Player m_Player;
    private int m_PlayerId;
    private bool m_IsReanimated = false;
    public Player m_PlayerNear;

    public float m_TimeRez = 2;

    private GameObject _go;

    private bool m_IsColliding=false;

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

        m_IsReanimated = true;
        StartCoroutine(ReanimationCoroutine());
        
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
        RezPlayer();
    }

    void RezPlayer()
    {
        if(m_PlayerNear!=null)
        {
            m_PlayerNear.GetComponent<Player>().Rez();
            m_PlayerNear = null;
            m_IsColliding = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (m_Player.isDead() == false)
        { 
            if (col.tag == "Player" && m_IsColliding == false)
            {
                m_IsColliding = true;
                PreRez(col.gameObject);              
            }
        }
    }

    void PreRez(GameObject _go)
    {
        m_PlayerNear = _go.GetComponent<ReturnParent>().m_Parent;
        LaunchRez();    
    }

    void OnTriggerExit(Collider col)
    {
        if (_go == m_PlayerNear)
        {
            m_PlayerNear = null;
            m_IsColliding = false;
        }
    }

}
