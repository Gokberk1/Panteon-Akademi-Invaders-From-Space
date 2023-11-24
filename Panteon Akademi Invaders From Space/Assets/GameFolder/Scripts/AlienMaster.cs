using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;

    private Vector3 _hMoveDistance = new Vector3(0.05f, 0, 0);
    private Vector3 _vMoveDistance = new Vector3(0, 0.15f, 0);

    private const float MAX_LEFT = -3f;
    private const float MAX_RIGHT = 3f;

    public static List<GameObject> _allAliens = new List<GameObject>();

    private bool _movingRight;
    private bool _entering = true;

    private const float START_Y = -0.5f;

    private float _moveTimer = 0.01f;
    private float _moveTime = 0.005f;
    private const float MAX_MOVE_SPEED = 0.02f;

    private float _shootTimer = 3f;
    private const float _shootTime = 3f;


    [SerializeField] GameObject _motherShip;
    private Vector3 _motherShipSpawnPos = new Vector3(5, 4.5f, 0);
    private float _motherShipTimer = 5f;
    private const float MOTHERSHÝP_MÝN = 15f;
    private const float MOTHERSHÝP_MAX = 60f;



    void Start()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Alien"))
        {
            _allAliens.Add(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_entering)
        {
            transform.Translate(Vector2.down * 10 * Time.deltaTime);

            if(transform.position.y <= START_Y)
            {
                _entering = false;
            }
        }
        else
        {
            if (_moveTimer <= 0)
            {
                MoveEnemies();
            }
            if (_shootTimer <= 0)
            {
                Shoot();
            }
            if (_motherShipTimer <= 0)
            {
                SpawnMotherShip();
            }

            _moveTimer -= Time.deltaTime;
            _shootTimer -= Time.deltaTime;
            _motherShipTimer -= Time.deltaTime;
        }

        
    }

    private void MoveEnemies()
    {
        int hitMax = 0;

        if(_allAliens.Count > 0)
        {
            for (int i = 0; i < _allAliens.Count; i++)
            {
                if (_movingRight)
                {
                    _allAliens[i].transform.position += _hMoveDistance;
                }
                else
                {
                    _allAliens[i].transform.position -= _hMoveDistance;
                }
                if(_allAliens[i].transform.position.x > MAX_RIGHT || _allAliens[i].transform.position.x < MAX_LEFT)
                {
                    hitMax++;
                }
            }
            if(hitMax > 0)
            {
                for (int i = 0; i < _allAliens.Count; i++)
                {
                    _allAliens[i].transform.position -= _vMoveDistance;
                }
                _movingRight = !_movingRight;
            }
            _moveTimer = GetMoveSpeed();
        }
    }

    private float GetMoveSpeed()
    {
        float f = _allAliens.Count * _moveTime;

        if (f < MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        else
        {
            return f;
        }
    }

    private void Shoot()
    {
        Vector2 pos = _allAliens[Random.Range(0, _allAliens.Count)].transform.position;

        //Instantiate(_bulletPrefab, pos, Quaternion.identity);
        GameObject obj = _objectPool.GetPooledObject();
        obj.transform.position = pos;

        _shootTimer = _shootTime;
    }

    private void SpawnMotherShip()
    {
        Instantiate(_motherShip, _motherShipSpawnPos, Quaternion.identity);
        _motherShipTimer = Random.Range(MOTHERSHÝP_MÝN, MOTHERSHÝP_MAX);
    }

}
