using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public int _damage;
    [SerializeField] private float _radius, _timeAttack;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private LayerMask _wallLayer;
    private float _startTimeAttack;
    private Collider2D _zone;
    
    void Update()
    {
        _zone = Physics2D.OverlapCircle(_attackPosition.position, _radius, _wallLayer);
        if (_startTimeAttack <= 0)
        {
            if (_zone != null && !FindObjectOfType<ScoreController>().stop)
            {
                _zone.GetComponent<Health>().TakeDamage(_damage);
                _startTimeAttack = _timeAttack;
            }
        }
        else
        {
            _startTimeAttack -= Time.deltaTime;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPosition.position, _radius);
    }
}
