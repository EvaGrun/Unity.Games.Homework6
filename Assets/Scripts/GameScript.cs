using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameScript : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI time;
    private float timeStart = 30;

    private int wind = 7;
    private int flame = 1;
    private int dawn = 7;

    [SerializeField] private TextMeshProUGUI windText;
    [SerializeField] private TextMeshProUGUI flameText;
    [SerializeField] private TextMeshProUGUI dawnText;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject timeOutPanel;

    [SerializeField] private AudioSource win;
    private SpritsChange spritsChange;

    void Update()
    {
        timeStart -= Time.deltaTime;
        if (timeStart <= 0)
        {
            timeOutPanel.SetActive(true);
        }
        time.text = Mathf.Round(timeStart).ToString();

    }

    public void StartGame()
    {
        timeStart = 30;
        this.enabled = true;
        mainPanel.SetActive(true);
        startPanel.SetActive(false);
    }


    private void Win(int wind, int flame, int dawn)
    {
        if (wind == 5 && flame == 5 && dawn == 5)
        {
            win.Play();
            winPanel.SetActive(true);
            this.enabled = false;
            time.text = "0";
        }
    }


    public void Wind()
    {
        wind -= 2;
        if (wind < 0) wind = 0;
        flame += 2;
        if (flame > 10) flame = 10;
        Win(wind, flame, dawn);
        //spritsChange.ChangeSprite(wind, flame, dawn);
        ChangeSprite(wind, flame, dawn);
        windText.text = wind.ToString() + "0%";
        flameText.text = flame.ToString() + "0%";
    }

    public void Flame()
    {
        wind += 2;
        if (wind > 10) wind = 10;
        dawn -= 2;
        if (dawn < 0) dawn = 0;
        Win(wind, flame, dawn);
        ChangeSprite(wind, flame, dawn);
        windText.text = wind.ToString() +"0%";
        dawnText.text = dawn.ToString() + "0%";
    }

    public void Dawn()
    {
        flame -= 2;
        if (flame < 0) flame = 0;
        dawn += 2;
        if (dawn > 10) dawn = 10;
        Win(wind, flame, dawn);
        ChangeSprite(wind, flame, dawn);
        flameText.text = flame.ToString() + "0%";
        dawnText.text = dawn.ToString() + "0%";
    }

    public void ReStart()
    {
        wind = 7;
        flame = 1;
        dawn = 7;
        windText.text = "70%";
        flameText.text = "10%";
        dawnText.text = "70%";
        ChangeSprite(wind, flame, dawn);
    }

    public void Exit()
    {
        Application.Quit();
    }


    /// <summary>
    /// Вопрос. то, что ниже, я перенесла из класса Sprite.Change
    /// хотела, чтоб это было два разных сркипта, но не получилось сделать так, чтоб заработало =) В чем ошибка?
    /// </summary>
    [SerializeField] private Sprite[] windSprites;
    [SerializeField] private Sprite[] flameSprites;
    [SerializeField] private Sprite[] dawnSprites;

    [SerializeField] private Image windImage;
    [SerializeField] private Image flameImage;
    [SerializeField] private Image dawnImage;


    public void ChangeSprite(int wind, int flame, int dawn)
    {
        if (wind < 1) wind = 1;
        if (flame < 1) flame = 1;
        if (dawn < 1) dawn = 1;
        windImage.sprite = windSprites[wind - 1];
        flameImage.sprite = flameSprites[flame - 1];
        dawnImage.sprite = dawnSprites[dawn - 1];
    }

}
