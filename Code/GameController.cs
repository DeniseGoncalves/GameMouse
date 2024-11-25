using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public  mouseController    _PlayerController;

    [Header("Limites de Movimento")]
    public Transform        limiteDireito;
    public Transform        limiteEsquerdo;

    [Header("Limite Lateral Camera")]

    public Camera           camera;

    public Transform        limiteCamEsquerda;
    public Transform        limiteCamDireita;
    public float            velocidadeLateralCamera;



    // Start is called before the first frame update
    void Start()
    {
        _PlayerController = FindObjectOfType(typeof(mouseController)) as mouseController;
    }

    // Update is called once per frame
    void Update()
    {
        limitarMovimentoPlayer();
    }

    void LateUpdate()
    {
        controlePosicaoCamera();
    }

    void controlePosicaoCamera()
    {
        if(camera.transform.position.x > limiteCamEsquerda.position.x && camera.transform.position.x < limiteCamDireita.position.x)
        {
            moverCamera();
        }
        
        else if(camera.transform.position.x <= limiteCamEsquerda.position.x && _PlayerController.transform.position.x > limiteCamEsquerda.position.x)
        {
            moverCamera();
        }

        else if(camera.transform.position.x >= limiteCamDireita.position.x && _PlayerController.transform.position.x < limiteCamDireita.position.x)
        {
            moverCamera();
        }
    }

    void moverCamera()
    {
        Vector3 posicaoDestinoCamera = new Vector3(_PlayerController.transform.position.x, camera.transform.position.y, -10);
        camera.transform.position = Vector3.Lerp(camera.transform.position, posicaoDestinoCamera, velocidadeLateralCamera * Time.deltaTime);
    }

    void limitarMovimentoPlayer()
    {

        float posX = _PlayerController.transform.position.x;

        if(posX > limiteDireito.position.x)
        {
            _PlayerController.transform.position = new Vector2(limiteDireito.position.x, 0);
        }
        else if(posX < limiteEsquerdo.position.x)
        {
            _PlayerController.transform.position = new Vector2(limiteEsquerdo.position.x, 0);
        }
    }
}
