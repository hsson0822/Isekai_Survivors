using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using System.Threading;
using static Unity.VisualScripting.Member;

public class GameManager : SingletonManager<GameManager>
{
    private bool isLoading;
    //private bool isPause;
    private float playtime;

    public PlayingUI playingUI;
    public PauseUI pauseUI;

    private CancellationTokenSource source;

    private void Start()
    {
        source = new CancellationTokenSource();

        isLoading = false;
        //isPause = false;

        playtime = 0.0f;
        playingUI.timer.text = "00:00";

        playingUI.pauseButton.onClick.AddListener(() => { PauseGame(); });
        TimerCheck().Forget();

        pauseUI.resumeButton.onClick.AddListener(() => { ResumeGame(); });
        pauseUI.backToMenuButton.onClick.AddListener(() => { BackToMenu(); });

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isLoading = true;
            Debug.Log("Start");
        }
    }

    private void PauseGame()
    {
        pauseUI.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        pauseUI.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
    }

    private void BackToMenu()
    {
        source?.Cancel();
        SceneManager.LoadScene(0);
    }

    async UniTaskVoid TimerCheck()
    {

        while (true)
        {
            await UniTask.WaitUntil(() => isLoading);
            //await UniTask.WaitUntil(() => !isPause);

            playtime += Time.deltaTime;

            int min = (int)playtime / 60;
            int sec = (int)playtime % 60;

            playingUI.timer.text = min + ":" + sec;
        }
    }
}
