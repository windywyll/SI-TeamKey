using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    [SerializeField]
    float m_speed, m_smoothTime;
    [SerializeField]
    int m_lifeMax, m_lifeSpan;
    [SerializeField]
    GameObject m_explosion;
    int m_Life;
    float m_startCountdown;
    Vector3 m_smoothVel2;
    Transform m_target;
    bool m_locked;
    int m_damage;

    Vector3 offset = Vector3.zero;

    public void setTarget(Transform target)
    {
        if (target != null)
            m_target = target;
        m_locked = true;
    }

    public void setDamage(int damage)
    {
        if (damage > 0)
            m_damage = damage;
    }

    public void getHit(int damage)
    {
        m_Life -= damage;

        if (m_Life <= 0)
            explode();
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("touched");

        if (col.transform.root.tag == "Player" || col.transform.root.tag == "Barrel")
            explode();
    }

	// Use this for initialization
	void Start () {
        m_Life = m_lifeMax;
        m_startCountdown = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (m_startCountdown + m_lifeSpan < Time.time)
            explode();

        if(m_locked)
            m_locked = checkDistanceFromTarget();

        if (m_locked)
            moveTowardsTarget();
        else
            moveForward();
	}

    bool checkDistanceFromTarget()
    {
        return Vector3.Distance(transform.position, m_target.position) > 1.0f;
    }

    void moveTowardsTarget()
    {
        if (transform.position.y <= m_target.position.y + 0.1 && transform.position.y >= m_target.position.y - 0.1)
        {
            Quaternion targetRotation;
            Vector3 lookPoint = Vector3.SmoothDamp(transform.position, m_target.transform.position + m_target.transform.forward, ref m_smoothVel2, m_smoothTime);
            targetRotation = Quaternion.FromToRotation(transform.up, m_target.transform.up);
            lookPoint -= transform.position;
            lookPoint.y = 0;
            targetRotation *= Quaternion.FromToRotation(transform.forward, lookPoint);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation * transform.rotation, m_smoothTime);
            Vector3 newPos = transform.position + transform.forward * Time.deltaTime * m_speed;
            float offset = 4 * Mathf.Sin(Time.time * 5);
            transform.position = newPos;
            transform.position = transform.position + transform.right * offset * 0.02f;
        }
        else
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * m_speed;
        }
    }

    void moveForward()
    {
        transform.position = transform.position + transform.forward * Time.deltaTime * m_speed;
    }

    void explode()
    {
        GameObject expl = Instantiate(m_explosion);
        expl.transform.position = transform.position;
        expl.GetComponent<Explosion>().setDamage(m_damage);
        Destroy(gameObject);
    }
}
