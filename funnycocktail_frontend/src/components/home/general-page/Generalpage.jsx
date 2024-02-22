import styles from './Generalpage.module.css'
import '../../../assets/styles/global-styles.css'
import { NavLink } from 'react-router-dom'

const Generalpage = () => {
    return(
        <>
            <div className={`${styles.mgt} ${styles.generalpageinner} container`}>
                <div className={`${styles.inner}`}>
                    <h1 className={`${styles.innertoptext}`}>Funny <span style={{color: '#C02CE7'}}>Cocktail</span></h1>
                    <h1 className={`${styles.innerbottext}`}>Твори, веселись, делись! <br /> Лучший ресурс для создания коктейлей.</h1>
                    <a href='#about' className={`btn`}>Что это такое?</a>
                </div>
                <div className={`${styles.imgs}`}>
                    <img src='./images/shapes/Ellipse.png'/>
                    <img src="./images/3d/bottle_1.webp" className={styles.bottle} />
                    <img src="./images/3d/bottle_2.png" style={{maxWidth: '345px'}} className={styles.bottle} />
                </div>
            </div>
        </>
    )
}

export default Generalpage