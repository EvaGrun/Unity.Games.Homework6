using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritsChange : MonoBehaviour
{
    [SerializeField] private Sprite[] windSprites;
    [SerializeField] private Sprite[] flameSprites;
    [SerializeField] private Sprite[] dawnSprites;

    [SerializeField] private Image windImage;
    [SerializeField] private Image flameImage;
    [SerializeField] private Image dawnImage;

    //private GameScript gameScript;

    public void ChangeSprite(int wind, int flame, int dawn)
    {
        if (wind < 1) wind = 1;
        else if (flame < 1) flame = 1;
        else if (dawn < 1) dawn = 1;
        windImage.sprite = windSprites[wind - 1];
        flameImage.sprite = flameSprites[flame - 1];
        dawnImage.sprite = dawnSprites[dawn - 1];
    }
}
