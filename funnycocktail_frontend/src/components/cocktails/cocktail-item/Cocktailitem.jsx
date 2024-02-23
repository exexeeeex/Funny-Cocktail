import { NavLink } from "react-router-dom"
import styles from './Cocktailitem.module.css'

const Cocktailitem = ({cocktail}) => {

    let powerColor = 'red';

    if(cocktail.powerId == 2) powerColor = 'orange'
    else if(cocktail.powerId == 3) powerColor = 'green'

    return(
        <NavLink key={cocktail.id} className={`${styles.cocktailitem}`}>
            <div className={`${styles.cocktailpower}`} style={{backgroundColor: `${powerColor}`}}></div>
                <h1 className={`${styles.cocktailname}`}>{cocktail.cocktailName}</h1>
                <h1 className={`${styles.cocktaildesc}`}>{cocktail.description}</h1>
        </NavLink>
    )
}

export default Cocktailitem