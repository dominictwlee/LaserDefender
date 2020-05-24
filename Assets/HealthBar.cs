using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    FloatVariable health;

    [SerializeField]
    FloatReference maxHealth;

    Image fillImage;

    enum HealthState {
        Healthy,
        Warning,
        Danger,
    }

    Dictionary<HealthState, Color> colors = new Dictionary<HealthState, Color>
    {
        [HealthState.Healthy] = new Color32(128, 255, 232, 255),
        [HealthState.Warning] = new Color32(255, 180, 0, 255),
        [HealthState.Danger] = new Color32(240, 45, 58, 255),
    };

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxHealth.Value;
        slider.value = maxHealth.Value;
        fillImage = transform.GetChild(0).gameObject.GetComponent<Image>();
        fillImage.color = colors[HealthState.Healthy];
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health.Value;
        SetHealthColor();
    }

    void SetHealthColor()
    {
        if (health.Value <= maxHealth.Value * 0.15)
        {
            fillImage.color = colors[HealthState.Danger];
        } else if (health.Value <= maxHealth.Value * 0.5)
        {
            fillImage.color = colors[HealthState.Warning];
        }
    }


}
