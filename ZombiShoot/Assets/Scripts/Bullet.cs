using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;

    void Start()
    {
        if(FindObjectOfType<ScoreController>().win || GameObject.Find("wall").GetComponent<Health>().health <= 0)
            damage = 1; speed = 6;
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Enemy"))
        {
            collision2D.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
