using System.Collections;
using UnityEngine;

public class SimpleMonsterRotation : MonoBehaviour
{
    [SerializeField]
    private float minRotation = 120f;
    [SerializeField]
    private float maxRotation = 270f;
    [SerializeField]
    private float minTime = 2f;
    [SerializeField]
    private float maxTime = 5f;
    [SerializeField]
    private float waitTime = 1f; // Tiempo de espera antes de cambiar de dirección

    private Coroutine rotationCoroutine;

    void OnEnable()
    {
        transform.eulerAngles = new Vector3(0, 180, 0); // Asegurar que empieza con una rotación de 180
        StartRotationCoroutine();
    }

    void OnDisable()
    {
        StopRotationCoroutine();
    }

    private void StartRotationCoroutine()
    {
        if (rotationCoroutine == null)
        {
            rotationCoroutine = StartCoroutine(RotateObject());
        }
    }

    private void StopRotationCoroutine()
    {
        if (rotationCoroutine != null)
        {
            StopCoroutine(rotationCoroutine);
            rotationCoroutine = null;
        }
    }

    IEnumerator RotateObject()
    {
        while (true)
        {
            float currentAngle = transform.eulerAngles.y;
            float targetAngle;

            if (currentAngle > 180)
            {
                // Si el ángulo actual es mayor a 180, la siguiente rotación será menor a 180
                targetAngle = Random.Range(minRotation, 180f);
            }
            else
            {
                // Si el ángulo actual es menor a 180, la siguiente rotación será mayor a 180
                targetAngle = Random.Range(180f, maxRotation);
            }

            // Definir el tiempo de rotación entre 2 y 5 segundos
            float rotationTime = Random.Range(minTime, maxTime);

            yield return RotateToAngle(targetAngle, rotationTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator RotateToAngle(float targetAngle, float duration)
    {
        float startAngle = transform.eulerAngles.y;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float angle = Mathf.LerpAngle(startAngle, targetAngle, elapsedTime / duration);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
            yield return null;
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, targetAngle, transform.eulerAngles.z);
    }
}
