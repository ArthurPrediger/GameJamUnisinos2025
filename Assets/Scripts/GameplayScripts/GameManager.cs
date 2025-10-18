using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SummonWerewolf();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ClearWerewolfs();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void SummonWerewolf()
    {
        players[Random.Range(0, players.Length)].GetComponent<PlayerManager>().ChangePlayerState(true);
    }
    void ClearWerewolfs()
    {
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerManager>().ChangePlayerState(false);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
