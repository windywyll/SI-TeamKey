using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    [SerializeField]
    private float m_lifeSpan = 12.0f;
    [SerializeField]
    private float m_speed = 40f;

    private float m_damage;
    private float startDeathCountdown;
    private GameObject m_creator;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 12);
        startDeathCountdown = Time.time;
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

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
