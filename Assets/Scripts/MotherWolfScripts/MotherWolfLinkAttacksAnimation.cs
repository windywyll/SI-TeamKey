using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherWolfLinkAttacksAnimation : MonoBehaviour {

    [SerializeField]
    private MotherWolfBarrelAttack m_barrel;
    [SerializeField]
    private MotherWolfObjectRain m_objectRain;
    [SerializeField]
    private MotherWolfMotorAttack m_motor;
    [SerializeField]
    private MotherWolfRocketAttack m_missile;

    public void launchRockets()
    {
        m_missile.launchMissiles();
    }
}
