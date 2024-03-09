import { useEffect, useState } from "react"
import styles from './Cocktails.module.css'
import '../../assets/styles/global-styles.css'
import { Cocktailservice } from "../../services/cocktail.service"
import Cocktailitem from "./cocktail-item/Cocktailitem"
import toast from "react-hot-toast"

const Cocktails = () => {

    const [cocktails, setCocktails] = useState([])

    useEffect(() => {
        const fetchData = async () => {
            try{
                const responce = await Cocktailservice.getAllCocktailsAsync();
                setCocktails(responce)
            }catch (error){
                toast.error(`Ошибка при получении списка коктейлей`, {
                    position: "bottom-right"
                })
            }
        };
        fetchData()
    }, [])

    return(
        <>
        <div className={`${styles.place} container`}>
            {cocktails.length && cocktails.map(cocktail => (
                <Cocktailitem key={cocktail.id} cocktail={cocktail}/>
            ))}
        </div>
        </>
    )
}   

export default Cocktails