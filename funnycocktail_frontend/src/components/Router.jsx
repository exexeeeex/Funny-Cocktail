import { Routes, Route } from "react-router-dom"
import App from "./home/App"
import Cocktails from "./cocktails/Cocktails"

const Router = () => {
    return(
        <Routes>
            <Route element={<App/>} path='/'></Route>
            <Route element={<Cocktails/>} path='/cocktails'></Route>
            <Route path='/cocktail/:id'></Route>
            <Route path='*' element={<div style={{
            display: 'flex',
            justifyContent: 'center',
            flexDirection: 'column',
            textAlign: 'center',
            marginTop: '200px',
            fontSize: '50px',
            color: 'black',
        }}>Not Found</div>}></Route>
        </Routes>
    )
}

export default Router