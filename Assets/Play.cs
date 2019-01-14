using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    #region Variable

    public Rigidbody2D rb;
    public int rotatespeed = 100;
    public int shootspeed = 10;
    public GameObject Arrow;
    public GameObject newArrow;
    public Text NumText;
    public int Num ;
    public bool first = false;


    public GameObject LevelComplete;
    public GameObject Lose;
    public GameObject ExitPannel;

    #endregion

    #region Collide

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Circle")
        {
            if (NumText.text == "1")
            {
                PlayerPrefs.SetInt("score", 2 * Num);
                LevelComplete.SetActive(true);
            }

            rb.gravityScale = 0;  //Stop old

            newArrow = Instantiate(Arrow, new Vector3(0.0f, -2.5f, 0.0f), Quaternion.identity);
            newArrow.tag = "Arrow"; //Create new

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Arrow.tag = "hit";        //Change old

            Num = int.Parse(NumText.text);
            Num = Num - 1;
            Debug.Log(Num);
            NumText.text = Num.ToString();
        }
        else
        {
            Destroy(Arrow);
            Lose.SetActive(true);
        }
    }

    #endregion

    #region Exit

    public void ExitButtonClick()
    {
        ExitPannel.SetActive(true);
    }

    public void ResumeBtnClick()
    {
        ExitPannel.SetActive(false);
    }

    public void ExitBtnClick()
    {
        SceneManager.LoadScene(0);
    }

    #endregion

    #region GamePlay

    void Start()
    {
        if (first == false)
        {
            Num = PlayerPrefs.GetInt("score", 2);
            NumText.text = Num.ToString();
            first = true;
        }
        else
        {
            return;
        }
    }

    void Update()
    {
        if (ExitPannel.activeSelf == false)
        {
            if (Input.GetKey("space"))
            {
                rb.gravityScale = -1;
            }

            if(Input.touchCount > 0)
            {
                rb.gravityScale = -1;
            }

            if (Arrow.tag == "hit")
            {
                Arrow.transform.Rotate(0, 0, Time.deltaTime * rotatespeed);
            }
        }
        else
        {
            return;
        }
    }

    #endregion

}
