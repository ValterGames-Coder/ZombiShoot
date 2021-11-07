using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private GameObject _win;
    public bool win;
    public int kill;
    [SerializeField] private Text _scoreText;
    [SerializeField] private RandomForce _force;
    [SerializeField] private GameObject _forceGameObject;
    public bool stop;

    void Start()
    {
        if(PlayerPrefs.HasKey("BulletDamage") == false) PlayerPrefs.SetInt("BulletDamage", 1);
        if(PlayerPrefs.HasKey("BulletSpeed") == false) PlayerPrefs.SetFloat("BulletSpeed", 5);
        stop = false;
        Time.timeScale = 1;
        _force = FindObjectOfType<RandomForce>();
    }
    
    void Update()
    {
        if (kill >= 50)
        {
            win = true;
            PlayerPrefs.SetInt("BulletDamage", 1);
            PlayerPrefs.SetFloat("BulletSpeed", 5);
            _win.SetActive(true);
            Time.timeScale = 0;
        }
        _scoreText.text = kill.ToString();
    }
}
