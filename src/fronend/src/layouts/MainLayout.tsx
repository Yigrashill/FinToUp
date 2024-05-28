import React from 'react'
import Navbar from '../Component/Navbar'
import Hero from '../Component/Hero'
import FinanceList from '../Component/Finance/FinanceList'
import { Outlet } from 'react-router-dom'

const MainLayout = () => {
  return (
    <div className="w-full  items-center px-6 md:px-6 bg-black dark:bg-slate-900">
      <Navbar />
    
      <Hero />
      <Outlet />


    </div>
  )
}

export default MainLayout