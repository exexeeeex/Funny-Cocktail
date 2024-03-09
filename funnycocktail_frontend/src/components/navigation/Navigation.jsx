import { NavLink, Link } from "react-router-dom"
import styles from './Navigation.module.css'
import '../../assets/styles/global-styles.css'
import { useEffect, useState } from "react"
import { Userservice } from "../../services/user.service"
import toast from "react-hot-toast"
import axios from "axios"

const Navigation = () => {
    const [active, setActive] = useState('/');
    const [visible, setVisible] = useState(true);
    const [authorname, setAuthorname] = useState('');
    const [user, setUser] = useState('')

    const changeVisible = () => {
        setVisible(false)
    }

    const setUsername = async () => {
        try {
            const response = await axios.post(`https://localhost:1337/api/authors/createusername?username=${authorname}`);
            localStorage.setItem(`author`, authorname)
            toast.success(`Теперь вас зовут ${authorname}`, {
                position: "top-center"
            });
        } catch (error) {
            toast.error("Имя занято!", {
                position: "bottom-right"
            });
        }
    }

    useEffect(() => {
        const storageItem = localStorage.getItem(`author`);
        if(storageItem != null) {setUser(storageItem)}
    })

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
            {user != null && <div className={`${styles.authorname}`}>{user}</div>}
            {user == null && <div style={{display: visible == true ? 'block' : 'none'}} onClick={changeVisible} className={`${styles.setnickname}`}>Указать никнейм</div>}
            <div className={`${styles.usernameblock}`} style={{display: visible == false ? 'block' : 'none'}}>
                <input onChange={(e) => setAuthorname(e.target.value)} value={authorname} className={`${styles.input}`} name='authorname' type="text"/>
                <button className={`${styles.btnus}`} onClick={setUsername}>Принять</button>
            </div>
        </div>
        </>
    )
}

export default Navigation