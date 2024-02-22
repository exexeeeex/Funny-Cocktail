import { useEffect, useState } from 'react'
import './App.css'
import Generalpage from './general-page/Generalpage'
import Navigation from '../navigation/Navigation'
import Aboutpage from './about-page/Aboutpage'
import Reviewspage from './reviews-page/Reviewspage'
import { Cocktailservice } from '../../services/cocktail.service'

function App() {
  return (
    <>
      <Generalpage/>
      <Aboutpage/>
      <Reviewspage />
    </>
  )
}

export default App
