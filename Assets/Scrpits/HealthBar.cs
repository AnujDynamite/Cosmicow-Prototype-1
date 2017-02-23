using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    private float totalHP;

    [SerializeField]
    private float currentHP;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(0) && currentHP > 0)
        {
            TakeDamage(-10);
        }
	}

    void TakeDamage(int _Damage)
    {
        currentHP += _Damage;
    }
}
