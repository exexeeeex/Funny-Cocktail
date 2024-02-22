import styles from './Aboutpage.module.css'
import '../../../assets/styles/global-styles.css'
import { NavLink } from 'react-router-dom'

const Aboutpage = () => {
    return(
        <>
        <div id='about' className={`container ${styles.aboutpage}`}>
            <div className={`${styles.aboutinner}`}>
                <div className={`${styles.innerheader}`}>
                    <h1 className={`${styles.headertext}`}>Что? Кто? Зачем?</h1>
                    <img className={`${styles.headerimg}`} src="./images/3d/think_emoji.png" alt="" />
                </div>
                <h1 className={`${styles.innertext}`}>Наш ресурс создан для того, чтобы вы смогли поделиться своими фантазиями и рецептами коктейлей! Познавайте новые рецепты, делитесь старыми и оценивайте!</h1>
                <NavLink to='#h' className={`btn`}>Ага, а дальше?</NavLink>
            </div>
            <div className={styles.imgs}>
                <img className={`${styles.img}`} src="./images/3d/3d_people.png" />
                <img className={`${styles.img}`} style={{position: 'absolute', left: '-10px', bottom: '0', zIndex: '1'}} src="./images/shapes/shape_1.png" />
            </div>
        </div>
        </>
    )
}

export default Aboutpage