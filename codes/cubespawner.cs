using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnInterval = 1.5f; // time between cubes
    public bool randomizeSize = true;
    public bool randomizeColor = true;

    // Fixed size options
    private readonly float[] cubeSizes = { 0.1f, 0.25f, 0.5f };
    // Fixed color options
    private readonly Color[] cubeColors = { Color.red, Color.blue };

    private void Start()
    {
        StartCoroutine(SpawnCubes());
    }

    IEnumerator SpawnCubes()
    {
        while (true)
        {
            SpawnCube();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnCube()
    {
        GameObject cube = Instantiate(cubePrefab, transform.position, Quaternion.identity);

        // Randomize size
        if (randomizeSize)
        {
            float randomScale = cubeSizes[Random.Range(0, cubeSizes.Length)];
            cube.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }

        // Randomize color
        if (randomizeColor)
        {
            Renderer cubeRenderer = cube.GetComponent<Renderer>();
            if (cubeRenderer != null)
            {
                Color randomColor = cubeColors[Random.Range(0, cubeColors.Length)];
                cubeRenderer.material.color = randomColor;
            }
        }
    }
}
