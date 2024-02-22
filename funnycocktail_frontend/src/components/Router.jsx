import { Routes, Route } from "react-router-dom"
import App from "./home/App"

const Router = () => {
    return(
        <Routes>
            <Route element={<App/>} path='/'></Route>
        </Routes>
    )
}

export default Router