using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EZCameraShake;
public class PlayerPhysics : MonoBehaviour
{
    public float bounceForce = 60f;
    float dotValue;
    float finalVal;
    public float minForce = 120f;
    bool isDamage;
    [Space]
    [Range(0f, 1f)]
    public float dirParam = .14f;
    Rigidbody2D playerRB;
    Animator anim;
    PlayerState state;

    [SerializeField] HealthBarFade fade;

    GameObject collidingObject;

    public GameObject collidingGameObject => collidingObject;

    [SerializeField] GameObject[] uiElements;
    [SerializeField] TextMeshProUGUI coinsamount;

    PlayerCoinCollector coinCollector;
    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        state = GetComponent<PlayerState>();
            anim = GetComponent<Animator>();
        coinCollector = GetComponentInChildren<PlayerCoinCollector>();
    }
    Vector2 finalForceDir;
    public Vector2 forceDir => finalForceDir;
    private void Update()
    {
        state.currentPlayerState = !isColliding ? PlayerCurrentState.InAir : PlayerCurrentState.Bounced;
        float worldDot = Vector2.Dot(Vector2.up, transform.up);
        if (worldDot < 0f)
        {
            finalForceDir = transform.up * -1f;
        }
        else
        {
            finalForceDir = transform.up;
        }

        if (uiElements[3] != null)
            uiElements[3].transform.position = transform.position;
        else
            return;


    }
    bool isColliding;
    Collision2D curCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
        collidingObject = collision.gameObject;
        curCollision = collision;
        //Find dot between player up dir and normal of collision
        dotValue = Vector2.Dot(collision.contacts[0].normal, transform.up);
        //Make it only positive.
        finalVal = Mathf.Abs(dotValue);
        //Create a final magnitude of force to apply.
        float forceMag = finalVal * bounceForce;
        CalculateAndAddForce(forceMag, finalVal);
        
            SoundManager.instance.jumpSound();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        collidingObject = collision.gameObject;
        isColliding = true;
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collidingObject = null;
        isColliding = false;


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")&&isDamage==false)
        {
          //  CameraShaker.Instance.ShakeOnce(4, 4, .1f,.2f);
            anim.SetTrigger("Hit");
            fade.Damage(1);
            StartCoroutine(Damageable());
            SoundManager.instance.hitSound();
         
        }
        else if (collision.CompareTag("Next"))
        {
            SoundManager.instance.WinSound();
                Win();        
        }
    }
    private void CalculateAndAddForce(float forceMag, float dotRes)
    {
        if (dotRes <= dirParam)
        {
            playerRB.AddForce(Vector2.up * minForce);
        }
        playerRB.AddForce(forceMag * finalForceDir);
    }
    IEnumerator Damageable()
    {
        isDamage = true;
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(.3f);
        Time.timeScale = 1;
        yield return new WaitForSeconds(1.7f);
        isDamage = false;
    }
    public void Win()
    {
        uiElements[0].SetActive(true);
        uiElements[1].SetActive(false);
        uiElements[2].SetActive(false);
        uiElements[3].SetActive(true);
        coinsamount.text = coinCollector.collectedCoins.ToString();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
