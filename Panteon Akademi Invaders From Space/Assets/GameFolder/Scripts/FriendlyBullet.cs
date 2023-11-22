using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
    private float _speed = 10;
   
    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            //Destroy(gameObject);
            collision.gameObject.GetComponent<Alien>().Kill();
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            //Destroy(collision.gameObject);
            //Destroy(gameObject);

            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
