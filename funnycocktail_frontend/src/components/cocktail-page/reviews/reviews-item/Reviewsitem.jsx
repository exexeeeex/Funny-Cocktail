import styles from './Reviewsitem.module.css'
const Reviewsitem = ({review}) => {
    return(
        <>
            <div className={`${styles.item}`} key={review.id}>

                <div style={{display: 'block'}}>
                    <h1>{review.nickname}</h1>
                    <p>{review.reviewText}</p>
                </div>
            </div>
        </>
    )
}

export default Reviewsitem