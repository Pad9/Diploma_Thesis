using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;

    public float nextQ;

    private void Start()
    {
        
        totalQuestions = QnA.Count; //Number of questions we have
        GoPanel.SetActive(false); //At the start we open the QnA panel
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Load the scene again
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Go to the next level of the game
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions; //How many questions we get right
    }

    public void correct()
    {
        //when an answer is right
        score += 1;
        QnA.RemoveAt(currentQuestion); //Remove the question that has already been answered
        StartCoroutine(waitForNext());

    }

    public void wrong()
    {
        //When an answer is wrong
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(waitForNext());
    }

    IEnumerator waitForNext() // Wait an amount of seconds before showing the next question/answers
    {
        yield return new WaitForSeconds(nextQ);
        generateQuestion();

    }


    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor; //Remake what color tha button was before going green for true or red for false
            options[i].GetComponent<AnswerScript>().isCorrect = false; //False by default.
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i]; //Take the answers from the list of the current question

            if (QnA[currentQuestion].CorrectAnswer == i + 1) //Answers are from i=1 to i=4
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0) //If we have questions
        {
            currentQuestion = Random.Range(0, QnA.Count); //Take a question from the list

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
        

    }


}
