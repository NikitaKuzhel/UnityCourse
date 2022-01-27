using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    [SerializeField] private GameObject[] _characterPrefab;
    [SerializeField] private Transform _spawnPoint;

    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = _characterPrefab[selectedCharacter];
        Instantiate(prefab, _spawnPoint.position, Quaternion.identity);
    }
}
