using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputValues : MonoBehaviour
{

    public GameObject inputField;
    public GameObject cart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StoreValue() {
        float newValue = float.Parse(inputField.GetComponent<Text>().text);
        cart.GetComponent<Cart>().startMovement(newValue);
    }
}
