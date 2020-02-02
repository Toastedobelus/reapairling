using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class Global
{
    public static int PlayerCount { get; set; }
    public static string EndGame { get; set; }
}

public class MainMenu : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;

    public GameObject numPlayers;

    private bool isEnteringPlayerCount = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        if (isStart)
        {
            numPlayers.SetActive(isEnteringPlayerCount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnteringPlayerCount && Input.GetKeyDown(KeyCode.Return))
        {
            InputField input = numPlayers.GetComponent<InputField>();
            int val = int.Parse(input.text);
            if (val >= 1 && val <= 4)
            {
                Global.PlayerCount = val;
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
        }
    }

    void OnMouseUp()
    {
        if (isStart)
        {
            isEnteringPlayerCount = true;
            numPlayers.SetActive(isEnteringPlayerCount);
        }
        if (isQuit)
        {
            Application.Quit();
        }
    }
}
