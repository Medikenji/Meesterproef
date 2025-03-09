# Klassendiagram uitbreiding

### Start Scene

Start scene uses Unity UI stuff we don't really need any new classes here

### Game Scene
The classes are written in kinda C# pseudo code

If I add an (?) after keywords like 'public' or 'private', it means I am unsure if that level of protection is the correct one for the variables in the class. Just keep that in mind when reading them, this is a first draft as this document is on version **1** of probably many.

```C#
class Player
{
    private GameManager _simmac;

    void Movement();
}
```

```C#
// GameManager was called Simmac before, on second thought I found GameManager to be a more suitable name - Dhw
class GameManager
{
    // Singleton jargon
    private GameManager _instance;

    public GameManager Instance()
    {
        if (_instance == null)
        {
            _instance = new();
        }
        return _instance();
    }

    // Game oriented code
    public List<Order> orders;
}
```

```C#
class Customer
{
    public(?) Order order;
}
```

```C#
class Order
{
    // All types are nullable because an order doesn't need to satisfy all fields
    public Drink? drink;
    public Desert? desert;
    public Fries? fries;
    public Burger? burger;
}
```

```C#
class OrderableItem
{
    // Does the customer have this item
    public(?) bool IsDelivered;

    // byte used because range is from 0-100
    public byte quality;
}
```

```C#
class Burger : OrderableItem
{
    enum Variant
    {
        normal,
        red,
        green,
        blue
    }

    // Burger modifier
    public Variant variant;
}
```

```C#
class Desert : OrderableItem
{

}
```

```C#
class Drink : OrderableItem
{

}
```

```C#
class Fries : OrderableItem
{

}
```

```C#
class Station
{

}
```

```C#
// Does the player click on the station, or does the station listen for the player's click to start interaction? - Dhw
class SceneStation : Station
{
    // Scene the station launches when the player interacts with it, perhaps through OnClick? - Dhw
    public(?) Scene scene;
}
```

```C#
class InteractableStation : Station
{
    // idrk how to properly model this class, it should just... *do* something when interacted with (eg. fulfill an order, or take an order) but I'm unsure rn how we'd implement allat - Dhw
}
```

```C#
class OrderAssemblyTable : InteractableStation
{
    // Dict to ensure we keep track of when an item was made, to enforce first in first out. Although as I'm typing this I'm already puzzled why we'd use a Dict for this rather than a simple List? We'll check later - Dhw
    public(?) Dictionary<int, OrderableItem> itemsInOAT;
}
```

```C#
class Register : InteractableStation
{
    // The register holds the customers, which hold the orders, we keep track of all the customers in an ordered list, and every customer gives the GameManager their order. Feedback on this approach highly appreciated. - Dhw
    public List<Customer> customers
}
```

```C#
class BaggingStation : SceneStation
{
    // Base class SceneStation already has the neccesary code to add a scene that will launch on interaction with this class
}
```

```C#
class KitchenLine : SceneStation
{
    // Base class SceneStation already has the neccesary code to add a scene that will launch on interaction with this class
}
```

```C#
// Stupendous name but this is what McDonalds really calls the station where you make drinks and deserts - Dhw
class BeverageDesertAsProduction : SceneStation
{
    // Base class SceneStation already has the neccesary code to add a scene that will launch on interaction with this class
}
```

## Minigame Scenes

### Burger Minigame

### Fries Minigame

### Drinks Minigame

### Desert Minigame
