using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterPos : MonoBehaviour
{
    [SerializeField] float _bulletDeactivePos;

    void Update()
    {
        if (transform.position.y > _bulletDeactivePos || transform.position.y < -_bulletDeactivePos)
        {
            gameObject.SetActive(false);
        }
    }
}
