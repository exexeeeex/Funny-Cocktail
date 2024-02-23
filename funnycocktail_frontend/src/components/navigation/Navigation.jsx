import { NavLink, Link } from "react-router-dom"
import styles from './Navigation.module.css'
import '../../assets/styles/global-styles.css'
import { useState } from "react"

const Navigation = () => {
    const [active, setActive] = useState('/');
    return(
        <>
        <div className={`${styles.navbar} container`}>
            <div style={{gap: '20px', display: 'flex'}}>
                <NavLink className={`${styles.navlink}`} style={{color: active == '/' ? '#FF00C7' : 'black'}} 
                onClick={() => setActive('/')}
                to='/'>
                    Главная
                </NavLink>
                <NavLink
                style={{color: active == '/cocktails' ? '#FF00C7' : 'black'}} 
                onClick={() => setActive('/cocktails')} 
                className={`${styles.navlink}`} to='/cocktails'>
                    Коктейли
                </NavLink>
                <NavLink
                style={{color: active == '/faq' ? '#FF00C7' : 'black'}} 
                onClick={() => setActive('/faq')}  
                className={`${styles.navlink}`} to='/faq'>
                    F.A.Q
                </NavLink>
            </div>
            <div className={`${styles.setnickname}`}>
                Указать никнейм
            </div>
        </div>
        </>
    )
}

export default Navigation