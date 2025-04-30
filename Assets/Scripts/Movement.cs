using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour, IDataPersistence
{
    public float moveSpeed = 3f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private bool positionLoaded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void LoadData(GameData data)
    {
        //Debug.Log("LoadData called with position: " + data.playerPosition);
        //rb.position = data.playerPosition;
        //positionLoaded = true;

        Debug.Log("LoadData called with position: " + data.playerPosition);
        StartCoroutine(SetPositionNextFrame(data.playerPosition));
    }

    private IEnumerator SetPositionNextFrame(Vector2 pos)
    {
        yield return null; // Wait 1 frame
        rb.position = pos;
        Debug.Log("Position forcibly applied in coroutine: " + rb.position);
        positionLoaded = true;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = rb.position;
        Debug.Log("💾 Saving player position: " + rb.position);
    }

   

    private void Update()
    {
        // Get input from horizontal and vertical axes
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        movement.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down

    }



    private void FixedUpdate()
    {
        if (!positionLoaded) return;

        // Move the player using Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
