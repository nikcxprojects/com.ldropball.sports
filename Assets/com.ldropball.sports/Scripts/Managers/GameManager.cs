using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private const int goalCount = 50;

    private Player PlayerPrefab { get; set; }
    private Goal GoalPrefab { get; set; }
    private Transform EnvironmentRef { get; set; }


    private void Awake()
    {
        PlayerPrefab = Resources.Load<Player>("player");
        GoalPrefab = Resources.Load<Goal>("goal");

        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    private void Start()
    {
        //Block.OnCollisionEnter += () =>
        //{
        //    var hit = Instantiate(Resources.Load<AudioSource>("hit"));
        //    hit.mute = GameObject.Find("SFX Source").GetComponent<AudioSource>().mute;

        //    if(SettingsManager.VibraEnable)
        //    {
        //        Handheld.Vibrate();
        //    }
        //};
    }

    private void DeleteLastObjects()
    {
        if (!FindObjectOfType<Player>())
        {
            return;
        }

        Destroy(FindObjectOfType<Player>().gameObject);

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
        CreateGoals();
    }

    public void EndGame()
    {
        DeleteLastObjects();
        UIManager.Instance.OpenWindow(5);
    }
}