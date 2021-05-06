<template>
    <section class="col-md">
        <h3>Om Find A Musician</h3>
        <img class="col-md-12 text-center" src="../assets/findamusician.jpg">
        <article class="row">
            <p>
            Find A Musician er en bedrift som fremhever norske musikktalenter innenfor alle sjangre! 
            Vi har derfor endelig kommet med en nettløsning der du kan se etter artister til ditt bryllup, 
            50-års fest eller hva enn det måtte være!
            <br>
            <br>
            Du kan også legge ut musikkoppdrag som du ønsker utført, slik at vi kan sjekke for deg 
            om noen av våre registrerte artister kunne passet til ditt ønskede arrangement.
            <br>
            <br> Når du har lagt ut et ønsket musikkoppdrag får du en <strong>ID</strong>. Dersom du skulle ønske å endre på forespørselen din er
            det bare å kontakte oss og oppgi din <strong>ID</strong> slik at vi får endret på oppdraget utifra dine ønsker. 
            <br>
            Dersom du selv er artist og ønsker å nå ut til et større publikum, 
            samt kunne bli booket til ulike musikkoppdrag - så kan du registrere deg her:
            <button class="btn btn-success"><router-link to="/registrer-artist">Registrer deg som artist!</router-link></button>
            </p>
        </article>
        <article class="row">
            <p><strong>Telefon:</strong> 123 45 678</p>
            <p><strong>E-post:</strong> Findamusician@mail.no</p>
            <p><strong>Adresse:</strong> Lochalhostveien 80, 8080 Oslo</p>
        </article>
    </section>
</template>


<style scoped>

h3{
    margin-top: 50px;
    margin-bottom: 50px;
    text-align: center;
}

img{
     height: 15vw;
     min-height: 500px;
     width:100%;
     object-fit: cover;
}

.row{
    margin-top: 30px;
    background-color: #F4F4F4;
    border: 1px solid #F4F4F4;
    border-radius: 15px;
    padding: 10px;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
}

p{
    font-size: 16px;
    line-height: 2;
}

.btn{
    margin-top: 30px;
    margin-bottom: 30px;
}

a{
    text-decoration: none;
    color: #FFFFFF;
    font-size: 14px;
}


</style>