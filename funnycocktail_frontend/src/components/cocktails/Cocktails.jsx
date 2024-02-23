import { useEffect, useState } from "react"
import styles from './Cocktails.module.css'
import '../../assets/styles/global-styles.css'
import { Cocktailservice } from "../../services/cocktail.service"
import Cocktailitem from "./cocktail-item/Cocktailitem"

const Cocktails = () => {

    const [cocktails, setCocktails] = useState([])

    useEffect(() => {
        const fetchData = async () => {
            try{
                const responce = await Cocktailservice.getAllCocktailsAsync();
                setCocktails(responce)
            }catch (error){
                alert(`Ошибка при получении списка коктейлей: ${error}`)
            }
        };
        fetchData()
    }, [])

    return(
        <>
        <div className={`${styles.place} container`}>
            {cocktails.length ? cocktails.map(cocktail => (
                <Cocktailitem key={cocktail.id} cocktail={cocktail}/>
            )): <h1>коктейлей нет</h1>}
        </div>
        </>
    )
}   

export default Cocktails