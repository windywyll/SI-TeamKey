using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("X_1")|| Input.GetButtonDown("X_2")|| Input.GetButtonDown("X_3")|| Input.GetButtonDown("X_4"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
