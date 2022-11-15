using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public float verticalSpeed = 5f;
    public float scaleFactor = 5f;
    public float damagePoints;
    public TextMeshProUGUI damageText;
    // Start is called before the first frame update
    void Start()
    {
        damageText.text = damagePoints.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(
            transform.position.x, transform.position.y + verticalSpeed * Time.deltaTime, 0);
        transform.localScale *= 1 - Time.deltaTime / scaleFactor;

    }
}
