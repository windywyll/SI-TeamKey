using UnityEngine;
using System.Collections;

public class MotherWolfMovement : MonoBehaviour {

    //[SerializeField]
    //private float m_rotatingSpeed;
    
    private Vector3 m_initPos;
    private Vector3 m_target;

	// Use this for initialization
	void Start () {
        m_initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if(m_target != null)
        {
            m_target.y = m_initPos.y;
            transform.LookAt(m_target);
        }
	}
}
