using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] ShipStats _shipStats;
    private const float _maxX = 4f;
    private const float _minX = -4f;
    //private float _speed = 3;
    //private float _cooldown = 0.5f;
    private bool _isShooting;

    private Vector2 _offScreenPos = new Vector2(0, -20);
    private Vector2 _startPos = new Vector2(0, -5);

    private float _dirextionX;

    private void Start()
    {
        _shipStats._currentHealth = _shipStats._maxHealth;
        _shipStats._currentLifes = _shipStats._maxLifes;
        transform.position = _startPos;
        UIManager.UpdateHealthBar(_shipStats._currentHealth);
        UIManager.UpdateLives(_shipStats._currentLifes);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > _minX)
        {
            transform.Translate(Vector2.left * _shipStats._shipSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < _maxX)
        {
            transform.Translate(Vector2.right * _shipStats._shipSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space) && !_isShooting)
        {
            StartCoroutine(Shoot());
        }

        _dirextionX = Input.acceleration.x;
        if(_dirextionX <= -0.1f && transform.position.x > _minX)
        {
            transform.Translate(Vector2.left * _shipStats._shipSpeed * Time.deltaTime);
        }
        else if(_dirextionX >= 0.1f && transform.position.x < _maxX)
        {
            transform.Translate(Vector2.right * _shipStats._shipSpeed * Time.deltaTime);
        }
    }

    public void ShootButton()
    {
        if (!_isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    public void AddHealth()
    {
        if(_shipStats._currentHealth == _shipStats._maxHealth)
        {
            UIManager.UpdateScore(250);
        }
        else
        {
            _shipStats._currentHealth++;
            UIManager.UpdateHealthBar(_shipStats._currentHealth);
        }
    }

    public void AddLife()
    {
        if (_shipStats._currentLifes == _shipStats._maxLifes)
        {
            UIManager.UpdateScore(1000);
        }
        else
        {
            _shipStats._currentLifes++;
            UIManager.UpdateLives(_shipStats._currentLifes);
        }
    }

    IEnumerator Shoot()
    {
        _isShooting = true;
        //Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        GameObject obj = _objectPool.GetPooledObject();
        obj.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(_shipStats._fireRate);
        _isShooting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            collision.gameObject.SetActive(false);
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        _shipStats._currentHealth--;
        UIManager.UpdateHealthBar(_shipStats._currentHealth);

        if (_shipStats._currentHealth <= 0)
        {
            _shipStats._currentLifes--;

            UIManager.UpdateLives(_shipStats._currentLifes);

            if (_shipStats._currentLifes <= 0)
            {
                Debug.Log("game over");
            }
            else
            {
                Debug.Log("respawn");
                StartCoroutine(Respawn());
            }
        }
       
    }

    IEnumerator Respawn()
    {
        transform.position = _offScreenPos;
        yield return new WaitForSeconds(2);
        _shipStats._currentHealth = _shipStats._maxHealth;
        transform.position = _startPos;
        UIManager.UpdateHealthBar(_shipStats._currentHealth);
    }



}
