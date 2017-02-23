using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayOverTime : MonoBehaviour
{

    [SerializeField]
    private float m_fDecayTime;

    private float m_fCurrentTime = 0;
	
	void Update ()
    {
        if (m_fCurrentTime <= m_fDecayTime)
        {
            m_fCurrentTime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
