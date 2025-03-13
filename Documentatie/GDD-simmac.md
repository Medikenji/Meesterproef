## Game Design Document Simmac

#### Douwe Westerdijk & Nolan Bijmholt </br> Alfa College - 2024/2025
Versie 0.1.7
### Inhoud

- [Game Vision](#game-vision)
- [Technische Details](#technische-details)
- [Gameplay](#gameplay-overzicht)
    - [Camera](#camera)
    - [Speler](#speler)
    - [Producten](#producten)
    - [Bestellingen](#bestellingen)
    - [Order Assembly Table](#oat)
    - [Klanten](#klanten)
    - [Medewerkers](#medewerkers)
    - [Tussendaagse Menu](#tussendaagse-menu)
- [Minigames](#minigames)
    - [Burger Stack](#burger-minigame---burger-stack)
    - [Put the Fries In the Bag (PFIB)](#fries-minigame---put-the-fries-in-the-bag)
    - [Shake Shifter](#drinks-minigame---milkshake-shift)
    - [Sniper Showdown/ Pop the Cherry](#dessert-minigame---sniper-showdown--pop-the-cherry)
- [UI](#ui)
- [Eindes](#eindes)
- [Game Manager](#game-manager)
- [Progressie & Spelbalans](#progressie--spelbalans)
- [Evenementen & Speciale Mechanieken](#evenementen--speciale-mechanieken)
- [Achievements](#achievements)
- [Save States](#save-states)
- [Audiovisueel](#audiovisual)
- [Taakverdeling](#taakverdeling)
- [Speelduur & Moeilijkheid](#speelduur--moeilijkheid)

---

### **Game Vision**

*Simmac is een restaurant tycoon / simulator. Je speelt als de restauranteigenaar
van het restaurant Simmac. Het is jouw taak om de klanten tevreden te houden
door hun bestellingen op te nemen, de producten te maken, de bestelling af te
leveren, en het restaurant staande te houden.*

*Let op dat je klanten niet te lang laat wachten of slecht eten geeft! De toekomst
van het restaurant ligt in de recensies van je klanten. Hoe lang hou jij het vol?
Neem werknemers aan om de werkdruk te verlagen en ga de strijd aan tegen de
economie om je restaurant draaiende te houden!*

---

### **Technische Details**
- **Engine:** *Unity 6000.0.40f1*
- **Platform:** *PC*
- **Besturing:**
    - Bewegen: *WASD - Pijltjestoetsen*
    - Interactie: *(Linkermuisknop)*
    - Menu/Pauze: *(Escape)*

---

### **Gameplay overzicht**
Jij speelt als restaurantmanager van Simmac. Je kan rondlopen binnen het
restaurant en de benodigde keuken- en servicefuncties bedienen op de
stations te klikken en hun minigames te spelen.

Aan het einde van de dag krijg je een overzicht van de boekhoudgegevens
van het restaurant. Hier kun je kiezen om personeel aan te nemen en ingrediënten
te kopen.

#### **Camera**

Simmac is een 2D-spel met een dynamische camera die de speler volgt. Wanneer de
camera maximaal uitzoomt, krijg je het hele restaurant te zien. De camera
volgt de speler niet meer in deze staat, omdat je alles kan zien is de speler
altijd zichtbaar. Dit is handig om de kassa in de gaten te houden voor klanten
terwijl je zelf in de keuken staat.

#### **Speler**

De speler kan vrij rondlopen in het restaurant en interacteren met de wereld. De
speler beweegt met het toetsenbord en gebruikt de muis voor interacties.

Interactie is alleen mogelijk binnen een vaste radius rondom de speler.

#### **Producten**

Producten worden ingekocht, bereid en geserveerd. Dit is de taak van de speler. Bij het inkopen moet de speler er om denken dat producten maar een bepaalde tijd bruikbaar zijn en dus niet te veel koopt in verband met verspilling.

Ook hebben producten 4 verschillende types: standaard, rood, groen en blauw. Dit hoeft de speler niet in te kopen maar wordt wel gebruikt bij bestellingen.

Ook hebben producten een interne kwaliteits meter. Deze varieerd van 0 tot 100 en bepaald hoe tevreden de klant is met de bestelling door alle kwaliteiten bij elkaar op te tellen.

Op dit moment bevat het spel 4 producten: Milkshakes, burgers, friet en desserts.

#### **Bestellingen**

Een bestelling wordt geplaats wanneer een klant naar de kassa voorin het restaurant
loopt. De klant wacht voor de kassa totdat de speler hier heen loopt en op het
station (de kassa) klikt.

Wanneer een klant een bestelling plaatst, wordt deze opgeslagen in de Game Manager
en weergegeven in de UI. Bestellingen bestaan uit burgers, friet, drankjes en
desserts.

Al het eten kan een *modifier* hebben. Dit maakt het een andere soort burger, of
drankje. In Simmac zijn deze modifiers kleuren. Je kan voor het beginnen van een
minigame kiezen wat voor soort mofifier je wilt gebruiken om de bestelling juist te maken. 

De speler moet de juiste stations gebruiken om de bestelling te maken. Als een
product is gemaakt, wordt het op de Order Assembly Table (OAT) geplaatst.

Zodra alle producten voor een bestelling op de OAT liggen, wordt de bestelling
automatisch afgegeven.

#### **Order Assembly Table**

De Order Assembly Table (OAT) is een centrale verzamelplaats voor alle gemaakte
consumpties in de keuken. Alles wat in de keuken gemaakt wordt eindigt in de OAT voordat het naar een
klant gaat.

Wanneer producten langdurig in de OAT liggen verslechtert hun kwaliteit na verloop van tijd.
Het is niet aan te raden om producten te maken zonder bestelling.

Oudere bestellingen krijgen prioriteit naar de klant. De speler kan producten uit de OAT
weggooien als ze te oud zijn. Als je dit niet doet kan een verouderd product aan de klant
gegeven worden, waardoor de klant ontevreden zal zijn.

#### **Klanten**

Klanten bestellen bij de kassa. De bestelling wordt in de UI weergegeven.

Klanten hebben een tevredenheidsmeter en een kans om een recensie achter te laten.
Terwijl ze wachten, daalt hun tevredenheid. Deze timer bepaald de maximale tevredenheid die
een klant kan hebben. Stel een klant wacht te lang en heeft een tevredenheid van 90%, dan
is de beste tevredenheid voor deze klant dus 90%, ongeacht van hoe goed het eten is.

De tevredenheid van de klant is verder gebonden aan hoe goed het eten gemaakt is, en
hoe oud dit eten is. Als je de minigames goed speelt resulteert dit in eten van 100%
kwaliteit. Hoe langer eten in de OAT ligt, hoe lager de kwaliteit zal worden. De kwaliteit
van het eten daalt lineair.

Nadat ze hun bestelling krijgen, stijgt of daalt hun tevredenheid afhankelijk van
de kwaliteit van het eten. Daarna verlaten ze het restaurant.

Recensies worden beïnvloed door de bestellingen. Slechte of extreem goede
bestellingen hebben meer impact op de kans dat een recensie wordt achtergelaten.

#### **Medewerkers**

Medewerkers kunnen worden aangenomen in het tussendaagse menu. Om dit te doen moet je een startbonus betalen en daarna hebben ze een vast dag salaris dat 1 keer per week in 1 keer wordt uitbetaald.

Medewerkers hebben een vaardigheden meter die van 0-100 gaat, wanneer ze beginnen zal dit per medewerker verschillen maar wel aan de lage kant zitten. Elke dag dat ze werken gaat dit omhoog tot een vast limiet dat verschilt per medewerker.

Medewerkers worden aan het begin van de dag op een willekeurig station gezet. Hier blijven ze de hele dag en regelen ze het bereiden van de producten. Stations die door medewerkers gebruikt worden kunnen nog wel door de speler gebruikt worden.

De vaardigheden meter van de medewerkers bepaald hoe goed de kwaliteit van hun producten zijn maar ook hoe weinig fouten ze maken. Zo kunnen ze denken dat ze een juiste variatie van een product hebben gemaakt maar kan het verkeerde in de OAT liggen. Hierdoor moet de speler altijd op blijven letten dat bestellingen wel af gemaakt zijn.


#### **Tussendaagse menu**

Aan het einde van de dag krijgt de speler het tussendaagse menu. Hier wordt eerst een overzicht gepresenteerd voor alle inkomsten en uitgaves.

En daarna een menu gepresenteerd waar wat algemene statistieken staan (de huidige dag, hoeveel medewerkers, etc.). Ook kan de speler hier medewerkers aannemen, voorraad voorspellingen zien en bestellen en naar de volgende dag gaan. Ook krijgt de speler de optie wanneer genoeg geld is verzameld om het restaurant te verkopen om het spel te beëindigen.

---

### **Minigames**

Je start een minigame door op een station te klikken. Elk station waar je eten / drinken
maakt heeft een unieke minigame. Je kan alleen op de stations klikken als je er naast staat.
Na het spelen van de minigame, verschijnt de consumptie die je hebt gemaakt in de OAT

#### **Burger Minigame - Burger Stack**

De burger minigame is geïnspireerd op [Tower Stack](https://www.1001games.com/skill/stack-tower).
Het onderste broodje ligt onderaan het scherm, elk volgend ingrediënt beweegt van
links naar rechts.

De speler moet klikken om het onderdeel perfect te stapelen. Dit wordt steeds
moeilijker omdat de snelheid toeneemt.

#### **Fries Minigame - Put the Fries In the Bag**

In PFIB beweegt een frietzak onderaan het scherm. De speler beweegt de zak met A
en D of de pijltjestoetsen.

In het begin van het spel krijg je een frietzak van willekeurige grootte, deze
zijn small, medium & large. Grotere frietzakken maken het spel makkelijker. De
score hangt af van de hoeveelheid frieten die de speler vangt.

#### **Drinks Minigame - Shake Shifter**

De speler ziet een transparante milkshakebeker met een percentage bovenaan. Een
kleur beweegt op en neer en vult de beker tijdelijk.

De speler moet klikken wanneer de vulling exact overeenkomt met het percentage.

#### **Dessert Minigame - Sniper Showdown / Pop the Cherry**

De speler staat op een schietbaan en moet een kers op een ijsje schieten. Dit doet de speler met behulp van instrumenten zoals zijn afstandsmeter, windmeter en geweer.

De speler krijgt vier pogingen om het kersje er goed op te schieten. Bij elke misser gaat de kwaliteit met een vaste hoeveelheid omlaag en als de speler alles mist wordt de kwaliteit een vaste lage waarde.

---

# alles na dit punt moet nog ingevuld worden



### **UI**
*(Beschrijf de verschillende schermen en HUD-elementen.)*

---

### Eindes
*(Benoem verschillende eindes en hun impact op de score)*

---

### **Game Manager**
*(Leg uit hoe de game manager bestellingen, klanten en economie beheert.)*

---

### **Progressie & Spelbalans**
*(Hoe wordt het spel moeilijker? Welke upgrades zijn er?)*

---

### **Evenementen & Speciale Mechanieken**
*(Welke random events zijn er? Bijvoorbeeld inspecities, storingen, etc.)*

---

### **Achievements**
*(Welke achievements zijn er en hoe worden ze behaald?)*

---

### **Save States**

De gebruiker krijgt 1 actieve save of mee te spelen, deze save laad de gamemanager in die alle benodigde info heeft om het spel op de juiste manier op te zetten.

Het spel wordt aan het eind van de dag opgeslagen in het tussendaagse menu, of aan het einde van de dag wanneer de speler failliet is. Hierdoor kun je halverwege de dag stoppen om het opnieuw te proberen.

Wanneer het spel wordt geladen verschijnt of het begin van de dag als je halverwege de dag stopt, het tussendaagse menu wanneer je de vorige keer aan het eind van de dag bent gestopt of het failliet scherm als je aan het einde van de dag bent gestopt en failliet bent.

---

### **Audiovisueel**
*(Beschrijf hoe de game eruitziet en klinkt.)*

---

### **Taakverdeling**
*(Wie is verantwoordelijk voor welk onderdeel?)*

---

### **Speelduur & Moeilijkheid**
*(Hoe lang duurt een gemiddelde sessie? Welke moeilijkheidsgraden zijn er?)*

---
