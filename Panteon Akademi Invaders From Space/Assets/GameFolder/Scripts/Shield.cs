using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Sprite[] _states;
    private int _health;
    private SpriteRenderer _sr;

    void Start()
    {
        _health = 4;
        _sr = GetComponent<SpriteRenderer>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("FriendlyBullet"))
        {
            collision.gameObject.SetActive(false);
            _health--;

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _sr.sprite = _states[_health - 1];
            }
        }
    }
}
