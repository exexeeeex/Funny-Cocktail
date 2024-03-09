import axios from "axios"

export const Reviewsservice = {
    async getAllReviewsByCocktailIdAsync(id){
        const responce = await axios.get(`https://localhost:1337/api/cocktailsreviews/getreviewsbyid?Id=${id}`);
        return responce.data;
    },
    async createReviewAsync(nickname, reviewText, cocktailId){
        const responce = await axios.post(`https://localhost:1337/api/cocktailsreviews/addreview`, {
            nickname: nickname,
            reviewText: reviewText,
            cocktailId: cocktailId
        })
        return responce.data;
    }
}