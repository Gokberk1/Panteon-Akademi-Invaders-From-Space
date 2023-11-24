using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float _fallSpeed;

    void Update()
    {
        transform.Translate(Vector2.down * _fallSpeed * Time.deltaTime);
    }

    public abstract void PickMeUp();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickMeUp();
        }
    }

}
