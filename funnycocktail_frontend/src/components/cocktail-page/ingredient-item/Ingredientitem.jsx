import { useEffect, useState } from 'react'
import styles from './Ingredientitem.module.css'

const Ingredientitem = ({ingredient}) => {

    const[image, setImage] = useState(null);

    let powerColor = 'red';

    if(ingredient.powerId == 2) powerColor = 'orange'
    else if(ingredient.powerId == 3) powerColor = 'green'

    useEffect(() => {
        const fetchData = () => {
            setImage(ingredient.image);
        };
        fetchData()
    })

    return(
        <div key={ingredient.id} className={`${styles.item}`}>
            <div style={{position: 'absolute', right:'5px', top: '5px', width: '15px', height: '15px', borderRadius: '100px', backgroundColor: `${powerColor}`}}></div>
            <div className={`${styles.img}`} style={{backgroundImage: `url(${image})`}}></div>
            <h1>{ingredient.name}</h1>
        </div>
    )
}

export default Ingredientitem