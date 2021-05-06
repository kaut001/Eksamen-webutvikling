<template>
    <section>
        <h3>Legg inn ønsket musikkoppdrag!</h3>
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
                <label class="form-label">Ønsket pris</label>
                <input class="form-control" v-model="price" type="text">
            </div>
            <div>
                <label class="form-label">Ønsket uke</label>
                <input class="form-control" v-model="week" type="text">
            </div>
             <div>
                <label class="form-label">E-post</label>
                <input class="form-control" v-model="contact" type="text">
            </div>
            <button class="btn btn-success" @click="postJob">Send inn forespørsel</button>
    </section>

<!-- Visning av alle musikkoppdrag fra databasen ved hjelp av v-for gjennom jobList array-->
    <section>
        <div class="row">
        <h3>Musikkoppdrag </h3>
        <job-item
        v-for="( job, i ) in jobList"
                :key="i"
                :id="job.id"
                :occasion="job.occasion"
                :price="job.price"
                :instrument="job.instrument"
                :week="job.week"
                :contact="job.contact"
                :genre="job.genre"
                :booked="job.booked"
        ></job-item>
        </div>
    </section>
</template>

<script>
import axios from 'axios'
import JobItem from './JobItem'
import { reactive, toRefs } from 'vue'

export default {
    setup() {

    // Putter alle musikkoppdrag fra databasen inn i jobs array
        const jobs = reactive({ jobList: [] });

    // Reaktivt objekt med properties som matcher modelklassens attributter. Brukeren kan dermed endre disse fra template gjennom v-model direktiv.
        const newJob = reactive( {
            occasion: "",
            instrument: "",
            price: "",
            week: "",
            contact: "",
            genre:""
        } );

    // Get metode som henter ut alle musikkoppdrag som finnes i databasen.
        axios("https://localhost:5001/job/")
             .then( response => { 
                 jobs.jobList = response.data;
              })

    // Funksjon som kjøres når brukeren trykker på knapp "send inn forespørsel" og sier hva objektet newJob skal inneholde. 
        const postJob = () => {
            axios.post("https://localhost:5001/job/", newJob)
            .then( response => {
                jobs.jobList.push( response.data );  
            } )
        }

        
        return {
                ...toRefs ( newJob ),
                ...toRefs( jobs ),
                postJob
            }
    },
    components: { JobItem }
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

.form-label {
    font-size: 14px;
    margin-top: 10px;
}


</style>
