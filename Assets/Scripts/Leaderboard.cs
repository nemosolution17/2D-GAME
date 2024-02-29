using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public string level;
    private int score;
    private float time;
    public string newLevel;
    private List<leaderBoard> SortedScoreList = new List<leaderBoard>();
    private List<leaderBoard> SortedTimeList = new List<leaderBoard>();
    public Text[] PlayerNameScore;
    public Text[] PlayerScore;
    public Text[] PlayerNameTime;
    public Text[] PlayerTime;
    // Start is called before the first frame update
    void Start()
    {
        string[][] input = File.ReadAllLines(@"C:\Users\1997g\Desktop\Master\Leaderboard\" + level + ".txt").Select(x => x.Split(' ')).ToArray();
        
        for (int i = 0; i < input.Length; i++)
        {
            leaderBoard lScores = new leaderBoard();
            lScores.PlayerName = input[i][0];
            lScores.Score = Int32.Parse(input[i][1]);
            lScores.Time = float.Parse(input[i][2], CultureInfo.InvariantCulture.NumberFormat);
            SortedScoreList.Add(lScores);
            SortedTimeList.Add(lScores);
        }
        SortedScoreList = SortedScoreList.OrderByDescending(entry => entry.Score).ToList();
        SortedTimeList = SortedTimeList.OrderBy(entry => entry.Time).ToList();

        for (int i = 0; i < 10 && i < input.Length; i++)
        {
            PlayerNameScore[i].text = SortedScoreList[i].PlayerName;
            PlayerScore[i].text = SortedScoreList[i].Score.ToString();
            PlayerNameTime[i].text = SortedTimeList[i].PlayerName;
            string minutes = ((int)SortedTimeList[i].Time / 60).ToString();
            string seconds = (SortedTimeList[i].Time % 60).ToString("f2");
            PlayerTime[i].text = minutes + ":" + seconds;
        }

    }
    public void NextLevel()
    {
        SceneManager.LoadScene(newLevel);
    }
    public void ReturnToLeaderboard()
    {
        SceneManager.LoadScene(5);
    }

}

public class leaderBoard
{
    public string PlayerName { get; set; }
    public int Score { get; set; }
    public float Time { get; set; }
}