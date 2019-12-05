//Hello, I am commenting on this. Sorry if I break this.
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script: MonoBehaviour
{
    public float speed;
    public int speedInt;
    public int movementspeed = 100;
    public Text countText;
    public Text winText;
    public Text leeaveText;
    public Text leaveText;

    private int count;
    private Rigidbody rb;
    private Renderer rend;
    private float moveHorizontal;
    private float moveVertical;
 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        leaveText.text = "";
        leeaveText.text = "";

    }
    public class Movement : MonoBehaviour
    {
        private Vector3 left;
        private Vector3 right;
        private Vector3 up;
        private Vector3 down;
        public Vector3 movementspeed;

        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate((Vector3.left + movementspeed) * Time.deltaTime);
                Debug.Log("left pressed");
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate((Vector3.right + movementspeed) * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate((Vector3.up + movementspeed) * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate((Vector3.down + movementspeed) * Time.deltaTime);
            }


        }
    }
  

    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Destroylife"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

  

    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count == 5)
        {
            winText.text = "You win!!";
        }
        if (count == 6)
        {
            leaveText.text = "Ok, you can go now";
        }
        if (count == 7)
        {
            leeaveText.text = "Please leave...";
        }
    }
}



// some of these codes didn't work like the leavetext and leeavetext.. 
