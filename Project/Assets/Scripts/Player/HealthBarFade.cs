
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarFade : MonoBehaviour
{
    //[SerializeField] PlayerController playermovement;
    private const float DAMAGED_HEALTH_FADE_TIMER_MAX = .6f;
    public float MaxHealth = 100f;
    private Image barImage;
    private Image damagedBarImage;
    private Color damagedColor;
    private float damagedHealthFadeTimer;
    private HealthSystem healthSystem;
    [SerializeField] Transform Player;
    Scene currentscene;
    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        barImage = transform.Find("Fade").GetComponent<Image>();
        damagedBarImage = transform.Find("BackGround").GetComponent<Image>();
        damagedColor = damagedBarImage.color;
        damagedColor.a = 0f;
        damagedBarImage.color = damagedColor;
    }

    private void Start()
    {
        healthSystem.SetUp(MaxHealth);
        SetHealth(healthSystem.GetHealthNormalized());
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        healthSystem.OnHealed += HealthSystem_OnHealed;

        currentscene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        //transform.position = new Vector2(Player.transform.position.x,Player.transform.position.y+ 1.1f);
        if (damagedColor.a > 0)
        {
            damagedHealthFadeTimer -= Time.deltaTime;
            if (damagedHealthFadeTimer < 0)
            {
                float fadeAmount = 5f;
                damagedColor.a -= fadeAmount * Time.deltaTime;
                damagedBarImage.color = damagedColor;
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Damage(1);

        }else if (Input.GetKeyDown(KeyCode.U))
        {
            Health(1);
        }

    }

    private void HealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        SetHealth(healthSystem.GetHealthNormalized());
    }

    private void HealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        if (damagedColor.a <= 0)
        {
            // Damaged bar image is invisible
            damagedBarImage.fillAmount = barImage.fillAmount;
        }
        damagedColor.a = 1;
        damagedBarImage.color = damagedColor;
        damagedHealthFadeTimer = DAMAGED_HEALTH_FADE_TIMER_MAX;

        SetHealth(healthSystem.GetHealthNormalized());
    }

    private void SetHealth(float healthNormalized)
    {
        barImage.fillAmount = healthNormalized;
        if (this.healthSystem.healthAmount <= 0)
            SceneManager.LoadScene(currentscene.buildIndex);
    }
    public void Damage(int SetDamage)
    {
        healthSystem.Damage(SetDamage);
    }
    public void Health(int SetHealth)
    {
        healthSystem.Heal(SetHealth);
    }
}
