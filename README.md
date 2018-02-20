## AIRDSubmit: Applikation til statistikindberetning til Dyreforsøgstilsynet

Med dette værktøj kan du indberette dyrestatistik direkte fra et Excel ark til [Fødevarestyrelsens indberetningssystem AIRD](https://www.foedevarestyrelsen.dk/Dyr/dyrevelfaerd/Dyreforsoegstilsynet/Sider/Ansoegning-og-indberetning.aspx). 

### Download 
Den nyeste version kan hentes her: [AIRDsubmit version 1.0](https://github.com/NovoNordiskScientificApplications/AIRDSubmit/releases/download/v1.0/AIRDsubmit.1.0.zip)

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


### Adgang

Brugernavnet er den e-mail addresse der er tilknyttet ens AIRD konto. Adgangskoden tildeles af dyreforsøgstilsynet og kan udleveres ved at kontakte dem per e-mail.

En bruger har mulighed for at indberette på alle tilladelser han/hun har lov til at se. Dvs. en firma administrator kan indberette for alle tilladelser tilknyttet den juridiske profil. Herudover kan man give andre bruger tilladelse til at se og indrapportere ved at gøre dem 'venner' i AIRD. Se dyreforsøgtilsynets hjemmeside for flere detailer.


### Teknisk information

De forventede værdier for multiple choice kolonnerne kan laves om i filen AIRDsubmit.exe.config. Her kan også ændres på det årstal som anvendes hvis intet er udfyldt.

Som udgangspunkt er det fikseret hvilkle data der forventes i de enkelte kolonner som set i Example.xlsx. 

### Kontakt

Applikationen er udviklet af Novo Nordisk A/S til alles brug. 

For spørgsmål angående indberetning kontakt venligst dyreforsøgstilsynet dyreforsoegstilsynet@fvst.dk 

For spørgsmål om applikationen kan udvikleren (Jesper B Rasmussen) kontaktes per e-mail jbqr@NovoNordisk.com
