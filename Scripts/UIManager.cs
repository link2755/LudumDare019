using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public string stressDisplay;
    public int stress;
    public GameObject textObj;
    public GameScript gamescript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stress = (int)gamescript.stress;
        stressDisplay = "Stress Meter: " + stress.ToString() + "\nPills: " + gamescript.pills.ToString();
        textObj.GetComponent<Text>().text = stressDisplay;
    }
}
