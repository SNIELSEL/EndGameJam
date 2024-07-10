using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderBoardHeightAdjuster : MonoBehaviour
{
    public GameObject[] rows;

    public void AdjustHeight()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        rows = GameObject.FindGameObjectsWithTag("Row");

        switch (rows.Length)
        {
            case 0:
                break;
            case 1:
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x,72);
                break;
            case 2:
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 173);
                break;
            case 3:
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 325);
                break;
            case 4:
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 435);
                break;
            case 5:
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 540);
                break;
            case 6:
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 650);
                break;
            case 7:
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 740);
                break;
            case 8:
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 850);
                break;
            case 9:
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 1000);
                break;
            case 10:
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 1111);
                break;
            default:
                break;
        }
    }
}
