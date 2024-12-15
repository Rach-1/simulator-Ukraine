using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text[] UiTime;
    public Text[] UiDate;
    public TimeFormat timeFormat = TimeFormat.Hour_24;
    public DateFormat dateFormat = DateFormat.DD_MM_YYYY;
    public float SecPerMin = 1;

    public bool PickMonth = false;
    public bool PickMonthHandled = false;


    private string time;
    private string date;

    private bool isAn = false;

    int hr;
    int min;

    int maxHr = 24;
    int maxMin = 60;

    int day=24;
    int month=7;
    int year=1991;

    int maxDay = 30;
    int maxMonth = 12;

    float timer = 0;

    public enum TimeFormat
    {
        Hour_24,
        Hour_12
    }
    public enum DateFormat
    {
        DD_MM_YYYY,
        MM_DD_YYYY,
        YYYY_DD_MM,
        YYYY_MM_DD
    }

    private void Awake()
    {
        if(hr < 12)
        {
            isAn = true;
        }
    }

    void Update()
    {
        if (PickMonth && !PickMonthHandled)
        {
            // Очікуємо, поки інший скрипт обробить PickMonth
            return;
        }
        PickMonth = false;
        if (timer >= SecPerMin)
        {
            min += 60;
            if(min >= maxMin)
            {
                min = 0;
                hr++;
                if (hr >= maxHr)
                {
                    hr = 0;
                    day++;
                    if (day >= maxDay)
                    {
                        day = 1;
                        month++;
                        PickMonth = true;
                        PickMonthHandled = false;
                        if (month > maxMonth)
                        {
                            year++;
                            month = 1;
                        }
                    }
                }
            }
            SetTimeDateString();

            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
            PickMonth = false;
        }
    }

    void SetTimeDateString()
    {
        switch (timeFormat)
        {
            case TimeFormat.Hour_24:
                {
                    if (hr <= 9)
                    {
                        time = "0" + hr + ":";
                    }
                    else
                    {
                        time = hr + ":";
                    }
                    if(min <= 9)
                    {
                        time += "0" + min;
                    }
                    else
                    {
                        time += min;
                    }
                    break;
                }
            case TimeFormat.Hour_12:
                {
                    int h; 

                    if (hr >= 13)
                    {
                        h = hr - 12;
                    }
                    else if (hr == 0)
                    {
                        h = 12;
                    }
                    else
                    {
                        h = hr;
                    }

                    time = h + ":";
                    if (min <= 9)
                    {
                        time += "0" + min;
                    }
                    else
                    {
                        time += min;
                    }
                    if(isAn)
                    {
                        time += " AM";
                    }
                    else
                    {
                        time += " PM";
                    }
                    break;
                }
        }

        switch (dateFormat)
        {
            case DateFormat.DD_MM_YYYY:
                {
                    date = day + "." + month + "." + year;
                    break;
                }
            case DateFormat.MM_DD_YYYY:
                {
                    date = month + "." + day + "." + year;
                    break;
                }
            case DateFormat.YYYY_DD_MM:
                {
                    date = year + "." + day + "." + month;
                    break;
                }
            case DateFormat.YYYY_MM_DD:
                {
                    date = year + "." + month + "." + day;
                    break;
                }
        }

        for(int i = 0; i < UiTime.Length; i++)
        {
            UiTime[i].text = time;
        }
        for (int i = 0; i < UiDate.Length; i++)
        {
            UiDate[i].text = date;
        }
    }

    public void SpeedSet(int speedSet)
    {
        if (speedSet == 1)
        {
            SecPerMin = 0.5f;
        }
        else if(speedSet == 2)
        {
            SecPerMin = 0.1f;
        }
        else
        {
            SecPerMin = 0f;
        }
    }
}
