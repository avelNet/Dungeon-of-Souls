using Assets.Scripts.Core;
using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private string _targetSpawnID;
    [SerializeField] private string _targetScene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(GameManager.Instance ==  null) { return; }
            GameManager.Instance.NextSpawnID = _targetSpawnID;
            SceneManager.LoadScene(_targetScene);
        }
    }
}