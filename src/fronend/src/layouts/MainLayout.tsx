import React from 'react'
import Navbar from '../Component/Navbar'
import Hero from '../Component/Hero'
import FinanceList from '../Component/Finance/FinanceList'
import { Outlet } from 'react-router-dom'

const MainLayout = () => {
  return (
    <div className="bg-gray-800">
      <Navbar />
      <Hero />
      <Outlet />
    </div>
  )
}

export default MainLayout