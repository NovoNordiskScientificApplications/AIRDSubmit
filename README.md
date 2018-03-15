## AIRDSubmit: Applikation til statistikindberetning til Dyreforsøgstilsynet

Med dette værktøj kan du indberette dyrestatistik direkte fra et Excel ark til [Fødevarestyrelsens indberetningssystem AIRD](https://www.foedevarestyrelsen.dk/Dyr/dyrevelfaerd/Dyreforsoegstilsynet/Sider/Ansoegning-og-indberetning.aspx). 

### Download 
Den nyeste version kan hentes her: [AIRDsubmit version 1.1](https://github.com/NovoNordiskScientificApplications/AIRDSubmit/releases/download/v1.1/AIRDsubmit.1.1.zip)

### Manual

Først udfyldes et excel ark med den statistik data der ønskes indberettet. Det anbefales at følgende Excel ark benyttes som udgangpunkt [Example.xlsx](/Documentation/Example.xlsx), da overskrifterne er nødvendige. Se billede

![Guide1.png](/Documentation/Guide1.png)

Start AIRDSubmit og åben det udfyldte Excel ark. Se billede

![Guide2.png](/Documentation/Guide2.png)

AIRDSubmit vil nu fortælle hvis der er nogle umiddelbare fejl i indberetningen, samt give foreslag til rettelser i en drop down menu. Se billede

![Guide3.png](/Documentation/Guide3.png)

Når dataen er klar udfyldes brugernavn og adgangskode og herefter kan statistikken indberettes vil at trykke på Upload to AIRD. Se afnit om adgang for detailer omkring tildeling af adgangskode.

Efter indsendelse vil alle rækker der successfuldt blev indsendt blive markeret grønne, og rækker med fejl i vil blive markeret røde. Ved gentagende forsøg vil de succesfulde (grønne) rækker ikke blive indsendt igen. Se billede

En typisk fejl er at man ikke har lov til at indrapportere på en tilladelse. Se nedenfor for flere detailer.

![Guide4.png](/Documentation/Guide4.png)

Når du er færdig med at indrapportere for året, så skal du logge på AIRD med NemID og 'Færdiggøre' indberetningen. Herefter vil det ikke længere være muligt at foretage ændringer eller indberette yderligere.


### Adgang

Brugernavnet er den e-mail addresse der er tilknyttet ens AIRD konto. Adgangskoden tildeles af dyreforsøgstilsynet og kan udleveres ved at kontakte dem per e-mail. Både brugernavn og password er case sensitiv.

En bruger har mulighed for at indberette på alle tilladelser han/hun har lov til at se. Dvs. en firma administrator kan indberette for alle tilladelser tilknyttet den juridiske profil. Herudover kan man give andre bruger tilladelse til at se og indrapportere ved at gøre dem 'venner' i AIRD. Se dyreforsøgtilsynets hjemmeside for flere detailer.


### Typiske fejl

Unauthorized: Der er en fejl i brugernavn eller password. De er case sensitive.

Anonymous: Der er ikke forbindelse til internettet.

CapitaId is not Matched: Du har ikke lov til at indberette på denne tilladelse. Tjek at nummeret er korrekt og hvis du indrapportere på vejene af andre, tjek at de har givet dig lov til at se tilladelsen som 'ven'.

Invalid code for 'PlaceOfBirth': Kan være en fejl i place of birth, men mere sandsynligt, reuse er sat til 'YES', men dyret har ikke været indrapporteret pga. studie start før 2014, som reuse betyder.

is not valid entry: En af indtastningerne i den linje matcher ikke nogen af de mulige fra drop down menuen. Feltet burde yderligere være omsluttet af en rød firkant.


### FAQ

"Åh nej, jeg tror jeg har dobbelt indberettet": Log in på AIRD med NemID. Under indberetning kan du trække en csv fil ud med alle indberetninger. Hvis du mener at der er en fejl kan du under edit slette de indberetninger. Tidsstemplet vil ofte være en hjælp.


### Teknisk information

De forventede værdier for multiple choice kolonnerne kan laves om i filen AIRDsubmit.exe.config. Her kan også ændres på det årstal som anvendes hvis intet er udfyldt.

Som udgangspunkt er det fikseret hvilkle data der forventes i de enkelte kolonner som set i Example.xlsx.


### Kontakt

Applikationen er udviklet af Novo Nordisk A/S til alles brug. 

For spørgsmål angående indberetning kontakt venligst dyreforsøgstilsynet dyreforsoegstilsynet@fvst.dk 

For spørgsmål om applikationen kan udvikleren (Jesper B Rasmussen) kontaktes per e-mail jbqr@NovoNordisk.com
