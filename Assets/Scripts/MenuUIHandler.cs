using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public string playerName;
    public Text BestScoreText;
    public InputField PlayerNameText;
    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text=$"BestScore: {GameManager.Instance.maxScorePlayerName} : {GameManager.Instance.maxScore}";
        Debug.Log( GameManager.Instance.playerName);
        PlayerNameText.text = GameManager.Instance.playerName;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPlayerNameValueChanged(string s)
    {
        Debug.Log(s);
        playerName = s;
    }
    public void StarNewClicked()
    {
        GameManager.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
       
       // ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
    public void ExitClicked()
    {
       #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
       #else
        Application.Quit(); // original code to quit Unity player
       #endif
       GameManager.Instance.playerName = playerName;
       GameManager.Instance.SaveData_toFile();
    }  
   
}
