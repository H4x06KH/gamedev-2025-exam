using JetBrains.Annotations;
using UnityEngine;
using static UnityEditor.UIElements.ToolbarMenu;

public class BrickSpawner : MonoBehaviour
{
    public GameObject[] brickPrefabs;
    public Vector2 brickSize;
    public float maxZOffset;
    public int rowCount;
    public int columnCount;
    public Vector2 brickSpawn;
    private int purpleBrickRow = 0;
    public GameObject purple;
    
    

    

    void Start()
    {

        float z = transform.position.z; // Will not change
        float y = transform.position.y; // Will change for every row of bricks
        for (int row = 0; row < rowCount; row++)
        {
            float x = brickSpawn.x; // Will change for every brick in a row
            for (int col = 0; col < columnCount; col++)
            {
                float randomZOffset = Random.Range(0f, maxZOffset);

                if (purpleBrickRow >= 0 & row == purpleBrickRow)
                {
                    Instantiate(purple, new Vector3(x, y, z + randomZOffset), purple.transform.rotation);
                }

                else

                {
                    int randomIndex = Random.Range(0, brickPrefabs.Length);
                    GameObject brick = brickPrefabs[randomIndex];
                    Instantiate(brick, new Vector3(x, y, z + randomZOffset), brick.transform.rotation);
                }

                x += brickSize.x;
            }
            y += brickSize.y;


        }
        
    }
}
