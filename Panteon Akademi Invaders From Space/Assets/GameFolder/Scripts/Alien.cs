using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] int _score;
    [SerializeField] GameObject _explosion;
    public void Kill()
    {
        AlienMaster._allAliens.Remove(gameObject);
        Instantiate(_explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
