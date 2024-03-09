import styles from './Cocktailcard.module.css'
const Cocktailcard = ({cocktail}) => {
    return(
        <>
        <div className={`${styles.place}`}>
            <h1>Коктейль {cocktail.cocktailName}</h1>
            <h1>Автор: {cocktail.authorName}</h1>
            <p>АХхахахахаххахаа</p>
        </div>
        </>
    )
}

export default Cocktailcard