using UnityEngine;
using UnityEngine.UI;

public class TimeGame : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _maxtime;
    [SerializeField] private Image image;
    private float timeCurtailImage;
    private float time;
    private bool isPlay;

    private void OnEnable()
    {
        WinGame.OnWin += OnPlay;
        GameOver.OnGameOver += OnPlay;
        GameOver.OnGameOver += End;
        RestartGame.NextGame += RestartTime;
        RestartGame.NextGame += OnPlay;
    }

    private void OnDisable()
    {
        WinGame.OnWin -= OnPlay;
        GameOver.OnGameOver -= OnPlay;
        GameOver.OnGameOver -= End;
        RestartGame.NextGame -= RestartTime;
        RestartGame.NextGame -= OnPlay;
    }

    void Start()
    {
        RestartTime();
    }

    private void RestartTime()
    {
        image.fillAmount = 0;
        timeCurtailImage = 0;
        time = _maxtime;
        _text.text = time.ToString();
    }

    private void Update()
    {
        if (isPlay)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                _text.text = Mathf.Round(time).ToString();
                CurtailImage();
            }
            else
            {
                GameOver.EndTime();
            }
        }
    }

    private void CurtailImage()
    {
        timeCurtailImage += Time.deltaTime;
        image.fillAmount = timeCurtailImage / _maxtime;
    }

    private void End()
    {
        image.fillAmount = 0;
    }

    public void OnPlay()
    {
        isPlay = !isPlay;
    }
}
