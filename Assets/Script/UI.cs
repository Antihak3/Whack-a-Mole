using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text blowsText;
    public int blows;
    public Text CoinsText;
    public int Coins;

    public GameObject PauseScreen;
    public GameObject GameOv;

    private void Update()
    {
        blowsText.text = blows.ToString();
        CoinsText.text = Coins.ToString();

        if (Coins <= 0)
        {
            Coins = 0;
            GameOver();
        }
    }

    public void ReloadLvl()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOv.SetActive(true);
    }

    public void PauseOn()
    {
        Time.timeScale = 0f;
        PauseScreen.SetActive(true);
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
        PauseScreen.SetActive(false);
    }

}
