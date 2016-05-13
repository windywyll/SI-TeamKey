using UnityEngine;
using System.Collections;

public class ExplosionMotor : MonoBehaviour {

    int m_damage;
    int m_lifeSpan = 1;
    float m_startCountdown;

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.root.tag == "Player")
            col.transform.root.GetComponent<Player>().Damages(m_damage);

        if (col.transform.root.tag == "Barrel")
            transform.position = transform.position;

        if (col.transform.root.tag == "MotherWolf")
            col.transform.root.GetComponent<MotherWolf>().becomeWeak();
    }

    public void setDamage(int damage)
    {
        if (damage > 0)
            m_damage = damage;
    }

    // Use this for initialization
    void Start()
    {
        m_startCountdown = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_startCountdown + m_lifeSpan < Time.time)
            Destroy(gameObject);
    }
}
