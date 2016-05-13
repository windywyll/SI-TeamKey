using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    [SerializeField]
    private float m_lifeSpan = 12.0f;
    [SerializeField]
    private float m_speed = 40f;

    private int m_damage;
    private float startDeathCountdown;
    private GameObject m_creator;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 12);
        startDeathCountdown = Time.time;
    }

    public void SetDamages( int _damages)
    {
        m_damage = _damages;
    }

    void Update()
    {
        if (startDeathCountdown + m_lifeSpan < Time.time)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        transform.position = transform.position + transform.forward * Time.fixedDeltaTime * m_speed;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.root.tag == "Rocket")
            col.transform.root.GetComponent<Rocket>().getHit(m_damage);

        if (col.transform.root.tag == "MotherWolf")
            col.transform.root.GetComponent<MotherWolf>().getHit(m_damage);

        if(col.transform.root.tag != "Player")
            Destroy(gameObject);
    }
}
