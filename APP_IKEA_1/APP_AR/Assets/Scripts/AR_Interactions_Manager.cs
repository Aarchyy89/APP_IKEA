using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AR_Interactions_Manager : MonoBehaviour
{
    
    public static AR_Interactions_Manager instance;

    [SerializeField, Tooltip("Cámara ar ubicada dentro del session origin")]
    private Camera arCamera;

    [SerializeField] private ARRaycastManager _raycastManager;
    
    [SerializeField, Tooltip("Pointer de debajo del objeto una vez instanciado")] 
    private GameObject arPointer;

    //private variables
    [Tooltip("Lista donde se guardaran las pulsaciones del usuario")]
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject itemObjeto_prefab;

    [Tooltip("Representacion del objeto donde se ha pulsado en pantalla")]
    private GameObject item_Selected;

    private bool is_initial_pos;
    private bool is_Over_Ui;
    private bool is_Over_ObjPrefab;

    //Getters & SETTERS
    public GameObject ARPointer => arPointer;

    public GameObject ItemObjetoPrefab
    {
        set => itemObjeto_prefab = value;
    }

    public bool IsInitialPosition
    {
        set => IsInitialPosition = value;   
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Update()
    {
        if(is_initial_pos)
        {
            Vector2 middlePositionScreen = new Vector2(Screen.width / 2, Screen.height / 2);
            _raycastManager.Raycast(middlePositionScreen, hits, TrackableType.Planes);

            //comprobamos que existe un plano que se encuentra en la mitad de la pantalla
            if(hits.Count > 0)
            {
                //si pulsamos sobre un plano movemos el gameobject que tiene el script
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;
                arPointer.SetActive(true);
                is_initial_pos = false;
            }

        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);    

            if(touch.phase == TouchPhase.Began)
            {
                var touchPosition = touch.position;
                is_Over_Ui = IsTapOverUI(touchPosition);
                is_Over_ObjPrefab = IsTapOverItemObjeto_prefab(touchPosition);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                //si movemos el dedo tenemos que verificar que estamos moviendo el dedo dentro de los planos
                if(_raycastManager.Raycast(touch.position, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;

                    if(!is_Over_Ui && is_Over_ObjPrefab)
                    {
                        transform.position = hitPose.position;
                    }
                }
            }

            if (is_Over_ObjPrefab && itemObjeto_prefab == null && !is_Over_Ui)
            {
                itemObjeto_prefab = item_Selected;
                item_Selected = null;
                arPointer.SetActive(true);
                transform.position = itemObjeto_prefab.transform.position;
                itemObjeto_prefab.transform.parent = arPointer.transform;

            }
        }
    }

    /// <summary>
    /// Método para comprobar si estamos pulsando sobre un elemento creado en pantalla
    /// </summary>
    private bool IsTapOverItemObjeto_prefab(Vector2 touchPosition)
    {
        // Creamos un rayo desde la camara al punto donde hemos pulsado
        Ray ray = arCamera.ScreenPointToRay(touchPosition);

        // Comprobamos si ha colisionado con algo
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // En caso de colisionar con un prefab instanciado con el tag Objeto, devolveremos true, de lo contrario false
            if (hit.collider.CompareTag("Objeto"))
            {
                // Dejamos guardado el objeto seleccionado
                item_Selected = hit.transform.gameObject;
                return true;
            }

        }

        return false;
    }


    /// <summary>
    /// Método para comprobar que donde estamos pulsando sobre un elemento de la UI
    /// </summary>
    private bool IsTapOverUI(Vector2 touchPosition)
    {
        // Assignamos el EventSystem de la interfaz de nuestra app al Pointer
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);

        // Asignamos la posición del TOUCH
        pointerEventData.position = new Vector2(touchPosition.x, touchPosition.y);

        // Verificamos si hay algún evento en la posición donde hemos pulsado
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, result);

        return result.Count > 0;
    }

    /// <summary>
    /// Métedo para dejar el objeto en el lugar donde se encuentra, de esta manera por si pulsamos en otro lugar de la
    /// pantalla no seguirá
    /// </summary>
    public void AssignItemPosition()
    {
        if (itemObjeto_prefab != null)
        {
            // Ya no hace falta que el objeto que hemos creado sea hijo del pointer por lo que le quitamos el parent
            itemObjeto_prefab.transform.parent = null;

            arPointer.SetActive(false);

            itemObjeto_prefab = null;
        }
    }

    /// <summary>
    /// Método para borrar el objeto que hemos seleccionado
    /// </summary>
    public void DeleteItem()
    {
        Destroy(itemObjeto_prefab);
        arPointer.SetActive(false);
    }

}
