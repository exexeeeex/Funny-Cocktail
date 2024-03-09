import styles from './Reviewspage.module.css'
import '../../../assets/styles/global-styles.css'
import Cocktailitem from './cocktail-item/Cocktailitem'
import { Cocktailservice } from '../../../services/cocktail.service'
import { useState, useEffect } from 'react'
import toast from 'react-hot-toast'

const Reviewspage = () => {

    const [reviews, setReviews] = useState([]);

    useEffect(() => {
      const fetchData = async () => {
          try {
              const responce = await Cocktailservice.getAllReviewsAsync();
              setReviews(responce);
          } catch (error) {
              console.error('Ошибка при загрузке отзывов: ', error);
              toast.error("Ошибка при загрузке отзывов.", {
                position: "bottom-right"
              })
          }
      };
      fetchData(); 
    }, []);

    return(
        <>
            <div className={`${styles.reviewspage} container`}>
                <div className={`${styles.reviewblock}`}>
                    <h1 className={`${styles.reviewheader}`}>Последние отзывы</h1>
                    {reviews.length ? reviews.slice(0, 2).map(review => (
                        <Cocktailitem key={review.id} review={review}/>
                    )) : <h1>Отзывов нет</h1>}
                </div>
                <div className={`${styles.inner}`}>
                    <div className={`${styles.innerheader}`}>
                        <img className={`${styles.smile}`} src="./images/shapes/smile.png" alt="" />
                        <h1 className={`${styles.headertext}`}>Лучшее, что я пил!</h1>
                    </div>
                    <h1 className={`${styles.bottomtext}`}>На сайте пристутствует гибкая система отзывов и оценок, чтобы вы наслаждались только лучшим</h1>
                    <a style={{marginLeft: '770px', fontSize: '20px'}} className='btn'>Это всё?</a>
                </div>
            </div>
        </>
    )
}

export default Reviewspage