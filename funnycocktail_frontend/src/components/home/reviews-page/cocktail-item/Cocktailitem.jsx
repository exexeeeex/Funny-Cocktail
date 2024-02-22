import styles from '../Reviewspage.module.css'

const Cocktailitem = ({review}) => {
    return(
        <>
        <div key={review.id} className={`${styles.reviewitem}`} style={{display: 'flex', gap: '10px'}}>
            <h1>{review.id}</h1>
            <div>
                <h1 className={`${styles.reviewitemheader}`}>{review.cocktailName}</h1>
                <h1 className={`${styles.reviewitembottom}`}>{review.reviewText}</h1>
            </div>
        </div>
        </>
    )
}

export default Cocktailitem