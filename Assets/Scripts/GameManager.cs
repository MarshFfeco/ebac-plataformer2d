using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Ebac.Core.Singleton;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject Player;

    [Header("Enemies")]
    public List<GameObject> Enemies;

    [Header("References")]
    public Transform startPoint;

    [Header("Animation")]
    public float duration = .5f;
    public float delay = .03f;

    private GameObject _currentPlayer;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(Player);
        _currentPlayer.transform.position = startPoint.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(Ease.OutBack).From();
    }
}
