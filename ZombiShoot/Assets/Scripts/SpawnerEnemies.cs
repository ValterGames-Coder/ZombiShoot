using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private List<int> _varenemies;
    [SerializeField] private float _borderHorizontal;
    [SerializeField, Range(0, 100)] private float _timeSpawn;
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int random = Random.Range(0, _enemies.Count);
        Vector2 spawn = new Vector2(Random.Range(_borderHorizontal, -_borderHorizontal), 6f);
        int randomvar = Random.Range(0, 100);
        if(!FindObjectOfType<ScoreController>().stop && _varenemies[random] >= randomvar) Instantiate(_enemies[random], spawn, Quaternion.identity);
        yield return new WaitForSeconds(_timeSpawn);
        StartCoroutine(Spawn());
    }
}
