## Taken

- Nolan
    - Saving states
    - Achievements
    - Minigames
        - Sniper showdown
    - Camera
    - Game manager
    - Item

- Douwe
    - Player movement
    - Player colliders
    - Asset design
        - Player
        - Floor
        - Walls
        - Basic devart for stations
        - Customer
    - OnClick interaction for stations
    - Minigames
        - Burger Stack
        - Put the fries in the bag
        - Shake shift

### Gameplay

- Player movement
    - Colliders (layer based?)
- OnClick interaction with stations
- Saving states
    - Can quit and continue later
    - Several saves?
- Achievements
    - Make easy to implement
- Customer -> GameManager -> Player <- OAT sharing orders code, actually no clue how technical this is
- Scene communication (the burger minigame should result in a burger of x type being placed in the OAT)
- Minigames
    - Global functionality to manage which order a minigame returns and its quality
    - Burger stack
    - Fry catcher
    - Shake shift
    - Sniper Showdown / Pop the cherry
- Camera
    - camera zoom
    - camera follow
- Customers
    - Review logic
    - Happiness logic
    - Order logic
- Items
    - Quality implementation
    - Oat interaction
- Restaurant inventory?
- UI
    - Day end menu
    - Orders
    - Popups for orders
- Economy


### Visual

- Assets Design
    - Player
        - animations
        - angles
    - Customer
        - Color coding?
    - Map spritesheet
        - floor
        - walls all angles
        - register
        - deepfryer
        - grill
        - table (for customers ofc, they wont sit but we need to pretend)
        - chair
        - stations
            - line kitchen (assemble burgers here)
            - fries bagging station
            - drinks & dessert dispensers
            - OAT (burgers, fries, drinks ect. end up here)
            - register out front
    - Static sprites
        - burger
        - fries
        - drink
        - dessert
