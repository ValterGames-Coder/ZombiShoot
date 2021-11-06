using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed;

    void FixedUpdate()
    {
        if(!FindObjectOfType<ScoreController>().stop)
            transform.Translate(Vector2.down *_speed * Time.deltaTime);
    }
}
