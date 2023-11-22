using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    private const float _maxX = 4f;
    private const float _minX = -4f;
    private float _speed = 3;
    private float _cooldown = 0.5f;
    private bool _isShooting;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > _minX)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < _maxX)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space) && !_isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        _isShooting = true;
        //Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        GameObject obj = _objectPool.GetPooledObject();
        obj.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(_cooldown);
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

    }



}
