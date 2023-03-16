using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Item_Manager : MonoBehaviour
{
    public string Item_Name;
    public Sprite Item_Image;
    public GameObject Item_Prefab;

    private void Start()
    {
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Item_Name;
        transform.GetChild(2).GetComponent<Image>().sprite = Item_Image;

        var button = GetComponent<Button>();
        button.onClick.AddListener(CreateItem);
    }


    private void CreateItem()
    {
        // Creamos un gameObject donde lo pondremos como hijo del ARPointer de la clase ARInteractionsManager
        GameObject itemToInstantiate = Instantiate(Item_Prefab);
        itemToInstantiate.transform.position = AR_Interactions_Manager.instance.ARPointer.transform.position;
        itemToInstantiate.transform.parent = AR_Interactions_Manager.instance.ARPointer.transform;

        // Asignamos como valor de la variable ItemObjetoPrefab el gameObject que acabamos de crear
        AR_Interactions_Manager.instance.ItemObjetoPrefab = itemToInstantiate;

        AR_Interactions_Manager.instance.IsInitialPosition = true;

    }
}
