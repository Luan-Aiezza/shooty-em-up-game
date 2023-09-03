using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    public Camera mainCamera;
    private float minX, maxX, minY, maxY;

    private void Start()
    {
        // Obtém os limites da câmera
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        minX = mainCamera.transform.position.x - cameraWidth / 2f;
        maxX = mainCamera.transform.position.x + cameraWidth / 2f;
        minY = mainCamera.transform.position.y - cameraHeight / 2f;
        maxY = mainCamera.transform.position.y + cameraHeight / 2f;
    }

    private void Update()
    {
        // Obtém a posição atual do jogador
        Vector3 playerPosition = transform.position;

        // Limita a posição do jogador aos limites da câmera
        playerPosition.x = Mathf.Clamp(playerPosition.x, minX, maxX);
        playerPosition.y = Mathf.Clamp(playerPosition.y, minY, maxY);

        // Define a posição do jogador após a limitação
        transform.position = playerPosition;
    }
}