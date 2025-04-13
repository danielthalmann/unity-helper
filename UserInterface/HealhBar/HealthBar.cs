using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    private Slider slider;

    [SerializeField]
    [Range(0,1)]
    private float health;
    private float changeSpeed = 0.5f;
    private float healtCursor = 0;


    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (slider.value != health)
        { 
            healtCursor += Time.deltaTime * changeSpeed / 100;
            slider.value = Mathf.Lerp(slider.value, health, healtCursor);
            if (Mathf.Abs(slider.value - health) < 0.001)
            {
                slider.value = health;
                healtCursor = 0;
            }
        }
    }

    public void SetHealth(float health, bool init = false)
    {
        this.health = health;
        if (init)
        {
            slider.value = health;
        }
    }

    public float getHealth()
    {
        return this.health;
    }

    public void addHealth(float value)
    {
        this.health += value;
        if (this.health < 0)
            this.health = 0;
        if (this.health > 1.0f)
            this.health = 1.0f;
    }
}
