using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public static Transform Target { get; set; }

    private void LateUpdate()
    {
        if(!Target)
        {
            return;
        }

        if (Target.position.y > transform.position.y)
        {
            transform.position = new Vector3(0, Target.position.y, -10);
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(0, 0, -10);
    }
}
