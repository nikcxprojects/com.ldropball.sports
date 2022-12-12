using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _camera;


    private bool IsPressing { get; set; }
    private Rigidbody2D Rigidbody { get; set; }
    private Vector2 Direction { get; set; }

    [SerializeField] float force;

    private void OnMouseDown()
    {
        IsPressing = true;
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
}
