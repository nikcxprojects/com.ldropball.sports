using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Sprite offSprite;
    [SerializeField] Sprite onSprite;

    [Space(10)]
    [SerializeField] AudioSource loop;
    [SerializeField] Button soundBtn;

    [Space(10)]
    [SerializeField] AudioSource sfx;
    [SerializeField] Button sfxBtn;

    [Space(10)]
    [SerializeField] Button vibroBtn;

    public static bool VibraEnable { get; set; } = false;

    private void Start()
    {
        loop.mute = sfx.mute = true;

        soundBtn.onClick.AddListener(() =>
        {
            loop.mute = !loop.mute;

            Sprite status = loop.mute ? offSprite : onSprite;
            soundBtn.GetComponent<Image>().sprite = status;
        });


        sfxBtn.onClick.AddListener(() =>
        {
            sfx.mute = !sfx.mute;

            Sprite status = sfx.mute ? offSprite : onSprite;
            sfxBtn.GetComponent<Image>().sprite = status;
        });

        vibroBtn.onClick.AddListener(() =>
        {
            VibraEnable = !VibraEnable;

            Sprite status = VibraEnable ?  onSprite : offSprite;
            vibroBtn.GetComponent<Image>().sprite = status;
        });

        soundBtn.onClick.Invoke();
        sfxBtn.onClick.Invoke();
        vibroBtn.onClick.Invoke();
    }
}
