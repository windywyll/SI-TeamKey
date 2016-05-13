using UnityEngine;
using System.Collections;

public class MotherWolfMovement : MonoBehaviour {

    //[SerializeField]
    //private float m_rotatingSpeed;
    
    private Vector3 m_initPos;
    private Quaternion m_initRot;
    private GameObject m_target;
    private Vector3 m_smoothVel2;
    private float m_smoothTime = 0.3f;

    // Use this for initialization
    void Start () {
        m_initPos = transform.position;
        m_initRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	    if(m_target != null)
        {
            Quaternion targetRotation;
            Vector3 lookPoint = Vector3.SmoothDamp(transform.position, m_target.transform.position + m_target.transform.forward, ref m_smoothVel2, m_smoothTime);
            targetRotation = Quaternion.FromToRotation(transform.up, m_target.transform.up);
            lookPoint -= transform.position;
            lookPoint.y = 0;
            targetRotation *= Quaternion.FromToRotation(transform.forward, lookPoint);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation * transform.rotation, m_smoothTime);
        }
	}

    public void setTarget(GameObject target)
    {
        m_target = target;
    }
}
