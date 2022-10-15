using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataCollector : MonoBehaviour
{

    private int moves = 0;
    private int movetooklongest = 0;
    private DateTime starttime;
    private DateTime endtime;
    private DateTime startmovetime;
    private DateTime time;
    private TimeSpan maxmovetime;
    private int deaths = 0;
    private int lives = 5;
    private int hints = 0;
    // private string likegame;
    // private string suggestions;
    // private string avatar_type;

    private static DataCollector _instance;

    public static DataCollector Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void IncrementMoves()
    {
        this.moves += 1;
        if (this.moves == 1)
        {
            //this.maxmovetime = GetMoveTime();
            SetStartMoveTime();
            this.maxmovetime = GetMoveTime();
            this.movetooklongest = this.moves;
        }
        else if (this.moves > 1)
        {
            if (this.maxmovetime < GetMoveTime())
            {
                this.maxmovetime = GetMoveTime();
                SetStartMoveTime();
                this.movetooklongest = this.moves;
            }
            else
            {
                SetStartMoveTime();
            }
        }
    }

    public int GetMoveTookLongest()
    {
        return this.movetooklongest;
    }


    public TimeSpan GetMaxMoveTime()
    {
        return this.maxmovetime;
    }

  

    public void IncrementDeaths()
    {
        this.deaths += 1;
        this.lives -= 1;
    }

    public int GetMoves()
    {
        return this.moves;
    }

    public int GetDeaths()
    {
        return this.deaths;
    }

    public int GetLives()
    {
        return this.lives;
    }
    
    public void SetLives() {
        this.deaths = 0;
        this.lives = 5;
    }

    public void SetStartMoveTime()
    {
        this.startmovetime = DateTime.Now;
    }

    public TimeSpan GetMoveTime()
    {
        return DateTime.Now.Subtract(this.startmovetime);
    }

    public void SetStartTime()
    {
        this.starttime = DateTime.Now;
    }

    public void SetEndTime()
    {
        this.endtime = DateTime.Now;
    }

    public DateTime GetStartTime()
    {
        return this.starttime;
    }

    public DateTime GetEndTime()
    {
        return this.endtime;
    }

    public TimeSpan GetDeltaTime()
    {
        return this.starttime.Subtract(this.endtime);
    }

    public void IncrementHints()
    {
        this.hints += 1;
    }

    public int GetHints()
    {
        return this.hints;
    }

    public void ResetHints()
    {
        this.hints = 0;
    }

    public void ResetMoves()
    {
        this.moves = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

