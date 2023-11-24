using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    [SerializeField] TextMeshProUGUI _scoreTxt;
    [SerializeField] TextMeshProUGUI _highScoreTxt;
    [SerializeField] TextMeshProUGUI _coinTxt;
    [SerializeField] TextMeshProUGUI _waveTxt;

    int _score;
    int _highScore;
    int _wave;

    [SerializeField] Image[] _lifeSprites;
    [SerializeField] Sprite[] _healthBars;
    [SerializeField] Image _healthBar;

    private Color32 _active = new Color(1, 1, 1, 1);
    private Color32 _inactive = new Color(1, 1, 1, 0.25f);


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

    public static void UpdateLives(int l)
    {
        foreach (Image i in _instance._lifeSprites)
        {
            i.color = _instance._inactive;
        }
        for (int i = 0; i < l; i++)
        {
            _instance._lifeSprites[i].color = _instance._active;
        }
    }

    public static void UpdateHealthBar(int h)
    {
        _instance._healthBar.sprite = _instance._healthBars[h];
    }

    public static void UpdateScore(int s)
    {
        _instance._score += s;
        _instance._scoreTxt.text = _instance._score.ToString("000,000");
    }

    public static void UpdateHighScore()
    {

    }

    public static void UpdateWave()
    {
        _instance._wave++;
        _instance._waveTxt.text = _instance._wave.ToString();
    }

    public static void UpdateCoins()
    {
        _instance._coinTxt.text = Inventory._currentCoins.ToString();
    }
}
