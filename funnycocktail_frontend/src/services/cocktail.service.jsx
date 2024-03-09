import axios from "axios";

export const Cocktailservice = {
    async getAllReviewsAsync(){
        const responce = await axios.get(`https://localhost:1337/api/cocktailsreviews/getallreviews`);
        return responce.data;
    },
    async getAllCocktailsAsync(){
        const responce = await axios.get(`https://localhost:1337/api/cocktails/getall`);
        return responce.data;
    },
    async getCocktailByIdAsync(id){
        const responce = await axios.get(`https://localhost:1337/api/cocktails/getbyid?Id=${id}`);
        return responce.data;
    }
}