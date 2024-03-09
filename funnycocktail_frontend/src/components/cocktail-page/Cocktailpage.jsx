import styles from './Cocktailpage.module.css'
import '../../assets/styles/global-styles.css'
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import { Cocktailservice } from '../../services/cocktail.service';
import toast from 'react-hot-toast';
import { Ingredientservice } from '../../services/ingredient.service';
import Ingredientitem from './ingredient-item/Ingredientitem';
import Cocktailcard from './cocktail-card/Cocktailcard';
import { Reviewsservice } from '../../services/reviews.service';
import Reviews from './reviews/Reviews';


const Cocktailpage = () => {
    const [cocktail, setCocktail] = useState([])
    const [ingredients, setIngredients] = useState([])
    const [reviews, setReviews] = useState([]);
    const {id} = useParams();

    useEffect(() => {
        const fetchData = async () => {
            try{
                const cocktailData = await Cocktailservice.getCocktailByIdAsync(id);            
                setCocktail(cocktailData);
                const ingredientData = await Ingredientservice.getIngredientsByCocktailId(id);
                setIngredients(ingredientData);
                const reviewsData = await Reviewsservice.getAllReviewsByCocktailIdAsync(id);
                setReviews(reviewsData);
            }catch{
                toast.error('Не удалось получить списки', {position: "bottom=right"})
            }
        };
        fetchData();
    }, []);


    return(
        <>
        <div className={`${styles.place} container`}>
            <h1>Основная информация</h1>
            <Cocktailcard cocktail={cocktail}/>
            <h1 style={{marginTop: '100px'}}>Ингредиенты</h1>
            <div className={`${styles.ingredientplace}`}>
                {ingredients.length && ingredients.map(ingredient => (
                    <Ingredientitem key={ingredient.id} ingredient={ingredient}/>
                ))}
            </div>
            <Reviews reviews={reviews}/>
        </div>
        </>
    )
}

export default Cocktailpage