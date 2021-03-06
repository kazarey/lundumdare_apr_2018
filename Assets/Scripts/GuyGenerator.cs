﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GuyGenerator : MonoBehaviour
{
    public GameObject guyPrefab;

    public SkinColor prohibitedSkin { get; set; }
    public DressColor prohibitedDress { get; set; }

    void Awake()
    {
        RandomizeProhibited();
    }

    void RandomizeProhibited()
    {
        prohibitedSkin = (SkinColor)Random.Range(1.0f, 4.0f);
        prohibitedDress = (DressColor)Random.Range(1.0f, 7.0f);
        Debug.Log("Incorrect skin: " + prohibitedSkin);
        Debug.Log("Incorrect dress: " + prohibitedDress);

        Game.Instance.PrintGuiltyColors(prohibitedSkin.ToString(), prohibitedDress.ToString());
    }

    public GameObject Generate()
    {

        Appearance appearance = new Appearance();

        var guyObj = Instantiate(guyPrefab);
        var spritesList = guyObj.GetComponentsInChildren<SpriteRenderer>();
        foreach (var spriteComp in spritesList)
        {
            if (spriteComp.gameObject.name == "Body")
            {
                switch (appearance.Skin)
                {
                    case SkinColor.red:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/male_1");
                        break;
                    case SkinColor.yellow:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/male_2");
                        break;
                    case SkinColor.purple:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/male_3");
                        break;
                }
            }
            else if (spriteComp.gameObject.name == "Cloth")
            {
                switch (appearance.Dress)
                {
                    case DressColor.blue:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_toga_blue");
                        break;
                    case DressColor.green:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_toga_green");
                        break;
                    case DressColor.red:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_toga_red");
                        break;
                    case DressColor.yellow:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_toga_yellow");
                        break;
                    case DressColor.white:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_toga_white");
                        break;
                    case DressColor.black:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_toga_black");
                        break;
                }
            }
            else if (spriteComp.gameObject.name == "Trinket")
            {
                switch (appearance.Brooch)
                {
                    case BroochType.red:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/trinkets/trinket1_red_right");
                        break;
                    case BroochType.yellow:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/trinkets/trinket2_yellow_right");
                        break;
                }
            }
            else if (spriteComp.gameObject.name == "Pants")
            {
                switch (appearance.Pants)
                {
                    case PantsColor.black:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_pants_black");
                        break;
                    case PantsColor.blue:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_pants_blue");
                        break;
                    case PantsColor.green:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_pants_green");
                        break;
                    case PantsColor.red:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_pants_red");
                        break;
                    case PantsColor.white:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_pants_white");
                        break;
                    case PantsColor.yellow:
                        spriteComp.sprite = Resources.Load<Sprite>("Sprites/clothes/clothes_male_pants_yellow");
                        break;
                }
            }
        }
        var guy = guyObj.GetComponent<Guy>();
        guy.isGuilty = (appearance.Skin == prohibitedSkin) || (appearance.Dress == prohibitedDress);
        Debug.Log("Generated a guilty guy:" + guy.isGuilty);

        return guyObj;
    }
}
