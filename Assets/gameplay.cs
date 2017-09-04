using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplay : MonoBehaviour {

    public UnityEngine.UI.Text crystalsText;
    public UnityEngine.UI.Text crystalsCapText;
    public UnityEngine.UI.Text supplyText;

    public float crystalsRaw;
    public float crystalsCapRaw;
    public int crystalsCap;
    public float timePerCrystal;
    public float timePerCrystalCapIncrease;
    public int crystalsCapMax;

    public int supply;
    public int supplySoftCap;

    public float speedFactor;
    public float regenerationModifier;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        crystalsCapRaw += Time.deltaTime / timePerCrystalCapIncrease * speedFactor;
        crystalsCap = Mathf.Min(Mathf.FloorToInt(crystalsCapRaw), crystalsCapMax);
        crystalsCapText.text = crystalsCap.ToString();

        regenerationModifier = 1f - ((float)supply / (float)supplySoftCap);
        crystalsRaw += Time.deltaTime / timePerCrystal * speedFactor * regenerationModifier;
        crystalsRaw = Mathf.Min(crystalsRaw, crystalsCap) ;
        crystalsText.text = crystalsRaw.ToString();

        supplyText.text = supply.ToString();
    }

    public void SpawnUnit(int cost)
    {
        if (crystalsRaw >= cost)
        {
            crystalsRaw -= cost;
        }
    }
}
