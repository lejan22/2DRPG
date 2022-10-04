using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public const string HORIZONTAL = "Horizontal", VERTICAL = "Vertical";
    private float inputTol = 0.2f; // Tol es lo mucho que presionas la tecla. La tolerancia va del 0 a uno
    private float xInput, YInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw(HORIZONTAL);
        if (Mathf.Abs(xInput) > inputTol)
        {
            Vector3 translation = new Vector3(xInput * speed * Time.deltaTime, 0, 0);
            transform.Translate(translation);
        }
        YInput = Input.GetAxisRaw(VERTICAL);
        if (Mathf.Abs(YInput) > inputTol)
        {
            Vector3 translation = new Vector3(0,YInput * speed * Time.deltaTime, 0);
            transform.Translate(translation);
        }
    }
}
