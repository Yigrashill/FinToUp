import React from 'react'
import { Outlet } from 'react-router-dom'
import Navbar from '../Components/Navbar'
import Hero from '../Components/Hero'
import { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css';

const MainLayout = () => {
  return (
    <>
      <Navbar />
      <Hero />

      <Outlet />
      <ToastContainer />
    </>
  )
}

export default MainLayout