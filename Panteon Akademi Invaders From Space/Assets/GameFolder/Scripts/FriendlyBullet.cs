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
}
