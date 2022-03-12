using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    static public GamePlay instance;
    private void Awake()
    {
        instance = this;
    }
    public List<GameObject> players=new List<GameObject>();
    public List<Transform>finishedPlayers=new List<Transform>();
    public List<Transform> platforms = new List<Transform>();
    private int totalPlayers;
    private float playerStartZpos;
    public Transform goal;
    public bool onPlay = false;
    // Start is called before the first frame update

    private void Start()
    {
        totalPlayers = players.Count;
       
    }
    // Update is called once per frame
    void Update()
    {
        if (onPlay)
        {
            CheckPlayReachedToGoalAndStopMove();
            CheckGameIsFinished();
        }
    }
    void CheckPlayReachedToGoalAndStopMove()
        {
        for (int i = players.Count-1; i>-1; i--)
        {
            PlayerMove playerMove = players[i].GetComponent<PlayerMove>();
            if (playerMove.distance > goal.position.z-playerStartZpos)
            {
                playerMove.doMove = false;
                finishedPlayers.Add(players[i].transform);
                players.Remove(players[i]);
            }
        }

        }
    void CheckGameIsFinished()
    {
        if(finishedPlayers.Count>=totalPlayers)
        {
            onPlay = false;
            for (int i = 0; i < platforms.Count; i++)
            {
                finishedPlayers[i].position = platforms[i].GetChild(0).position + new Vector3(0, finishedPlayers[i].lossyScale.y, 0);          }
        }
    }
    public void PlayGame()
    {
        onPlay = true;
        playerStartZpos = players[0].transform.position.z;
        foreach (var sub in players)
        {
           PlayerMove playermove= sub.GetComponent<PlayerMove>();
            if (playermove != null)
                playermove.doMove = true;
        }
    }
}
