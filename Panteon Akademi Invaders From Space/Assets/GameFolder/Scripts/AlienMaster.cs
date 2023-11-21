using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    private Vector3 _hMoveDistance = new Vector3(0.05f, 0, 0);
    private Vector3 _vMoveDistance = new Vector3(0, 0.15f, 0);

    private const float MAX_LEFT = -3f;
    private const float MAX_RIGHT = 3f;

    public static List<GameObject> _allAliens = new List<GameObject>();

    private bool _movingRight;

    private float _moveTimer = 0.01f;
    private float _moveTime = 0.005f;

    private const float MAX_MOVE_SPEED = 0.02f;

    // Start is called before the first frame update
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
        if(_moveTimer <= 0)
        {
            MoveEnemies();
        }
        _moveTimer -= Time.deltaTime;
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
}
