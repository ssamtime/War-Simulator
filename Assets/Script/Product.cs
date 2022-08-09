using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Product", menuName = "Scriptalbe Object/Product", order = 1)]
public class Product : ScriptableObject
{
    public int price;
    public Sprite border;
    public Sprite picture;
    public Sprite priceTag;

}
