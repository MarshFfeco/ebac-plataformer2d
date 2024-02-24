using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MenuButtonsManager : MonoBehaviour
{
    [Header("Ui Buttons")]
    public List<GameObject> buttons;

    [Header("Animation")]
    public float duration = .5f;
    public float delay = .03f;

    private void Awake()
    {
        HideAllButtons();
        ShowButtons();
    }

    private void HideAllButtons()
    {
        for (byte i = 0; i < buttons.Count; i++)
        {
            buttons[i].transform.localScale = Vector3.zero;
            buttons[i].SetActive(false);
        }
    }

    private void ShowButtons()
    {
        for (byte i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetActive(true);
            buttons[i].transform.DOScale(1, duration).SetDelay(i * delay).SetEase(Ease.OutBack);
        }
    }
}
