using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    
    [SerializeField] private AudioClip audio;
    [SerializeField] private string sceneName;
    [SerializeField] private Text score;
    public void LoadingScene()
    {
        
        Application.LoadLevel(sceneName); // goi scene khac
        ScoreManager.score = 0f; // reset diem
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "score: " + ((int)ScoreManager.score).ToString();
    }
}
