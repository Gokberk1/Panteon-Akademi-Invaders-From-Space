using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] int _score;
    [SerializeField] GameObject _explosion;
    [SerializeField] GameObject _coinPrefab;
    [SerializeField] GameObject _lifePrefab;
    [SerializeField] GameObject _healthPrefab;

    private const int LIFE_CHANCE = 50;
    private const int HEALTH_CHANCE = 100;
    private const int COIN_CHANCE = 250;


    public void Kill()
    {
        UIManager.UpdateScore(_score);
        AlienMaster._allAliens.Remove(gameObject);
        Instantiate(_explosion, transform.position, Quaternion.identity);

        int ran = Random.Range(0, 1000);

        if(ran <= LIFE_CHANCE)
        {
            Instantiate(_lifePrefab, transform.position, Quaternion.identity);
        }
        else if(ran <= HEALTH_CHANCE)
        {
            Instantiate(_healthPrefab, transform.position, Quaternion.identity);
        }
        else if(ran <= COIN_CHANCE)
        {
            Instantiate(_coinPrefab, transform.position, Quaternion.identity);
        }

        if (AlienMaster._allAliens.Count == 0)
        {
            GameManager.SpawnNewWave();
        }

        gameObject.SetActive(false);
    }
}
