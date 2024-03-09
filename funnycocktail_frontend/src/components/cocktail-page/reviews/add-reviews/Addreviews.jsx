import { useEffect, useState } from 'react'
import styles from './Addreviews.module.css'
import { useLocation, useParams } from 'react-router-dom'
import { Reviewsservice } from '../../../../services/reviews.service'
import toast from 'react-hot-toast'

const Addreviews = ({nickname}) => {

    const[review, setReview] = useState('')
    const {id} = useParams();

    const createReview = async () => {
        try{
            const responce = await Reviewsservice.createReviewAsync(nickname, review, id);
            toast.apply(`Отзыв добавлен!`)
            location.reload();
            return responce;
        }
        catch{
            toast.error(`Ошибка при добавлении отзыва`, {position: "bottom-right"})
        }
    }

    const handleUpdateReviewText = (e) => {
        setReview(e.target.value)
    }
    return(
        <>
        <div className={`${styles.place}`}>
            <textarea onChange={handleUpdateReviewText} className={`${styles.input}`} placeholder="Оставьте отзыв" type="text" />
            <button onClick={createReview} className={`${styles.btn}`}>Принять</button>
        </div>
        </>
    )
}

export default Addreviews