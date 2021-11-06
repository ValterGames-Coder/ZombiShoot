using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private Vector3 _mousePosition;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private GameObject _bullet;
    public float timeShoot;
    private float _startTimeShoot;
    [SerializeField] private AudioSource _shootAudio;
    
    void Start()
    {
        timeShoot = 1f;
        _startTimeShoot = timeShoot;
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = _mousePosition - transform.position;
        diff.Normalize();
        if (!FindObjectOfType<ScoreController>().stop)
        {
            Rotatiton(diff, 90);
        }

        if (Input.GetMouseButton(0) && _startTimeShoot <= 0)
        {
            Instantiate(_bullet, _shootPosition.position, transform.rotation);
            _shootAudio.Play();
            _startTimeShoot = timeShoot;
        }
        else
        {
            _startTimeShoot -= Time.deltaTime;
        }
    }

    private void Rotatiton(Vector3 diff, float rad)
    {
        if (transform.rotation.z < 80 || transform.rotation.z > -80)
        {
            float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - rad;
            transform.rotation = Quaternion.Euler(0, 0, rot);
        }
    }
}
