using UnityEngine;
using TMPro;
using System;
public class GameLogic : MonoBehaviour
{
    public int score;
    private int startTime;
    [SerializeField]private PlayerController player;
    [SerializeField] private AuthManager AuthManager;
    [SerializeField] GameObject PanelRestart;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI userNameText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnEnable()
    {
        startTime = Convert.ToInt32(Time.time);
        player.gameObject.SetActive(true);
        finalScoreText.text = "";
        scoreText.text = "Puntos: 0";
        
        userNameText.text = AuthManager.credentials.username;
        PanelRestart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.IsAlive)
        {
            score = Convert.ToInt32(Time.time -startTime);
            UpdateScore(score);
        }
        else
        {
            SendScore();
        }
    }
    public void GetUserNameUI(string userName)
    {
        userNameText.text = userName;
    }
    public void UpdateScore(float timeSurvived)
    {
        string formattedScore = timeSurvived.ToString("F2");
        scoreText.text = $"Puntos: {score}";
        //Debug.Log($"Puntaje: {score}");
    }
    public void SendScore()
    {
        AuthManager.UpdateData(score);
        PanelRestart.SetActive(true);
        scoreText.text = "";
        finalScoreText.text = $"Puntos: {score}";
        gameObject.SetActive(false);

        
    }
}
