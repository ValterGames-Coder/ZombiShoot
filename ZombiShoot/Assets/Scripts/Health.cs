using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health, numOfHeart;
    [SerializeField] private List<Image> _hearts;
    [SerializeField] private Sprite _fullHeart, _emptyHeart;
    [SerializeField] private GameObject _lose;
    [SerializeField] private Sprite _diedSprite;
    private bool _isDied;
    
    void Update()
    {
        if (health > numOfHeart) health = numOfHeart;
        for (int i = 0; i < _hearts.Count; i++)
        {
            if (i < Mathf.RoundToInt(health)) _hearts[i].sprite = _fullHeart;
            else _hearts[i].sprite = _emptyHeart;
        }

        if (health <= 0)
        {
            if (gameObject.name == "wall")
            {
                _lose.SetActive(true);
                Time.timeScale = 0;
            }
            else if (gameObject.layer == 7)
            {
                StartCoroutine(Died());

            }
            else Destroy(gameObject);
        }
    }

    private IEnumerator Died()
    {
        GetComponent<Enemy>()._speed = 0;
        GetComponent<AttackEnemy>()._damage = 0;
        GetComponent<Animator>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = _diedSprite;
        if(!_isDied) FindObjectOfType<ScoreController>().kill++;
        _isDied = true;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
