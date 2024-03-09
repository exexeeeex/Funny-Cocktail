import axios from "axios"

export const Ingredientservice = {
    async getIngredientsByCocktailId(id){
        const responce = await axios.get(`https://localhost:1337/api/ingredients/getbycocktailid?Id=${id}`);
        return responce.data;
    }
}