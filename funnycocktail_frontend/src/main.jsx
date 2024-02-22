import React from 'react'
import ReactDOM from 'react-dom/client'
import { BrowserRouter } from 'react-router-dom'
import Router from './components/Router.jsx'
import Navigation from './components/navigation/Navigation.jsx'

ReactDOM.createRoot(document.getElementById('root')).render(
    <BrowserRouter>
      <Navigation/>
      <Router />
    </BrowserRouter>,
)
