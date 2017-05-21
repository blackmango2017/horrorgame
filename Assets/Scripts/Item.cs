using UnityEngine;

[System.Serializable]
public class Item : System.ICloneable {

    public int _id = 1;
    public string _name = "TEST";
    public string _description = "테스트용";
    public Sprite image;
    public bool isEnable = true;

    public object Clone() {
        Item temp = new Item();
        temp._id = _id;
        temp._name = _name;
        temp._description = _description;
        temp.image = image;

        return temp;
    }
}
