# SSWDI - Serverside Web development-indi

## Status

- [![Build Status](https://dev.azure.com/AS-SWDI/AnimalShelter/_apis/build/status/AnimalShelter-ASP.NET%20Core-CI?branchName=master)](https://dev.azure.com/AS-SWDI/AnimalShelter/_build/latest?definitionId=1&branchName=master)

## Services

 - Management: https://as-wj.azurewebsites.net/
 - API (v2): https://as-api-wj.azurewebsites.net/swagger
 - Adoption:  https://as-adoption-wj.azurewebsites.net/

## AnimalShelter contains:

 - A UI for Management & Adoption of animals
 - Two API's one on Lvl 2 (Verbs) and one on Lvl 3 (HATEOAS)
	- This is done for seperation of concerns
 - Clean Architecture (Domain Models, services, Repository - Interface pattern)
 - Generic Repository for less repetition
 - Seperate Identity instance


## User stories
- US_01 Als vrijwilliger wil ik een nieuw dier kunnen inschrijven in het asiel, zodat het ter adoptie aan
kan worden geboden. (DONE)
- US_02 Als medewerker wil ik de status van een dier bij kunnen werken, zodat altijd de juiste
informatie voor een toekomstige eigenaar inzichtelijk is. (DONE)
- US_03 Als klant wil ik een overzicht hebben van alle dieren die op dit moment adopteerbaar zijn,
zodat ik weet of er een dier in de opvang zit die interessant voor mij kan zijn. (WIP)
 - US_04 Als klant wil ik interesse kunnen tonen in een dier, zodat de vrijwilligers weten dat er een
potentiële nieuwe eigenaar komt kijken.  (WIP)
- US_05 Als klant wil ik een dier ter adoptie aan kunnen melden, zodat het asiel een afspraak met mij
kan maken voor het afleveren van het dier. (DONE, apart from Identity in Adoption)

## Business rules

- BR_1. Het maximaal te plaatsen dieren per verblijf wordt niet overschreden.
- BR_2. Niet gesteriliseerde/gecastreerde dieren kunnen niet qua geslacht gemengd
geplaatst worden in hetzelfde verblijf.
- BR_3. Een behandeling kan niet in worden gevoerd als het dier nog niet in het asiel is
opgenomen of nadat het dier overleden is.
- BR_4. Bij een aantal behandelingen is een toelichting verplicht.
- BR_5. Voor een dier moet ofwel de leeftijd uit worden gerekend aan de hand de
geboortedatum of de geschatte leeftijd moet ingevuld zijn.


## Sources used
- https://wildermuth.com/2018/08/12/Seeding-Related-Entities-in-EF-Core-2-1-s-HasData()
- https://www.yogihosting.com/aspnet-core-consume-api/#create