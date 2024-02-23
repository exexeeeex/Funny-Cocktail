import styles from './Endpage.module.css'
import '../../../assets/styles/global-styles.css'
import { NavLink } from 'react-router-dom'

const Endpage = () => {
    return(
        <>
            <div className={`${styles.endpage} container`}>
                <div>
                    <h1 className={`${styles.title}`}>Стараемся для вас!</h1>
                    <h1 className={`${styles.subtitle}`}>Наш проект находится в постоянной разработке, поэтому мы будем рады увидеть фидбек от вас!</h1>
                </div>
                <NavLink className='btn' to='/cocktails'>К Коктейлям!</NavLink>
            </div>
        </>
    )
}

export default Endpage