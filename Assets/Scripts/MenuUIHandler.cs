using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StarNewClicked()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.playerName = GameManager.Instance.PlayerNameText.text;
       // ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
    public void ExitClicked()
    {
       #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
       #else
        Application.Quit(); // original code to quit Unity player
       #endif
      GameManager.Instance.SaveData_toFile();
    }  
   
}
