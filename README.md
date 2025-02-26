## Simmac: Fast food simulator

---

> ### Inhoud

- [Samenvatting](#samenvatting)
- [Gameplay](#gameplay)
- [Visueel](#visueel)
- [Scoring](#scoring)
- [AI](#ai)

---

> ### Samenvatting

In het spel speel jij als de manager van het fastfoodrestaurant Simmac. Het is jouw verantwoordelijkheid om klanten tevreden te houden door eten te serveren en tegelijk 
het restaurant niet failliet te laten gaan. In het begin regel jij alles zelf, maar naarmate het restaurant bekender en drukker wordt, zul je mensen in moeten huren om 
te helpen en de drukte aan te kunnen. Dit doe je totdat je besluit het restaurant te verkopen of wanneer je failliet gaat.

---

> ### Gameplay

Jij speelt als een restaurantmanager van Simmac. Je kunt rondlopen binnen het restaurant en de benodigde keuken- en servicefuncties bedienen. Wanneer je een bestelling opneemt, 
wordt deze in de UI opgeslagen. Je moet vervolgens de bestelling maken en serveren door minigames te spelen. Deze minigames bepalen de kwaliteit van het product en 
daardoor de tevredenheid van de klant. Dit doe je de hele dag door. Aan het einde van de dag krijg je een overzicht te zien met alle boekhoudgegevens. Hier kun je ook 
ingrediënten kopen voor de volgende dag, maar let op: eten kan bederven. Daarnaast kun je besluiten om medewerkers aan te nemen. Er kunnen ook elke dag willekeurige evenementen 
plaatsvinden.

#### Minigames

Wanneer je bezig bent met een bestelling, moet je minigames uitvoeren. Deze minigames kosten een vaste hoeveelheid tijd en bepalen op basis van jouw prestaties de kwaliteit 
van de bestelling.

#### Medewerkers

Medewerkers huur je in door een startbonus te betalen en elke dag een vast salaris te geven. Medewerkers kunnen beïnvloed worden door evenementen. In het begin hebben medewerkers 
vaak een laag vaardigheidsniveau, wat hun prestaties matig maakt. Dit verlicht de druk voor de speler, maar kan nadelig zijn voor de klanten. Hoe langer een medewerker in jouw 
restaurant werkt, hoe beter ze worden in hun werk, waardoor dit nadeel na verloop van tijd afneemt. Ook zijn er verjaardagen, waardoor het salaris van een medewerker elke 100 
dagen na hun verjaardag zal stijgen. De startbonus wordt ook hoger elke keer dat een medewerker vertrekt.

<div style="page-break-after: always;"></div>

#### Evenementen

Gedurende het spel kunnen willekeurige evenementen plaatsvinden, die positief of negatief kunnen zijn en invloed hebben op jou, de klanten of jouw medewerkers. Ernstigere 
evenementen zijn zeldzamer. Voorbeelden zijn een onverwachte voetbalwedstrijd die veel klanten aantrekt of een stroomuitval die je een dag zonder inkomen laat.

#### Recensies

Klanten laten recensies achter op basis van hun ervaring. Dit bepaalt de uiteindelijke score van jouw restaurant, wat weer invloed heeft op het aantal klanten dat je 
ontvangt. Recensies kunnen echter ook sneller negatief worden, waardoor het restaurant altijd onstabiel blijft.

---

> ### Visueel

Het spel wordt gepresenteerd in 2D pixelart, vanuit een top-down perspectief. De camerahoek en graphics zijn geïnspireerd door 
[Hotline Miami](https://store.steampowered.com/app/219150/Hotline_Miami/) (zonder het geweld).

---

> ### Scoring

Het spel eindigt wanneer je besluit het restaurant te verkopen, dit kan alleen nadat het restaurant een bepaalde waarde heeft bereikt of wanneer je failliet gaat of sterft. 
De score wordt bepaald door de waarde van het restaurant op het moment dat het spel eindigt, plus de hoogste waarde die het restaurant ooit heeft gehad. Daarnaast kun je 
score-multipliers krijgen afhankelijk van de eindes die je behaalt.

---

> ### AI

De AI bestaat uit drie onderdelen:

- De game manager
- De klanten
- De medewerkers

#### Game Manager

De game manager bepaalt hoeveel klanten er verschijnen en welke medewerkers beschikbaar zijn om te huren. Ook zorgt deze ervoor dat de evenementen op een gebalanceerde 
manier plaatsvinden.

#### Klanten

Klanten hebben een tevredenheidsmeter en een willekeurige kans om een recensie achter te laten.

#### Medewerkers

Medewerkers hebben een vaardigheidsniveau dat moet worden omgezet naar hun werkprestaties. Ze kunnen ook worden beïnvloed door externe factoren.
