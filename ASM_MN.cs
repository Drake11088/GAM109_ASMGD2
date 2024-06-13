using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Threading;
using UnityEditor.Animations;
using UnityEngine.UIElements;
using UnityEngine.Experimental.GlobalIllumination;
using System;
using Unity.VisualScripting;

public class ASM_MN : Singleton<ASM_MN>
{
    public List<Region> listRegion = new List<Region>();
    public List<Players> listPlayer = new List<Players>();
    public int currentPlayerId = 1;

    private void Start()
    {
        createRegion();
    }

    public void createRegion()
    {
        listRegion.Add(new Region(0, "VN"));
        listRegion.Add(new Region(1, "VN1"));
        listRegion.Add(new Region(2, "VN2"));
        listRegion.Add(new Region(3, "JS"));
        listRegion.Add(new Region(4, "VS"));
    }

    public void YC1()
    {

        string name = ScoreKeeper.Instance.GetUserName();
        int id = ScoreKeeper.Instance.GetID();
        int score = ScoreKeeper.Instance.GetScore();
        int idR = ScoreKeeper.Instance.GetIDregion();
        string regionName = "VN";
        if (idR == 0)
        {
            regionName = name;
        }
        else if (idR == 1)
        {
            regionName = name;
        }

        Players player = new Players(id = 1, "Player1", score = 60, new Region(1, "VN1"))
        {
            Rank = CalculateRank(score)
        };
        listPlayer.Add(player);
        Players player2 = new Players(id = 2, "Player2", score = 300, new Region(2, "VN2"))
        {
            Rank = CalculateRank(score)
        };
        listPlayer.Add(player2);
        Region playerRegion1 = new Region(idR, regionName);
        Players player3 = new Players(id = 3, "Player3", score = 600, playerRegion1)
        {
            Rank = CalculateRank(score)
        };
        listPlayer.Add(player3);
    }
    public string CalculateRank(int score)
    {
        if (score < 100)
            return "Hạng đồng";
        if (score < 500)
            return "Bạc";
        if (score < 1000)
            return "Vàng";
        return "Kim cương";
    }
    public void YC2()
    {
        // sinh viên viết tiếp code ở đây
        foreach (var player in listPlayer)
        {
            Debug.Log($"Id: {player.Id}, Name: {player.Name}, Score: {player.Score}, Region: {player.PlayerRegion}, Rank: {player.Rank}");
        }
    }
    public void YC3()
    {
        // sinh viên viết tiếp code ở đây
        int currentPlayerScore = 250; 
        var lowerScorePlayers = listPlayer.Where(p => p.Score < currentPlayerScore);
        foreach (var player in lowerScorePlayers)
        {
            Debug.Log($" các Player có score bé hơn score hiện tại của người chơi là : Id: {player.Id}, Name: {player.Name}, Score: {player.Score}, Region: {player.PlayerRegion}, Rank: {player.Rank}");
        }
    }
    public void YC4()
    {
        // sinh viên viết tiếp code ở đây

        var player = listPlayer.FirstOrDefault(p => p.Id == currentPlayerId);
        if (player != null)
        {
            Debug.Log($"Id: {player.Id}, Name: {player.Name}, Score: {player.Score}, Region: {player.PlayerRegion}, Rank: {player.Rank}");
        }
    }    
    public void YC5()
    {
        // sinh viên viết tiếp code ở đây
        var sortedPlayers = listPlayer.OrderByDescending(p => p.Score);
        foreach (var player in sortedPlayers)
        {
            Debug.Log($"Id: {player.Id}, Name: {player.Name}, Score: {player.Score}, Region: {player.PlayerRegion}, Rank: {player.Rank}");
        }
    }
    public void YC6()
    {
        // sinh viên viết tiếp code ở đây
        var lowestScorePlayers = listPlayer.OrderBy(p => p.Score).Take(5);
        foreach (var player in lowestScorePlayers)
        {
            Debug.Log($"Id: {player.Id}, Name: {player.Name}, Score: {player.Score}, Region: {player.PlayerRegion}, Rank: {player.Rank}");
        }
    }
    public void YC7()
    {
        // sinh viên viết tiếp code ở đây
        Thread bxhThread = new Thread(() =>
        {
            var regionGroups = listPlayer.GroupBy(p => p.PlayerRegion);
            using (StreamWriter writer = new StreamWriter("bxhRegion.txt"))
            {
                foreach (var group in regionGroups)
                {
                    double averageScore = group.Average(p => p.Score);
                    writer.WriteLine($"Region: {group.Key}, Average Score: {averageScore}");
                }
            }
        });
        bxhThread.Name = "BXH";
        bxhThread.Start();
    }

    void CalculateAndSaveAverageScoreByRegion()
    {
        // sinh viên viết tiếp code ở đây
    }
}

[SerializeField]
public class Region
{
    public int ID;
    public string Name;
    public Region(int ID, string Name)
    {
        this.ID = ID;
        this.Name = Name;
    }
}

[SerializeField]
public class Players
{
    // sinh viên viết tiếp code ở đây
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public string Rank { get; set; }
    public Region PlayerRegion { get; set; }
    ScoreKeeper sc;
    public Players(int id, string name, int score, Region region)
    {
        Id = id;
        Name = name;
        Score = score;
        PlayerRegion = region;
    }
}