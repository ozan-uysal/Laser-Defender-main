using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3);
    }

    // Update is called once per frame
    void  FixedUpdate()
    {
        transform.Translate(Vector3.up*speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Health health))
        {
            Debug.Log("hit");
            health.health -= damage;
            
            ScoreManager.instance.UpdateScore();
            Destroy(gameObject);
        }
    }
    
}
