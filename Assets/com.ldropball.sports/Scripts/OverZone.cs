using UnityEngine;

public class OverZone : MonoBehaviour
{
    private void Awake()
    {
        Goal.OnCompleted += (goal) =>
        {
            transform.position = new Vector2(0, goal.position.y - 2);
        };
    }

    private void OnDestroy()
    {
        Goal.OnCompleted = null;
    }

    private void Start()
    {
        transform.position = new Vector2(0, -10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.EndGame();
    }
}
