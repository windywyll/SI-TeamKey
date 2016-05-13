using UnityEngine;
using System.Collections;

public class ObjectRain : MonoBehaviour {
    
    [SerializeField]
    float m_speed;
    [SerializeField]
    float m_height, m_width, m_depth, m_maxFallLeft, m_maxFallRight, m_maxFallUp, m_maxFallDown;
    int m_damage;
    bool m_isFalling;
    Vector3 m_landingPoint;

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.root.tag == "player")
        {
            col.transform.root.GetComponent<Player>().Damages(m_damage);
        }
    }

    public void setDamage(int damage)
    {
        if (damage > 0)
            m_damage = damage;
    }

    public void selectLandingPoint()
    {
        m_landingPoint = new Vector3(Random.Range(m_maxFallLeft - m_width / 2, m_maxFallRight + m_width / 2), -1 + m_height / 2, Random.Range(m_maxFallDown - m_depth / 2, m_maxFallUp + m_depth / 2));
        //rafiner tant que ça tombe sur une barrière
        m_isFalling = true;
    }

    void fall()
    {
        if (transform.position.y >= m_landingPoint.y + 0.1f || transform.position.y <= m_landingPoint.y - 0.1f)
        {
            transform.LookAt(m_landingPoint);
            Transform temp = transform.FindChild("Visuals");
            temp.LookAt(transform.position + Vector3.forward);
            temp = transform.FindChild("Physics");
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
        //launchParticle
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (m_isFalling)
            fall();
        else
            touchGround();
    }
}
