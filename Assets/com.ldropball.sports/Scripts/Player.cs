using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _camera;

    private bool IsPressing { get; set; }
    private Rigidbody2D Rigidbody { get; set; }
    private Vector2 Direction { get; set; }

    private const float force = 60;

    private void OnMouseDown()
    {
        IsPressing = true;
    }

    private void OnMouseDrag()
    {
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.angularVelocity = 0;
    }

    private void OnMouseUp()
    {
        IsPressing = false;
        Rigidbody.AddForce(Direction * force, ForceMode2D.Impulse);
    }

    private void Awake()
    {
        _camera = Camera.main;
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = new Vector2(0, -3);
    }

    private void Update()
    {
        if(Time.timeScale < 1 || !IsPressing)
        {
            return;
        }

        Direction = GetDirection();
    }

    Vector2 GetDirection()
    {
        return (_camera.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Vector2.Distance(transform.position, FindObjectOfType<CameraFollower>().transform.position) > 6)
        {
            GameManager.Instance.EndGame();
        }
    }
}
