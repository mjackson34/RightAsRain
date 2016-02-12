using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public float increment = 1;
    public float maxHitPoints = 100f;
    private float currentHitPoints = 0f;

    public Transform healthbar;
    public Slider healthSlider;

    public void damage(float increment)
    {
        if (currentHitPoints <= maxHitPoints)
        {
            currentHitPoints += increment;
        }
        
    }

    float currentHealth()
    {
        return currentHitPoints / maxHitPoints;
    }

    void settingHealthSlider()
    {
        healthSlider.value = currentHitPoints;
        //healthbar.localScale = new Vector3(currentHealth(), 1f, 1f);
    }

    void Update()
    {
        //damage(1f);
        //currentHealth();
        settingHealthSlider();
        if (currentHitPoints >= maxHitPoints)
        {
            string sceneName = SceneManager.GetActiveScene().name;

            // load the same scene
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
