<template>
<div class="col-xs-12 col-md-6 col-xl-4 card-group">
    <div class="card">
        <!-- Dynamisk src. OBS alle bilder brukt i oppgaven er hentet fra unsplash.com og lov å bruke i både kommersiell og ikke-kommersiell sammenheng  -->
        <img :src="`https://localhost:5001/images/${image}`" class="card-img-top"/>
            <div class="card-body">
        <!-- v-bind for å vise innhold -->
                <h3 class="card-title">{{ name }}</h3>
                <hr>
                <p class="card-text">Pris per time: {{ price }} ,- NOK</p>
                <p class="card-text">Instrument: {{ instrument }}</p>
                <p class="card-text">Musikksjanger: {{ genre }}</p>
                <p class="card-text">Musiker ID: {{ id }}</p>
                <div>
                    <button class="button" @click="like +=1"><p>&#128077; {{ like }}</p></button>
                    <button class="button" @click="dislike +=1"><p>&#128078; {{ dislike }}</p></button>
                </div>
            </div>
    </div>
</div>
</template>

<script>
import { ref } from 'vue'

export default {

// Muligjør liking og disliking av artister. Dette blir ikke lagret i local storage, så nullstiller seg ved omlasting av side
setup(){
        const like = ref(0);
        like.value+1
    
        const dislike = ref(0);
        dislike.value+1
        
        return { like, dislike }
},

// Henter inn props fra modellklassen til artist
    props: {
        id: Number,
        name: String,
        price: Number, 
        instrument: String,
        image: String,
        isAvailable: Boolean,
        genre: String
    }
}
</script>

<style scoped>

.card {
    margin-top: 50px;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
}

.card-img-top {
     height: 15vw;
     min-height: 300px;
     width:100%;
     object-fit: cover;
  }

.button{
    border: none;
    background-color: #FFFFFF;
}

</style>