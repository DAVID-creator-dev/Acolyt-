using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [HideInInspector] public List<WordDataScriptable> wordDataScriptables = new List<WordDataScriptable>(); 

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        wordDataScriptables = Resources.LoadAll<WordDataScriptable>("ScriptableObjects").ToList();
    }
}