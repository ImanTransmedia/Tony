using System.Collections;
using UnityEngine;

public class MonsterRotation : MonoBehaviour
{
    private float targetAngle;
    private float rotationTime;
    private float sleepTime = 0.2f;
    [SerializeField]
    private float minRotation = 45f;
    [SerializeField]
    private float maxRotation = 65f;
    [SerializeField]
    private float minTime = 2f;
    [SerializeField]
    private float maxTime = 5f;

    private bool rotatePositive = true;

    void Start()
    {
        StartCoroutine(RotateObject());
    }

    IEnumerator RotateObject()
    {
        while (true)
        {
            // Definir el �ngulo objetivo de rotaci�n entre 45 y 65 grados
            targetAngle = Random.Range(minRotation, maxRotation);

            // Definir el tiempo de rotaci�n entre 2 y 5 segundos
            rotationTime = Random.Range(minTime, maxTime);

            float startAngle = transform.eulerAngles.y;
            float endAngle = rotatePositive ? startAngle + targetAngle : startAngle - targetAngle;
            float elapsedTime = 0f;

            // Realizar la rotaci�n hacia el �ngulo objetivo
            while (elapsedTime < rotationTime)
            {
                elapsedTime += Time.deltaTime;
                float angle = Mathf.Lerp(startAngle, endAngle, elapsedTime / rotationTime);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
                yield return null;
            }

            // Asegurar que el objeto alcance el �ngulo objetivo
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, endAngle, transform.eulerAngles.z);

            // Esperar un momento antes de volver a la posici�n original
            yield return new WaitForSeconds(sleepTime);

            // Determinar si se debe tomar el camino m�s largo de regreso
            bool takeLongWay = Random.value > 0.5f;

            // Volver a la posici�n original
            startAngle = transform.eulerAngles.y;
            if (takeLongWay)
            {
                // Calcular el �ngulo m�s largo
                endAngle = (startAngle + 180) % 360;
                rotationTime = Random.Range(minTime, maxTime);
                elapsedTime = 0f;

                // Realizar la rotaci�n en el camino m�s largo
                while (elapsedTime < rotationTime)
                {
                    elapsedTime += Time.deltaTime;
                    float angle = Mathf.Lerp(startAngle, endAngle, elapsedTime / rotationTime);
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
                    yield return null;
                }

                // Asegurar que el objeto alcance el �ngulo objetivo
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, endAngle, transform.eulerAngles.z);

                // Ajustar el tiempo para regresar a 0 desde el nuevo �ngulo
                rotationTime = Random.Range(minTime, maxTime);
                startAngle = endAngle;
                endAngle = 0;
            }
            else
            {
                // Ajustar directamente a 0 grados
                endAngle = 0;
            }

            elapsedTime = 0f;
            while (elapsedTime < rotationTime)
            {
                elapsedTime += Time.deltaTime;
                float angle = Mathf.Lerp(startAngle, endAngle, elapsedTime / rotationTime);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
                yield return null;
            }

            // Asegurar que el objeto alcance la posici�n original
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);

            // Alternar la direcci�n de rotaci�n
            rotatePositive = !rotatePositive;

            // Esperar antes de comenzar la siguiente rotaci�n
            yield return new WaitForSeconds(sleepTime);
        }
    }
}
