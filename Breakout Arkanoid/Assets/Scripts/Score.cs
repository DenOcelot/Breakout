using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int scoreMultiplier = 1000;   
    public int slowCost = 500;
    
    int slowTimes;
    bool set;
    public bool slowMo;
    public GameObject win;
    public GameObject lose;
    GameObject[] TotalBlocks;
    GameObject[] Blocks;
    GameObject[] Balls;

    TextMeshProUGUI text;

    TimeManager timeM;
    AudioReverbFilter reverb;
    AudioLowPassFilter lowPass;
    PostProcessVolume volume;
    Vignette vignette = null;

    Timer timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 0.1f;
        timer.Run();

        text = GetComponent<TextMeshProUGUI>();
        timeM = GetComponent<TimeManager>();
        reverb = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioReverbFilter>();
        lowPass = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioLowPassFilter>();
        //win = GameObject.FindGameObjectWithTag("win");
        //lose = GameObject.FindGameObjectWithTag("lose");

        volume = gameObject.GetComponent<PostProcessVolume>();

        
        volume.profile.TryGetSettings(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        Blocks = GameObject.FindGameObjectsWithTag("Block");
        Balls = GameObject.FindGameObjectsWithTag("Ball");
        if (!set)
        {
            TotalBlocks = GameObject.FindGameObjectsWithTag("Block");
            set = true;
        }
        if (Blocks.Length == 0 && Balls.Length != 0)
        {
            win.SetActive(true);
            score = +32000;
        }
        else{ 
        score = (TotalBlocks.Length - Blocks.Length) * 1000 - slowCost * slowTimes;
        }
        if(Balls.Length == 0 && Blocks.Length != 0)
        {
            lose.SetActive(true);
        }
        text.text = score.ToString();
        if (slowMo)
        {
            reverb.enabled = true;
            lowPass.enabled = true;


            
            vignette.intensity.value = 0.35f;
        }

        if (timer.Finished)
        {
            timer = gameObject.AddComponent<Timer>();
            timer.Duration = 1.5f;
            timer.Run();
            reverb.enabled = false;
            lowPass.enabled = false;

            
            vignette.intensity.value = 0;

            slowMo = false;
        }



        if (Input.GetKeyDown(KeyCode.DownArrow) && score != 0)
        {
            slowMo = true;
            slowTimes++;
            timeM.DoSlowmotion();

        }
    }
}
