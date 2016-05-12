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

    private Vibrations m_Vibrations;

    private Player m_Player;

    // Use this for initialization
    void Start ()
    {
        Initialize();
	}

    void Initialize()
    {
        m_Player = GetComponent<Player>();
        m_PlayerId = m_Player.m_PlayerId;
        m_Vibrations=GetComponent<Vibrations>();
        m_Ammo = m_MaxAmmo;
        StartCoroutine(ShootCooldown());
    }

    public void SetCanShoot(bool _can)
    {
        m_CanShoot = _can;
    }

    void Update()
    {
        if (m_Player.isDead() == false)
        {
            ShootInput();
        }
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

        if (Input.GetButtonDown("X_" + m_PlayerId.ToString())&& m_IsReloading==false && m_IsShooting==false)
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
                    if(m_IsReloading==false)
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
            GetComponent<PlayerData>().AddBulletsLaunched();

            m_Vibrations.ShootVibration();
            m_Ammo--;
            UIManager.instance.DecrementBullet(m_PlayerId);
            GameObject _bullet = Instantiate(m_Bullet, m_Canon.transform.position, transform.rotation) as GameObject;
            _bullet.GetComponent<BulletMovement>().SetDamages(m_Damages);
            _bullet.GetComponent<BulletMovement>().SetCreator(gameObject);
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
                m_Vibrations.ReloadVibration(true);
                
                float _time = m_CooldownReload;

                bool _done = false;

                while (_time > 0)
                {
                    yield return new WaitForSeconds(0.1f);
                    _time -= 0.1f;

                    if(_time<=0.2f && _done==false)
                    {
                        _done = true;
                        m_Vibrations.ReloadVibration(false);
                        UIManager.instance.ReloadBullets(m_PlayerId);
                    }
                }

                m_Ammo = m_MaxAmmo;

                //UI
                yield return new WaitForSeconds(0.1f);
                m_IsReloading = false;
            }
        }
    }


}
