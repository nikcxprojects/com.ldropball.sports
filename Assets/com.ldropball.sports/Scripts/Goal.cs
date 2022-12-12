using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private const float yOffset = 3.0f;
    public static Transform Parent { get; set; }

    public static Action<Transform> OnCompleted { get; set; }

    public void Instantiate()
    {
        Parent = GameObject.Find("goals").transform;
        int index = Parent.childCount;

        float xOffset = index % 2 == 0 ? -1.46f : 1.46f;

        Vector2 position = new Vector2(xOffset, index * yOffset);
        Quaternion rotation = Quaternion.Euler(xOffset < 0 ? Vector3.up * 180 : Vector3.zero);

        Instantiate(gameObject, position, rotation, Parent);
    }

    public void Destroy()
    {
        OnCompleted = null;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D()
    {
        OnCompleted?.Invoke(transform);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
