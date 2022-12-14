using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private const int goalCount = 50;

    private Player PlayerPrefab { get; set; }
    private Goal GoalPrefab { get; set; }
    private OverZone OverZonePrefab { get; set; }
    private Transform EnvironmentRef { get; set; }


    private void Awake()
    {
        PlayerPrefab = Resources.Load<Player>("player");
        GoalPrefab = Resources.Load<Goal>("goal");
        OverZonePrefab = Resources.Load<OverZone>("over zone");

        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    private void DeleteLastObjects()
    {
        if (!FindObjectOfType<Player>())
        {
            return;
        }

        Destroy(FindObjectOfType<Player>().gameObject);
        Destroy(FindObjectOfType<OverZone>().gameObject);

        Goal[] goals = FindObjectsOfType<Goal>();
        foreach (Goal g in goals)
        {
            g.Destroy();
        }

        Goal.Parent.DetachChildren();
    }

    private void CreateGoals()
    {
        for (int i = 0; i < goalCount; i++)
        {
            GoalPrefab.Instantiate();
        }
    }

    public void StartGame()
    {
        DeleteLastObjects();
        FindObjectOfType<CameraFollower>().Reset();

        CameraFollower.Target = Instantiate(PlayerPrefab, EnvironmentRef).transform;
        Instantiate(OverZonePrefab, EnvironmentRef);

        CreateGoals();
    }

    public void EndGame()
    {
        DeleteLastObjects();
        UIManager.Instance.OpenWindow(5);
    }
}