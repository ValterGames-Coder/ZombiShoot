using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomForce : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private List<string> _texts;
    [SerializeField] private Image _imageUpgrade;
    [SerializeField] private Text _textUpgrade;
    [SerializeField] private GameObject[] _upgradeButton;
    [SerializeField] private int _indexUpgrade;
    [SerializeField] private GunController _gunController;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private List<int> _waves;
    private ScoreController _score;

    void Start()
    {
        _score = FindObjectOfType<ScoreController>();
    }

    void Update()
    {
        if (_score.kill != 0 && _score.stop == false)
        {
            for (int i = 0; i < _waves.Count; i++)
            {
                if (_waves[i] == _score.kill)
                {
                    _gameObject.SetActive(true);
                    StartCoroutine(Casino());
                    _score.stop = true;
                }
            }
        }
    }
    

    public IEnumerator Casino()
    {
        _waves.Remove(_waves[0]);
        int random = 0;
        for (int i = 0; i < 20; i++)
        {
        	random = Random.Range(0, _sprites.Count);
                _imageUpgrade.sprite = _sprites[random];
                _textUpgrade.text = _texts[random];
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
        }
        _indexUpgrade = random;
        _imageUpgrade.sprite = _sprites[_indexUpgrade];
        _textUpgrade.text = _texts[_indexUpgrade];
        _upgradeButton[_indexUpgrade].SetActive(true);
    }
    public void UpHealth()
    {
        if(_health.health < 5)
            _health.health++;
    }

    public void UpRealoding()
    {
        _gunController.timeShoot -= 0.2f;
        _bullet.speed += 0.2f;
    }

    public void UpDamage()
    {
        if(_bullet.damage < 3)
            _bullet.damage++;
    }
    public void Stop()
    {
        _score.stop = false;
        for (int i = 0; i < 3; i++)
        {
            _upgradeButton[i].SetActive(false);
        } 
        _gameObject.SetActive(false);
    }
}
