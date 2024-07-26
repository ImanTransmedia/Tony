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
            // Definir el ángulo objetivo de rotación entre 45 y 65 grados
            targetAngle = Random.Range(minRotation, maxRotation);

            // Definir el tiempo de rotación entre 2 y 5 segundos
            rotationTime = Random.Range(minTime, maxTime);

            float startAngle = transform.eulerAngles.y;
            float endAngle = rotatePositive ? startAngle + targetAngle : startAngle - targetAngle;
            float elapsedTime = 0f;

            // Realizar la rotación hacia el ángulo objetivo
            while (elapsedTime < rotationTime)
            {
                elapsedTime += Time.deltaTime;
                float angle = Mathf.Lerp(startAngle, endAngle, elapsedTime / rotationTime);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
                yield return null;
            }

            // Asegurar que el objeto alcance el ángulo objetivo
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, endAngle, transform.eulerAngles.z);

            // Esperar un momento antes de volver a la posición original
            yield return new WaitForSeconds(sleepTime);

            // Determinar si se debe tomar el camino más largo de regreso
            bool takeLongWay = Random.value > 0.5f;

            // Volver a la posición original
            startAngle = transform.eulerAngles.y;
            if (takeLongWay)
            {
                // Calcular el ángulo más largo
                endAngle = (startAngle + 180) % 360;
                rotationTime = Random.Range(minTime, maxTime);
                elapsedTime = 0f;

                // Realizar la rotación en el camino más largo
                while (elapsedTime < rotationTime)
                {
                    elapsedTime += Time.deltaTime;
                    float angle = Mathf.Lerp(startAngle, endAngle, elapsedTime / rotationTime);
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
                    yield return null;
                }

                // Asegurar que el objeto alcance el ángulo objetivo
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, endAngle, transform.eulerAngles.z);

                // Ajustar el tiempo para regresar a 0 desde el nuevo ángulo
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

            // Asegurar que el objeto alcance la posición original
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);

            // Alternar la dirección de rotación
            rotatePositive = !rotatePositive;

            // Esperar antes de comenzar la siguiente rotación
            yield return new WaitForSeconds(sleepTime);
        }
    }
}
