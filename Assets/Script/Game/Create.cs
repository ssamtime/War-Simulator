using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Create : MonoBehaviour
{
    [SerializeField] Product product;
    [SerializeField] Image border;
    [SerializeField] Image picture;
    [SerializeField] Image priceTag;
    [SerializeField] Text price;
    [SerializeField] Button createButton;

    private bool check;

    private void Start()
    {
        border.sprite = product.border;
        picture.sprite = product.picture;
        priceTag.sprite = product.priceTag;
        price.text = product.price.ToString()+" $";
    }
    public void Update()
    {
        
    }
    public void CreateUnit(int count)
    {
        
        SoundManager.Instance.Sound(0);
        switch(count)
        {
            case 0: Instance("Goblin",product.price);
                StartCoroutine(Wait(3.0f));
                break;

            case 1:
                Instance("Wizard", product.price);
                StartCoroutine(Wait(5.0f));
                break;
        }
    }
    public void Instance(string name,int price)
    {
        if (DataManager.instance.money >= price)
        {
            DataManager.instance.money -= price;

            Instantiate(
            Resources.Load<GameObject>(name),
            new Vector3(-15, 1, 15),
            Quaternion.Euler(0, 90, 0));

            DataManager.instance.Save();
        }
        else
            return;
        
    }
    public IEnumerator Wait(float timer)
    {
        
        createButton.interactable = false;
        while(timer>1.0f)
        {
            check = false;
            timer -= Time.deltaTime;
            createButton.image.fillAmount = (1.0f / timer);
            yield return new WaitForFixedUpdate();
        }

        check = true;
        createButton.interactable = true;
        
    }
}
