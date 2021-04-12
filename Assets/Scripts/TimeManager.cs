using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

// TimeManager tm = GameObject.FindGameObjectWithTag("Tagtm").GetComponent<TimeManager>();
/*
        if(tm.isDayOver()){
            tm.StartNewDay();
        }
*/
public class TimeManager : MonoBehaviour
{
    private readonly TimeSpan interval = new TimeSpan(0,0, 0, 3,0);
    private TimeSpan prevtime;
    private string time;
    private TimeUtil instance;
    private bool nighttime;

    private int counter = 0; 
    private int countmax; 

    public TextMeshProUGUI timeText;

    private readonly string NIGHTTIME_STR = "NIGHTTIME";

    private readonly string[] times = 
    { "9:00 AM", "9:15 AM", "9:30 AM","9:45 AM",
    "10:00 AM", "10:15 AM", "10:30 AM","10:45 AM",
    "11:00 AM", "11:15 AM", "11:30 AM","11:45 AM",
    "12:00 PM", "12:15 PM", "12:30 PM","12:45 PM",
    "1:00 PM", "1:15 PM", "1:30 PM","1:45 PM",
    "2:00 PM", "2:15 PM", "2:30 PM","2:45 PM",
    "3:00 PM", "3:15 PM", "3:30 PM","3:45 PM",
    "4:00 PM", "4:15 PM", "4:30 PM","4:45 PM",
    "5:00 PM" };
    // Start is called before the first frame update
    void Awake()
    {
        instance = TimeUtil.Instance;
        nighttime = true;
        prevtime = new TimeSpan();
        countmax = times.Length;
        time = NIGHTTIME_STR;
        timeText.text=string.Format("{0}", times);

    }

    // Update is called once per frame
    void Update()
    {
        if(!nighttime){
            TimeSpan currtime = new TimeSpan();
            currtime = instance.GetStopWatchTimeSpan();
            if(instance.getTimeSpan() == currtime || counter >= countmax){
                instance.ResetStopWatchandGetTimeSpan();
                time = NIGHTTIME_STR;
                nighttime = true;
            }
            else {
                if(currtime-prevtime >= interval){
                    counter++;
                    prevtime = currtime;
                }
                if( counter < countmax){
                    time = times[counter];
                    
                }
            }
        }     
    }

   public void StartNewDay(){
       this.reset();
       instance.StartStopWatch();
    }

    public bool isDayOver() {
        return nighttime;
    }
    public string getCurrentTime(){
        
      //  UnityEngine.Debug.LogWarning(time);
        return time;
    }

    private void reset(){
        nighttime = false;
        counter = 0;
        prevtime = new TimeSpan();
        instance.ResetStopWatchandGetTimeSpan();
    }

    public int getDays(){
        return instance.getDays();
    }

    // public void DisplayTime(){
    //     time=getCurrentTime();
    //     timeText.text=string.Format("{0}", time);
    // }
}
