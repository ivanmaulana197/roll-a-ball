using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI coinText;
    public GameObject winTextObj;
    private int coin;
    private Rigidbody rb;
    private float moveX, moveY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coin = 0;
        SetCoinText();
        winTextObj.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        moveX = movementVector.x;
        moveY = movementVector.y;
    }

    void SetCoinText()
    {
        coinText.text = "Coin: " + coin.ToString();
        if (coin >= 35)
        {
            winTextObj.SetActive(true);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            coin++;
            SetCoinText();
        }
    }
}
