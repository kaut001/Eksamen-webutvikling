<template>
    <div class="col-xs-12 col-md-6 card-group">
        <div class="card bg-light border-secondary mb-3" style="width: 30em;">
            <article>
                <!-- v-bind for å vise innhold -->
                <h3 class="card-header">Musikkoppdrag nr.{{ id }}</h3>
                <div class="card-body text-secondary">
                <h4 class="card-title">Anledning: <i>{{ occasion }}</i></h4>
                <p class="card-text">Sjanger: {{ genre }}</p>
                <p class="card-text">Instrument: {{ instrument }}</p>
                <p class="card-text">Budsjett: {{ price }},- NOK</p>
                <p class="card-text">Ønsket uke: Uke {{ week }}, 2021</p>
                <p class="card-text">Kontaktinfo: {{ contact }}</p>
                <p class="card-text" id="booked">{{ booked }}</p>
                </div>
            </article>
        </div>
    </div>
</template>

<script>
export default {

// Henter inn props fra modellklassen til job
    props: {
        id: Number,
        contact: String,
        occasion: String, 
        instrument: String,
        price: Number,
        week: Number,
        genre: String,
        booked: String
    }
}
</script>

<style scoped>

.card-text{
    font-size: 14px;
}

    #booked{
        color: #198754;
        font-weight: bold;
        text-align: end;
    }

</style>