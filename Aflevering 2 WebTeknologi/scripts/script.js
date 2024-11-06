//Henter værdien fra dropdown
const userSelect = userSelectMenu.addEventListener('change',function(){
console.log(userSelectMenu.value)

//definerer objectet hvor data skal fremgå
const container = document.getElementById('main-content');

//Giver mig mulighed for at se at .JSON data er korrekt loadet igennem console
console.log(albumData);

//DOM-manipulation
container.innerHTML = 
    "<img src='img/"+ userSelectMenu.value + ".jpg' id='gallery' width='200' height='200'></img>" +
    "<p>Artist: <em><strong>" + albumData[userSelectMenu.value].artistName + "</em></strong></p>" +
    "<p>Album: <em><strong>" + albumData[userSelectMenu.value].albumName + "</em></strong></p>"+
    "<p>Year: <em><strong>" + albumData[userSelectMenu.value].productionYear + "</em></strong></p>"+
    "<p>Tracks: <em><strong>" + albumData[userSelectMenu.value].trackList.length + "</em></strong></p>"+
    "<a href='"+ albumData[userSelectMenu.value].artistWebsite + "' target='_blank'> <p><em> Website </em></p></a>";
});

//data fra albums.json gemmes i global variabel således at det kan tilgås i hele scriptet. "Null" fordi den er/skal være tom indtil den "får" data i fetch. 
let albumData = null;

//Data loades fra albums.json
fetch('data/albums.json')
.then(response => response.json())
//Gemmes i en global variabel (albumData) for at kunne tilgå når ønsket
.then(data => {
    albumData = data;
});

//Funktionalitet som henter tracks pba. knaptryk
trackSelect.addEventListener('click', function() {
//definerer indeks-nummer ud fra 
const albumIndex = userSelectMenu.value;

//Henter album-objektet fra albumData
const album = albumData[albumIndex];

//Definerer hvor elementet som senere skal manipuleres
const trackContainer = document.getElementById('trackContainer');
    
/* elementet 'trackContainer' manipuleres.
først findes tracklisten for det valgte album med udgangspunkt i const albumIndex og album.
Map tager hvert element i mit nested array fra JSON filen og vha. track-funktionen genereres der et <li> element hvori tracknummer og tracktitle indgår. 
Join bruges herefter til at sætte det hele sammen til en string som indsættes (sammen med </ul>) i trackContainer. */
trackContainer.innerHTML = "<p>Tracklist:</p><ul id='tracklist'>" + 
album.trackList.map(track => "<li>" + track.trackNumber + ". " + track.trackTitle + "</li>").join('') + 
"</ul>";})
