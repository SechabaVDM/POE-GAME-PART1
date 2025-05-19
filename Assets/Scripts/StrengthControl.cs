using UnityEngine;

public class StrengthControl : MonoBehaviour
{
    public static int strengthCount = 30;
    [SerializeField] GameObject strengthDisplay;
    public GameManager gameManager;
    // Update is called once per frame
    void Update()
    {
        strengthDisplay.GetComponent<TMPro.TMP_Text>().text = "Strength: " + strengthCount;
        

    }
}
