## Game Design Document Simmac

#### Douwe Westerdijk & Nolan Bijmholt



### Gameplay overzicht

Jij speelt als restaurantmanager van Simmac. Je kunt rondlopen binnen het restaurant en de benodigde keuken- en servicefuncties bedienen door minigames te spelen. De kwaliteit van de bestellingen bepaalt de tevredenheid van de klant, wat zorgt voor hogere recensies.
Aan het einde van de dag krijg je een overzicht te zien met alle boekhoudgegevens van die dag. Dit dient ook als menu voor andere opties binnen het spel, zoals medewerkers aannemen of ingrediënten kopen. Er kunnen ook elke dag willekeurige evenementen plaatsvinden.

- #### Camera

    Simmac is een 2D-spel met een dynamische camera die de speler volgt, wanneer de camera te ver uitgezoomed is krijg je een overzicht van het hele restaurant met een vaste camera angle. Wanneer de speler minigames speelt, verandert de camera en de scène naar de benodigde positie. Dit verschilt per minigame.

- #### Speler

    De speler kan zich zowel in de x- als de y-as bewegen. Ook kan de speler botsen en interacteren met de wereld, zoals het vertragen wanneer de speler door medewerkers loopt of wanneer ze iets vasthouden.
    Daarnaast wordt de speler bestuurd met de muis, die bepaalt waar de speler heen kijkt en waarmee ze kunnen interacteren. Dit kan alleen met functies die zich binnen een vaste radius van de speler bevinden, wat wordt aangegeven met een muiscursor.

- #### Bestellingen

    Wanneer een klant een bestelling plaatst, wordt deze opgeslagen en weergegeven in de UI. Sommige bestellingen worden met een kleur aangegeven. De speler moet op basis van de bestelling naar de juiste stations gaan, de juiste producten maken en eventueel een kleur kiezen.
    Wanneer een product is gemaakt, wordt deze op de OAT (Order Assembly Table) geplaatst. Zodra alle producten voor een bestelling op de OAT liggen, wordt de bestelling automatisch klaargemaakt en afgegeven.

- #### OAT

    Wanneer producten op de OAT liggen, verslechtert hun kwaliteit na verloop van tijd. Daarom is het niet aan te raden om producten te maken zonder dat ze besteld zijn of om met meerdere bestellingen tegelijk bezig te zijn. Zodra alle benodigde producten voor een specifieke bestelling op de OAT liggen, wordt deze automatisch afgeleverd. Oudere bestellingen krijgen automatisch prioriteit. Ook kan de speler producten uit de OAT weggooien, dit is handig wanneer er te oude producten in liggen.