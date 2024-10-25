# Sistem za internet i TV provajdere

### Opis projekta

Projekat sistem za internet i TV provajdere predstavlja projekat petoro studenata III godine predmeta **Dizajniranje softvera**, _Prirodno-matematičkog fakulteta_. Specifikacija zahteva projekta se može naći [ovde](https://github.com/marijajolovic/Sistem-za-internet-i-TV-provajdere/blob/main/docs/opisProjekta.md). Tim čine:
- [Radovan Drašković](https://github.com/Drashko73)
- [Marija Jolović](https://github.com/marijajolovic)

Projekat se može klonirati putem git komande
`git clone http://gitlab.pmf.kg.ac.rs/ds/projekat-2023/tim-01.git`
ili preuzimanjem .zip foldera sa sadržajem projekta.

# Potrebno za pokretanje aplikacije u razvojnom okruženju

Potrebni paketi koji se koriste za konekciju sa odgovarajućim tipom baze nalaze se u fajlu _requirements.txt_, čiji se sadržaj može videti [ovde](https://github.com/marijajolovic/Sistem-za-internet-i-TV-provajdere/blob/main/requirements.txt)
Obzirom da se projekat sastoji iz _class library_ biblioteke i _windows forms app_-a potrebno je build-ovati biblioteku pre korišćenja projekta i izmeniti putanju u _config_ fajlu do odgovarajuće baze na računaru (u slučaju konekcije sa SQLite bazom podataka) ili navesti server i odgovarajuće kredencijale (u slučaju konekcije sa MySQL bazom podataka).

# Podrška za rad sa bazama podataka
- SQLite
- MySQL

UML dijagram koji predstavlja strukturu biblioteke se može preuzeti [ovde](https://github.com/marijajolovic/Sistem-za-internet-i-TV-provajdere/blob/main/docs/UML_packet_providers.png).
<div>
  <img src="../docs/UML_packet_providers.png" alt="UML dijagram" height=700>
</div>

Primer rada aplikacije:
https://gitlab.pmf.kg.ac.rs/ds/projekat-2023/tim-01/-/blob/master/docs/vid.mp4?expanded=true&viewer=rich
