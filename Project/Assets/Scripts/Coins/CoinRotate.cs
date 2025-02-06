using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    bool isright;
    public float horizontal;
    public float vertical;
    public float coinRotateSpeed = 5f;
    Vector3 coinScale;
    [SerializeField] Transform Target;
   

  
    private void Start()
    {
        coinScale = transform.localScale;
        InvokeRepeating(nameof(Movement), 0, 2f);
    }
    private void Update()
    {
        if (isright)
        {
            transform.Translate(Vector2.right * Time.deltaTime * horizontal);
            transform.Translate(Vector2.up * Time.deltaTime * vertical);
        }

        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * horizontal);
            transform.Translate(Vector2.down * Time.deltaTime * vertical);
        }
          
        coinScale.x = Mathf.Sin(Time.time * coinRotateSpeed);
        transform.localScale = coinScale;
       

    }
    void Movement()
    {
        isright = !isright;
    }
}
