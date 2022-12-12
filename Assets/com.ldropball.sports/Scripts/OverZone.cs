using UnityEngine;

public class OverZone : MonoBehaviour
{
    private void Awake()
    {
        Goal.OnCompleted += EventHandler;
    }

    private void OnDestroy()
    {
        Goal.OnCompleted -= EventHandler;
    }

    private void EventHandler(Transform refTransform)
    {
        transform.position = new Vector2(0, refTransform.position.y - 2);
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
