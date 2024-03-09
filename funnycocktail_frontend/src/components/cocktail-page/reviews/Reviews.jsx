import toast from 'react-hot-toast'
import styles from './Reviews.module.css'
import Reviewsitem from './reviews-item/Reviewsitem'
import Addreviews from './add-reviews/Addreviews'
import { useEffect, useState } from 'react'

const Reviews = ({reviews}) => {

    const [nickname, setNickname] = useState('')

    useEffect(() =>{
        const fetchData = () => {
            const author = localStorage.getItem(`author`)
            if(author != null){
                setNickname(author);
            }
        };
        fetchData()
    })

    return(
        <>
            <div className={`${styles.place}`}>
                <h1>Отзывы</h1>
                <Addreviews nickname={nickname}/>
                {reviews.length && reviews.map(review =>(
                    <>
                        <Reviewsitem review={review} key={review.id}/>
                    </> 
                ))}
            </div>
        </>
    )
}

export default Reviews