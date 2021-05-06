<template>
<section class="col-md">
    <h3>Admin</h3>
    <p><i>Denne siden er ment å kun være tilgjengelig for admins av siden</i></p>
    <p>Her kan du <strong>endre</strong> musikkoppdrag, markere de som <strong>"utført"</strong> eller <strong>slette</strong> musikkoppdrag</p>
</section>
<section class="row">
    <h4>Hent musikkoppdrag etter ID</h4>
    <div>
        <label class="form-label">Musikkoppdrag nr.</label>
        <input class="form-control" v-model="id" type="text">
        <button class="btn btn-success" @click="getJobById">Hent oppdrag</button>
    </div>
    <div>
        <label class="form-label">Anledning</label>
        <input class="form-control" v-model="occasion" type="text">
    </div>
    <div>
        <label class="form-label">Sjanger</label>
        <input class="form-control" v-model="genre" type="text">
    </div>
    <div>
        <label class="form-label">Instrument</label>
        <input class="form-control" v-model="instrument" type="text">
    </div>
     <div>
        <label class="form-label">Pris</label>
        <input class="form-control" v-model="price" type="text">
    </div>
    <div>
        <label class="form-label">Uke</label>
        <input class="form-control" v-model="week" type="text">
    </div>
    <div>
        <label class="form-label">Kontaktinfo</label>
        <input class="form-control" v-model="contact" type="text">
    </div>
    <div>
        <label class="form-label">Utført?</label>
        <input class="form-control" v-model="booked" type="text" placeholder="Hvis ja skriv; 'Utført'">
    </div>
</section>

<div>
    <button class="btn btn-success" @click="putJob">Lagre endring</button>
    <button class="btn btn-danger" @click="deleteJob">Slett oppdrag</button>
</div>

</template>

<script>
import axios from 'axios'
import { reactive, toRefs } from 'vue'

export default {
    setup(){

        const jobObject = reactive( {id:"", occasion:"", genre:"", instrument:"", contact:"", price:"", week:"", booked:"" })

    // Gjør det mulig for brukeren å hente ut en spesifikk musikkoppdrag etter id. jobObject sine attributter blir lik det oppdraget vi får ut sine attributter(response.data)
        const getJobById = () => {
            axios(`https://localhost:5001/job/${jobObject.id}`)
            .then(response => {

                jobObject.occasion = response.data.occasion;
                jobObject.genre = response.data.genre;
                jobObject.instrument = response.data.instrument;
                jobObject.price = response.data.price;
                jobObject.week = response.data.week;
                jobObject.contact = response.data.contact;
                jobObject.booked = response.data.booked;
            })
        }

    // Funksjon som oppdaterer databasen med endret musikkoppdrag ved å trykke på "lagre endring" knapp. Sender over objekt til jobController.
        const putJob = () => {
            const jobToEdit = { 
                id: parseInt(jobObject.id), // parseInt for å få datatypen til å stemme med datatypene i jobController
                occasion: jobObject.occasion,
                genre: jobObject.genre,
                instrument: jobObject.instrument,
                price: parseInt(jobObject.price), // parseInt for å få datatypen til å stemme med datatypene i jobController
                week: parseInt(jobObject.week), // parseInt for å få datatypen til å stemme med datatypene i jobController
                contact: jobObject.contact,
                booked: jobObject.booked
                }

    // Utfører PUT ved å kontakte jobController og sende inn objektet jobToEdit.
                axios.put("https://localhost:5001/job/", jobToEdit)
                    .then( response => {
                        console.log( response.data );
                    })

                console.log( jobToEdit );

                alert("Endring utført");
        }

    // Sletter et musikkoppdrag ved å trykke på "slett oppdrag" knapp
        const deleteJob = () => {
            axios.delete(`https://localhost:5001/job/${jobObject.id}`)
                .then( response => {
                    console.log( response.data )
                })

        alert("slettet");
                
        }

        return { 
            getJobById,
        ...toRefs( jobObject ),
            putJob,
            deleteJob 
        }
    },
}

</script>

<style scoped>

h3{
    margin-top: 50px;
    margin-bottom: 50px;
    text-align: center;
}

p{
    font-size: 16px;
    line-height: 2;
    text-align: center;
}

.row{
    margin-top: 100px;
}

.btn{
    margin-top: 20px;
    margin-bottom: 20px;
    margin-right: 10px;
}

.form-label{
    font-size: 14px;
}

</style>

