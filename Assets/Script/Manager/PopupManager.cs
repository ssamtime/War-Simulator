using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PopupManager : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text timer;

    private static GameObject prefab;

    // PopupManager로 전역에서 접근할수 있는 함수
    public static PopupManager Show(string message,string timer)
    {
        if(prefab == null)
        {
            prefab = (GameObject)Resources.Load("Game Result Window");
        }

        GameObject obj = Instantiate(prefab);
        PopupManager resultPopup = obj.GetComponent<PopupManager>();
        resultPopup.UpdateContent(message, timer);

        return resultPopup;
    }
    
    //팝업의 내용을 업데이트하는 함수
    public void UpdateContent(string titleMessage,string timerMessage)
    {
        title.text = titleMessage;
        timer.text = timerMessage;
    }

    public void CanclePopup()
    {
        Destroy(gameObject);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
