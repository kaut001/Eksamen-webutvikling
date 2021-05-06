<template>
<div>
    <nav class="navbar navbar-collapse navbar-expand-lg navbar-light">
        <ul class="navbar-nav mx-auto">
            <li class="nav-item"><router-link class="nav-link" to="/">Hjem</router-link></li>
            <li class="nav-item"><router-link class="nav-link" to="/artister">Våre artister</router-link></li>
            <li class="nav-item"><router-link class="nav-link" to="/oppdrag">Musikkoppdrag</router-link></li>
            <li class="nav-item"><router-link class="nav-link" to="/registrer-artist">Registrer deg som artist</router-link></li>
            <li class="nav-item"><router-link class="nav-link" to="/om-oss">Om oss</router-link></li>
            <li class="nav-item"><router-link class="nav-link" to="/endre-musikkoppdrag">Admin</router-link></li>
        </ul>
    </nav>
</div>
</template>


<style scoped>
   
.navbar {
    margin-top: 30px;
    margin-bottom: 30px;
}

a:hover{
    color: #F75DA5 !important;
}


</style>