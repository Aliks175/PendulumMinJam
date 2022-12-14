using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeGame : MonoBehaviour
{
    [SerializeField] private float _maxtime;
    [SerializeField] private Image _image;
    private float timeCurtailImage;
    private int lastTimeGame;
    private bool isPlay;
    public static event Action<int> OnTime;

    private void OnEnable()
    {
        RestartGameV2.NextGame += TranslateTime;
        ControlSpawnV2.OnStart += OnPlay;
        RestartGameV2.NextGame += RestartTime;
        RestartGameV2.NextGame += OnPlay;
    }

    private void OnDisable()
    {
        RestartGameV2.NextGame -= TranslateTime;
        ControlSpawnV2.OnStart -= OnPlay;
        RestartGameV2.NextGame -= RestartTime;
        RestartGameV2.NextGame -= OnPlay;
    }


    private void Start()
    {
        RestartTime();
    }

    private void TranslateTime()
    {
        OnTime?.Invoke(ResultTime());
    }

    private void RestartTime()
    {
        _image.fillAmount = 0;
        timeCurtailImage = 0;
    }

    private void Update()
    {
        if (isPlay)
        {
            if (timeCurtailImage > _maxtime)
            {
                GameOverV2.EndTime();
            }
            else
            {
                CurtailImage();
            }
        }
    }

    private int ResultTime()
    {
        return (lastTimeGame);
    }

    private void CurtailImage()
    {
        timeCurtailImage += Time.deltaTime;
        lastTimeGame = (int)(_maxtime - timeCurtailImage);
        _image.fillAmount = timeCurtailImage / _maxtime;
    }

    public void OnPlay()
    {
        isPlay = !isPlay;
    }
}
