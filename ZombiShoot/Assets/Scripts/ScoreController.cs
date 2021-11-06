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
        _force = FindObjectOfType<RandomForce>();
    }
    
    void Update()
    {
        if (kill >= 50)
        {
            win = true;
            _win.SetActive(true);
            Time.timeScale = 0;
        }
        _scoreText.text = kill.ToString();
    }
}
