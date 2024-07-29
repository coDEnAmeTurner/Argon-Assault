using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TryAgainButton : 
    ColorChangingText,
    IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        int currentIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIdx);
    }

    
}
