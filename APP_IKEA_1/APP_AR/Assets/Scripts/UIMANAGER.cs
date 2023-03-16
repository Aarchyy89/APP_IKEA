using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMANAGER : MonoBehaviour
{
    [Header("---paneles----")]
    public GameObject PANEL_vertical_muebles;
    public GameObject PANEL_VERTICAL_BOTON;
    public GameObject PANEL_scroll_SILLAS;
    public GameObject panel_scroll_mesas;
    public GameObject panel_scroll_mesillas;
    public GameObject panel_scroll_sofas;
    public GameObject panel_scroll_sillon;
    
    [Header("---Botones----")]
    public Button ActivarUI_BUT;
    public Button position_but;
    public Button rotate_BUT;
    public Button escale_BUT;
    public Button quit_MUEBLE_BUT;
    public Button take_pic_but;

    public bool all_active;


    [SerializeField] private Item_Manager _item_manager;
    [SerializeField] private Item_Manager _item_manager_mesa;
    [SerializeField] private Item_Manager _item_manager_mesita;
    [SerializeField] private Item_Manager _item_manager_sofas;
    [SerializeField] private Item_Manager _item_manager_sillon;
    
    [SerializeField] private List<Item> lista_sillas = new List<Item>();
    [SerializeField] private GameObject content_lista_sillas;

    [SerializeField] private List<Item> lista_mesas = new List<Item>();
    [SerializeField] private GameObject content_lista_mesas;

    [SerializeField] private List<Item> lista_mesitas = new List<Item>();
    [SerializeField] private GameObject content_lista_mesitas;

    [SerializeField] private List<Item> lista_sofas = new List<Item>();
    [SerializeField] private GameObject content_lista_sofas;

    [SerializeField] private List<Item> lista_sillones = new List<Item>();
    [SerializeField] private GameObject content_lista_sillones;

    public static UIMANAGER UIM;

    private void Awake()
    {
        UIM = this;
    }

    private void Start()
    {
 
    }

    #region Instancias

    public void LimpiarLista()
    {
        foreach (Transform child in content_lista_sillas.transform)
        {
            Destroy(child.gameObject);
        }
    }

    

    public void FuncionSillas()
    {
        //var button = GetComponent<Button>();
        //button.onClick.AddListener();
        PANEL_scroll_SILLAS.SetActive(true); 
        panel_scroll_mesas.SetActive(false);
        panel_scroll_mesillas.SetActive(false);
        panel_scroll_sofas.SetActive(false);
        panel_scroll_sillon.SetActive(false);
    }

    public void FuncionMesas()
    {
        PANEL_scroll_SILLAS.SetActive(false);
        panel_scroll_mesas.SetActive(true);
        panel_scroll_mesillas.SetActive(false);
        panel_scroll_sofas.SetActive(false);
        panel_scroll_sillon.SetActive(false);
    }

    public void FuncionMesitas()
    {
        PANEL_scroll_SILLAS.SetActive(false);
        panel_scroll_mesas.SetActive(false);
        panel_scroll_mesillas.SetActive(true);
        panel_scroll_sofas.SetActive(false);
        panel_scroll_sillon.SetActive(false);
    }

    public void FuncionSofas()
    {
        PANEL_scroll_SILLAS.SetActive(false);
        panel_scroll_mesas.SetActive(false);
        panel_scroll_mesillas.SetActive(false);
        panel_scroll_sofas.SetActive(true);
        panel_scroll_sillon.SetActive(false);
    }

    public void FuncionSillones()
    {
        PANEL_scroll_SILLAS.SetActive(false);
        panel_scroll_mesas.SetActive(false);
        panel_scroll_mesillas.SetActive(false);
        panel_scroll_sofas.SetActive(false);
        panel_scroll_sillon.SetActive(true);
    }

    public void CrearSillas()
    {
        FuncionSillas();
        LimpiarLista();

        foreach (var item in lista_sillas)
        {
            Item_Manager item_manager;
            item_manager = Instantiate(_item_manager, content_lista_sillas.transform);
            item_manager.Item_Name = item.Item_Name;
            item_manager.Item_Image = item.Item_Image;
            item_manager.Item_Prefab = item.Item_Prefab;
            item_manager.name = item.name;
        }
    }

    public void CrearMesas()
    {
        FuncionMesas();
        LimpiarLista();

        foreach (var item in lista_mesas)
        {
            Item_Manager item_manager;
            item_manager = Instantiate(_item_manager_mesa, content_lista_mesas.transform);
            item_manager.Item_Name = item.Item_Name;
            item_manager.Item_Image = item.Item_Image;
            item_manager.Item_Prefab = item.Item_Prefab;
            item_manager.name = item.name;
        }
    }

    public void CrearMesitas()
    {
        FuncionMesitas();
        LimpiarLista();

        foreach (var item in lista_mesitas)
        {
            Item_Manager item_manager;
            item_manager = Instantiate(_item_manager_mesita, content_lista_mesitas.transform);
            item_manager.Item_Name = item.Item_Name;
            item_manager.Item_Image = item.Item_Image;
            item_manager.Item_Prefab = item.Item_Prefab;
            item_manager.name = item.name;
        }
    }

    public void CrearSofas()
    {
        FuncionSofas();
        LimpiarLista();

        foreach (var item in lista_sofas)
        {
            Item_Manager item_manager;
            item_manager = Instantiate(_item_manager_sofas, content_lista_sofas.transform);
            item_manager.Item_Name = item.Item_Name;
            item_manager.Item_Image = item.Item_Image;
            item_manager.Item_Prefab = item.Item_Prefab;
            item_manager.name = item.name;
        }
    }

    public void CrearSillones()
    {
        FuncionSillones();
        LimpiarLista();

        foreach (var item in lista_sillones)
        {
            Item_Manager item_manager;
            item_manager = Instantiate(_item_manager_sillon, content_lista_sillones.transform);
            item_manager.Item_Name = item.Item_Name;
            item_manager.Item_Image = item.Item_Image;
            item_manager.Item_Prefab = item.Item_Prefab;
            item_manager.name = item.name;
        }
    }

    #endregion


    public void ActivarTodo()
    {


        if (all_active == false)
        {
            PANEL_vertical_muebles.SetActive(true);
            PANEL_VERTICAL_BOTON.SetActive(true);

            rotate_BUT.gameObject.SetActive(true);
            escale_BUT.gameObject.SetActive(true);
            position_but.gameObject.SetActive(true);
            quit_MUEBLE_BUT.gameObject.SetActive(true);
            take_pic_but.gameObject.SetActive(true);
            all_active = true;
        }
        else
        {
            PANEL_vertical_muebles.SetActive(false);
            PANEL_VERTICAL_BOTON.SetActive(false);

            rotate_BUT.gameObject.SetActive(false);
            escale_BUT.gameObject.SetActive(false);
            position_but.gameObject.SetActive(false);
            quit_MUEBLE_BUT.gameObject.SetActive(false);
            take_pic_but.gameObject.SetActive(false);
            all_active = false;

        }
       
    }

    public void Quitt()
    {
        Application.Quit();
    }

}


