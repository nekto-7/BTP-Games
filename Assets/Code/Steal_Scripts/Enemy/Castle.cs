using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public float totalHealth = 100f;
    public float currentHealth;
    // 4 and 5 
    public int scene;
    public Slider healthSlider;
    public Transform[] attackPoints;
    void Start()
    {
        currentHealth = totalHealth;

        healthSlider.maxValue = totalHealth;
        healthSlider.value = currentHealth;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        healthSlider.value = currentHealth;
        if(totalHealth <= 0)
        {
            SceneManager.LoadScene(scene);
        }
    }
}

