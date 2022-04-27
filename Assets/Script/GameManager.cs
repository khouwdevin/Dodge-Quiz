using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public Questions[] questions;

    private static List<Questions> unanswered;

    private Questions currentQuestions;

    [SerializeField]
    private Text factText;
    
    private Text answerleftText, answerrightText;

    [SerializeField]
    public GameObject satelite_left, satelite_right, question_text;
    
    [SerializeField]
    public GameObject pass, wrong;

    [SerializeField]
    private GameObject rocket; 

    public static string player_answer;

    public AudioSource true_audio, false_audio;

    // Start is called before the first frame update
    void Start()
    {
        if(unanswered == null || unanswered.Count == 0)
        {
            unanswered = questions.ToList<Questions>();
        }
        GenerateQuestions();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Timer.Isrunning)
        {
            try
            {
                if (player_answer.Equals("left"))
                {
                    PlayerChooseLeft();
                    player_answer = null;
                }
                else if (player_answer.Equals("right"))
                {
                    PlayerChooseRight();
                    player_answer = null;
                }
            }
            catch (Exception e)
            {

            }
            if (Timer.timer <= 0)
            {
                Timer.timer = 5f;
                pass.SetActive(false);
                wrong.SetActive(false);
                GenerateQuestions();
                question_text.SetActive(true);
            }
        }
        if(unanswered.Count() == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    void GenerateQuestions()
    {
        int questionnumber = UnityEngine.Random.Range(0, unanswered.Count - 1);

        currentQuestions = unanswered[questionnumber];

        factText.text = currentQuestions.fact;
        try
        {
            answerleftText.text = currentQuestions.answerleft;
            answerrightText.text = currentQuestions.answerright;
        }
        catch(Exception e) { }

        unanswered.RemoveAt(questionnumber);

        if(unanswered.Count == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void PlayerChooseLeft()
    {
        question_text.SetActive(false);
        if (currentQuestions.isLeft)
        {
            Debug.Log("Correct");
            pass.SetActive(true);
            true_audio.Play();
            //change the factText to correct
            Timer.Clock(5f);
        }
        else
        {
            Debug.Log("Wrong");
            wrong.SetActive(true);
            false_audio.Play();
            Timer.Clock(5f);
        }
    }

    public void PlayerChooseRight()
    {
        question_text.SetActive(false);
        if (currentQuestions.isLeft)
        {
            Debug.Log("Wrong");
            wrong.SetActive(true);
            true_audio.Play();
            Timer.Clock(5f);
        }
        else
        {
            Debug.Log("True");
            pass.SetActive(true);
            false_audio.Play();
            Timer.Clock(5f);
        }
    }

}
