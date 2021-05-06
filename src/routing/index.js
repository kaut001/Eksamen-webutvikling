import { createRouter, createWebHistory } from 'vue-router'
import HomePage from '../views/HomePage'
import BookingPage from '../views/BookingPage'
import AboutPage from '../views/AboutPage'
import ArtistPage from '../views/ArtistPage'
import RegisterArtistPage from '../views/RegisterArtistPage'
import JobEdit from '../components/jobs/JobEdit'
import PageNotFound from '../views/PageNotFound'

const routes = [
    {
        name: "HomePage",
        path: "/",
        component: HomePage
    },
    {
        name: "ArtistPage",
        path: "/artister",
        alias: "/våre-artister",
        component: ArtistPage
    },

    {
        name: "BookingPage",
        path: "/oppdrag",
        component: BookingPage
    },

    {
        name: "AboutPage",
        path: "/om-oss",
        component: AboutPage
    },
    
    {
        name: "RegisterArtistPage",
        path: "/registrer-artist",
        component: RegisterArtistPage
    },

    {
        name: "JobEdit",
        path: "/endre-musikkoppdrag",
        component: JobEdit
    },

    {
        name: "PageNotFound",
        path: "/:catchAll(.*)",
        component: PageNotFound
    }

];


const router = createRouter({
    history: createWebHistory(),
    routes
});


export default router;