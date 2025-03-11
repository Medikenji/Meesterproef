## Game Design Document Simmac

#### Douwe Westerdijk & Nolan Bijmholt </br> Alfa College - 2024/2025

### Inhoud

- [Inleiding](#inleiding)
- [Gameplay](#gameplay-overzicht)
    - [Camera](#camera)
    - [Speler](#speler)
    - [Bestellingen](#bestellingen)
    - [OAT](#oat)
    - [Klanten](#klanten)

### Inleiding

Simmac is een restaurant tycoon / simulator. Je speelt als de restauranteigenaar van het restaurant Simmac. Het is jouw taak om de klanten tevreden te houden door hun bestellingen op te nemen, de producten te maken, en de bestelling afleveren. Let op om de klanten niet te lang te laten wachten of ze slecht kwaliteit eten te geven! De toekomst van het restaurant is in de handen van de recensies van je klanten. Hoe lang hou jij het vol? Neem werknemers aan om de werkdruk te versprijden, en ga de strijd aan tegen de economie om je restaurant zo lang mogelijk draaiend te houden!

<div style="break-after: page"></div>

### Gameplay overzicht

Jij speelt als restaurantmanager van Simmac. Je kan rondlopen binnen het restaurant en de benodigde keuken- en servicefuncties bedienen door minigames te spelen. De kwaliteit van de bestellingen bepaalt de tevredenheid van de klant, wat zorgt voor hogere recensies.
Aan het einde van de dag krijg je een overzicht te zien van alle boekhoudgegevens van de dag. Dit dient ook als menu voor andere opties binnen het spel, zoals medewerkers aannemen of ingrediënten kopen. Er kunnen ook elke dag willekeurige evenementen plaatsvinden.

- #### Camera

    Simmac is een 2D-spel met een dynamische camera die de speler volgt, wanneer de camera maximaal uitgezoomed is krijg je een overzicht van het hele restaurant met een vaste camera angle. Wanneer de speler minigames speelt, verandert de camera naar de benodigde positie en hoek. Dit verschilt per minigame.

- #### Speler

    De speler kan vrij rondlopen in het restaurant. Ook kan de speler botsen en interacteren met de wereld, zoals het vertragen wanneer de speler door medewerkers loopt, of wanneer ze iets vasthouden.
    De spelers beweging bestuur je met je toetsenbors. De muis wordt gebruikt om te interacteren met de verschillende stations in het restaurant. Dit kan alleen met functies die zich binnen een vaste radius van de speler bevinden. Deze afstand is een grid unit om de speler heen.

- #### Bestellingen

    Wanneer een klant een bestelling plaatst, wordt deze opgeslagen in de Gamemanager van Simmac, en weergegeven in de UI. Bestellingen bestaan uit vier mogelijke elementen: Burgers, Friet, Drinks, en Deserts. De speler moet op basis van de bestelling naar de juiste stations gaan, de juiste producten maken en eventueel een kleur kiezen.
    Wanneer een product is gemaakt, wordt deze op de OAT (Order Assembly Table) geplaatst. Zodra alle producten voor een bestelling op de OAT liggen, wordt de bestelling automatisch klaargemaakt en afgegeven.

- #### OAT

    Wanneer producten op de OAT liggen, verslechtert hun kwaliteit na verloop van tijd. Het niet aan te raden om producten te maken zonder dat ze besteld zijn of om met meerdere bestellingen tegelijk bezig te zijn. Zodra alle benodigde producten voor een specifieke bestelling op de OAT liggen, wordt deze automatisch afgeleverd. Oudere bestellingen krijgen automatisch prioriteit. Ook kan de speler producten uit de OAT weggooien, dit is handig wanneer er te oude producten in liggen.

- #### Klanten

    Klanten hebben een tevredenheidsmeter en een interne kans om een recensie achter te laten. Nadat klanten hebben besteld en betaald, wachten ze in het restaurant. Zo lang ze wachten, gaat hun tevredenheidsmeter omlaag.
    Hoe veel de meter omlaag gaat, verschilt per klant. Nadat ze hun bestelling hebben gekregen, gaat de tevredenheidsmeter omhoog of omlaag op basis van de kwaliteit van hun bestelling. Nadat ze hun bestelling hebben ontvangen, vertrekken ze direct en laten ze mogelijk een recensie achter. Dit hangt af van hun interne recensie-kans, maar ook van hun bestelling; een hele goede of hele slechte bestelling verandert de kans op een recensie.

### Minigames

De producten in Simmac worden gemaakt door naar een station te lopen in het restaurant. Wanneer je naast een station staat kan je met de muis hierop klikken. Hierdoor komt een popup tevoorschijn waarin je kan kiezen wat voor product je wil maken (bv. voor burgers, is deze normaal, rood, blauw, ect).

- #### Burger Minigame - Burger Stack

    De burger minigame is geinspireerd op [Tower Stack](https://www.1001games.com/skill/stack-tower). Het onderste broodje van de burger ligt op de onderkant van het scherm, en elk volgend onderdeel van de burger slide van links naar rechts en terug over het broodje (net zoals in tower stack, maar dan zonder de alternatieve hoeken). Het is de speler hun taak om in te klikken wanneer dit onderdeel perfect boven het onderdeel eronder ligt. Dit zal heel makkelijk zijn voor de eerste onderdelen, maar na elk onderdeel gaan de volgende sneller heen en weer bewegen, waardoor de timing lastiger is.

-   #### Fries Minigame - Put the fries in the bag

-   #### Drinks Minigame - Milkshake Shift

-   #### Dessert Minigame - Sniper Showdown / Pop the cherry

### UI

### Game Manager

### Achievements

### Save States

### Audiovisual

### more?
