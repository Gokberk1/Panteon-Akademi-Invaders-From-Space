using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] float _seconds;

    private void Start()
    {
        Destroy(gameObject,_seconds);
    }
}
