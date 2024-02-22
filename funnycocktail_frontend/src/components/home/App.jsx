import { useState } from 'react'
import './App.css'
import Generalpage from './general-page/Generalpage'
import Navigation from '../navigation/Navigation'
import Aboutpage from './about-page/Aboutpage'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <Generalpage/>
      <Aboutpage/>
    </>
  )
}

export default App
