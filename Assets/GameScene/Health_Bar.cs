using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    [SerializeField] private GameObject[] health_Bar;
    [SerializeField] private PlayerHealth playerHealth;
    void Update()
    {
        for (int i = 0; i < health_Bar.Length; i++)
        {

            if (i < playerHealth.Current_PlayerHealth)
            {
                health_Bar[i].SetActive(true);
            }
            else
            {
                health_Bar[i].SetActive(false);
            }

        }
    }
}
