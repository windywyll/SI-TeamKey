using UnityEngine;
using System.Collections;

public class PlayerGun : MonoBehaviour {

    public GameObject m_Bullet;
    public GameObject m_Canon;

    int m_Damages=1;

    public float m_ShootCooldownDelay=0.1f;
    public float m_CooldownReload =2.0f;

    bool m_CanShoot=true;

    public int m_PlayerId;

    public int m_MaxAmmo = 30;
    public int m_Ammo;

    private bool m_IsShooting=false;

    private bool m_IsReloading = false;

    public float m_OffsetBalistic = 0.1f;


    // Use this for initialization
    void Start ()
    {
        Initialize();
	}

    void Initialize()
    {
        m_PlayerId = GetComponent<Player>().m_PlayerId;
        m_Ammo = m_MaxAmmo;
        StartCoroutine(ShootCooldown());
    }

    void Update()
    {
        ShootInput();
    }
	
    void ShootInput()
    {
        if (m_CanShoot)
        {
            if (Input.GetAxis("TriggersR_" + m_PlayerId.ToString()) > 0)
            {
                m_IsShooting = true;
            }
            else
            {
                m_IsShooting = false;
            }
        }
        else
        {
            m_IsShooting = false;
        }

        if (Input.GetButtonDown("X_" + m_PlayerId.ToString()))
        {
            StartCoroutine(Reload());
        }

    }


    IEnumerator ShootCooldown()
    {
        while(true)
        {
            while (m_Ammo > 0)
            {
                while (m_IsShooting)
                {
                    Shoot();
                    yield return new WaitForSeconds(m_ShootCooldownDelay);
                }
                yield return new WaitForSeconds(m_ShootCooldownDelay);
            }
            yield return new WaitForSeconds(m_ShootCooldownDelay);
        }
    }

    void Shoot()
    {
        if (m_Ammo > 0)
        {
            m_Ammo--;
            GameObject _bullet = Instantiate(m_Bullet, m_Canon.transform.position, transform.rotation) as GameObject;
            _bullet.GetComponent<BulletMovement>().SetDamages(m_Damages);
            _bullet.transform.eulerAngles = new Vector3(_bullet.transform.eulerAngles.x, _bullet.transform.eulerAngles.y + Random.Range(-m_OffsetBalistic, m_OffsetBalistic), _bullet.transform.eulerAngles.z);
        }
    }

    IEnumerator Reload()
    {
        if (m_Ammo != m_MaxAmmo)
        {
            if (m_IsReloading == false)
            {

                m_IsReloading = true;
                float _time = m_CooldownReload;

                while (_time > 0)
                {
                    yield return new WaitForSeconds(0.1f);
                    _time -= 0.1f;
                }

                m_Ammo = m_MaxAmmo;
                //UI

                m_IsReloading = false;
            }
        }
    }


}
