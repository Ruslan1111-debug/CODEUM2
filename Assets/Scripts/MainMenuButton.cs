using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public Button button;

    void Awake(){
    button.onClick.AddListener(()=>{
    SceneManager.LoadScene(0);});
   }
}
