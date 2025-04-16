## Verbeter Voorstel Simmac<br/>

**Douwe Westerdijk | Nolan Bijmholt**

### Inhoudsopgave

### Inleiding

In dit document staat alles wat er nog nodig is om het prototype van Simmac verder uit te werken. Alle voorstellen zijn gebaseerd op het testrapport en een hernieuwde blik op de tot dusver voltooide demo van het Simmac prototype.

### Test resultaten

**Tutorial GUI**<br/>
***Geschatte tijdsduur: 2 dagen***

Alle minigames hebben nog een GUI nodig die uitlegt hoe de spellen werken. Hoewel dit niet bij elk spel voor problemen zorgde, is het voor de consistentie wel wenselijk om dit bij alle spellen toe te voegen. Dit scherm zal verschijnen zodra een spel voor het eerst wordt gespeeld in een nieuwe save.
Dit komt in de vorm van een uitleg video met bijbehoorende tekst.

---

**Bugs**<br/>
***Geschatte tijdsduur: 3 dagen***

Er zijn ook enkele bugs gevonden, zoals visuele bugs bij Shake Shifter en een collision-bug bij Put the Fries in the Bag (PFIB). Daarnaast lijkt het bij PFIB onmogelijk om het spel perfect uit te voeren. Daarom is het, naast het oplossen van de collision-bug, ook belangrijk om te kijken naar een mogelijke herziening van het puntensysteem.

Ook is er bij alle spellen een probleem met het correct verwijderen van assets nadat een spel is gespeeld. Dit leidt niet per se tot directe logistieke bugs, maar kan wel gevolgen hebben voor de performance en de gameplay.

---

**Sniper Showdown**<br/>
***Geschattte tijdsduur: 2 dagen***

Sniper Showdown is over het algemeen positief ontvangen, maar er waren wel opmerkingen over de moeilijkheidsgraad en de initiële begrijpelijkheid van het spel. Er zullen GUI-elementen toegevoegd moeten worden om de besturing duidelijker te maken, en ook hints voor de eerste keer spelen om het doel van het spel beter uit te leggen.

---

**Audio visuele eisen**<br/>
***Geschatte tijdsduur: 15 dagen***

Er was ook kritiek op de audiovisuele aspecten van het spel. Dit was te verwachten, aangezien het doel van deze demo vooral was om de gameplay te demonstreren. Uiteindelijk zullen er echter wel hoogwaardige audiovisuele assets gemaakt en geïmplementeerd moeten worden.

Hoewel we momenteel gebruikmaken van basisassets voor een minimale visuele ervaring, zal waarschijnlijk alles inclusief de UI, de hoofdgame en de minigames opnieuw ontworpen moeten worden door iemand met ervaring en expertise. Deze persoon zal ook nodig zijn voor het ontwikkelen van nieuwe assets voor toekomstige functies, wat betekent dat we ons team zullen moeten uitbreiden.

Het implementeren van alle huidige benodigde assets zal naar verwachting ongeveer 15 dagen kosten. Bij het toevoegen van nieuwe features zal het werk aan de audiovisuele elementen continu moeten worden voortgezet.

### Nog niet geimplementeerde features

**Code refactoren**
***Geschatte tijdsduur: 3 dagen***

De huidige code is sterk gericht op de functionaliteiten van de eerste demo. Dit maakt het testen en presenteren van het spel voorlopig soepel, maar om het spel verder uit te breiden, zal de codebase moeten worden gerefactord voor betere onderhoudbaarheid. Dit houdt onder andere in dat er meer comments toegevoegd moeten worden en dat de onderlinge relaties tussen de classes opnieuw ontworpen moeten worden.

---

**Medewerkers**<br/>
***Geschatte tijdsduur: 5 dagen***

Een geplande feature die de gameloop van Simmac verder zal uitbreiden, is de mogelijkheid om medewerkers in te huren. Dit voegt extra kosten toe tijdens het spel, maar vermindert ook de werkdruk voor de speler, waardoor er meer ruimte ontstaat om zich te richten op andere taken binnen het spel.

Er is op dit moment nog geen specifieke code geschreven voor het medewerkerssysteem, maar er bestaan al wel helperfuncties die de implementatie kunnen ondersteunen. Ook bij het refactoren van de code zal rekening gehouden worden met deze toekomstige uitbreiding.

---

**Inventaris**<br/>
***Geschatte tijdsduur: 7 dagen***

Een geplande feature die de gameloop van Simmac complexer zal maken, maar ook interessanter voor de speler is het toevoegen van een inventarissysteem.

Dit systeem dwingt de speler om zijn geld beter te beheren op basis van voorspellingen die het spel geeft. De inventaris bepaalt hoeveel er nog van elk product geproduceerd kan worden, en producten in de inventaris zullen kunnen bederven. Hierdoor moet de speler goed nadenken over hoeveel hij koopt en produceert.

Bij het refactoren van de code zal rekening worden gehouden met dit nieuwe systeem, zodat de uiteindelijke implementatie soepeler kan verlopen. De huidige codebase is hier namelijk nog niet op voorbereid.

---

**Evenemeten**<br/>
***Geschatte tijdsduur: 6 dagen***

Er moeten ook meer evenementen aan het spel worden toegevoegd. De code voor het eventsysteem is al aanwezig, maar er moeten nog extra evenementen worden bedacht en geïmplementeerd om het spel dynamischer, interessanter en iets chaotischer te maken.

---

**Gamefeel**<br/>
***Geschatte tijdsduur: 12 dagen***

Het spel moet grondig getest worden, en op basis van toekomstige feedback uit nieuwe tests zullen we het spel zorgvuldig moeten balanceren. Dit is nodig om ervoor te zorgen dat alle systemen goed en stabiel met elkaar samenwerken.

Hoewel veel van deze balansverbeteringen al zullen plaatsvinden tijdens de ontwikkeling van nieuwe features, is het ook belangrijk om het volledige spel in een betafase te testen. Dit stelt ons in staat om het spel foutloos en volledig gepolijst te publiceren.

---

Dit document geeft een inschatting van wat er nog geimplementeerd moet worden maar omdat dit spel zal updates blijven ontvangen wanneer in de er in de toekomst behoefte is aan updates.