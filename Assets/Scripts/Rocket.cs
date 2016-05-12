using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    [SerializeField]
    float m_speed, m_smoothTime;
    Vector3 m_smoothVel2;
    Transform m_target;
    bool m_locked;

    public void setTarget(Transform target)
    {
        if (target != null)
            m_target = target;
        m_locked = true;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

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
            transform.position = transform.position + transform.forward * Time.deltaTime * m_speed;
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
}
