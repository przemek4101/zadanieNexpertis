# zadanieNexpertis

Zadanie:
Zaprojektuj API w oparciu o framework .NET 5.0.
Wymagane endpointy:
-> /api/user/login - W requeście przekazany ma być {username:user, password:user}, endpoint musi zwracać token JWT.
-> /api/currencies/{data} - Kursy pobierane powinny być z http://api.nbp.pl/ i zapisywane w bazie danych(Wykorzystać Entity Framework).
Kursy pobierane z bazy danych, jeżeli dla danego dnia nie występuje, pobrać z API.

Musi być user:test password:test
Oceniane będą:
Swagger,OOP,Znajomość frameworka .NET, znajomość REST API, clean code, Git.

Do testowania API proponujemy użyć narzędzia Postman.
Gotowy projekt proszę wrzucić na swoje repozytorium i przesłać link do projektu.
