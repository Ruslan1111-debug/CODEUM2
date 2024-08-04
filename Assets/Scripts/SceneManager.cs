
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonDebugScript : MonoBehaviour
{
    public Button button;

    void Awake(){
    button.onClick.AddListener(()=>{
    SceneManager.LoadScene(1);});
   }
}
