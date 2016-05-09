using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    int m_PlayerNumber;
    const int m_MAXLIFE=100;
    int m_Life;
    bool m_IsDead;
    bool m_Invincible;

    float m_TimeInvincible = 3;

    // Use this for initialization
    void Start ()
    {
        Initialize();
	}
	
    void Initialize()
    {
        m_Life = m_MAXLIFE;
        m_IsDead = false;
        m_Invincible = false;
    }

    bool IsDead()
    {
        return m_IsDead;
    }

    void Damages(int _damages)
    {
        //if the player is not invincible
        if (!m_Invincible)
        {
            //Is alive after damages
            if (m_Life - _damages > 0)
            {
                m_Life -= _damages;
                StartCoroutine(InvincibleShoot());
            }
            else
            {
                m_Life = 0;
                Died();
            }
        }
    }

    void Died()
    {
        m_IsDead = true;
        m_Invincible = true;
    }



    IEnumerator InvincibleShoot()
    {
        m_Invincible = true;
        yield return new WaitForSeconds(m_TimeInvincible);
        m_Invincible = false;
    }

}
