using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour {

    private Vibrations m_Vibrations;
    private int m_PlayerId;

    public bool m_IsDashing=false;
    private bool m_CanDash = true;

    public float m_DashTime = 0.3f;

    public float m_Cooldown = 1;

    private Player m_Player;

    public float m_DashSpeed = 8;

    // Use this for initialization
    void Start ()
    {
        m_Player = GetComponent<Player>();
        m_PlayerId = m_Player.m_PlayerId;
        m_Vibrations = GetComponent<Vibrations>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_Player.isDead() == false)
        {
            if (Input.GetAxis("TriggersL_" + m_PlayerId.ToString()) > 0)
            {
                if (m_CanDash && !m_IsDashing)
                {
                    StartCoroutine(Dash());
                }

            }
        }
        else
        {
            StopAllCoroutines();
        }
    }

    IEnumerator Dash()
    {
        //Dash
        m_IsDashing = true;
        GetComponent<PlayerGun>().SetCanShoot(false);
        m_Vibrations.DashVibration(m_DashTime);
        GetComponent<Player>().SetInvincible(true);
        GetComponent<PlayerMove>().StartDash(m_DashSpeed,m_DashTime);


        yield return new WaitForSeconds(m_DashTime);

        //Stop Dashing
        GetComponent<Player>().SetInvincible(false);
        m_CanDash = false;
        m_IsDashing = false;
        GetComponent<PlayerGun>().SetCanShoot(true);

        //Cooldow
        yield return new WaitForSeconds(m_Cooldown);
        m_CanDash = true;

    }
}
