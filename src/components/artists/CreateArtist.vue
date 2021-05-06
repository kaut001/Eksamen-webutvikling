<template>
    <section class="row">
        <header>
            <h3>Registrer deg som artist hos oss</h3>
            <p>Vi er alltid på utkikk etter flere musikktalenter! 
            Ved å registrere deg her får du muligheten til å nå ut til et stort publikum 
            og bli booket til mange ulike oppdrag!</p>
        </header>
        <section>
            <form class="form-inline my-2 my-lg-0">
                <label class="form-label">Artistnavn</label>
                <input class="form-control" v-model="name" type="text">
            </form>
            <div>
                <label class="form-label">Pris per time</label>
                <input class="form-control" v-model="price" type="text">
            </div>
            <div>
                <label class="form-label">Instrument</label>
                <input class="form-control" v-model="instrument" type="text">
            </div>
            <div>
                <label class="form-label">Musikksjanger</label>
                <input class="form-control" v-model="genre" type="text">
            </div>
            <div>
                <label class="form-label">Legg til et bilde fra din maskin</label>
                <input class="form-control" @change="setImage" type="file">
                <p>Valgt bilde: {{ image }}</p>
            </div>
            <div>
                <input class="btn btn-success" @click="postArtist" type="button" value="Registrer deg">
            </div>
        </section>
    </section>
</template>

<script>
import axios from 'axios'
import {reactive, toRefs} from 'vue'

export default {
    setup(){

        // Reaktivt objekt med properties som matcher modelklassens attributter. Brukeren kan dermed endre disse fra template gjennom v-model direktiv.
        const artistInput = reactive({ name: "", price:"", instrument:"", image:"", genre:""});

        // Objekt som lagrer bilde som brukeren har valgt
        const artistImage = new FormData();

        // Funksjon som blir kjørt når brukeren laster opp bilde (@change). Får tak i ett bilde som brukeren laster opp som vi legger til i artistImage og image.
        const setImage = ( e ) => {
            artistImage.append("file", e.target.files[0]);
            artistInput.image = e.target.files[0].name;
        }

        // Funksjon som kjøres når brukeren trykker på knapp "registrer deg" og sier hva objektet newArtist skal inneholde. 
        const postArtist = () => {
            
            const newArtist = {
                name: artistInput.name,
                price: parseInt(artistInput.price),
                instrument: artistInput.instrument,
                genre: artistInput.genre,
                image: artistInput.image
            }

        // Første post metode som får tak i artist controller og som gjør det mulig å poste en ny artist til databasen
            axios.post("https://localhost:5001/artist/", newArtist) 
                .then( () => {

        // Post metode for å poste artistbilde til databasen
                    axios({ 
                        method: "POST",
                        url: "https://localhost:5001/artist/UploadImage",
                        data: artistImage,
                        config: { headers: { "Content-Type": "multipart/form-data" }}
                    })
                })

                alert("Takk for din registrering!");
        }

        return {...toRefs( artistInput ), setImage, postArtist}
    },
}


</script>

<style scoped>

h3{
    margin-top: 50px;
    margin-bottom: 50px;
    text-align: center;
}

.btn{
    margin-top: 20px;
}

.form-label{
    font-size: 14px;
    margin-top: 10px;
}
</style>