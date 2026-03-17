using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private float timer;

    [SerializeField] private float possibleWinTime;

    [SerializeField] private GameObject[] spawners;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= possibleWinTime)
        {
            foreach (var spawner in spawners)
            {
                spawner.SetActive(false);
            }
            EndGameManager.endGameManager.StartResolveSequence();
            gameObject.SetActive(false);
        }
    }
}
