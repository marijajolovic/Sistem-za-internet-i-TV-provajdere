# Design patterns

### Creational design patterns

* Singleton

*kreacioni patern*

<div>
  <img src="./resources/images/singleton.png" alt="Singleton logo" height=150>
</div>

Korišćen za potrebe kreiranja konekcije sa bazom podataka kako bi se izbeglo višestruko pozivanje
konstruktora klase i na taj način rezultovalo kreiranjem više različitih instanci klase _Database_. 
Umesto toga, instanca klase se može dobiti pozivanjem metode _GetInstance_ koja će vratiti instancu
klase ukoliko je već napravljena, odnosno kreirati instancu ukoliko se poziva prvi put. 
Da bi prethodno navedeno ponašanje radilo adekvatno, konstruktor klase Database je privatan i 
poziva ga samo metoda _GetInstance_ ukoliko instanca nije već kreirana.

* Factory Method

*kreacioni patern*

<div>
  <img src="./resources/images/factory_method.png" alt="Factory method logo" height=150>
</div>

Korišćen kako bi se na lepši način rešilo pitanje da li je potrebno napraviti konekciju 
sa **SQLite** bazom podataka ili **MySQL** bazom podataka. Ova odluka se moze rešiti i 
preko jednostavnih _if_ naredbi, ali na ovaj način, omogućeno moguće buduće dodavanje
konekcije sa nekom novom bazom bez da menjanja postojećeg kod, već samo dodavanjem nove klase 
koja ce obrađivati konekciju sa tom bazom. Takođe, od korisnika je na ovaj način sakriveno kako 
se uspostavlja konekcija i sa kojom bazom, jer se sve navedeno radi u privatnom konstruktoru klase 
dok se potrebni podaci dobijaju iz konfiguracionog fajla.

* Prototype

*kreacioni patern*

<div>
  <img src="./resources/images/prototype.png" alt="Prototype method logo" height=150>
</div>

Prototype patern se u okviru ovog projekta koristi kako bi se omogućilo efikasno kreiranje
kopija objekata tipova _Client_ i _Packet_. Ovaj šablon omogućava kreiranje novih instanci 
objekata kroz kloniranje postojećih, umesto kreiranja novih objekata pozivanjem konstruktora. 
Unapređuje efikasnost i fleksiblnost kreiranja novih instanci objekata u okviru projekta, i 
doprinosi boljoj organizaciji i performansama aplikacije.

* Builder

*kreacioni patern*

<div>
  <img src="./resources/images/builder.png" alt="Prototype method logo" height=150>
</div>

Builder dizajn obrazac omogućava fleksibilnu i čistu izgradnju i konfiguraciju složenih 
objekata _Packet_. Time se izbegava nepotrebna kompleksnost i smanjuje kod za korisnike koji 
konstruišu pakete. Implementira se kroz separaciju konstrukcije i reprezentacije, tako što razdvaja
proces konstrukcije objekata _Packet_ od njihove interne reprezentacije. Svaki konkretni builder 
**InternetPacketBuilder**, **TVPacketBuilder**, i **CombinedPacketBuilder** definiše kako se 
konkretan tip paketa gradi, dok _DirectorPacketBuilder_ koordinira opisanim procesom.

* Decorator 

*strukturni patern*

<div>
  <img src="./resources/images/decorator.png" alt="Decorator method logo" height=150>
</div>

Dekorator šablon se koristi u ovom projektu kako bi se dinamički dodala nova ponašanja
**logger** objektima. To se postiže implementacijom **omotačkih** klasa koje sadrže ova 
dodatna ponašanja, omogućavajući fleksibilno proširenje funkcionalnosti logger-a. 
Ovime se postiže modularan i proširiv dizajn za funkcionalnost logger-a. 
Nova ponašanja mogu se lako uključiti u logger objekte, olakšavajući prilagođavanje i skalabilnost, 
uz poštovanje principa objektno-orijentisanog dizajna.

* Facade 

*strukturni patern*

<div>
  <img src="./resources/images/facade.png" alt="Facade method logo" height=150>
</div>

U ovom projektu se koristi Facade šablon kako bi se obezbedio jednostavan i kohezivan interfejs za pristup 
složenom podsistemu, čime se olakšava korišćenje više komponenti iz jednog centralnog mesta. 
Metode kao što su _getProviderName()_, _getAllClients(string like)_ 
i _registerClient(string username, string firstName, string lastName)_ pružaju jednostavan interfejs 
za čitanje podataka o pružaocu usluge, dobijanje svih klijenata ili registrovanje novih klijenata.
Ove metode delegiraju složene zadatke specijalizovanim klasama poput **ClientLogic** za rad sa klijentima 
i **PacketLogic** za rad sa paketima.

* Command

*paterni ponašanja*

<div>
  <img src="./resources/images/command.png" alt="Command method logo" height=150>
</div>

U ovom projektu se koristi Command šablon kako bi se razdvojilo pozivanje aktiviranja i deaktiviranja
paketa od objekata koji ih izvršavaju. Time je postignuta veća fleksibilnost i proširivost, omogućavajući
lako dodavanje novih akcija.

* Memento

*paterni ponašanja*

<div>
  <img src="./resources/images/memento.png" alt="Memento method logo" height=150>
</div>

U ovom projektu se koristi Memento šablon kako bi se omogućilo snimanje i vraćanje stanja podsistema Database. 
Klasa Snapshot čuva prethodna stanje sistema, odnosno promene izvršene u bazi. Pomoću nje je moguće snimiti trenutno stanje sistema (CreateSnapshot), vraćanje podisistema u prethodno stanje (RestoreSnapshot) kao i ponovno izvršavanje akcija (RedoSnapshot). Interfejs ICommandMemento obezbeđuje postojanje metoda za redo i undo čiju implementaciju vrši klasa ConcreteCommand klasa definišući konkretne akcije ponovnog izvršavanja prethodne komande ili njenog vraćanja.

Ovaj obrazac omogućava efikasno upravljanje stanjem sistema, omogućavajući njegovo snimanje u različitim trenucima i vraćanje u prethodna stanja po potrebi.
