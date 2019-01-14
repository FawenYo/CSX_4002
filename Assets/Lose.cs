using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{

    #region Variable

    public Text NumScore;
    public Text ScoreText;
    public int historyscore;
    public int NumScoreInt;

    #endregion

    void Start()
    {
        historyscore = PlayerPrefs.GetInt("score", 2);
        NumScoreInt = int.Parse(NumScore.text);
        NumScoreInt = historyscore - NumScoreInt;
        NumScore.text = NumScoreInt.ToString();
        ScoreText.text = ("Score : " + NumScore.text  + "/" + historyscore);
    }
    public void RestartButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
