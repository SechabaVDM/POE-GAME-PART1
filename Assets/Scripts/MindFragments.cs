using UnityEngine;

public class MindFragments : MonoBehaviour
{
    public static int mindCount = 0;
    [SerializeField] GameObject mindDisplay;
    private void Update()
    {
        mindDisplay.GetComponent<TMPro.TMP_Text>().text = "Mind Fragment:" + mindCount;
    }
}
