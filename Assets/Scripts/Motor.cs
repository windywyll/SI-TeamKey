using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {

    [SerializeField]
    GameObject m_explosion;
    MotherWolfMotorAttack m_creator;
    [SerializeField]
    float m_lifetime, m_speed, m_speedMove;
    [SerializeField]
    float m_height, m_width, m_depth, m_maxFallLeft,m_maxFallRight,m_maxFallUp, m_maxFallDown;
    float m_startCountdown;
    int m_damage;
    bool m_isFalling, m_isDecaying = true;
    Vector3 m_landingPoint;

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.root.tag == "Bullet" && !m_isFalling)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.position + col.transform.root.forward, out hit, (m_width / 2) + 0.5f))
            {
                    if(hit.collider.transform.root.tag == "Ground")
                        transform.position += col.transform.root.forward * Time.deltaTime * m_speedMove;
            }
            else
            {
                transform.position += col.transform.root.forward * Time.deltaTime * m_speedMove;
            }
        }
    }

    public void setDamage(int damage)
    {
        m_damage = damage;
    }

    public void setCreator(MotherWolfMotorAttack creator)
    {
        m_creator = creator;
    }

	// Use this for initialization
	void Start () {
	}

    public void selectLandingPoint()
    {
        m_landingPoint = new Vector3(Random.Range(m_maxFallLeft - m_width / 2, m_maxFallRight + m_width / 2), -1 + m_height / 2, Random.Range(m_maxFallDown - m_depth / 2, m_maxFallUp + m_depth / 2));
        //rafiner tant que ça tombe sur une barrière
        m_isFalling = true;
        m_isDecaying = false;
    }

    void fall()
    {
        if (transform.position.y >= m_landingPoint.y + 0.1f || transform.position.y <= m_landingPoint.y - 0.1f)
        {
            transform.LookAt(m_landingPoint);
            Transform temp = transform.FindChild("Visuals");
            temp.LookAt(transform.position + Vector3.forward);
            temp = transform.FindChild("Physic");
            temp.LookAt(transform.position + Vector3.forward);
            transform.position += transform.forward * Time.deltaTime * m_speed;
        }
        else
        {
            m_isFalling = false;
        }
    }

    void touchGround()
    {
        m_startCountdown = Time.time;
        m_isDecaying = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (m_startCountdown + m_lifetime < Time.time && m_isDecaying)
            explode();

        if (!m_isDecaying)
        {
            if (m_isFalling)
                fall();
            else
                touchGround();
        }
	}

    void explode()
    {
        GameObject expl = Instantiate(m_explosion);
        expl.transform.position = transform.position;
        expl.GetComponent<ExplosionMotor>().setDamage(m_damage);
        m_creator.motorExplode();
        Destroy(gameObject);
    }
}
