using System;
using System.Collections;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endGameManager;
    public bool isGameOver = false;

    PanelController panelController;
    private void Awake()
    {
        if (endGameManager == null)
        {
            endGameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartResolveSequence()
    {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }

    IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2f);
        ResolveGame();
    }

    public void ResolveGame()
    {
        if (isGameOver == false)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        panelController.ActivateWinScreen();
    }

    public void LoseGame()
    {
        panelController.ActivateLoseScreen();
    }

    public void RegisterPanelController(PanelController _panelController)
    {
        panelController = _panelController;
    }
}
