<template>
    <section class="col-md">
        <h3>Våre artister</h3>
        <p>Vi har artister i mange ulike sjangre. Hvis du vet hvilken sjanger du ser etter kan du søke/filtrere under.</p>
    </section>

<!-- Søk etter sjanger for å se artist -->
    <section class="col-md">
        <div class="form-inline">
            <input class="form-control" id="clear-search" v-model="searchString.genre" type="search" placeholder="'jazz', 'hip hop', 'klassisk', 'pop', 'rock'...">
            <button class="btn btn-success" @click="filterArray" type="submit">Søk etter sjanger</button>
        </div>
    </section>
    
<!-- Visning av alle artister fra databasen ved hjelp av v-for gjennom artistList array-->
    <section class="col-md">
        <div class="row">
            <artist-item
                v-for="( artist, i ) in artistList"
                :key="i"
                :id="artist.id"
                :name="artist.name"
                :price="artist.price"
                :instrument="artist.instrument"
                :image="artist.image"
                :isAvailable="artist.isAvailable"
                :genre="artist.genre"
                :count="artist.count"
                >
            </artist-item>
        </div>
    </section>
</template>


<script>
import axios from 'axios'
import ArtistItem from './ArtistItem'
import { reactive, toRefs } from 'vue'

export default {
    setup(){

        // Putter alle artister fra databasen inn i artistList array
        const artists = reactive({ artistList: [] });

        // Tar i mot sjanger brukeren søker etter og lagrer det i searchString
        let searchString = reactive( { genre:""});
        
        axios("https://localhost:5001/artist/") 
             .then( response => { 
                artists.artistList = response.data;
              })

        // Funksjon som kjøres ved klikk på knapp. Filtrerer vising av artister ut i fra sjanger som bruker søker etter
        function filterArray(){
            artists.artistList = artists.artistList.filter( artist => artist.genre === searchString.genre);
        }
      
        return { ...toRefs( artists ), filterArray, searchString }
            
        },
       
        components: { ArtistItem }
    }

</script>


<style scoped>
        
h3{
    margin-top: 50px;
    margin-bottom: 50px;
    text-align: center;
}

p{
    text-align: center;
    margin-bottom: 50px;
}

.form-inline {
    margin-top: 20px;
}

.form-control{
    margin-top: 10px;
    margin-bottom: 10px;
}


</style>