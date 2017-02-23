using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPoints : MonoBehaviour {

    [SerializeField]
    private int currentSP;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown("m"))
        {
            GainSkillPoints(1);
        }
	}

    void GainSkillPoints(int _SP)
    {
        currentSP += _SP;
    }
}
