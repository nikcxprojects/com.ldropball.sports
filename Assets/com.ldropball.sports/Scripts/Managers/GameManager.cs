using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private Player PlayerPrefab { get; set; }
    private Transform EnvironmentRef { get; set; }


    private void Awake()
    {
        PlayerPrefab = Resources.Load<Player>("player");
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

    public void StartGame()
    {
        Instantiate(PlayerPrefab, EnvironmentRef);
    }

    public void EndGame()
    {
        if (FindObjectOfType<Player>())
        {
            Destroy(FindObjectOfType<Player>().gameObject);
        }

        UIManager.Instance.OpenWindow(5);
    }
}