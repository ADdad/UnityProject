using UnityEngine;

public class buttonClick : MonoBehaviour
{
    private int counter = 0;
    
    void OnClick ()
    {
        counter++;
        Debug.Log("CLicked");
    }
}