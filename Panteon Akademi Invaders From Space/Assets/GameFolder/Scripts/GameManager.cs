using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] _allAlienSets;
    private GameObject _currentSet;
    private Vector2 _spawnPos = new Vector2(0, 10);

    public static GameManager _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnNewWave();
    }

    public static void SpawnNewWave()
    {
        _instance.StartCoroutine(_instance.SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        if(_currentSet != null)
        {
            Destroy(_currentSet);
        }
        yield return new WaitForSeconds(3);

        _currentSet = Instantiate(_allAlienSets[Random.Range(0, _allAlienSets.Length)], _spawnPos, Quaternion.identity);
        UIManager.UpdateWave();
    }
}
