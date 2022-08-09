using UnityEngine.UI;
using UnityEngine;

public class Create : MonoBehaviour
{
    [SerializeField] Product product;
    [SerializeField] Image border;
    [SerializeField] Image picture;
    [SerializeField] Text price;
    [SerializeField] Image priceTag;

    private void Start()
    {
        border.sprite = product.border;
        picture.sprite = product.picture;
        priceTag.sprite = product.priceTag;
        price.text = product.price.ToString()+" $";
    }
    public void CreateUnit(int count)
    {
        switch(count)
        {
            case 0: Instantiate
                    (   Resources.Load<GameObject>("Goblin"),
                        new Vector3(-15, 1, 15),
                        Quaternion.Euler(0,90,0)
                    );
                break;
            case 1:
                Instantiate
                (Resources.Load<GameObject>("Wizard"),
                    new Vector3(-15, 1, 15),
                    Quaternion.Euler(0, 90, 0)
                );
                break;
        }
    }
}
