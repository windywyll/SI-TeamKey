using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

	public int m_PlayerId;

    int m_PlayerNumber;
    const int m_MAXLIFE=100;
    int m_Life;

     [SerializeField]
    bool m_IsDead;
    bool m_Invicible;

    public float m_InvicibilityTime = 1;

    public Collider m_ColliderSphere;
    public Collider m_ColliderAlife;

    public SpriteRenderer m_Arrow;

    public Color[] m_ColorPlayer = new Color[4];

    // Use this for initialization
    void Start ()
    {
        m_Life = m_MAXLIFE;
        m_IsDead = false;
        m_Invicible = false;
        ChangeCollider(true);
        Rename();

        m_Arrow.color = m_ColorPlayer[m_PlayerId-1];
        gameObject.layer = 8;
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
            GetComponent<PlayerData>().AddDamagesTaken(_damages);
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
        GetComponent<PlayerData>().AddDeath();
        m_IsDead = true;
        m_Invicible = true;
        ChangeCollider(false);
        gameObject.layer = 11;
    }

    IEnumerator Invincible()
    {
        m_Invicible = true;
        yield return new WaitForSeconds(m_InvicibilityTime);
        m_Invicible = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Back_" + m_PlayerId.ToString()))
        {
            Died();
        }
    }

    public void Rez()
    {
        m_ColliderSphere.enabled = false;
        m_IsDead = false;
        StartCoroutine(Invincible());
        m_Life = m_MAXLIFE;
        ChangeCollider(true);
        gameObject.layer = 8;
    }

    void ChangeCollider(bool _aliveCollider)
    {
        m_ColliderAlife.enabled = _aliveCollider;
        m_ColliderSphere.enabled = !_aliveCollider;
    }
}
