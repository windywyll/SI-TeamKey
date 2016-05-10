using UnityEngine;
using System.Collections;



public class Player : MonoBehaviour {

	public int m_PlayerId;

    int m_PlayerNumber;
    const int m_MAXLIFE=100;
    int m_Life;
    bool m_IsDead;
    bool m_Invicible;

    public float m_InvicibilityTime = 1;

    // Use this for initialization
    void Start ()
    {
        m_Life = m_MAXLIFE;
        m_IsDead = false;
        m_Invicible = false;
        Rename();
	}

    void Rename()
    {
        switch (m_PlayerId)
        {
            case 1:
                name = "Player Red";
                break;

            case 2:
                name = "Player Blue";
                break;

            case 3:
                name = "Player Green";
                break;

            case 4:
                name = "Player Yellow";
                break;

        }
    }

    public void SetInvincible( bool _isInvincible)
    {
        m_Invicible = _isInvincible;
    }

    public bool isDead()
    {
        return m_IsDead;
    }

    public void Damages(int _damages)
    {
        if(!m_IsDead && !m_Invicible)
        {
            if (m_Life - _damages >= 0)
            {
                m_Life -= _damages;
                StartCoroutine(Invincible());
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
        m_Invicible = true;
    }

    IEnumerator Invincible()
    {
        m_Invicible = true;
        yield return new WaitForSeconds(m_InvicibilityTime);
        m_Invicible = false;
    }

}
