using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataCollector : System.Object  //don't want to attach it to an object, just want it roll with it
{

    private int moves = 0;
    private DateTime starttime;
    private DateTime endtime;
    private DateTime startmovetime;
    private DateTime time;
    private TimeSpan maxmovetime;
    private int deaths = 0;
   // private string likegame;
   // private string suggestions;
   // private string avatar_type;

    public void IncrementMoves()
    {
        this.moves += 1;
        if (this.moves == 1)
        {
            this.maxmovetime = GetMoveTime();
            SetStartMoveTime();
        }
        else if (this.moves > 1)
        {
            if (this.maxmovetime < GetMoveTime())
            {
                this.maxmovetime = GetMoveTime();
                SetStartMoveTime();
            }
            else
            {
                SetStartMoveTime();
            }
        }
    }

        
    

    public TimeSpan GetMaxMoveTime()
    {
        return this.maxmovetime;
    }

    public void IncrementDeaths()
    {
        this.deaths += 1;
    }

    public int GetMoves()
    {
        return this.moves;
    }

    public int GetDeaths()
    {
        return this.deaths;
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

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}