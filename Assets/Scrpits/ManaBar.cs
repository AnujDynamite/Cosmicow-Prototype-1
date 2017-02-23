using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour {

    [SerializeField]
    private float maxMana;

    [SerializeField]
    private float currentMana;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(1) && currentMana > 0)
        {
            UseMana(-10);
        }
    }

    void UseMana(int _Mana)
    {
        currentMana += _Mana;
    }
}
