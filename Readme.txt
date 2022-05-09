Read me for bachelorprosjektet ved TietoEvry

##############################################

For å åpne dette prosjektet åpner man .sln (solution) filen inne i dette repoet med MVS (Microsoft Visual Studio)

Dette prosjektet er delt inn i to del prosjekter:

			1. MyPagePrototype		- Hoved programmet, hvor kildekoden til tjenesten ligger
			2. MyPagePrototype.Tests	- Unit tester for testing av den utviklede tjenesten

Kommentarer i koden rundt klassene og metodene er skrevet for å gjøre løsningen lettere å sette seg inn i

###############################################

MyPagePrototype

Navnet til prosjektet er valgt ut ettersom vi skulle utvikle noe som kunne passe inn i MinSide løsningen til Kristiansand kommune.
Vi har derfor forsøkt å lage så forklarende navn som mulig. 

App_Start:

I App_Start mappen defineres rutingen og hvordan tjenesten kobler sammen view-ene og controller-ene. I tillegg til dette ligger
CustomAuthorize klassen. Denne klassen arver fra AuthorizeAttribute klassen i MVC tillegget. Denne klassen tar seg av omruting om bruker ikke
er autorisert til å se en gitt side. Dette vil da sende bruker tilbake til front siden (Logg inn). 

Content: 

Content mappen inneholder style filer for bootstrap. I tillegg til dette ligger det CSS filer for de ulike view-ene i tjenesten. Site.css er 
fra kommunen sin egen løsning, og brukes på front og placeholder sidene. CSS filene er veldig modulære for å gjøre det enkelt å arbeide med.
Navbar.css er definisjonen av nav baren som brukes til innsendings sidene.

Controllere:

Controller mappen holder alle kontrollerene og håndterer request ene som kommer i tjenesten.
 
	HjemController:
	- Index
		Denne handlingen gir bruker front siden.
	- LoggInn
		Denne handlingen er implementert for å simulere innlogging. Dette håndteres av IdPortalen i dag, og er noe vi ikke tar stilling til
	- LoggUt
		Denne handlingen er implementert for å simulere utlogging.
	- Placeholder 
		Dette er sider som ikke har noe innhold. Dette ettersom det er noe vår løsning ikke tar stilling til.
	- Dispose
		Denne handlingen frigir ressurser i sammenheng med databasen. 


	InnboksController:
	- Index 
		Denne handlingen viser en liste over meldinger til en gitt bruker
	- Slett 
		Denne handlingen sletter en gitt melding
		

	KontaktInfoController:
	- Send (uten parameter) 
		Denne viser et forhåndsutfylt skjema som kan redigeres om bruker ønsker.
	- Send (med parameter) 
		Denne tar imot utfylt skjema og ruter slik at en kvittering blir generert og kvittering vises.
		

	KvitteringController: 
	- GenKvittering 
		Denne kommer etter send funksjonen. Denne genererer en ny kvittering basert på innsendt byggesak og kontaktinfo
		og ruter til detaljer
	- Detaljer 
		Denne henter og viser en kvittering til bruker basert på id
		

	MineByggesakerController:
	- Index 
		Denne viser en liste over registrerte byggesaker for en gitt bruker
	- Registrer (uten parameter) 
		Denne viser et skjema for registrering av en ny byggesak. 
	- Registrer (med parameter) 
		Denne tar imot og registrerer en ny byggesak basert på innsendt skjema
	- FjernEndring 
		Denne kjører hvis en feil under innsendingen oppstår, slik at byggesaken fjernes og kan sendes inn på nytt. 
		

	ProfilController:
	- Index 
		Denne viser da bare dataene som ligger lagret på bruker
		
DAL:

DAL (Data access layer) mappen inneholder to klasser for å lage en database kontekst og så en initialisererklasse som fyller denne
konteksten med dummy data. Kontekst klassen definerer databasens oppbyggning og forholdene mellom entitetene i tjenesten. Databasen
settes også her til å begynne blank hver gang man starter tjenesten. 

Model:

Model mappen inneholder klassene eller entitetsdefinisjonene. Dette vil da være de ulike objektene som brukes av tjenesten og funksjonene 
den bruker. Bruker klassen definerer en innlogget bruker og personens informasjon. Byggesak klassen definerer infoen tilknyttet en byggesak.
Kontaktinfo klassen definerer den person informasjonen bruker ønsker å knytte til en gitt byggesak. Kvittering definerer en samling av
informasjon som knytter sammen den gitte byggesak men kontaktinfo. Melding klassen definerer meldinger som kan komme til en bruker i den 
digitale postkassen, eller innboks løsningen. 

Resources:

Resources mappen inneholder dummy data som eventuelt kunne kommet fra AI tjenesten til Norkart. Her har vi et eksempel på et matrikkel kart
og et ortofoto. I tillegg til dette har vi en pdf fil som forklarer en gitt sak, som kobles til en gitt melding.

View:

Så kommer view mappen. Her ligger alle view-ene til tjenesten. Dette er da hva bruker interagerer med. Har vi igjen en mappe for hver av 
controllerene til tjenesten. 

View-ene er: 

	- Hjem viser front siden. I tillegg til dette ligger et placeholder view her. Dette er en side som sender
	  bruker tilbake til den delen av tjenesten vi har utviklet. Placeholder viewet er et view som er istedenfor de sidene vi ikke har tatt stilling
	  til i denne tjenesten. 

	- Innboks viewet er for å vise en liste over meldingene som er sendt til en gitt bruker. 

	- Kontaktinfo viewet viser et utfylt skjema for en ny byggesak.

	- Kvittering viewet viser en samling av en byggesak og kontaktinfo sammen med status.

	- MineByggesaker viser en liste over registrerte byggesaker. Her ligger også view-et for skjema for å registrere en ny byggesak.

	- Profil viewet viser informasjon om innlogget bruker. 

	- Shared mappen er design felles for view-ene. Felles definisjonene kan være spesifikke, som at nav-baren inkluderes i alle innsendingssidene
	  for en ny byggesak, men ikke i de andre view-ene. Ellers er header og footer felles for alle view-ene og inkludert i felles mappen. 

Fane-ikon:

Favicon.ico er illustrasjonen som vises oppe i fanen i nettleseren.


MyPagePrototype.Tests

Navnet til dette delprosjektet er likt hovedprosjektet med unntak av en .Tests endelse. Dette forklarer at det er her testene ligger.

Mappene under dette prosjektet er delt inn i Controllere, DAL (Data access layer) og Modellene. Dette speiler strukturen i den faktiske
tjenesten. Noen unntak er Views, som ikke skal ha noe logikk og vi valgte derfor ikke lage tester til disse. Løsningen er holdt veldig
modulær, med løs kobling mellom klassene. Dette skal bidra til at det er oversiktlig og lett å ta over. 

Controllere:

Controller test klassene er utviklet for å teste at de ulike view-ene controllerene returnerer eller ruter til stemmer med ønsket resultat.
Dette da både når de får parametere som innput og når de ikke får innput. Vi tester også overload metodene (Klassene med like navn).

DAL: 

DAL mappen har to klasser, en kontekst klasse og en initialiserer klasse. Kontekst klassen tester om tjenesten er i stand til å generere en
database kontekst med de gitte innstillingene som er definert i klassen, og i onModelCreation metoden. Initialiserer klassen undersøker om 
tjenesten er i stand til å fylle den genererte databasen med dummy data. 

Model:

Til sist har vi modell mappen. Her ligger tester for de ulike modellene i tjenesten. Her sjekkes det da om man kan lage et nytt objekt med 
ønsket innhold. 