using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipStats 
{
    [Range(1, 5)]
    public int _maxHealth;
    [HideInInspector]
    public int _currentHealth;
    [HideInInspector]
    public int _maxLifes = 3;
    [HideInInspector]
    public int _currentLifes = 3;

    public float _shipSpeed;
    public float _fireRate;
}
