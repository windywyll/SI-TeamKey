using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    public float m_speed = 40f;
    public float m_damage;
    public GameObject m_creator;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 12);
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
