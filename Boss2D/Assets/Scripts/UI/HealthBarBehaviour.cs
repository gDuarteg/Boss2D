using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour {

    public Slider HealthSlider;
    public Color Low;
    public Color High;
    public Vector3 Offset;

    public void SetHealth(float health, float maxHealth) {
        HealthSlider.gameObject.SetActive(health < maxHealth);
        HealthSlider.value = health;
        HealthSlider.maxValue = maxHealth;
        HealthSlider.fillRect.GetComponent<Image>().color = Color.Lerp(Low, High, HealthSlider.normalizedValue);
    }

    void Update() {
        HealthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
