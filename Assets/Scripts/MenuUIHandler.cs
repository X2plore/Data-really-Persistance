using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR //Editor
using UnityEditor; //Editor
#endif //Editor
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    //private GameObject playerNameInput;
    private string namePlayerString;
    private TMP_InputField playerNameInput;
    private TMP_Text pleaseInputPlayerNameText;
    private TMP_Text highScoreMenuText;
    

    // Start is called before the first frame update
    void Start()
    {
        
        if (GameObject.Find("PlayerNameField(TMP)") != null)
        {
            playerNameInput = GameObject.Find("PlayerNameField(TMP)").GetComponent<TMP_InputField>();
        }
        if (GameObject.Find("PleaseInputPlayerName(TMP)") != null)
        {
            pleaseInputPlayerNameText = GameObject.Find("PleaseInputPlayerName(TMP)").GetComponent<TMP_Text>();
            pleaseInputPlayerNameText.enabled = false;  
        }
        if (GameObject.Find("HighScoreText(TMP)") != null)
        {
            //Debug.Log("Highscore exist");
            highScoreMenuText = GameObject.Find("HighScoreText(TMP)").GetComponent<TMP_Text>();
            GameManager.instance.LoadHighScore();
            highScoreMenuText.text = $"Player: {GameManager.instance.playerNameHighScore} High Score: {GameManager.instance.highScore} ";
        }
        //Debug.Log("Nameplayer" + namePlayerString);
        //playerNameInput = GetComponent<TMP_InputField>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //namePlayerString = playerNameInput.text;
    }
    public void StartButtomClicked()
    {
        if(playerNameInput.text != "")
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            pleaseInputPlayerNameText.enabled = true;
            //Debug.Log("Input Player Name");
        }
    }
    public void ExitButtonClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
    public void BackButtonClicked()
    {
        
        if (GameObject.Find("GameManager") != null)
        {
            GameManager.instance.SaveHighScore();
        }
        SceneManager.LoadScene(0);
    }
    public void PlayerNameInputed()
    {
        if(playerNameInput.text == "")
        {
            pleaseInputPlayerNameText.enabled = true;
        }
        else
        {
            namePlayerString = playerNameInput.text;
            GameManager.instance.playerName = namePlayerString;
            pleaseInputPlayerNameText.enabled = false;
            //Debug.Log("Nameplayer" + namePlayerString);
        }

    }
}
