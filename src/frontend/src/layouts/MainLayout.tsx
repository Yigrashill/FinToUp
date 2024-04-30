import React from 'react'
import { Outlet } from 'react-router-dom'
import Navbar from '../Components/Navbar'
import Hero from '../Components/Hero'

const MainLayout = () => {
  return (
    <>
      <Navbar />
      <Hero />

      <Outlet />
    </>
  )
}

export default MainLayout